using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.Data
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(Coffee))]
        public int CoffeeId { get; set; }
        public virtual Coffee Coffee { get; set; }

        [Required]
        [Display(Name = "How many Pounds?")]
        public int LbsOfCoffee { get; set; }

        [Display(Name = "Date purchased")]
        [DataType(DataType.Date)]
        public DateTimeOffset DateOfPurchase { get; set; }

      /*  [Display(Name = "Date Modified")]
        [DataType(DataType.Date)]
        public DateTimeOffset? ModifiedUtc { get; set; }*/
        public string FirstName { get; set; }
        public string LastName { get; set; }


    }
}
