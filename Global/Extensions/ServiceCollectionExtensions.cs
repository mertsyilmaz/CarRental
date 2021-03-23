using Global.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Global.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection servicesCollection,IGlobalModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(servicesCollection);
            }

            return ServiceTool.Create(servicesCollection);
        }
    }
}
