using Application.GasStation.Module;
using Application.Pump.Module;
using Application.PumpHistory.Module;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Module
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services.AddGasStationModule();
            services.AddPumpModule();
            services.AddPumpHistoryModule();

            return services;
        }
    }
}
