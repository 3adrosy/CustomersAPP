using BL.BusinessManagers.Interfaces;
using BL.Dtos;
using CustomersApp.Controllers;
using DAL.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomersApp.Controllers.Apies
{
    public class CustomerTypeController : BaseApiController<ICustomerTypesBusinessManager, CustomerType, CustomerTypeDto>
    {
        public ICustomerTypesBusinessManager CustomerTypesBusinessManager { get; set; }


        [Inject]
        public CustomerTypeController(ICustomerTypesBusinessManager customerTypesBusinessManager) : base(customerTypesBusinessManager)
        {
            CustomerTypesBusinessManager = customerTypesBusinessManager;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET api/customers
        public IHttpActionResult Get()
        {


            try
            {
                var result = CustomerTypesBusinessManager.Get();
                return Ok(result);
            }
            catch (Exception e)
            {

                throw;
            }

        }


    }
}
