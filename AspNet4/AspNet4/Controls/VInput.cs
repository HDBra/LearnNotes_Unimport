using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNet4.Controls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:VInput runat=server></{0}:VInput>")]
    public class VInput : WebControl
    {
        private string nspace = "AspNet4.Models";
        private string model = "Order";
        public string Namespace
        {
            get { return nspace; }
            set { nspace = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public string Property { get; set; }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.AddAttribute(HtmlTextWriterAttribute.Id, Property.ToLower());
            output.AddAttribute(HtmlTextWriterAttribute.Name, Property.ToLower());
            Type modelType = Type.GetType(string.Format("{0}.{1}", Namespace, Model));
            PropertyInfo propInfo = modelType.GetProperty(Property);
            var attr = propInfo.GetCustomAttribute<RequiredAttribute>(false);
            if (attr != null)
            {
                output.AddAttribute("data-val", "true");
                output.AddAttribute("data-val-required", attr.ErrorMessage);
            }
            output.RenderBeginTag("input");
            output.RenderEndTag();
        }
    }
}
