using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Winston.Infrastructure.Ioc;

namespace Winston.API.App_Start
{
    public class Bootstrapper
    {
        public static IContainer SetAutofacContainer()
        {
            var builder = IoCFactory.GetContainer();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            IContainer container = builder.Build();

            return container;
        }
    }
}