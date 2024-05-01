using System;

namespace Application.PumpHistory.Models
{
    public class PumpHistoryViewModel
    {
        public Guid PumpId { get; set; }
        public int PumpNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
    }
}
