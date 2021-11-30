using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.Models
{
    public class PurchaseListItem
    {
        public int PurchaseId { get; set; }
        public int LbsOfCoffee { get; set; }
        public int CustomerId { get; set; }
        public int CoffeeId { get; set; }
        public string CoffeeName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfPurchase { get; set; }

    }
}
