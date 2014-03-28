using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        #region constructor
        private IProductsRepository repository;
        private int PageSize = 2;
        public ProductController(IProductsRepository productRepository)
        {
            this.repository = productRepository;
        }
        #endregion

        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }


        public ViewResult List(int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products.OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo { CurrentPage = page,ItemsPerPage=PageSize,TotalItems=repository.Products.Count()}
            };
            return View(model);
        }
    }
}
