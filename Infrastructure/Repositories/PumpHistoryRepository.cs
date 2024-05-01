using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public class PumpHistoryRepository : IPumpHistoryRepository
    {
        private readonly List<PumpHistory> _pumpHistory = new();

        public IEnumerable<PumpHistory> GetAll() => _pumpHistory;

        public void Add(PumpHistory historyEntry)
        {
            if (historyEntry == null)
                throw new ArgumentNullException(nameof(historyEntry));

            historyEntry.Id = Guid.NewGuid();
            _pumpHistory.Add(historyEntry);
        }
    }
}
