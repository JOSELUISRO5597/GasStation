using MediatR;
using System;

namespace Application.Pump.Commands
{
    public class SetPumpStatusCommand : IRequest<bool>
    {
        public Guid PumpId { get; set; }

        public bool Status { get; set; }
    }
}
