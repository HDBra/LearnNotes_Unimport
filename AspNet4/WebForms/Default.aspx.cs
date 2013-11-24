using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] cities = { "London", "New York", "Paris", " < input/>" };
            string myCity = cities[new Random().Next(cities.Length)];
            mySpan.InnerText = Server.HtmlEncode(myCity);
        }

        protected string GetCity()
        {
            string[] cities = { "London", "New York", "Paris" };
            return cities[new Random().Next(cities.Length)];
        }

        public string[] GetCities()
        {
            return new[] { "London", "New York", "Paris", " <input />" };
        }

    }
}