using MediatR;
using System;

namespace Application.PumpHistory.Commands
{
    public class RecordTransactionCommand: IRequest<bool>
    {
        public Guid PumpId { get; set; }
        public decimal Amount { get; set; }
    }
}
