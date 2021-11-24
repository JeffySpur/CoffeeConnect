using CoffeeConnect.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.Models
{
    public class CustomerListItem
    {
        
        public string FullName { get; set; }
        public virtual ICollection<Coffee> Coffees { get; set; } = new List<Coffee>();
    }
}
