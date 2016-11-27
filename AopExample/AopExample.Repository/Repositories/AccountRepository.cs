using AopExample.DAL.Identity.Models;
using AopExample.Model.Models;
using AopExample.Repository.Common.Repositories;
using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AopExample.Repository.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser, Guid> userManager;

        private readonly IMapper mapper;

        public AccountRepository(UserManager<ApplicationUser, Guid> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task RegisterAsync(User user)
        {
            var appUser = this.mapper.Map<ApplicationUser>(user);

            var result = await this.userManager.CreateAsync(appUser, "123456");
        }

        public Task<ApplicationUser> FindAsync(string userName, string password)
        {
            return this.userManager.FindAsync(userName, password);
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUser user, string authenticationType)
        {
            var userIdentity = await this.userManager.CreateIdentityAsync(user, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}