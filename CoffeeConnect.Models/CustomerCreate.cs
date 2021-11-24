using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.Models
{
    public class CustomerCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least one charcter for the customer name.")]
        [MaxLength(70, ErrorMessage = "Name cannot exceed 70 characters.")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least one charcter for the customer name.")]
        [MaxLength(70, ErrorMessage = "Name cannot exceed 70 characters.")]
        public string LastName { get; set; }


    }
}
