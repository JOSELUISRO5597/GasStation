using Application.PumpHistory.Query;
using Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;

namespace UnitTest.Application.PumpHistory.Query
{
    public abstract class TestForGetPumpHistoryQuery: BasePumpHistoryTest
    {
        protected List<Domain.Entities.PumpHistory> PumpHistory;
        protected GetPumpHistoryQuery Query;
        protected GetPumpHistoryQueryHandler QueryHandler;

        public TestForGetPumpHistoryQuery()
        {
            PumpHistoryRepositoryMock = new Mock<IPumpHistoryRepository>();

            var pumpId1 = Guid.NewGuid();
            var pumpId2 = Guid.NewGuid();

            PumpHistory = GetMockedPumpHistory(pumpId1, pumpId2);

            MoqRepositoryServices();

            Query = new GetPumpHistoryQuery();
            QueryHandler = new GetPumpHistoryQueryHandler(PumpHistoryRepositoryMock.Object);
        }

        protected virtual void MoqRepositoryServices()
        {
            PumpHistoryRepositoryMock.Setup(repo => repo.GetAll()).Returns(PumpHistory);
        }
    }
}
