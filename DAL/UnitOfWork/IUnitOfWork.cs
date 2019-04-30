using DAL.Models;
using DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        void Dispose(bool disposing);

        void SaveTimeControl(DateTime requestTime);

        TRepository Repository<TEntity, TRepository>() where TEntity : class, IBaseEntity,
            new()
            where TRepository : IBaseRepository<TEntity>;
    }

}
