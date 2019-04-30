using DAL.ConstantsAndGlobals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Helper
{
    public static class HelperMethods
    {

        public static int LastRandom = 0;


        public static int GenerateRandomIntNumber(int from, int to)
        {

            try
            {
                Random random = new Random();
                var result = random.Next(from, to);

                //to decrease the probability of redundancy for the random number
                if (result < 70 && result > 18 && result == LastRandom)
                {
                    result = random.Next(from, to);
                }

                LastRandom = result;

                return result;

            }
            catch (Exception e)
            {

                throw;
            }
        }


        public static int GetRandomCustomerType(int TypesCount)
        {

            try
            {
                // can be dynamic instead of magic number
                int typeId = random.Next(1,TypesCount);

                return typeId;

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public static int GetRandomCustomerGender(int GenderNo = 2)
        {
            
            try
            {
                // can be dynamic instead of magic number
                int typeId = random.Next(0, GenderNo);

                return typeId;

            }
            catch (Exception e)
            {

                throw;
            }
        }


        public static Random random = new Random();



        /// <summary>
        /// Throw Exception if the Bulk Insert Of Random Customers for a given Number, took time more than allowed 1 minute.
        /// </summary>
        /// <param name="requestDateTime"></param>
        /// <returns></returns>
        public static void CheckRequestTimeOut(DateTime requestDateTime)
        {

            try
            {
                // TimeSpan span = DateTime.UtcNow.Subtract(requestDateTime);
                var requestMinutes = (DateTime.UtcNow.Subtract(requestDateTime)).TotalMinutes;

                if ( (DateTime.UtcNow.Subtract(requestDateTime)).TotalMinutes > AppConstants.RequestTimeLimit)
                {
                    Exception timeoutRequest = new Exception("The request took " + requestMinutes + " minutes that is a time more than allowed 1 minute.");
                    throw new NotImplementedException(AppConstants.RequestTimeOutMessage);

                }

            }
            catch (Exception e)
            {
                //throw new NotImplementedException();

                throw;
            }
        }


    }



}
