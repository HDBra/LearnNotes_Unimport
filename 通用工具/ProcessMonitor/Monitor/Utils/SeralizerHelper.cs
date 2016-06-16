using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ProcessMonitor.Utils
{
    public static class SeralizerHelper
    {
        /// <summary>
        /// 将对象序列化到destFile文件中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="destFile"></param>
        public static void ToFile<T>(T obj, String destFile) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.Indent = true;
            using (StreamWriter streamWriter = new StreamWriter(destFile, false, Encoding.UTF8))
            {
                using (XmlWriter writer = XmlWriter.Create(streamWriter, settings))
                {
                    serializer.Serialize(writer, obj, ns);
                }
            }
        }

        /// <summary>
        /// 将xml解析为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <param name="isFile">true,表示str表示文件名；false,表示str表示要转换的xml字符串</param>
        /// <returns></returns>
        public static T ToObject<T>(string str, bool isFile = true) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            if (!isFile)
            {
                using (StreamReader reader = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(str)), Encoding.UTF8))
                {
                    return (T)serializer.Deserialize(reader);
                }
            }
            else
            {
                using (StreamReader reader = new StreamReader(str, Encoding.UTF8))
                {
                    return (T)serializer.Deserialize(reader);
                }
            }
        }
    }
}
