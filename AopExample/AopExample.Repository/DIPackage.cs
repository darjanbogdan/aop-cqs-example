using AopExample.Repository.Common.Repositories;
using AopExample.Repository.Repositories;
using SimpleInjector;
using SimpleInjector.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopExample.Repository
{
    public class DIPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IUserRepository, UserRepository>(Lifestyle.Transient);
            container.Register<IAccountRepository, AccountRepository>(Lifestyle.Transient);
        }
    }
}