using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.Models
{
    public class PurchaseCreate
    {
        public int CustomerId { get; set; }
        public int CoffeeId { get; set; }
        public int LbsOfCoffee { get; set; }
    }
}
