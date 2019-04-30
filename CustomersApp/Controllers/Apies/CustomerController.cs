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
using System.Web;
using System.Web.Http;

namespace CustomersApp.Controllers.Apies
{
    public class CustomerController : BaseApiController<ICustomersBusinessManager, Customer, CustomerDto>
    {
        public ICustomersBusinessManager CustomersBusinessManager { get; set; }


        [Inject]
        public CustomerController(ICustomersBusinessManager customersBusinessManager) : base(customersBusinessManager)
        {
            CustomersBusinessManager = customersBusinessManager;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET api/customers/
        public IHttpActionResult Get()
        {


            try
            {
                var result = CustomersBusinessManager.Get();
                return Ok(result);
            }
            catch (Exception e)
            {

                throw;
            }

        }


        /// <summary>
        /// Gets the customers including their types navigation properties
        /// </summary>
        /// <returns></returns>
        // GET api/customers/GetIncluding
        public IHttpActionResult GetIncluding()
        {


            try
            {
                var result = CustomersBusinessManager.Get(null, null, c => c.CustomerType);
                return Ok(result);
            }
            catch (Exception e)
            {

                throw;
            }

        }



        /// <summary>
        /// Gets the Top 1000 customers including their types navigation properties
        /// </summary>
        /// <returns></returns>
        // GET api/customers/GetTop1000
        public IHttpActionResult GetTop1000()
        {

            try
            {
                var result = CustomersBusinessManager
                    .Get(null, c => c.OrderBy(ct => ct.Id), c => c.CustomerType).Take(1000);

                return Ok(result);
            }
            catch (Exception e)
            {

                throw;
            }

        }


        /// <summary>
        /// Gets the Top 1000 customers including their types navigation properties
        /// </summary>
        /// <returns></returns>
        // POST api/customers/GetTop1000
        public IHttpActionResult BulkInserOfRandomCustomers([FromBody] BulkInsertInputDto bulkInsertInputDto)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    var result = CustomersBusinessManager
                        .BulkInsertOfRandomCustomers(bulkInsertInputDto.BulkNumber);

                    return Ok(result);

                }

                else
                {
                    return BadRequest("The number must be equal or greater than 100.");
                }

            }
            catch (Exception e)
            {

                throw;
            }

        }


    }
}
