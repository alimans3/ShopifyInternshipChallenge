using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopifyChallenge.Core;

namespace ShopifyChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductStore Store;

        public ProductsController(IProductStore store)
        {
            Store = store;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ProductsController>>> GetProducts(bool available)
        {
            if (available)
            {
                return Ok(await Store.GetAvailableProducts());
            }

            return Ok(await Store.GetAllProducts());
        }

        [HttpPost]
        public async Task<ActionResult> Post(string title)
        {
            try 
            {
                await Store.PurchaseProduct(title);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Product Cannot be purchased");
            }
        }
    }
}