using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothy.Models.ClothyViewModels
{
    public class MakeOrderViewModel
    {
        public Guid Id { get; set; }

        //[EmailAddress]
        [Required]
        public string Mail;

        [Required]
        public string Phone;

        [Required]
        public string Address;
    }
}
