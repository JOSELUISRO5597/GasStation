using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;


namespace Infrastructure.Repositories
{
    public class PumpRepository : IPumpRepository
    {
        private readonly List<Pump> _pumps = new();

        public Pump GetById(Guid id) => _pumps.Find(p => p.Id == id);

        public IEnumerable<Pump> GetAll() => _pumps;

        public void Add(Pump pump)
        {
            if (pump == null)
            {
                throw new ArgumentNullException(nameof(pump));
            }

            pump.Id = Guid.NewGuid();
            pump.Number = _pumps.Count + 1;
            _pumps.Add(pump);
        }

        public void Update(Pump pump)
        {
            if (pump == null)
            {
                throw new ArgumentNullException(nameof(pump));
            }

            var index = _pumps.FindIndex(p => p.Id == pump.Id);

            if (index != -1)
            {
                _pumps[index] = pump;
            }
        }

        public void Delete(Guid id) => _pumps.RemoveAll(p => p.Id == id);

        public void DeleteAll() => _pumps.Clear();

    }
}
