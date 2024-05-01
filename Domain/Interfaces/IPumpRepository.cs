using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IPumpRepository
    {
        Pump GetById(Guid id);
        IEnumerable<Pump> GetAll();
        void Add(Pump pump);
        void Update(Pump pump);
        void Delete(Guid id);
        void DeleteAll();
    }
}
