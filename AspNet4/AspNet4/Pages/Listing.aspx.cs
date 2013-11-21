using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AspNet4.Models;
using AspNet4.Models.Repository;

namespace AspNet4.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        private int pageSize = 4;
        private  Repository repo = new Repository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected IEnumerable<Product> GetProducts()
        {
            return repo.Products.OrderBy(r=>r.ProductID).Skip((CurrentPage-1)*pageSize).Take(pageSize);
        }

        protected int CurrentPage
        {
            get
            {
                int page;
                page = int.TryParse(Request.QueryString["page"], out page) ? page : 1;
                return page > MaxPage ? MaxPage : page;
            }
        }

        protected int MaxPage
        {
            get
            {
                return (int)Math.Ceiling((decimal)repo.Products.Count() / pageSize);
            }
        }
    }
}