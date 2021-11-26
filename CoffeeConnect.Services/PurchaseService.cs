using CoffeeConnect.Data;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.Services
{
    public class PurchaseService
    {
        private readonly Guid _userId;
        public PurchaseService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePurchase(PurchaseCreate model)
        {
            var entity =
                new Purchase()
                {
                    OwnerId = _userId,
                    CoffeeId = model.CoffeeId,
                    CustomerId = model.CustomerId,
                    LbsOfCoffee = model.LbsOfCoffee
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.purchases.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<PurchaseListItem> GetPurchases()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.purchases.Where(p => p.OwnerId == _userId)
                    .Select(p => new PurchaseListItem
                    {
                        PurchaseId = p.PurchaseId,
                        CoffeeName = p.Coffee.CoffeeName,
                        FullName = p.Customer.FullName,
                        DateOfPurchase = p.DateofPurchase

                    }
                    );
                return query.ToArray();
            }
        }

    }
}
