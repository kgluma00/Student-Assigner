using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SA.Business.Interfaces;
using SA.Business.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SA.Business.DI
{
    public static class BusinessService
    {
        public static IServiceCollection AddBusinessServicesCollection(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.TryAdd(ServiceDescriptor.Scoped<IUserService, UserService>());

            return services;
        }
    }
}
