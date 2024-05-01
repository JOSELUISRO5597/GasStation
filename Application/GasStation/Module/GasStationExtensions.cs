using Application.GasStation.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Application.GasStation.Module
{
    public static class GasStationExtensions
    {
        public static IServiceCollection AddGasStationModule(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRequestHandler<GasStationInitializerCommand, IEnumerable<Domain.Entities.Pump>>), typeof(GasStationInitializerCommandHandler));

            return services;
        }
    }
}
