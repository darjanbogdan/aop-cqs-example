using AopExample.DAL.Identity.Manager;
using AopExample.DAL.Identity.Models;
using AopExample.Repository.Common.Repositories;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace AopExample.Web.Infrastructure.Owin.Providers
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly IAccountRepository accountRepository;

        public CustomOAuthProvider(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var allowedOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            ApplicationUser user = await this.accountRepository.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            if (!user.EmailConfirmed)
            {
                context.SetError("invalid_grant", "User did not confirm email.");
                return;
            }

            ClaimsIdentity oAuthIdentity = await this.accountRepository.GenerateUserIdentityAsync(user, "JWT");

            var ticket = new AuthenticationTicket(oAuthIdentity, null);

            context.Validated(ticket);
        }
    }
}