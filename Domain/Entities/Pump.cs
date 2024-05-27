using System;

namespace Domain.Entities
{
    public class Pump
    {
        public Pump()
        {

        }

        public Pump(Guid id, int number, bool isLocked, decimal currentPrice)
        {
            Id = id;
            Number = number;
            IsLocked = isLocked;
            CurrentPrice = currentPrice;
        }

        public Guid Id { get; set; }
        public int Number { get; set; }
        public bool IsLocked { get; set; }
        public decimal CurrentPrice { get; set; }
    }
}
