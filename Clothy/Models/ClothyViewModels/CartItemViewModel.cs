using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothy.Models.ClothyViewModels
{
    public class CartItemViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
