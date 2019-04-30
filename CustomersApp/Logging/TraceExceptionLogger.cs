using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace CustomersApp.Logging
{
    public class TraceExceptionLogger : ExceptionLogger
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(TraceExceptionLogger));

        public override void Log(ExceptionLoggerContext context)
        {
            string postData = string.Empty;

            try
            {
                var data = ((System.Web.Http.ApiController)
                      context.ExceptionContext.ControllerContext.Controller)
                      .ActionContext.ActionArguments.Values;

                postData = JsonConvert.SerializeObject(data);
            }
            catch
            {
                // DO SOMETHING ??          
            }

            Logger.FatalFormat(
                Environment.NewLine + "Fetal error WEBAPI:URL:{0}»» METHOD: {1} " + Environment.NewLine + "»»»» Exception: {2}", context.Request.RequestUri, context.Request.Method,
        context.ExceptionContext.Exception);
        }
    }
}