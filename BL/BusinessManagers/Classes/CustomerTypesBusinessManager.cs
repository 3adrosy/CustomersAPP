using BL.BusinessManagers.Interfaces;
using BL.Dtos;
using BL.Helper;
using DAL.Models;
using DAL.Repository.Classes;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.BusinessManagers.Classes
{
    public class CustomerTypesBusinessManager
                <TRepository> : BaseBusinessManager<CustomerType, TRepository, CustomerTypeDto>,
            ICustomerTypesBusinessManager where TRepository : CustomerTypesRepository

    {
        public CustomerTypesBusinessManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        //public override BusinessCustomResponse<CustomerDto> Update(CustomerDto entityToUpdateVM, object id, params Expression<Func<Customer, object>>[] IgnoreSelector)
        //{
        //    return base.Update(entityToUpdateVM, id, s => s.Id);
        //}



    }

}
