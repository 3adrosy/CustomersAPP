using AutoMapper;
using BL.AutoMapper;
using BL.BusinessManagers.Interfaces;
using BL.Helper;
using DAL.Models;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BL.BusinessManagers.Classes
{
    public class BaseBusinessManager<TEntity, TRepository, TEntityDto> : IBaseBusinessManager<TEntity,
        TEntityDto> where TEntity : class, IBaseEntity,
        new()
        where TRepository : IBaseRepository<TEntity>
          where TEntityDto : class
    {
        public BaseBusinessManager(IUnitOfWork _uow)
        {

            if (_uow == null)
            {
                throw new ArgumentNullException("no repository provided");
            }


            UnitOfWork = _uow;
            Repository = UnitOfWork.Repository<TEntity, TRepository>();


        }

        protected IBaseRepository<TEntity> Repository { get; set; }
        protected IUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetById(object id)
        {
            var entity = Repository.GetById(id);
            if (entity.IsDeleted)
            {
                entity = null;
            }
            return entity;
        }
        public virtual TEntity GetByIdWithDeleted(object id)
        {
            var entity = Repository.GetById(id);

            return entity;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntityDto GetVMById(object id)
        {
            TEntity entity = Repository.GetById(id);
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TEntityDto, TEntity>().ReverseMap();

            });
            TEntityDto itemVM = Mapper.Map<TEntityDto>(entity);

            return itemVM;
        }
        public virtual void DeleteByFilter(Expression<Func<TEntity, bool>> filter)
        {
            Repository.DeleteByFilter(filter);
            UnitOfWork.Save();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual BusinessCustomResponse<TEntityDto> Save(TEntityDto itemVm)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TEntityDto, TEntity>().ReverseMap();

            });
            TEntity item = Mapper.Map<TEntity>(itemVm);
            TEntity addedItem = Repository.Save(item);
            UnitOfWork.Save();
            TEntityDto itemVMNew = Mapper.Map<TEntityDto>(addedItem);
            return BusinessCustomResponse(itemVMNew);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual BusinessCustomResponse<TEntity> Save(TEntity item)
        {
            var addedItem = Repository.Save(item);

            UnitOfWork.Save();
            return BusinessCustomResponse<TEntity>(addedItem);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public virtual List<TEntity> SaveList(List<TEntity> items)
        {
            var addedItem = Repository.SaveList(items);

            UnitOfWork.Save();
            return addedItem;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public virtual void SaveListVoid(List<TEntity> items)
        {
            try
            {
                var addedItems = Repository.SaveList(items);
                UnitOfWork.Save();

            }
            catch (Exception e)
            {

                throw;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public virtual void SaveListVoidTimeControl(List<TEntity> items, DateTime requestTime)
        {
            try
            {
                HelperMethods.CheckRequestTimeOut(requestTime);

                var addedItems = Repository.SaveListTimeControl(items, requestTime);

                HelperMethods.CheckRequestTimeOut(requestTime);

                UnitOfWork.SaveTimeControl(requestTime);

            }
            catch (Exception e)
            {

                throw;
            }
        }


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="items"></param>
        ///// <returns>List of entity Dtos</returns>
        //public virtual List<TEntityDto> SaveListReturnDtos(List<TEntity> items)
        //{
        //    var addedItems = Repository.SaveList(items);
        //    UnitOfWork.Save();

        //    List<TEntityDto> itemDtos = Mapper.Map<List<TEntityDto>>(addedItems);

        //    return itemDtos;
        //}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityToUpdate"></param>
        /// <returns></returns>
        public virtual BusinessCustomResponse<TEntityDto> Update(TEntityDto entityToUpdateVM, object id, params Expression<Func<TEntity, object>>[] IgnoreSelector)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TEntityDto, TEntity>().Ignore<TEntityDto, TEntity>(IgnoreSelector).ReverseMap();

            });
            var entityToUpdate = Repository.GetById(id);

            Mapper.Map<TEntityDto, TEntity>(entityToUpdateVM, entityToUpdate);

            var editedItem = Repository.Update(entityToUpdate);
            TEntityDto editedItemVM = Mapper.Map<TEntityDto>(editedItem);

            UnitOfWork.Save();
            return BusinessCustomResponse(editedItemVM);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityToUpdate"></param>
        /// <returns></returns>
        public virtual BusinessCustomResponse<TEntity> Update(TEntity entityToUpdate)
        {
            var editedItem = Repository.Update(entityToUpdate);
            UnitOfWork.Save();
            return BusinessCustomResponse<TEntity>(editedItem);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual BusinessCustomResponse<TEntity> Delete(object id)
        {
            var deletedItem = Repository.Delete(id);
            UnitOfWork.Save();
            return BusinessCustomResponse<TEntity>(deletedItem);
        }
        public virtual BusinessCustomResponse<TEntity> DeleteSoftly(object id)
        {
            var entity = Repository.GetById(id);
            entity.IsDeleted = true;
            var deletedItem = Repository.Update(entity);
            UnitOfWork.Save();
            return BusinessCustomResponse<TEntity>(deletedItem);
        }
        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Repository.Get(filter, orderBy, includeProperties).Where(s => s.IsDeleted == false);
        }
        public virtual IQueryable<TEntity> GetWithDeleted(Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
          params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Repository.Get(filter, orderBy, includeProperties);
        }
        public virtual IQueryable<TEntityDto> GetVM(Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var res = Repository.Get(filter, orderBy, includeProperties);
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TEntityDto, TEntity>().ReverseMap();

            });
            IQueryable<TEntityDto> resVM = Mapper.Map<IQueryable<TEntityDto>>(res);
            return resVM;

        }
        public int Count(Expression<Func<TEntity, bool>> filter)
        {
            return Repository.Count(filter);

        }
        private BusinessCustomResponse<T> BusinessCustomResponse<T>(T res)
        {
            return new BusinessCustomResponse<T>
            {
                ErrorMsg = "",
                Success = true,
                response = res
            };

        }
    }
}
