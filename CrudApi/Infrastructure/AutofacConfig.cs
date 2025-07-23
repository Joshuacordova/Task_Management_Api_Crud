using Autofac;
using Autofac.Integration.WebApi;
using CrudApi.Repositories;
using CrudApi.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace CrudApi.Infrastructure
{
	public class AutofacConfig
	{
		public static void RegisterDependecies()
		{

			var builder = new ContainerBuilder();

            // Register your services and repositories here
            //Repositories
            builder.RegisterGeneric(typeof(TaskRepository<>)).As(typeof(ITaskRepository<>)).InstancePerRequest();

            //Services
            builder.RegisterType<TaskService>().As<ITaskService>().InstancePerLifetimeScope();

            //Web API configuration
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}