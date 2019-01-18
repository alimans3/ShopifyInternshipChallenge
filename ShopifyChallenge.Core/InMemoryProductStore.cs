using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyChallenge.Core
{
    public class InMemoryProductStore : IProductStore
    {
        private List<Product> Products;

        public InMemoryProductStore(IEnumerable<Product> products)
        {
            Products = products.ToList();
        }
        
        public Task<List<Product>> GetAllProducts()
        {
            return Task.FromResult(Products);
        }

        public Task<List<Product>> GetAvailableProducts()
        {
            var toReturn = new List<Product>();
            foreach (var product in Products)
            {
                if (product.InventoryCount > 0)
                {
                    toReturn.Add(product);
                }
            }

            return Task.FromResult(toReturn);
        }

        public Task PurchaseProduct(string title)
        {
            try
            {
                var product = Products.FirstOrDefault(product1 => product1.Title == title);
                if (product.InventoryCount <= 0)
                {
                    throw new InventoryException("Product not available for purchase");
                }
                product.InventoryCount--;
                return Task.CompletedTask;
            }
            catch (Exception)
            {
                throw new InventoryException("Product not available for purchase");
            }
        }
    }
}