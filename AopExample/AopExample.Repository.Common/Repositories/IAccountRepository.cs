using AopExample.DAL.Identity.Models;
using AopExample.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AopExample.Repository.Common.Repositories
{
    public interface IAccountRepository
    {
        Task RegisterAsync(User user);

        Task<ApplicationUser> FindAsync(string userName, string password);

        Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUser user, string authenticationType);
    }
}