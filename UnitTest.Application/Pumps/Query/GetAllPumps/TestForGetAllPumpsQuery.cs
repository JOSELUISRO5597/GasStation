using Application.Pump.Query;
using Domain.Entities;
using Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;

namespace UnitTest.Application.Pumps.Query.GetAllPumps
{
    public abstract class TestForGetAllPumpsQuery
    {
        protected Mock<IPumpRepository> PumpRepositoryMock;
        protected List<Pump> Pumps;
        protected GetAllPumpsQuery Query;
        protected GetAllPumpsQueryHandler QueryHandler;

        protected void ConfigureTest()
        {
            PumpRepositoryMock = new Mock<IPumpRepository>();
            Pumps = GetAllMockedPumps();

            MoqRepositoryServices();
            GetCommandObjects();
        }

        protected virtual List<Pump> GetAllMockedPumps()
        {
            return new List<Pump>()
            {
                new Pump(Guid.NewGuid(),1, false, 0),
                new Pump(Guid.NewGuid(),2, false, 0),
                new Pump(Guid.NewGuid(),3, false, 0),
                new Pump(Guid.NewGuid(),4, false, 0)
            };
        }

        protected virtual void MoqRepositoryServices()
        {
            PumpRepositoryMock.Setup(repo => repo.GetAll()).Returns(Pumps);
        }

        private void GetCommandObjects()
        {
            Query = new GetAllPumpsQuery();
            QueryHandler = new GetAllPumpsQueryHandler(PumpRepositoryMock.Object);
        }
    }
}
