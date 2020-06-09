using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sa.Repository.DI
{
    public static class RepositoryService
    {
        public static IServiceCollection AddRepositoriesCollection(this IServiceCollection services) //, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.TryAdd(ServiceDescriptor.Scoped<ISaRepository, SaRepository>());

            return services;
        }
    }
}
