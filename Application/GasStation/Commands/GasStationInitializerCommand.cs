using MediatR;
using System.Collections.Generic;

namespace Application.GasStation.Commands
{
    public class GasStationInitializerCommand: IRequest<IEnumerable<Domain.Entities.Pump>>
    {
    }
}
