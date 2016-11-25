using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace AopExample.Web.Infrastructure.Owin
{
    public static class OwinContextProviderMiddleware
    {
        public static void UseOwinContextProvider(this IAppBuilder app)
        {
            app.Use(async (context, next) =>
            {
                CallContext.LogicalSetData("IOwinContext", context);
                await next();
            });
        }
    }
}