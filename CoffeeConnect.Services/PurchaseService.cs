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
                    LbsOfCoffee = model.LbsOfCoffee,
                    DateOfPurchase = DateTimeOffset.Now
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
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        LbsOfCoffee = p.LbsOfCoffee,
                        DateOfPurchase = p.DateOfPurchase
                    }
                    );
                return query.ToArray();
            }
        }
                        

        public PurchaseDetail GetPurchaseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.purchases.Single(e => e.PurchaseId == id && e.OwnerId == _userId);
                return
                    new PurchaseDetail
                    {
                        PurchaseId = entity.PurchaseId,
                        CustomerId = entity.CustomerId,
                        CoffeeId = entity.CoffeeId,
                        LbsOfCoffee = entity.LbsOfCoffee,
                        CreatedUtc = entity.DateOfPurchase,
                        

                    };
                        


            }
        }

        public bool UpdatePurchase(PurchaseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.purchases.Single(p => p.PurchaseId == model.PurchaseId && p.OwnerId == _userId);

              /*  entity.CoffeeName = model.CoffeeName;*/
                entity.LbsOfCoffee = model.LbsOfCoffee;
                entity.CustomerId = model.CustomerId;
                entity.CoffeeId = model.CoffeeId;
    

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePurchase(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.purchases.Single(e => e.PurchaseId == id);
                ctx.purchases.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }


    }
}
