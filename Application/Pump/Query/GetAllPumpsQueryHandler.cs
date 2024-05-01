using Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Pump.Query
{
    public class GetAllPumpsQueryHandler: IRequestHandler<GetAllPumpsQuery, IEnumerable<Domain.Entities.Pump>>
    {
        private readonly IPumpRepository _pumpRepository;

        public GetAllPumpsQueryHandler(IPumpRepository pumpRepository)
        {
            _pumpRepository = pumpRepository;
        }

        public async Task<IEnumerable<Domain.Entities.Pump>> Handle(GetAllPumpsQuery request, CancellationToken cancellationToken)
        {
            var pumps = _pumpRepository.GetAll();

            return pumps;
        }
    }
}
