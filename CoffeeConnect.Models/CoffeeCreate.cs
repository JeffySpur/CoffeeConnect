using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.Models
{
    public class CoffeeCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least one charcter for the coffee name.")]
        [MaxLength(70, ErrorMessage = "Name cannot exceed 70 characters.")]
        public string CoffeeName { get; set; }
        [MaxLength(400, ErrorMessage = "Description cannot be more than 400 characters. ")]
        public string CoffeeDescription { get; set; }
        public decimal PricePerPound { get; set; }
    }
}
