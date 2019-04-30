using BL.BusinessManagers.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace CustomersApp.Controllers.FE
{
    public class BaseMVCController<TManager, TEntity, TEntityDto> : Controller
        where TEntity : class, IBaseEntity, new()
       where TEntityDto : class

        where TManager : IBaseBusinessManager<TEntity, TEntityDto>
    {
        IBaseBusinessManager<TEntity, TEntityDto> BusinessManager { get; set; }
        public BaseMVCController(IBaseBusinessManager<TEntity, TEntityDto> tBusinessManager)
        {
            BusinessManager = tBusinessManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected bool EntityExisted(Expression<Func<TEntity, bool>> filter)
        {

            return BusinessManager.Count(filter) != 0;
        }

    }
}