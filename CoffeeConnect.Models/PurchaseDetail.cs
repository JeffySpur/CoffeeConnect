using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.Models
{
    public class PurchaseDetail
    {
        public int PurchaseId { get; set; }
        public int CustomerId { get; set; }
     /*   public string FirstName { get; set; }*/

        public int CoffeeId { get; set; }
        public string CoffeeName { get; set; }
        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Date Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public int LbsOfCoffee { get; set; }

    }
}
