using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothy.Models.ClothyViewModels
{
    public class CartViewModel
    {
        public Guid Id { get; set; }
        public List<CartItemViewModel> Models { get; }

        public CartViewModel(List<CartItemViewModel> models)
        {
            Id = Guid.NewGuid();
            Models = models;
        }
    }
}
