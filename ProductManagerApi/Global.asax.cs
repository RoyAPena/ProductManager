using ProductManager.CompositionModel;
using System.Web.Http;

namespace ProductManagerApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoFacConfig.ConfigureContainer();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //WebApiConfig.Register(RouteTable.Routes);
        }
    }
}
