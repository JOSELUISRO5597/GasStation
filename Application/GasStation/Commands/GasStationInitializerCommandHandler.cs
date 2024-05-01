using Domain.Builder;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.GasStation.Commands
{
    public class GasStationInitializerCommandHandler : IRequestHandler<GasStationInitializerCommand, IEnumerable<Domain.Entities.Pump>>
    {
        private readonly IPumpRepository _pumpRepository;

        public GasStationInitializerCommandHandler(IPumpRepository pumpRepository)
        {
            _pumpRepository = pumpRepository;
        }

        public async Task<IEnumerable<Domain.Entities.Pump>> Handle(GasStationInitializerCommand command, CancellationToken cancellationToken)
        {
            _pumpRepository.DeleteAll();

            for (var i = 0; i < 4; i++)
            {
                var pump = new PumpBuilder()
                    .WithId(Guid.NewGuid())
                    .Lock()
                    .Build();

                _pumpRepository.Add(pump);
            }

            return _pumpRepository.GetAll();
        }
    }
}
