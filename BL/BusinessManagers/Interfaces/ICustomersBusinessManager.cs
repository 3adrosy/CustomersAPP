using BL.Dtos;
using BL.Helper;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BusinessManagers.Interfaces
{
    public interface ICustomersBusinessManager : IBaseBusinessManager<Customer, CustomerDto>
    {
        BusinessCustomResponse<int> BulkInsertOfRandomCustomers(int bulkNumber);
        IQueryable<CustomerDto> GetTop1000Dtos();
        
        BusinessCustomResponse<int> BulkInsertOfRandomCustomersTimeControl(BulkInsertOfRandomCustomersFormDto bulkInsertOfRandomCustomersFormDto);
        

    }
}
