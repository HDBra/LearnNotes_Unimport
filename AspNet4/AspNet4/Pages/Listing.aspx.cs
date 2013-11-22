using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AspNet4.Models;
using AspNet4.Models.Repository;
using AspNet4.Pages.Helpers;
using System.Web.Routing;

namespace AspNet4.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        private int pageSize = 4;
        private  Repository repo = new Repository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int selectedProductId;
                if (int.TryParse(Request.Form["add"], out selectedProductId))
                {
                    Product selectedProduct = repo.Products.Where(r => r.ProductID == selectedProductId).FirstOrDefault();
                    if (selectedProduct != null)
                    {
                        SessionHelper.GetCart(Session).AddItem(selectedProduct, 1);
                        SessionHelper.Set(Session, SessionKey.RETURN_URL, Request.RawUrl);

                        Response.Redirect(RouteTable.Routes.GetVirtualPath(null, "cart", null).VirtualPath);
                    }
                }
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            return FilterProducts().OrderBy(r=>r.ProductID).Skip((CurrentPage-1)*pageSize).Take(pageSize);
        }

        protected int CurrentPage
        {
            get
            {
                int page;
                page = GetPageFromRequest();
                return page > MaxPage ? MaxPage : page;
            }
        }

        protected int MaxPage
        {
            get
            {
                int prodCount = FilterProducts().Count();
                return (int)Math.Ceiling((decimal)repo.Products.Count() / pageSize);
            }
        }

        private IEnumerable<Product> FilterProducts()
        {
            IEnumerable<Product> products = repo.Products;
            string currentCategory = (string)RouteData.Values["category"] ?? Request.QueryString["category"];
            return currentCategory == null ? products : products.Where(p => p.Category.Equals(currentCategory, StringComparison.CurrentCultureIgnoreCase));
        }

        private int GetPageFromRequest()
        {
            int page;
            string reqValue = (string) RouteData.Values["page"] ?? Request.QueryString["page"];
            return reqValue != null && int.TryParse(reqValue, out page) ? page : 1;
        }

    }
}