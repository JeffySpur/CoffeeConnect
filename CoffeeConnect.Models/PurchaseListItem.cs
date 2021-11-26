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
        public string CoffeeName { get; set; }
        public string FullName { get; set; }
        public DateTimeOffset DateOfPurchase { get; set; }
    }
}
