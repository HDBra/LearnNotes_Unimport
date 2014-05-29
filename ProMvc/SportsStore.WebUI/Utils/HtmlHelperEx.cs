using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SportsStore.WebUI.Utils
{
    public static class HtmlHelperEx
    {
        public static MvcHtmlString ListArrayItems(this HtmlHelper html, string[] list)
        {
            TagBuilder tag = new TagBuilder("ul");
            foreach (string s in list)
            {
                TagBuilder itemTag = new TagBuilder("li");
                itemTag.SetInnerText(s);
                tag.InnerHtml += itemTag.ToString();
            }
            return new MvcHtmlString(tag.ToString());
        }

        public static MvcHtmlString DisplayMessage(this HtmlHelper html, string msg)
        {
            string result = string.Format("This is the message:<p>{0}</p>",html.Encode(msg));
            return new MvcHtmlString(result);
        }


    }
}