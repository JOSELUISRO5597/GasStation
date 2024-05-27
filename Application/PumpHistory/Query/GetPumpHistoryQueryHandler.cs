using Application.PumpHistory.Models;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.PumpHistory.Query
{
    public class GetPumpHistoryQueryHandler : IRequestHandler<GetPumpHistoryQuery, IEnumerable<PumpHistoryViewModel>>
    {
        private readonly IPumpHistoryRepository _pumpHistoryRepository;

        public GetPumpHistoryQueryHandler(IPumpHistoryRepository pumpHistoryRepository)
        {
            _pumpHistoryRepository = pumpHistoryRepository;
        }

        public async Task<IEnumerable<PumpHistoryViewModel>> Handle(GetPumpHistoryQuery request, CancellationToken cancellationToken)
        {
            var orderedHistory = new List<PumpHistoryViewModel>();
            
            try
            {
                var allPumpHistory = _pumpHistoryRepository.GetAll();

                orderedHistory = allPumpHistory
                    .GroupBy(h => h.PumpId)
                    .Select(g => new
                    {
                        PumpId = g.Key,
                        PumpNumber = g.FirstOrDefault().PumpNumber,
                        TotalAmount = g.Sum(h => h.Amount),
                        LastDateTime = g.Max(h => h.Date)
                    })
                    .OrderByDescending(g => g.TotalAmount)
                    .ThenByDescending(g => g.LastDateTime)
                    .Select(g => new PumpHistoryViewModel
                    {
                        PumpId = g.PumpId,
                        PumpNumber = g.PumpNumber,
                        Amount = g.TotalAmount,
                        DateTime = g.LastDateTime
                    })
                    .ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return orderedHistory;
        }
    }
}
