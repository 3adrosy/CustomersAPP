using DAL.DBContext;
using DAL.UnitOfWork;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NinjectModules
{
    public class HelperModule : NinjectModule
    {
        public override void Load()
        {

            Bind<IUnitOfWork>().To<UnitOfWork<DBContext.DBContext>>();
            Bind<IDbContext>().To<DBContext.DBContext>();
            Bind<UnitOfWork<DBContext.DBContext>>().ToSelf().InSingletonScope();
            Bind<DBContext.DBContext>().ToSelf().InSingletonScope();

        }
    }
}
