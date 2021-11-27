using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.Models
{
    public class PurchaseEdit
    {
        public int PurchaseId { get; set; }
        public int LbsOfCoffee { get; set; }
        public string CoffeeName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
