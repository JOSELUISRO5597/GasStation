using Domain.Entities;
using Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;

namespace UnitTest.Application.Pumps
{
    public abstract class BasePumpTest: BaseUnitTest
    {
        protected Mock<IPumpRepository> PumpRepositoryMock;

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
    }
}
