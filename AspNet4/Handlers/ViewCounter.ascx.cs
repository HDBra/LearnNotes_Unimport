using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Handlers
{
    public partial class ViewCounter : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected int? GetCounter()
        {
            return Session["counter"] as int? ?? 0;
        }
    }
}