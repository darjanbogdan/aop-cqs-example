using AopExample.DAL.Identity.Models;
using AopExample.Repository.Infrastructure.Mapper;
using AopExample.Web.Infrastructure.DependencyInjection;
using AopExample.Web.Infrastructure.Owin;
using AopExample.Web.Infrastructure.Owin.Providers;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(AopExample.Web.Startup))]

namespace AopExample.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = SimpleInjectorContainerFactory.Create();

            container.RegisterPackages();

            container.RegisterSingleton<IOwinContextProvider>(new CallContextOwinContextProvider());

            #region Mapper

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<RepositoryProfile>();
            });

            container.Register<IMapper>(() => config.CreateMapper(container.GetInstance));

            #endregion Mapper

            app.UseOwinContextExecutionScope(container);

            app.UseOwinContextProvider();

            ConfigureOAuthTokenGeneration(app);

            HttpConfiguration httpConfig = new HttpConfiguration();

            WebApiConfig.Register(httpConfig);

            container.RegisterWebApiControllers(httpConfig);

            httpConfig.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            //app.CreatePerOwinContext(() => container.GetInstance<UserManager<ApplicationUser, Guid>>());

            app.UseCors(CorsOptions.AllowAll);

            app.UseWebApi(httpConfig);

            container.Verify();
        }

        private void ConfigureOAuthTokenGeneration(IAppBuilder app)
        {
            // Plugin the OAuth bearer JSON Web Token tokens generation and Consumption will be here
        }
    }
}