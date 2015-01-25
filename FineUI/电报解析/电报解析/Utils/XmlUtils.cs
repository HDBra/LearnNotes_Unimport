using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace 电报解析.Utils
{
    public static class XmlUtils
    {
        public static String TrimValue(this XElement element, String name)
        {
            if (element == null || element.Element(name) == null)
            {
                return string.Empty;
            }

            return element.Element(name).Value.Trim();
        }
    }
}
