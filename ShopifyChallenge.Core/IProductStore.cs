using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopifyChallenge.Core
{
    public interface IProductStore
    {
        /// <summary>
        /// Gets all products in store
        /// </summary>
        /// <returns> List of all products</returns>
        Task<List<Product>> GetAllProducts();

        /// <summary>
        /// Gets only products that can be purchased
        /// </summary>
        /// <returns> List of products available for purchase </returns>
        Task<List<Product>> GetAvailableProducts();

        /// <summary>
        /// Purchases a product
        /// </summary>
        /// <exception cref="InventoryException"> if product is not available for purchase</exception>>
        Task PurchaseProduct(string title);

    }
}