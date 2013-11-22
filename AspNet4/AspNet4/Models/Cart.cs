using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet4.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection.Where(r=>r.Product.ProductID == product.ProductID).FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(r => r.Product.ProductID == product.ProductID);
        }


        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(r => r.Product.Price * r.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get
            {
                return lineCollection;
            }
        }


    }


    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}