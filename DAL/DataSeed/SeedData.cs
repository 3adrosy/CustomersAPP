using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataSeed
{
    public class SeedData
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        
    }

    public static class CustomerTypes
    {
        public static readonly SeedData DiscountCustomer
            = new SeedData
            {
                Id = 1,
                Name = "Discount Customer",
                Description = "Customers that shops frequently but bases buying decision primarily on markdowns."
            };

        public static readonly SeedData ImpulseCustomer
            = new SeedData { Id = 2, Name = "Impulse Customer",
                Description = "Customers that do not have a specific product in mind and purchases goods when it seems good at the time."
            };

        public static readonly SeedData LoyalCustomer
            = new SeedData
            {
                Id = 3,
                Name = "Loyal Customer",
                Description = "Customers that make up a minority of the customer base but generates a large portion of sales."
            };

        public static readonly SeedData NeedbasedCustomer
            = new SeedData { Id = 4, Name = "Need-based Customer",
                Description = "Customers with the intention of buying a specific product."
            };

        public static readonly SeedData WanderingCustomer
            = new SeedData { Id = 5, Name = "Wandering Customer",
                Description = "Customers that are not sure of what they want to buy."
            };

    }


}
