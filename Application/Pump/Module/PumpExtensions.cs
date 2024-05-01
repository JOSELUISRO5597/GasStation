using Application.Pump.Commands;
using Application.Pump.Query;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Application.Pump.Module
{
    public static class PumpExtensions
    {
        public static IServiceCollection AddPumpModule(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRequestHandler<GetAllPumpsQuery, IEnumerable<Domain.Entities.Pump>>), typeof(GetAllPumpsQueryHandler));

            services.AddScoped(typeof(IRequestHandler<SetPumpStatusCommand, bool>), typeof(SetPumpStatusCommandHandler));
            services.AddScoped(typeof(IRequestHandler<SetPumpPriceCommand, bool>), typeof(SetPumpPriceCommandHandler));
            
            return services;
        }
    }
}
