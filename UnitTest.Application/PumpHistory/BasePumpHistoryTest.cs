using Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;

namespace UnitTest.Application.PumpHistory
{
    public abstract class BasePumpHistoryTest: BaseUnitTest
    {
        protected Mock<IPumpHistoryRepository> PumpHistoryRepositoryMock;
        protected Mock<IPumpRepository> PumpRepositoryMock;

        protected virtual List<Domain.Entities.PumpHistory> GetMockedPumpHistory(Guid pumpId1, Guid pumpId2)
        {
            return new List<Domain.Entities.PumpHistory>()
            {
                new Domain.Entities.PumpHistory { PumpId = pumpId1, PumpNumber = 1, Amount = 100, Date = new DateTime(2024, 5, 1) },
                new Domain.Entities.PumpHistory { PumpId = pumpId2, PumpNumber = 2, Amount = 200, Date = new DateTime(2024, 5, 2) },
                new Domain.Entities.PumpHistory { PumpId = pumpId1, PumpNumber = 1, Amount = 150, Date = new DateTime(2024, 5, 3) },
                new Domain.Entities.PumpHistory { PumpId = pumpId2, PumpNumber = 2, Amount = 50, Date = new DateTime(2024, 5, 4) }
            };
        }
    }
}
