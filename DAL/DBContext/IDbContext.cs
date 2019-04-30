using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBContext
{
    public interface IDbContext
    {
        int SaveChanges();
        DbEntityEntry Entry(object o);
        void Dispose();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

    }
}
