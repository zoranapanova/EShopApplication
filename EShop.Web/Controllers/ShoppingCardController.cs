using EShop.Web.Data;
using EShop.Web.Models.Domain;
using EShop.Web.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EShop.Web.Controllers
{
    public class ShoppingCardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<EShopApplicationUser> _userManager;

        public ShoppingCardController(ApplicationDbContext context, UserManager<EShopApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var loggedInUser = await _context.Users
                .Where(z => z.Id == userId)
                .Include(z => z.UserCard)
                .Include(z => z.UserCard.ProductInShoppingCards)
                .Include("UserCard.ProductInShoppingCards.Product")
                .FirstOrDefaultAsync();

            var userShoppingCard = loggedInUser.UserCard;

            var productPrice = userShoppingCard.ProductInShoppingCards.Select(z => new
            {
                ProductPrice = z.Product.Price,
                Quantity = z.Quantity

            }).ToList();

            double totalPrice = 0;

            foreach(var item in productPrice)
            {
                totalPrice += item.ProductPrice * item.Quantity;
            }

            ShoppingCardDTO shoppingCardDTOitem = new ShoppingCardDTO
            {
                Products  = userShoppingCard.ProductInShoppingCards.ToList(),
                TotalPrice = totalPrice
            };

           // var allProducts = userShoppingCard.ProductInShoppingCards.Select(z => z.Product).ToList();
            return View(shoppingCardDTOitem);
        }
    }
}
