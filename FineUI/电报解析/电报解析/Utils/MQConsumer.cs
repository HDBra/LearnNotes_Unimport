using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using Utils;
using 电报解析.Models;

namespace 电报解析.Utils
{
    public static class MQConsumer
    {
        //创建连接工厂
        private static IConnectionFactory factory = new ConnectionFactory(ConfigurationManager.AppSettings["MQUri"]);
        //连接
        private static IConnection connection = null;

        /// <summary>
        /// 本地ICAO码
        /// </summary>
        private static String localIcao = ConfigurationManager.AppSettings["LocalIcao"];

        /// <summary>
        /// init 消费者
        /// </summary>
        public static bool InitConsumer()
        {
            try
            {

                if (connection != null)
                {
                    CloseConsumer();
                }

                //通过工厂构建链接
                connection = factory.CreateConnection();
                //设置连接的标识
                connection.ClientId = "HuiZhouDatagramPaser";
                //启动连接
                connection.Start();
                //通过连接创建一个对话
                ISession session = connection.CreateSession();
                //通过会话创建一个消费者
                IMessageConsumer consumer =
                    session.CreateConsumer(new ActiveMQQueue(ConfigurationManager.AppSettings["MQName"]));
                //注册监听事件
                consumer.Listener += ConsumerOnListener;
                return true;
            }
            catch (Exception ex)
            {
                NLogHelper.Error("初始化MQ失败："+ex);
                return false;
            }
        }

        /// <summary>
        /// 关闭消费者
        /// </summary>
        public static void CloseConsumer()
        {
            try
            {
                if (connection != null)
                {
                    connection.Stop();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                NLogHelper.Error("关闭MQ连接失败："+ex);
            }
        }

        /// <summary>
        /// 消费
        /// </summary>
        /// <param name="message"></param>
        private static void ConsumerOnListener(IMessage message)
        {
            ActiveMQTextMessage textMessage = message as ActiveMQTextMessage;
            if (textMessage == null||textMessage.Text == null)
            {
                NLogHelper.Info("MQ消息为空");
                return;
            }
            else
            {
                NLogHelper.Info("MQ消息为："+textMessage.Text);
            }
            try
            {
                XElement doc = XElement.Parse(textMessage.Text);
                //获取报文类型
                String gramType = doc.Element("META").Element("SUBTYPE").Value.Trim();

                #region 落地报
                if (gramType.Equals(GramType.ARR.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    //落地报
                    foreach (XElement arrItem in doc.Elements(gramType))
                    {
                        String isoffinid = arrItem.TrimValue("ARR")=="1"?"IN":"OUT";//1 进港； 0 出港
                        String flightName = arrItem.TrimValue("FLIGHTNAME");//航班号
                        string dept = arrItem.TrimValue("DEPT");//出发机场 四字码
                        String dest = arrItem.TrimValue("DEST");//目的机场
                        String land = arrItem.TrimValue("LAND");//降落机场
                        String slandingTime = arrItem.TrimValue("LANDINGTIME");//落地时间
                        DateTime dt;
                        if (!DateTime.TryParse(slandingTime, out dt))
                        {
                            continue;
                        }
                        //因为报文中机场是四字码，需要转成三字码
                        String endAirport = String.IsNullOrEmpty(land) ? dest : land;
                        String startAirport = dept;
                        Dictionary<String, string> dics = SqlHelper.GetInstance().GetICAOIATA();
                        if (dics.ContainsKey(endAirport))
                        {
                            endAirport = dics[endAirport];
                        }
                        if (dics.ContainsKey(startAirport))
                        {
                            startAirport = dics[startAirport];
                        }
                        if (land.Equals(localIcao) || dest.Equals(localIcao))
                        {
                            //只有目的站或者降落站和本站相关的才处理
                            String sql = @"UPDATE fids_flt_active SET 
      [startairport] = @startairport
      ,[endairport] = @endairport
      ,realend = @realend
      ,status='ARR'
      WHERE CONVERT(VARCHAR(10),[flightdate],120)=@flightdate and isoffinid=@isffinid and (airlineiata+flightno)=@flightname";
                            SqlParameter[] parameters = new SqlParameter[6];
                            parameters[0] = new SqlParameter("@startairport",SqlDbType.VarChar);
                            parameters[0].Value = startAirport;
                            parameters[1] = new SqlParameter("@endairport", SqlDbType.VarChar);
                            parameters[1].Value = endAirport;
                            parameters[2] = new SqlParameter("@realend",SqlDbType.DateTime);
                            parameters[2].Value = dt;
                            parameters[3] = new SqlParameter("@flightdate", SqlDbType.VarChar);
                            parameters[3].Value = dt.ToString("yyy-MM-dd");
                            parameters[4] = new SqlParameter("@isffinid", SqlDbType.VarChar);
                            parameters[4].Value = isoffinid;
                            parameters[5] = new SqlParameter("@flightname", SqlDbType.VarChar);
                            parameters[5].Value = flightName;
                            SqlHelper.GetInstance().ExecuteNonQuery(sql, CommandType.Text, parameters);
                            NLogHelper.Info("更新落地航班:"+flightName+"；始发站："+startAirport+"；目的站："+dest+";落地时间："+dt);
                        }
                    }
                }
                #endregion

                #region 起飞报

                if (gramType.Equals(GramType.DEP.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    //起飞报
                    foreach (XElement item in doc.Elements(gramType))
                    {
                        String isoffinid = item.TrimValue("ARR") == "1" ? "IN" : "OUT";//1 进港； 0 出港
                        String flightName = item.TrimValue("FLIGHTNAME");//航班号
                        string dept = item.TrimValue("DEPT");//出发机场 四字码
                        String dest = item.TrimValue("DEST");//目的机场
                        String takeoffTime = item.TrimValue("TAKEOFFTIME");//起飞时间
                        DateTime dt;
                        if (!DateTime.TryParse(takeoffTime, out dt))
                        {
                            continue;
                        }
                        //因为报文中机场是四字码，需要转成三字码
                        String endAirport = dest;
                        String startAirport = dept;
                        Dictionary<String, string> dics = SqlHelper.GetInstance().GetICAOIATA();
                        if (dics.ContainsKey(endAirport))
                        {
                            endAirport = dics[endAirport];
                        }
                        if (dics.ContainsKey(startAirport))
                        {
                            startAirport = dics[startAirport];
                        }
                        if (dept.Equals(localIcao) || dest.Equals(localIcao))
                        {
                            //只有目的站或者始发站和本站相关的才处理
                            String sql = @"UPDATE fids_flt_active SET 
      [startairport] = @startairport
      ,[endairport] = @endairport
      ,realstart = @realstart
      ,status='DEP'
      WHERE CONVERT(VARCHAR(10),[flightdate],120)=@flightdate and isoffinid=@isffinid and (airlineiata+flightno)=@flightname";
                            SqlParameter[] parameters = new SqlParameter[6];
                            parameters[0] = new SqlParameter("@startairport", SqlDbType.VarChar);
                            parameters[0].Value = startAirport;
                            parameters[1] = new SqlParameter("@endairport", SqlDbType.VarChar);
                            parameters[1].Value = endAirport;
                            parameters[2] = new SqlParameter("@realstart", SqlDbType.DateTime);
                            parameters[2].Value = dt;
                            parameters[3] = new SqlParameter("@flightdate", SqlDbType.VarChar);
                            parameters[3].Value = dt.ToString("yyy-MM-dd");
                            parameters[4] = new SqlParameter("@isffinid", SqlDbType.VarChar);
                            parameters[4].Value = isoffinid;
                            parameters[5] = new SqlParameter("@flightname", SqlDbType.VarChar);
                            parameters[5].Value = flightName;
                            SqlHelper.GetInstance().ExecuteNonQuery(sql, CommandType.Text, parameters);
                            NLogHelper.Info("更新起飞航班:" + flightName + "；始发站：" + startAirport + "；目的站：" + dest + ";起飞时间：" + dt);
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                NLogHelper.Error("解析处理MQ失败："+ex);
            }
        }
    }
}
