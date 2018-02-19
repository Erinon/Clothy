using Clothy.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Clothy.Data
{
    public class ClothyDbContext : DbContext
    {
        public IDbSet<Item> Items { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<Order> Orders { get; set; }

        public ClothyDbContext(string cnnstr) : base(cnnstr)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>().HasKey(i => i.Id);
            modelBuilder.Entity<Item>().Property(i => i.Name).IsRequired();
            modelBuilder.Entity<Item>().Property(i => i.Price).IsRequired();
            modelBuilder.Entity<Item>().Property(i => i.Description).IsRequired();
            modelBuilder.Entity<Item>().Property(i => i.Sizes).IsRequired();
            modelBuilder.Entity<Item>().Property(i => i.CategoryId).IsOptional();

            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired();

            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().HasMany(u => u.Cart).WithMany(i => i.Carts);

            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Order>().Property(o => o.UserId).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.DateCreated).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.Mail).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.Phone).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.Address).IsRequired();
        }
    }
}
