using EShop.Web.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web.Models.Domain
{
    public class ShoppingCard
    {
        public Guid Id { get; set; }
        public string OwnerId { get; set; }
        public EShopApplicationUser Owner {get; set;}
        public virtual ICollection<ProductInShoppingCard> ProductInShoppingCards { get; set; }
    }
}
