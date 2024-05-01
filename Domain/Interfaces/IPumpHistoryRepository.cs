using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IPumpHistoryRepository
    {
        IEnumerable<PumpHistory> GetAll();
        void Add(PumpHistory historyEntry);
    }
}
