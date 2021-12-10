using ProductManager;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ProductManager
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "ProductManager");
                    c.IncludeXmlComments(string.Format(@"{0}\bin\ProductManagerApi.XML",
                                         System.AppDomain.CurrentDomain.BaseDirectory));
                    c.DescribeAllEnumsAsStrings();
                    c.DocumentFilter<AuthTokenOperation>();
                    c.ApiKey("Token")
                    .Description("Bearer token")
                    .Name("Authorization")
                    .In("header");
                })
                .EnableSwaggerUi(c =>
                {
                    c.EnableApiKeySupport("Authorization", "header"); 
                });
        }
    }

    public class AuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.paths.Add("/Token", new PathItem
            {
                post = new Operation
                {
                    tags = new List<string> { "Auth" },
                    consumes = new List<string>
                {
                    "application/x-www-form-urlencoded"
                },
                    parameters = new List<Parameter> {
                    new Parameter
                    {
                        type = "string",
                        name = "grant_type",
                        required = true,
                        @in = "formData"
                    },
                    new Parameter
                    {
                        type = "string",
                        name = "username",
                        required = false,
                        @in = "formData"
                    },
                    new Parameter
                    {
                        type = "string",
                        name = "password",
                        required = false,
                        @in = "formData"
                    }
                }
                }
            });
        }
    }
}
