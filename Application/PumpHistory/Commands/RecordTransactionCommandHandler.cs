using Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.PumpHistory.Commands
{
    public class RecordTransactionCommandHandler: IRequestHandler<RecordTransactionCommand, bool>
    {
        private readonly IPumpHistoryRepository _pumpHistoryRepository;
        private readonly IPumpRepository _pumpRepository;

        public RecordTransactionCommandHandler(IPumpHistoryRepository pumpHistoryRepository, IPumpRepository pumpRepository)
        {
            _pumpHistoryRepository = pumpHistoryRepository;
            _pumpRepository = pumpRepository;
        }

        public async Task<bool> Handle(RecordTransactionCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var pump = _pumpRepository.GetById(command.PumpId);

                if (pump != null)
                {
                    var historyEntry = new Domain.Entities.PumpHistory
                    {
                        PumpId = pump.Id,
                        PumpNumber = pump.Number,
                        Date = DateTime.Now,
                        Amount = command.Amount
                    };

                    _pumpHistoryRepository.Add(historyEntry);
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }
    }
}
