using CoffeeConnect.Data;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.Services
{
    public class CoffeeService
    {
        public bool CreateCoffee(CoffeeCreate model)
        {
            var entity =
                new Coffee()
                {
                    CoffeeName = model.CoffeeName,
                    CoffeeDescription = model.CoffeeDescription,
                    PricePerPound = model.PricePerPound
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.coffees.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<CoffeeListItem> GetCoffees()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.coffees.Select(e => new CoffeeListItem
                    {
                        CoffeeId = e.CoffeeId,
                        CoffeeName = e.CoffeeName,
                        CoffeeDescription = e.CoffeeDescription,
                        PricePerPound = e.PricePerPound

                    }
                    );
                return query.ToList();
            }
        }
    }
}
