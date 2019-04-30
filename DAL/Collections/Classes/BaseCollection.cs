using DAL.Collections.Interfaces;
using DAL.DBContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Collections.Classes
{
    public class BaseCollection<TModel, TContext> :
        IBaseCollection<TModel, TContext> where TModel : class, IBaseEntity,
        new() where TContext : IDbContext
    {
        private TContext _context;

        private DbSet<TModel> dbSet;
        public TContext ContextObject
        {
            get { return _context; }
            set
            {
                _context = value;
                dbSet = ContextObject.Set<TModel>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual IQueryable<TModel> Get(
            Expression<Func<TModel, bool>> filter = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
            params Expression<Func<TModel, object>>[] includeProperties)
        {
            IQueryable<TModel> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            return query;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TModel GetByID(object id)
        {
            return dbSet.Find(id);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TModel Insert(TModel entity)
        {
            return dbSet.Add(entity);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public List<TModel> InsertList(List<TModel> entities)
        {
            return dbSet.AddRange(entities).ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public List<TModel> InsertListTimeControl(List<TModel> entities, DateTime requestTime)
        {
            try
            {
                DALHelperMethods.HelperDALMethods.CheckRequestTimeOutDAL(requestTime);

                return dbSet.AddRange(entities).ToList();

            }
            catch (Exception e)
            {

                throw;
            }


        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public void VoidInsertListTimeControl(List<TModel> entities, DateTime requestTime)
        {

            using (var context = new DBContext.DBContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {

                        DALHelperMethods.HelperDALMethods.CheckRequestTimeOutDAL(requestTime);


                        //  dbSet.AddRange(entities);
                        foreach (var entity in entities)
                        {

                           DALHelperMethods.HelperDALMethods.CheckRequestTimeOutDAL(requestTime);

                            Customer newCustomer = new Customer();

                            foreach (PropertyInfo pi in entity.GetType().GetProperties())
                            {
                                try
                                {

                                  //get the value of property and try 
                                  //to assign it to the property of T type object:
                                  newCustomer.GetType().GetProperty(pi.Name).SetValue(newCustomer,
                                                            pi.GetValue(entity, null), null);

                                }
                                catch (Exception ex)
                                {
                                    throw;
                                }
                            }

                            DALHelperMethods.HelperDALMethods.CheckRequestTimeOutDAL(requestTime);

                            context.Customers.Add(newCustomer);

                            context.SaveChanges();

                        }

                        DALHelperMethods.HelperDALMethods.CheckRequestTimeOutDAL(requestTime);


                        transaction.Commit();

                    }

                    catch (Exception e)
                    {
                        transaction.Rollback();

                        throw;
                    }
                }
            }
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void InsertOrEdit(TModel entity)
        {
            dbSet.AddOrUpdate(entity);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TModel Delete(object id)
        {
            var entityToDelete = dbSet.Find(id);
            return Delete(entityToDelete);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        public virtual void DeleteByFilter(Expression<Func<TModel, bool>> filter)
        {
            IQueryable<TModel> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            dbSet.RemoveRange(query);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityToDelete"></param>
        /// <returns></returns>
        public virtual TModel Delete(TModel entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            return dbSet.Remove(entityToDelete);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityToUpdate"></param>
        /// <returns></returns>
        public virtual TModel Update(TModel entityToUpdate)
        {

            var entity = dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            return entity;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityToUpdate"></param>
        /// <returns></returns>
        public virtual int Count(Expression<Func<TModel, bool>> filter)
        {

            return dbSet.Count(filter);
        }
    }
}
