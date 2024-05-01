using Application.PumpHistory.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.PumpHistory.Query
{
    public class GetPumpHistoryQuery : IRequest<IEnumerable<PumpHistoryViewModel>>
    {
    }
}
