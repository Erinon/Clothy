using Clothy.Data;
using Clothy.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Clothy.Repositories
{
    public class CategorySqlRepository : ICategoryRepository
    {
        private ClothyDbContext _context;

        public CategorySqlRepository(ClothyDbContext context)
        {
            _context = context;
        }

        public Task<Category> GetCategoryById(Guid catId)
        {
            return  _context.Categories.SingleAsync(c => c.Id.Equals(catId));
        }

        public async Task AddCategory(Category cat)
        {
            _context.Categories.Add(cat);

            await _context.SaveChangesAsync();
        }

        public Task<List<Category>> GetAllCategories()
        {
            return _context.Categories.OrderBy(i => i.Name)
                                      .ToListAsync();
        }

        public async Task RemoveCategory(Guid catId)
        {
            _context.Categories.Remove(await GetCategoryById(catId));

            await _context.SaveChangesAsync();
        }

        public async Task EditCategory(Category cat)
        {
            Category target = await GetCategoryById(cat.Id);

            target.Name = cat.Name;

            await _context.SaveChangesAsync();
        }
    }
}
