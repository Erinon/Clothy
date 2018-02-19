using System;
using System.ComponentModel.DataAnnotations;

namespace Clothy.Models.ClothyViewModels
{
    public class AddCategoryViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
