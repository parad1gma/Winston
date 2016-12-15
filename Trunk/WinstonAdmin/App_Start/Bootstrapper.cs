using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Winston.Infrastructure.Ioc;

namespace Winston.Admin.App_Start
{
    public class Bootstrapper
    {
        public static void SetAutofacContainer()
        {
            var builder = IoCFactory.GetContainer();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}