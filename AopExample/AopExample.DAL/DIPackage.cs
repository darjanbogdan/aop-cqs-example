using AopExample.DAL.Context;
using AopExample.DAL.Identity.Manager;
using AopExample.DAL.Identity.Models;
using AopExample.DAL.Identity.Storage;
using Microsoft.AspNet.Identity;
using SimpleInjector;
using SimpleInjector.Packaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopExample.DAL
{
    public class DIPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<DbContext>(() => new ApplicationDbContext(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString), Lifestyle.Scoped);

            container.Register<IUserStore<ApplicationUser, Guid>, ApplicationUserStore>(Lifestyle.Scoped);

            container.Register<IRoleStore<ApplicationRole, Guid>, ApplicationRoleStore>(Lifestyle.Scoped);

            container.Register<UserManager<ApplicationUser, Guid>, ApplicationUserManager>(Lifestyle.Scoped);
        }
    }
}