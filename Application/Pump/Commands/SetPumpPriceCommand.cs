using MediatR;
using System;

namespace Application.Pump.Commands
{
    public class SetPumpPriceCommand: IRequest<bool>
    {
        public Guid PumpId { get; set; }
        public decimal Price { get; set; }
    }
}
