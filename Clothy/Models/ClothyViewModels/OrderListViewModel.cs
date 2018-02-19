using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothy.Models.ClothyViewModels
{
    public class OrderListViewModel
    {
        public List<OrderViewModel> Models { get; }

        public OrderListViewModel(List<OrderViewModel> models)
        {
            Models = models;
        }
    }
}
