using BL.BusinessManagers.Classes;
using BL.BusinessManagers.Interfaces;
using DAL.DBContext;
using DAL.Repository.Classes;
using DAL.UnitOfWork;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.NinjectModules
{
    public class HelperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbContext>().To<DBContext>().InRequestScope();
            Bind<IUnitOfWork>().To<UnitOfWork<DBContext>>().InRequestScope();

            Bind<ICustomersBusinessManager>().To<CustomersBusinessManager<CustomersRepository>>().InRequestScope();
            Bind<ICustomerTypesBusinessManager>().To<CustomerTypesBusinessManager<CustomerTypesRepository>>().InRequestScope();
        }
    }
}
