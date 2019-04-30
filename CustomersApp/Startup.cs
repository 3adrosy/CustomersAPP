using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartupAttribute(typeof(CustomersApp.Startup))]
namespace CustomersApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // GlobalConfiguration.Configuration.EnableDependencyInjection();

            ConfigureAuth(app);
        }
    }
}
