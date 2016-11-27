using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace AopExample.Web.Infrastructure.Owin.Providers
{
    public class CallContextOwinContextProvider : IOwinContextProvider
    {
        public IOwinContext CurrentContext
        {
            get
            {
                return (IOwinContext)CallContext.LogicalGetData("IOwinContext");
            }
        }
    }
}