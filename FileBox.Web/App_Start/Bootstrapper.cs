using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using FileBox.Data.Infrastructure;
using FileBox.Data.Repository;
using FileBox.Service;
using FileBox.Web.Global.Auth;
using FileBox.Web.Mappings;

namespace FileBox.Web.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            AutoMapperConfiguration.Configure();
        }
        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<CustomAuthentication>().As<IAuthentication>().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(UserInfoRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(UserInfoService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}