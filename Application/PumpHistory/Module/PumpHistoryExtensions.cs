using Application.PumpHistory.Commands;
using Application.PumpHistory.Models;
using Application.PumpHistory.Query;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Application.PumpHistory.Module
{
    public static class PumpHistoryExtensions
    {
        public static IServiceCollection AddPumpHistoryModule(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRequestHandler<GetPumpHistoryQuery, IEnumerable<PumpHistoryViewModel>>), typeof(GetPumpHistoryQueryHandler));
            services.AddScoped(typeof(IRequestHandler<RecordTransactionCommand, bool>), typeof(RecordTransactionCommandHandler));

            return services;
        }
    }
}
