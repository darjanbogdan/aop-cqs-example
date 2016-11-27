using AopExample.DAL.Identity.Models;
using AopExample.Model.Models;
using AopExample.Repository.Common.Repositories;
using AopExample.Web.Infrastructure.Owin;
using AopExample.Web.Infrastructure.Owin.Providers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AopExample.Web.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        private readonly IOwinContextProvider provider;
        private readonly IUserRepository userRepository;
        private readonly IAccountRepository accountRepository;

        public TestController(IOwinContextProvider provider, IUserRepository userRepository, IAccountRepository accountRepository)
        {
            this.provider = provider;
            this.userRepository = userRepository;
            this.accountRepository = accountRepository;
        }

        [Route("")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAsync()
        {
            var users = await this.userRepository.FindAsync(null, 0, 10);

            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> RegisterAsync()
        {
            //var user = new ApplicationUser()
            //{
            //    Id = Guid.NewGuid(),
            //    Email = "kostbone@gmail.com",
            //    EmailConfirmed = true,
            //    FirstName = "Darjan",
            //    LastName = "Bogdan",
            //    UserName = "admin"
            //};

            //await this.manager.CreateAsync(user, "Adm!n123");

            //await this.manager.AddToRoleAsync(user.Id, "Administrator");

            await this.accountRepository.RegisterAsync(new User()
            {
                Id = Guid.NewGuid(),
                Email = "kostbone+2@gmail.com",
                FirstName = "DarjanTest",
                LastName = "BogdanTest",
                UserName = "darjantest2"
            });

            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}