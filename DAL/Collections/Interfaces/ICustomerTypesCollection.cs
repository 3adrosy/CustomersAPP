using DAL.DBContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Collections.Interfaces
{
    interface ICustomerTypesCollection : IBaseCollection<CustomerType, IDbContext>
    {
    }
}
