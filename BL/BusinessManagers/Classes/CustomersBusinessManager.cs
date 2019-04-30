using AutoMapper;
using BL.AutoMapper;
using BL.BusinessManagers.Interfaces;
using BL.Dtos;
using BL.Helper;
using DAL.ConstantsAndGlobals;
using DAL.DataSeed;
using DAL.Models;
using DAL.Repository.Classes;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BL.BusinessManagers.Classes
{
    public class CustomersBusinessManager
                <TRepository> : BaseBusinessManager<Customer, TRepository, CustomerDto>,
            ICustomersBusinessManager where TRepository : CustomersRepository

    {
        public CustomersBusinessManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

            Mapper.Initialize(cfg =>
            {
                //cfg.CreateMap<CustomerType, CustomerTypeDto>();
                //cfg.CreateMap<Customer, CustomerDto>();
            });


        }


        /// <summary>
        /// Bulk Insert Of Random Customers for a given Number
        /// </summary>
        /// <param name="bulkNumber"></param>
        /// <returns></returns>
        public BusinessCustomResponse<int> BulkInsertOfRandomCustomers(int bulkNumber)
        {

            try
            {
                var customersList = GenerateRandomCustomers(bulkNumber);

                this.SaveListVoid(customersList);

                return this.BusinessCustomResponse<int>(bulkNumber);

            }
            catch (Exception e)
            {

                throw;
            }
        }


        /// <summary>
        /// Bulk Insert Of Random Customers for a given Number
        /// </summary>
        /// <param name="bulkNumber"></param>
        /// <returns></returns>
        public BusinessCustomResponse<int> BulkInsertOfRandomCustomersTimeControl(BulkInsertOfRandomCustomersFormDto bulkInsertOfRandomCustomersFormDto)
        {

            try
            {
                HelperMethods.CheckRequestTimeOut(bulkInsertOfRandomCustomersFormDto.RequestTime);

                var customersList = GenerateRandomCustomers(bulkInsertOfRandomCustomersFormDto.BulkNumber);

                HelperMethods.CheckRequestTimeOut(bulkInsertOfRandomCustomersFormDto.RequestTime);

                this.SaveListVoidTimeControl(customersList, bulkInsertOfRandomCustomersFormDto.RequestTime);
                
                return this.BusinessCustomResponse<int>(bulkInsertOfRandomCustomersFormDto.BulkNumber);

            }
            catch (Exception e)
            {
                //throw new NotImplementedException();

                throw;
            }
        }



        /// <summary>
        /// Generate Random Customer entity objects and return list of them 
        /// </summary>
        /// <param name="bulkNumber"></param>
        /// <returns></returns>
        public List<Customer> GenerateRandomCustomers(int bulkNumber)
        {
            
            try
            {

                List<Customer> randomCustomers = new List<Customer>();

                for (int i = 0; i < bulkNumber; i++)
                {
                    var newCustomer = GenerateRandomCustomer();

                    randomCustomers.Add(newCustomer);
                }

                return randomCustomers;
            }
            catch (Exception e)
            {

                throw;
            }
        }


        /// <summary>
        /// Generate Random Customer entity object
        /// </summary>
        /// <returns></returns>
        public Customer GenerateRandomCustomer()
        {

            try
            {
                Customer result = new Customer();
                result.Age = this.GenerateRandomCustomerAge();
                result.CustomerTypeId = this.GetRandomCustomerType();
                result.Gender = this.GetRandomCustomerGender() == 0? Enums.DepartmentNames.Female : Enums.DepartmentNames.Male ;

                return (result);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        /// <summary>
        /// Generates Random Age for a new customer
        /// </summary>
        /// <returns></returns>
        public int GenerateRandomCustomerAge()
        {

            try
            {
               // var result = GenerateRandomIntNumber(AppConstants.MinAge, AppConstants.MaxAge);
              //  var result = HelperMethods.GenerateRandomIntNumber(AppConstants.MinAge, AppConstants.MaxAge);
                var result = RandomInteger(AppConstants.MinAge, AppConstants.MaxAge);

                return result;

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public int GenerateRandomIntNumber(int from, int to)
        {

            try
            {
                Random random = new Random();
                var result = random.Next(from, to);

                //to decrease the probability of redundancy for the random number
                //if (result < 70 && result > 18 && result == LastRandom)
                //{
                //    result = random.Next(from, to);
                //}

                //LastRandom = result;

                return result;

            }
            catch (Exception e)
            {

                throw;
            }
        }



        /// <summary>
        /// Gets Random Customer-Type for a new customer
        /// </summary>
        /// <returns></returns>
        public int GetRandomCustomerType()
        {

            try
            {
                // can be dynamic instead of magic number                
               // var result = HelperMethods.GetRandomCustomerType(6);
                var result = RandomInteger(1, 6);

                return result;

            }
            catch (Exception e)
            {

                throw;
            }
        }

        /// <summary>
        /// Gets Random Customer-Gender for a new customer
        /// </summary>
        /// <returns></returns>
        public int GetRandomCustomerGender()
        {

            try
            {
                // can be dynamic instead of magic number                
               // var result = HelperMethods.GetRandomCustomerGender(2);
                var result = RandomInteger(0,2);
                
                return result;

            }
            catch (Exception e)
            {

                throw;
            }
        }


        public IQueryable<CustomerDto> GetTop1000Dtos()
        {

            try
            {
               var result = this.Get(null, c => c.OrderBy(ct => ct.Id), c => c.CustomerType).Take(1000);

                var output = CustomMapping.MapCustomerObjects(result);

               return output;

            }
            catch (Exception e)
            {

                throw;
            }
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



        //


        //public override BusinessCustomResponse<CustomerDto> Update(CustomerDto entityToUpdateVM, object id, params Expression<Func<Customer, object>>[] IgnoreSelector)
        //{
        //    return base.Update(entityToUpdateVM, id, s => s.Id);
        //}


        #region Random

        // The random number provider.
        private RNGCryptoServiceProvider Rand = new RNGCryptoServiceProvider();

        // Return a random integer between a min and max value.
        private int RandomInteger(int min, int max)
        {
            uint scale = uint.MaxValue;
            while (scale == uint.MaxValue)
            {
                // Get four random bytes.
                byte[] four_bytes = new byte[4];
                Rand.GetBytes(four_bytes);

                // Convert that into an uint.
                scale = BitConverter.ToUInt32(four_bytes, 0);
            }

            // Add min to the scaled difference between max and min.
            return (int)(min + (max - min) *
                (scale / (double)uint.MaxValue));
        }


        #endregion




    }

}
