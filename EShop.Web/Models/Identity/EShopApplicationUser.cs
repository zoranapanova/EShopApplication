using EShop.Web.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web.Models.Identity
{
    public class EShopApplicationUser : IdentityUser
    { 
      public string FirstName { get; set; }
      public string LastName { get; set; }

      public virtual ShoppingCard UserCard { get; set; }
    }
}
