using Domain.Entities;
using System;

namespace Domain.Builder
{
    public class PumpBuilder
    {
        private readonly Pump _pump;

        public PumpBuilder()
        {
            _pump = new Pump();
        }

        public PumpBuilder WithId(Guid id)
        {
            _pump.Id = id;
            return this;
        }

        public PumpBuilder Lock()
        {
            _pump.IsLocked = true;
            return this;
        }

        public Pump Build()
        {
            return _pump;
        }
    }
}
