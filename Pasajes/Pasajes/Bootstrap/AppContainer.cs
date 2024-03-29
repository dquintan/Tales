﻿using Autofac;
using Pasajes.Contracts;
using Pasajes.Repository;
using System;

namespace Pasajes.Bootstrap
{
    public class AppContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            // View models
            // builder.RegisterType<ExampleViewModel>();

            // Services = data
            builder.RegisterType<ITalesService>().As<ITalesService>();

            // Services - general
            // builder.RegisterType<NavidationService>().As<INavigationService>();

            // General
            builder.RegisterType<GenericRepository>().As<IGenericRepository>();

            _container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
