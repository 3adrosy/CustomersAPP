using DAL.DBContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Collections.Interfaces
{
    public interface IBaseCollection<TEntity, TContext>
        where TEntity : class, IBaseEntity,
        new()
        where TContext : IDbContext
    {
        TContext ContextObject { get; set; }

        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity GetByID(object id);
        TEntity Insert(TEntity entity);
        List<TEntity> InsertList(List<TEntity> entity);

        TEntity Update(TEntity entityToUpdate);

        void InsertOrEdit(TEntity entity);

        TEntity Delete(object id);
        TEntity Delete(TEntity entityToDelete);
        void DeleteByFilter(Expression<Func<TEntity, bool>> filter);
        int Count(Expression<Func<TEntity, bool>> filter);

        List<TEntity> InsertListTimeControl(List<TEntity> entity, DateTime requestTime);
        void VoidInsertListTimeControl(List<TEntity> entity, DateTime requestTime);

    }
}
