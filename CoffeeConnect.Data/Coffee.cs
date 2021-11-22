using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.Data
{
    public class Coffee
    {
        [Key]
        public int CoffeeId { get; set; }

        [Required]
        [Display(Name = "Name of Coffee")]
        [MaxLength(150, ErrorMessage = "Please enter the name of the coffee you wish to add.")]
        public string CoffeeName { get; set; }

        [Required]
        [Display(Name = "How many are in stock?")]
        [Range(1,9999, ErrorMessage="Please enter the how many pound of coffee are in stock.")]
        public int AmountInStock { get; set; }

        [Required]
        [Display(Name = "What is the price per pound of this coffee?")]
        [Range(1, 9999, ErrorMessage = "Please enter the price of this coffee per pound.")]
        public decimal PricePerPound { get; set; }
    }
}
