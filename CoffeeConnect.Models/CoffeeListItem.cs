using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.Models
{
    public class CoffeeListItem
    {
        public int CoffeeId { get; set; }
        public string CoffeeName { get; set; }
        public decimal PricePerPound { get; set; }
        public string CoffeeDescription { get; set; }
    }
}
