using Clothy.Data;
using Clothy.Entities;
using Clothy.Models.ClothyViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Clothy.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly ClothyDbContext _context;

        public CategoryListViewComponent(ClothyDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string view)
        {
            CategoryListViewModel model = new CategoryListViewModel(
                (await GetAllCategories())
                .Select(i => new CategoryViewModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                }).ToList());

            return View(view, model);
        }

        public Task<List<Category>> GetAllCategories()
        {
            return _context.Categories.OrderBy(c => c.Name)
                                      .ToListAsync();
        }
    }
}
