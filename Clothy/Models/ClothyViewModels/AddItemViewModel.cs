using Clothy.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothy.Models.ClothyViewModels
{
    public class AddItemViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [MinLength(5)]
        [MaxLength(1024)]
        public string Description { get; set; }

        [Required]
        public string Sizes { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
    }
}
