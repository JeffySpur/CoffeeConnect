using CoffeeConnect.Data;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.Services
{
    public class CustomerService
    {
        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()
                {
                   
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.customers.Select(e => new CustomerListItem
                    {
                       
                        FirstName = e.FirstName,
                        LastName = e.LastName
                    }
                    );
                return query.ToList();
            }
        }
    }
}
                        

