namespace DAL.Migrations
{
    using DataSeed;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.DBContext.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.DBContext.DBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.CustomerTypes.AddOrUpdate(
               p => p.Id,
               new CustomerType { Id = CustomerTypes.DiscountCustomer.Id, Name = CustomerTypes.DiscountCustomer.Name, Description = CustomerTypes.DiscountCustomer.Description },
               new CustomerType { Id = CustomerTypes.ImpulseCustomer.Id, Name = CustomerTypes.ImpulseCustomer.Name, Description = CustomerTypes.ImpulseCustomer.Description },
               new CustomerType { Id = CustomerTypes.LoyalCustomer.Id, Name = CustomerTypes.LoyalCustomer.Name, Description = CustomerTypes.LoyalCustomer.Description },
               new CustomerType { Id = CustomerTypes.NeedbasedCustomer.Id, Name = CustomerTypes.NeedbasedCustomer.Name, Description = CustomerTypes.NeedbasedCustomer.Description },
               new CustomerType { Id = CustomerTypes.WanderingCustomer.Id, Name = CustomerTypes.WanderingCustomer.Name, Description = CustomerTypes.WanderingCustomer.Description }
             );




        }
    }
}
