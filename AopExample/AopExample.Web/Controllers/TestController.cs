using AopExample.DAL.Identity.Models;
using AopExample.Web.Infrastructure.Owin;
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
        private readonly UserManager<ApplicationUser, Guid> manager;

        public TestController(IOwinContextProvider provider, UserManager<ApplicationUser, Guid> manager)
        {
            this.provider = provider;
            this.manager = manager;
        }

        [Route("")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAsync()
        {
            var user = await this.manager.FindByNameAsync("SuperPowerUser");

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> RegisterAsync()
        {
            var user = new ApplicationUser()
            {
                Id = Guid.NewGuid(),
                Email = "kostbone@gmail.com",
                EmailConfirmed = true,
                FirstName = "Darjan",
                LastName = "Bogdan",
                UserName = "admin"
            };

            await this.manager.CreateAsync(user, "Adm!n123");

            await this.manager.AddToRoleAsync(user.Id, "Administrator");

            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}