using BL.AutoMapper;
using BL.BusinessManagers.Interfaces;
using BL.Dtos;
using CustomersApp.ViewModels;
using DAL.ConstantsAndGlobals;
using DAL.Models;
using Newtonsoft.Json;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomersApp.Controllers.FE
{
    public class CustomersController : BaseMVCController<ICustomersBusinessManager, Customer, CustomerDto>
    {

        public ICustomersBusinessManager CustomersBusinessManager { get; set; }


        [Inject]
        public CustomersController(ICustomersBusinessManager customersBusinessManager) : base(customersBusinessManager)
        {
            CustomersBusinessManager = customersBusinessManager;

        }


        /// <summary>
        /// Gets the Top 1000 customers including their types navigation properties
        /// </summary>
        /// <returns></returns>
        // Post customers/GetTop1000
        public ActionResult BulkInsertOfRandomCustomersForm(BulkInsertOfRandomCustomersFormVM bulkInsertOfRandomCustomersFormVM)
        {



            try
            {
                if (ModelState.IsValid)
                {
                    BulkInsertInputDto bulkInsertInputDto = new BulkInsertInputDto
                    {
                        BulkNumber = bulkInsertOfRandomCustomersFormVM.BulkNumber
                    };

                    var result = CustomersBusinessManager
                        .BulkInsertOfRandomCustomers(bulkInsertInputDto.BulkNumber);

                    bulkInsertOfRandomCustomersFormVM.ResultMessage
                        = result.Success ? bulkInsertOfRandomCustomersFormVM.BulkNumber.ToString() + " Customers were created successfully."
                            : "Customers creation failed.";

                    bulkInsertOfRandomCustomersFormVM.IsFailed = result.Success ? false : true;

                    return View("BulkInsertOfRandomCustomersPage", bulkInsertOfRandomCustomersFormVM);

                }

                else
                {
                    return View();
                }

            }
            catch (Exception e)
            {
                bulkInsertOfRandomCustomersFormVM.ResultMessage
                        = "Customers creation failed: " + e.Message.Replace(" See the inner exception for details.", "");

                bulkInsertOfRandomCustomersFormVM.IsFailed =  true;

                return View("BulkInserOfRandomCustomersPage", bulkInsertOfRandomCustomersFormVM);

            }

        }


        
        /// <summary>
        /// Gets the Top 1000 customers including their types navigation properties
        /// </summary>
        /// <returns></returns>
        // Post customers/GetTop1000
        public ActionResult BulkInsertOfRandomCustomersPage()
        {
            return View(new BulkInsertOfRandomCustomersFormVM());
             
        }


        /// <summary>
        /// Gets the Top 1000 customers including their types navigation properties
        /// </summary>
        /// <returns></returns>
        // GET customers/GetTop1000
        public ActionResult GetTop1000()
        {

            try
            {
                var result = CustomersBusinessManager
                    .Get(null, c => c.OrderBy(ct => ct.Id), c => c.CustomerType).Take(1000);

                return View(result);
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
        // GET customers/GetTop1000
        public JsonResult GetTop1000JSON()
        {

            //try
            //{
            //    //var result = CustomersBusinessManager
            //    //    .GetVM(null, c => c.OrderBy(ct => ct.Id), c => c.CustomerType).Take(1000);

            //    //var resultSer = JsonConvert.SerializeObject(result, Formatting.Indented,
            //    //           new JsonSerializerSettings
            //    //           {
            //    //               ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //    //           });

            //    var result = CustomersBusinessManager.GetTop1000Dtos();

            //    return Json(result, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception e)
            //{

            //    throw;
            //}

            try
            {
                var result = CustomersBusinessManager
                    .Get(null, c => c.OrderBy(ct => ct.Id), c => c.CustomerType).Take(1000);

                var output = CustomMapping.MapCustomerObjects(result);



                return Json(output, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                throw;
            }



        }

        public ActionResult GetTop1000AjaxApi()
        {
            return View(new List<Customer>());

        }

        public ActionResult GetTop1000AjaxMVC()
        {
            return View(new List<Customer>());

        }




        /// <summary>
        /// Gets the Top 1000 customers including their types navigation properties
        /// </summary>
        /// <returns></returns>
        // Post customers/GetTop1000
        public ActionResult BulkInsertOfRandomCustomersTimeControlPage()
        {
            return View(new BulkInsertOfRandomCustomersFormDto());

        }

        /// <summary>
        /// Gets the Top 1000 customers including their types navigation properties
        /// </summary>
        /// <returns></returns>
        // Post customers/GetTop1000
        public ActionResult BulkInsertOfRandomCustomersTimeControlForm(BulkInsertOfRandomCustomersFormDto bulkInsertOfRandomCustomersFormVM)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    bulkInsertOfRandomCustomersFormVM.RequestTime = DateTime.UtcNow;

                    var result = CustomersBusinessManager
                        .BulkInsertOfRandomCustomersTimeControl(bulkInsertOfRandomCustomersFormVM);

                    bulkInsertOfRandomCustomersFormVM.ResultMessage
                        = result.Success ? bulkInsertOfRandomCustomersFormVM.BulkNumber.ToString() + " Customers were created successfully."
                            : "Customers creation failed.";

                    bulkInsertOfRandomCustomersFormVM.IsFailed = result.Success ? false : true;

                    return View("BulkInsertOfRandomCustomersTimeControlPage", bulkInsertOfRandomCustomersFormVM);

                }

                else
                {
                    return View();
                }

            }
            catch (Exception e)
            {
                if (e.Message.ToLower() == AppConstants.RequestTimeOutMessage.ToLower())
                {
                    return View("RequestTimeOutPage");
                }

                else
                {
                    bulkInsertOfRandomCustomersFormVM.ResultMessage
                            = "Customers creation failed: " + e.Message.Replace(" See the inner exception for details.", "");

                    bulkInsertOfRandomCustomersFormVM.IsFailed = true;

                    return View("BulkInserOfRandomCustomersPage", bulkInsertOfRandomCustomersFormVM);

                }


            }

        }



        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateBulkOfCustomers()
        { 
            return View();
        }



    }
}