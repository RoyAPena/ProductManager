using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using ProductManagerApi.Entities.Model;
//using ProductManagerApi.Repository.SQL;
//using ProductManagerApi.Services;
using System;

[assembly: OwinStartup(typeof(ProductManagerApi.Startup))]

namespace ProductManagerApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
        
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new ProductManagerContext());
            
            var oAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseOAuthBearerTokens(oAuthOptions);
        }
    }
}