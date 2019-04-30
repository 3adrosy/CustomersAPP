using DAL.Collections.Classes;
using DAL.DBContext;
using DAL.Models;
using DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Classes
{
    public class CustomerTypesRepository : BaseRepository<CustomerTypesCollection, CustomerType>, ICustomerTypesRepository
    {
        public CustomerTypesRepository(IDbContext context) : base(context)
        {
            Context = context;

        }

        public IDbContext Context { get; set; }


    }
}
