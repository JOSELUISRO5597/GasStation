using Application.Pump.Query;
using Domain.Entities;
using Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;

namespace UnitTest.Application.Pumps.Query.GetAllPumps
{
    public abstract class TestForGetAllPumpsQuery: BasePumpTest
    {
        protected List<Pump> Pumps;
        protected GetAllPumpsQuery Query;
        protected GetAllPumpsQueryHandler QueryHandler;

        public TestForGetAllPumpsQuery()
        {
            PumpRepositoryMock = new Mock<IPumpRepository>();
            Pumps = GetAllMockedPumps();

            MoqRepositoryServices();

            Query = new GetAllPumpsQuery();
            QueryHandler = new GetAllPumpsQueryHandler(PumpRepositoryMock.Object);
        }

        protected virtual void MoqRepositoryServices()
        {
            PumpRepositoryMock.Setup(repo => repo.GetAll()).Returns(Pumps);
        }
    }
}
