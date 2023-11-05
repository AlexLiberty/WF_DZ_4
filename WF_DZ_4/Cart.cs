using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WF_DZ_4
{
    internal class Cart
    {
        private List<Product> products;
        public Cart() 
        {
            products = new List<Product>();
        }
        public decimal TotalGasStation {  get; set; }
        public decimal TotalMiniCafe 
        {
            get 
            {
                return products.Sum(e => e.Price * e.Count);
            }
        }
        public decimal TotalToPay
        {
            get 
            {
                return TotalGasStation+TotalMiniCafe;
            }
        }
        public void AddProduct(Product product)
        {
            if (products.Any(e => e.Id.Equals(product.Id)))
            {
                products.FirstOrDefault(e=>e.Id.Equals(product.Id)).Count += 1;
            }
            else
            {
                product.Count = 1;
                products.Add(product);
            }  
        }
        public void RemoveProduct(Product product)
        {
            products = products.Where(e=>e.Id!=product.Id).ToList();
        }
        public void ChangeAmount(string productId, int count)
        {
            if(products.Any(e=>e.Id.Equals(productId))) 
            {
                products.FirstOrDefault(e=>e.Id.Equals(productId)).Count=count;
            }
        }

    }
}
