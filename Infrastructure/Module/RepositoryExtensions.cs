using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Module
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
        {
            services.AddSingleton<IPumpRepository, PumpRepository>();
            services.AddSingleton<IPumpHistoryRepository, PumpHistoryRepository>();

            return services;
        }
    }
}
