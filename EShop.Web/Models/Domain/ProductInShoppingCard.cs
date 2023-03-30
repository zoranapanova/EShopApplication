using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web.Models.Domain
{
    public class ProductInShoppingCard
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid ShoppingCardId { get; set; }
        public ShoppingCard ShoppingCard { get; set; }
        public int Quantity { get; set; }
    }
}
