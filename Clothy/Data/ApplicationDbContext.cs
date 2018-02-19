using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Clothy.Models;
using Clothy.Models.ClothyViewModels;

namespace Clothy.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Clothy.Models.ClothyViewModels.AddItemViewModel> AddItemViewModel { get; set; }

        public DbSet<Clothy.Models.ClothyViewModels.AddCategoryViewModel> AddCategoryViewModel { get; set; }

        public DbSet<Clothy.Models.ClothyViewModels.ItemViewModel> ItemViewModel { get; set; }

        public DbSet<Clothy.Models.ClothyViewModels.MakeOrderViewModel> MakeOrderViewModel { get; set; }

        public DbSet<Clothy.Models.ClothyViewModels.CartViewModel> CartViewModel { get; set; }
    }
}
