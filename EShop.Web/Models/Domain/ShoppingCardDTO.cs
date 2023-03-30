using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web.Models.Domain
{
    public class ShoppingCardDTO
    {
        public List<ProductInShoppingCard> Products { get; set; }
        public double TotalPrice { get; set; }
    }
}
