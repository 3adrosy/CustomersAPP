using BL.BusinessManagers.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomersApp.Controllers
{
    public class BaseApiController<TManager, TEntity, TEntityDto> : ApiController
        where TEntity : class, IBaseEntity, new()
       where TEntityDto : class

        where TManager : IBaseBusinessManager<TEntity, TEntityDto>
    {
        IBaseBusinessManager<TEntity, TEntityDto> BusinessManager { get; set; }
        public BaseApiController(IBaseBusinessManager<TEntity, TEntityDto> tBusinessManager)
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
