using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet4.Models.Repository
{
    public class Repository
    {
        private readonly EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products
        {
            get
            {
                return context.Products;
            }
        }
    }
}