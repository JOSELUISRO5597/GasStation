using System;

namespace Domain.Entities
{
    public class PumpHistory
    {
        public Guid Id { get; set; }
        public int PumpNumber { get; set; }
        public Guid PumpId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
