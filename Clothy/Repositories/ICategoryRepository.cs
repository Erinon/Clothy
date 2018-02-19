using Clothy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothy.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryById(Guid catId);
        Task AddCategory(Category cat);
        Task<List<Category>> GetAllCategories();
        Task RemoveCategory(Guid catId);
        Task EditCategory(Category cat);
    }
}
