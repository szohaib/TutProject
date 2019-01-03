using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using MSEADEW.Models;
using MSEADEW_BAL.BAL;
using System.Data;
using MSEADEW.Helper;

namespace MSEADEW.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;
        private MSEADEW_BAL.BAL.Admin.Login _login = null;
        private DataSet _dataSet = null;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        //public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        //{
        //    var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

        //    ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);

        //    if (user == null)
        //    {
        //        context.SetError("invalid_grant", "The user name or password is incorrect.");
        //        return;
        //    }

        //    ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
        //       OAuthDefaults.AuthenticationType);
        //    ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
        //        CookieAuthenticationDefaults.AuthenticationType);

        //    AuthenticationProperties properties = CreateProperties(user.UserName);
        //    AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
        //    context.Validated(ticket);
        //    context.Request.Context.Authentication.SignIn(cookiesIdentity);
        //}

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                _login = new MSEADEW_BAL.BAL.Admin.Login();
                _dataSet = new DataSet();
                _dataSet = _login.GetLoginDetails(context.UserName);

                string encriptedPassword = EncryptAndDecrypt.Encrypt(context.Password);


                if (_dataSet.Tables[0].Rows[0][2].ToString() == encriptedPassword)
                {
                    var Identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    Identity.AddClaim(new Claim("UserId", context.UserName));
                    var props = new AuthenticationProperties(new Dictionary<string, string>
                            {
                                {
                                    "Email",_dataSet.Tables[0].Rows[0][1].ToString()
                                },
                                {
                                    "RoleId", _dataSet.Tables[0].Rows[0][5].ToString()
                                },
                                {
                                    "FirstName", _dataSet.Tables[0].Rows[0][3].ToString()
                                },
                                {
                                    "LastName", _dataSet.Tables[0].Rows[0][4].ToString()
                                },
                                {
                                    "UserId", _dataSet.Tables[0].Rows[0][0].ToString()
                                },
                            });
                    AuthenticationTicket ticket = new AuthenticationTicket(Identity, props);
                    context.Validated(Identity);
                    context.Validated(ticket);

                }
                else
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    //if (user.Invalid_Attempts_Count < 5 && userInvalidAttempts.IsLocked == false)
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}