using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothy.Models.ClothyViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
