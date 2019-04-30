﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : IBaseEntity
    {
        TEntity GetById(object id);
        TEntity Save(TEntity item);
        TEntity Update(TEntity entityToUpdate);
        TEntity Delete(object id);
        void DeleteByFilter(Expression<Func<TEntity, bool>> filter);
        List<TEntity> SaveList(List<TEntity> items);
        void SaveOrEdit(TEntity item);
        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties);

        int Count(Expression<Func<TEntity, bool>> filter);

        List<TEntity> SaveListTimeControl(List<TEntity> items, DateTime requestTime);

    }
}
