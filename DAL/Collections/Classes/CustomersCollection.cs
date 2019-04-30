using DAL.Collections.Interfaces;
using DAL.DBContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Collections.Classes
{
    public class CustomersCollection : BaseCollection<Customer, IDbContext>, ICustomersCollection
    {
    }
}
