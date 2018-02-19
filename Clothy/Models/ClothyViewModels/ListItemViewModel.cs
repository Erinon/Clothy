using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothy.Models.ClothyViewModels
{
    public class ListItemViewModel
    {
        public List<ItemViewModel> Models { get; }

        public ListItemViewModel(List<ItemViewModel> models)
        {
            Models = models;
        }
    }
}
