using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace Utils
{

    /// <summary>
    /// 自定义数据库访问通用类
    /// </summary>
    public class SqlHelper
    {
        /// <summary>
        /// SqlHleper的单件实例
        /// </summary>
        private static SqlHelper _instance;

        #region 其实多线程下获取实例时应该加锁，但不加不会引发错误(前提是连接字符串不变)

        /// <summary>
        /// 用于获取使用默认连接字符串的SqlHelper的唯一实例。
        /// </summary>
        /// <returns></returns>
        public static SqlHelper GetInstance()
        {
            //如果_instance为null，则构建一个实例
            return _instance ?? (_instance = new SqlHelper());
        }

        /// <summary>
        /// 设置连接字符串，并返回使用该链接字符串的SqlHelper的唯一实例
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static SqlHelper GetInstance(string connectionString)
        {
            if (_instance == null)
            {
                _instance = new SqlHelper();
            }

            if (!string.IsNullOrEmpty(connectionString))
            {
                _instance._connectionString = connectionString;
            }

            return _instance;
        }

        #endregion

        /// <summary>
        /// 私有的连接字符串，它默认使用配置文件中的连接字符串。
        /// </summary>
        private string _connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnString"];

        //User ID=sa;Initial Catalog=WirelessCity_POI;Data Source=192.168.85.136;Password=smssdev
        //<add name="ConnectionString" connectionString="Data Source=192.168.163.204;Initial Catalog=Fids;User ID=fids;Password=fids" />
        //private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyStock.Properties.Settings.SmartStockConnectionString"].ConnectionString;

        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        private SqlHelper()
        {
        }

        /// <summary>
        /// 测试数据库连接是否畅通。
        /// </summary>
        /// <returns>
        /// 如果返回值为true,表示数据库连接畅通。
        /// 如果返回值为false，表示数据库连接不畅通。通常修改连接字符串可解决该问题。
        /// </returns>
        public bool IsConnectionActive()
        {
            bool result = true;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(_connectionString);
                conn.Open();
            }
            catch (Exception ex)
            {
                NLogHelper.Error("连接数据库错误"+_connectionString+":"+ex);
                result = false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// ExecuteNonQuery操作，对数据库进行 增、删、改 操作（1）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, CommandType.Text, null);
        }

        /// <summary>
        /// ExecuteNonQuery操作，对数据库进行 增、删、改 操作（2）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <param name="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNonQuery(string sql, CommandType commandType)
        {
            return ExecuteNonQuery(sql, commandType, null);
        }

        /// <summary>
        /// ExecuteNonQuery操作，对数据库进行 增、删、改 操作（3）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <param name="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <param name="parameters">参数数组 </param>
        /// <returns> </returns>
        public int ExecuteNonQuery(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    connection.Open();
                    count = command.ExecuteNonQuery();
                }
            }
            return count;
        }

        /// <summary>
        /// SqlDataAdapter的Fill方法执行一个查询，并返回一个DataSet类型结果（1）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <returns>DataSet代表了select语句的结果。</returns>
        public DataSet ExecuteDataSet(string sql)
        {
            return ExecuteDataSet(sql, CommandType.Text, null);
        }

        /// <summary>
        /// SqlDataAdapter的Fill方法执行一个查询，并返回一个DataSet类型结果（2）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <param name="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <returns>DataSet代表了select语句的结果。</returns>
        public DataSet ExecuteDataSet(string sql, CommandType commandType)
        {
            return ExecuteDataSet(sql, commandType, null);
        }

        /// <summary>
        /// SqlDataAdapter的Fill方法执行一个查询，并返回一个DataSet类型结果（3）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <param name="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <param name="parameters">参数数组 </param>
        /// <returns>DataSet代表了select语句的结果。</returns>
        public DataSet ExecuteDataSet(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds);
                }
            }
            return ds;
        }

        /// <summary>
        /// SqlDataAdapter的Fill方法执行一个查询，并返回一个DataTable类型结果（1）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <returns> </returns>
        public DataTable ExecuteDataTable(string sql)
        {
            return ExecuteDataTable(sql, CommandType.Text, null);
        }

        /// <summary>
        /// SqlDataAdapter的Fill方法执行一个查询，并返回一个DataTable类型结果（2）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <param name="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <returns> </returns>
        public DataTable ExecuteDataTable(string sql, CommandType commandType)
        {
            return ExecuteDataTable(sql, commandType, null);
        }

        /// <summary>
        /// SqlDataAdapter的Fill方法执行一个查询，并返回一个DataTable类型结果（3）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <param name="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <param name="parameters">参数数组 </param>
        /// <returns> </returns>
        public DataTable ExecuteDataTable(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        //clear是为了调试使用
                        command.Parameters.Clear();
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                }
            }
            return data;
        }

        /// <summary>
        /// ExecuteReader执行一查询，返回一<c>SqlDataReader</c>对象实例（1）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <returns></returns>
        /// <remarks>
        /// <example>
        /// 返回值SqlDataReader使用完毕后，应关闭。
        /// <code>
        /// SqlDataReader sdr = object.ExecuteReader(sql);
        /// while(sdr.Read())
        /// {
        /// }
        /// sdr.Close();
        /// </code>
        /// </example>
        /// </remarks>
        public SqlDataReader ExecuteReader(string sql)
        {
            return ExecuteReader(sql, CommandType.Text, null);
        }

        /// <summary>
        /// ExecuteReader执行一查询，返回一SqlDataReader对象实例（2）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <param name="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <returns> </returns>
        public SqlDataReader ExecuteReader(string sql, CommandType commandType)
        {
            return ExecuteReader(sql, commandType, null);
        }

        /// <summary>
        /// ExecuteReader执行一查询，返回一SqlDataReader对象实例（3）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <param name="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <param name="parameters">参数数组 </param>
        /// <returns></returns>
        /// <remarks>
        /// 返回值SqlDataReader使用完毕后，要调用
        /// </remarks>
        public SqlDataReader ExecuteReader(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            command.CommandType = commandType;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// ExecuteScalar执行一查询，返回查询结果的第一行第一列（1）,如果为空，返回null.
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <returns> </returns>
        public Object ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, CommandType.Text, null);
        }

        /// <summary>
        /// ExecuteScalar执行一查询，返回查询结果的第一行第一列（2）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <param name="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <returns> </returns>
        public Object ExecuteScalar(string sql, CommandType commandType)
        {
            return ExecuteScalar(sql, commandType, null);
        }

        /// <summary>
        /// ExecuteScalar执行一查询，返回查询结果的第一行第一列（3）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <param name="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <returns> </returns>
        public Object ExecuteScalar(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            object result = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    connection.Open();
                    result = command.ExecuteScalar();
                }
            }
            return result;
        }

        /// <summary>
        /// 返回当前连接的数据库中所有由用户创建的数据库
        /// </summary>
        /// <returns> </returns>
        public DataTable GetTables()
        {
            DataTable data = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                data = connection.GetSchema("Tables");
            }
            return data;
        }

        /// <summary>
        /// 开始事务
        /// </summary>
        /// <param name="sqlList"></param>
        /// <returns></returns>
        public bool ExecTransaction(IEnumerable<string> sqlList)
        {
            SqlConnection conn = null;
            SqlTransaction trans = null;
            try
            {
                conn = new SqlConnection(_connectionString);
                //先打开连接在开始事务
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                //开始事务
                trans = conn.BeginTransaction();
                command.Transaction = trans;
                foreach (string sql in sqlList)
                {
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (trans != null)
                {
                    trans.Rollback();
                }
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 开始事务
        /// </summary>
        /// <param name="sqlList"></param>
        /// <returns></returns>
        public bool ExecTransactionSafed(IEnumerable<string> sqlList)
        {
            SqlConnection conn = null;
            SqlTransaction trans = null;
            try
            {
                conn = new SqlConnection(_connectionString);
                //先打开连接在开始事务
                conn.Open();
                //开始事务
                trans = conn.BeginTransaction();
                foreach (string sql in sqlList)
                {
                    using (SqlCommand command = new SqlCommand(sql, conn, trans))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (trans != null)
                {
                    trans.Rollback();
                }
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }


        public Dictionary<String, String> GetICAOIATA()
        {
            Dictionary<string,string> dics = new Dictionary<string, string>();
            String sql = "select IATA,icao from fids_cfg_airport";
            DataTable dt = ExecuteDataTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                String icao = row["icao"].ToString().Trim();
                String iata = row["IATA"].ToString().Trim();
                if (!dics.ContainsKey(icao))
                {
                    dics.Add(icao,iata);
                }
            }
            return dics;
        } 
    }
}