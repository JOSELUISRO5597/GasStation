using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Pump.Query
{
    public class GetAllPumpsQueryHandler : IRequestHandler<GetAllPumpsQuery, IEnumerable<Domain.Entities.Pump>>
    {
        private readonly IPumpRepository _pumpRepository;

        public GetAllPumpsQueryHandler(IPumpRepository pumpRepository)
        {
            _pumpRepository = pumpRepository;
        }

        public async Task<IEnumerable<Domain.Entities.Pump>> Handle(GetAllPumpsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Entities.Pump> pumps;

            try
            {
                pumps = _pumpRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                pumps = new List<Domain.Entities.Pump>();
            }

            return pumps;
        }
    }
}
