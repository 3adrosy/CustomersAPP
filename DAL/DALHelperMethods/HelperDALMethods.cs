using DAL.ConstantsAndGlobals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DALHelperMethods
{
    public static class HelperDALMethods
    {


        /// <summary>
        /// Throw Exception if the Bulk Insert Of Random Customers for a given Number, took time more than allowed 1 minute.
        /// </summary>
        /// <param name="requestDateTime"></param>
        /// <returns></returns>
        public static void CheckRequestTimeOutDAL(DateTime requestDateTime)
        {
            
            try
            {
                // TimeSpan span = DateTime.UtcNow.Subtract(requestDateTime);
                var requestMinutes = (DateTime.UtcNow.Subtract(requestDateTime)).TotalMinutes;

                if ((DateTime.UtcNow.Subtract(requestDateTime)).TotalMinutes > AppConstants.RequestTimeLimit)
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

        /// <summary>
        /// Throw Exception if the Bulk Insert Of Random Customers for a given Number, took time more than allowed 1 minute.
        /// </summary>
        /// <param name="requestDateTime"></param>
        /// <returns></returns>
        public static void CheckRequestTimeOutDALTest(DateTime requestDateTime)
        {

            try
            {
                // TimeSpan span = DateTime.UtcNow.Subtract(requestDateTime);
                var requestMinutes = (DateTime.UtcNow.Subtract(requestDateTime)).TotalMinutes;

                if ((DateTime.UtcNow.Subtract(requestDateTime)).TotalMinutes > 0)
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
