using Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Pump.Commands
{
    public class SetPumpPriceCommandHandler: IRequestHandler<SetPumpPriceCommand, bool>
    {
        private readonly IPumpRepository _pumpRepository;

        public SetPumpPriceCommandHandler(IPumpRepository pumpRepository)
        {
            _pumpRepository = pumpRepository;
        }

        public async Task<bool> Handle(SetPumpPriceCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var pump = _pumpRepository.GetById(command.PumpId);

                if (pump != null)
                {
                    pump.CurrentPrice = command.Price;
                    _pumpRepository.Update(pump);
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
