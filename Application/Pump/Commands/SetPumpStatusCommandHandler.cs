using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Pump.Commands
{
    public class SetPumpStatusCommandHandler: IRequestHandler<SetPumpStatusCommand, bool>
    {
        private readonly IPumpRepository _pumpRepository;

        public SetPumpStatusCommandHandler(IPumpRepository pumpRepository)
        {
            _pumpRepository = pumpRepository;
        }

        public async Task<bool> Handle(SetPumpStatusCommand command, CancellationToken cancellationToken)
        {
            var pump = _pumpRepository.GetById(command.PumpId);

            if (pump != null)
            {
                pump.IsLocked = command.Status;
                _pumpRepository.Update(pump);
            }

            return true;
        }
    }
}
