using FluentValidation.WebApi;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;

namespace ProductManagerApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors();
            // Web API configuration and services
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var formatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            formatter.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            FluentValidationModelValidatorProvider.Configure(config);

            // Adding JSON type web api formatting.  
            config.Formatters.Clear();
            config.Formatters.Add(formatter);
        }
    }
}