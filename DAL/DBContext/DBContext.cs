using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBContext
{
    public partial class DBContext : DbContext, IDbContext
    {

        public DBContext()
                    : base("name=CustomersAppEntities")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        #region Entities
        public virtual DbSet<Customer> Customers { get; set; }
        
        public virtual DbSet<CustomerType> CustomerTypes { get; set; }

        #endregion



    }
}
