using BL.Helper;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.BusinessManagers.Interfaces
{
    public interface IBaseBusinessManager<TEntity, TEntityDto> where TEntity : class, IBaseEntity
        where TEntityDto : class
    {
        BusinessCustomResponse<TEntityDto> Update(TEntityDto entityToUpdateVM, object id, params Expression<Func<TEntity, object>>[] IgnoreSelector);
        TEntity GetById(object id);
        BusinessCustomResponse<TEntityDto> Save(TEntityDto itemVm);
        TEntityDto GetVMById(object id);
        BusinessCustomResponse<TEntity> Save(TEntity item);
        BusinessCustomResponse<TEntity> Update(TEntity entityToUpdate);
        BusinessCustomResponse<TEntity> Delete(object id);
        int Count(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> GetWithDeleted(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity GetByIdWithDeleted(object id);
        BusinessCustomResponse<TEntity> DeleteSoftly(object id);

        IQueryable<TEntityDto> GetVM(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties);
        List<TEntity> SaveList(List<TEntity> items);
        void DeleteByFilter(Expression<Func<TEntity, bool>> filter);

        void SaveListVoidTimeControl(List<TEntity> items, DateTime requestTime);

    }
}
