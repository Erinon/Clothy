using Clothy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothy.Models.ClothyViewModels
{
    public class ItemViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Sizes { get; set; }
        public string Picture { get; set; }
        public Guid CategoryId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
