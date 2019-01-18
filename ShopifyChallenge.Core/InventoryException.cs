using System;

namespace ShopifyChallenge.Core
{
    public class InventoryException : Exception
    {
        public InventoryException(string message) : base(message)
        {
            
        }
    }
}