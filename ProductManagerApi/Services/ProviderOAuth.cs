//using Microsoft.Owin.Security;
//using Microsoft.Owin.Security.Cookies;
//using Microsoft.Owin.Security.OAuth;
//using ProductManagerApi.Contract.Repository;
//using System;
//using System.Collections.Generic;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace ProductManagerApi.Services
//{
//    public class ProviderOAuth : OAuthAuthorizationServerProvider
//    {
//        //private readonly IUserRepository _userRepository;
//        private static readonly string _publicClientId = "self";

//        public ProviderOAuth(/*IUserRepository userRepository*/)
//        {
//            //_userRepository = userRepository;
//        }

//        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
//        {
//            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
//            var user = await _userRepository.LoginOauth(context.UserName, context.Password).ConfigureAwait(false);

//            if (user == null)
//            {
//                context.SetError("invalid_grant", "The user name or password is incorrect.");
//                return;
//            }

//            var claims = new List<Claim>();

//            claims.Add(new Claim(ClaimTypes.Name, user.Username));

//            ClaimsIdentity oAuthClaimIdentity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
//            ClaimsIdentity cookiesClaimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationType);

//            AuthenticationProperties properties = CreateProperties(user.Username);
//            AuthenticationTicket ticket = new AuthenticationTicket(oAuthClaimIdentity, properties);

//            context.Validated(ticket);
//            context.Request.Context.Authentication.SignIn(cookiesClaimIdentity);
//        }

//        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
//        {
//            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
//            {
//                context.AdditionalResponseParameters.Add(property.Key, property.Value);
//            }

//            return Task.FromResult<object>(null);
//        }

//        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
//        {
//            if (context.ClientId == null)
//            {
//                context.Validated();
//            }

//            return Task.FromResult<object>(null);
//        }

//        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
//        {
//            if (context.ClientId == _publicClientId)
//            {
//                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

//                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
//                {
//                    context.Validated();
//                }
//            }

//            return Task.FromResult<object>(null);
//        }

//        public static AuthenticationProperties CreateProperties(string userName)
//        {
//            IDictionary<string, string> data = new Dictionary<string, string>
//                                               {
//                                                   { "userName", userName }
//                                               };

//            return new AuthenticationProperties(data);
//        }
//    }
//}