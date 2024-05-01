using System;

namespace Domain.Entities
{
    public class Pump
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public bool IsLocked { get; set; }
        public decimal CurrentPrice { get; set; }
    }
}
