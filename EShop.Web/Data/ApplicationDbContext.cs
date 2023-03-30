using EShop.Web.Models.Domain;
using EShop.Web.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<EShopApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShoppingCard> ShoppingCards { get; set; }
        public virtual DbSet<ProductInShoppingCard> ProductInShoppingCards { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCard>()
              .Property(z => z.Id)
              .ValueGeneratedOnAdd();

            builder.Entity<ProductInShoppingCard>()
                .HasKey( z => new { z.ProductId, z.ShoppingCardId});

            builder.Entity<ProductInShoppingCard>()
                .HasOne(z => z.Product)
                .WithMany(z => z.ProductInShoppingCards)
                .HasForeignKey(z => z.ShoppingCardId);

            builder.Entity<ProductInShoppingCard>()
                .HasOne(z => z.ShoppingCard)
                .WithMany(z => z.ProductInShoppingCards)
                .HasForeignKey(z => z.ProductId);

            builder.Entity<ShoppingCard>()
                .HasOne<EShopApplicationUser>(z => z.Owner)
                .WithOne(z => z.UserCard)
                .HasForeignKey<ShoppingCard>(z => z.OwnerId);

        }
    }
}
