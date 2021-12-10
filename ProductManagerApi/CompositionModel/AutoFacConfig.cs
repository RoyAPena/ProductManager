using Autofac;
using Autofac.Integration.WebApi;
using ProductManagerApi;
using System.Reflection;
using System.Web.Http;

namespace ProductManager.CompositionModel
{
    public class AutoFacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiModelBinderProvider();
            builder.RegisterModule(new CompositionModel());
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            var container = builder.Build();
            
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}