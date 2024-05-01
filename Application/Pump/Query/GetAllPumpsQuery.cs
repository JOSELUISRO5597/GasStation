using MediatR;
using System.Collections.Generic;

namespace Application.Pump.Query
{
    public class GetAllPumpsQuery: IRequest<IEnumerable<Domain.Entities.Pump>>
    {
    }
}
