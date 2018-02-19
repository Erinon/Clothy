using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothy.Models.ClothyViewModels
{
    public class CategoryListViewModel
    {
        public List<CategoryViewModel> Models { get; }

        public CategoryListViewModel(List<CategoryViewModel> models)
        {
            Models = models;
        }
    }
}
