using Application.Pump.Commands;
using Domain.Entities;
using Domain.Interfaces;
using Moq;
using System;

namespace UnitTest.Application.Pumps.Commands.SetPumpStatus
{
    public abstract class TestForSetPumpStatusCommand : BasePumpTest
    {
        protected Pump Pump;
        protected SetPumpStatusCommandHandler CommandHandler;

        public TestForSetPumpStatusCommand()
        {
            PumpRepositoryMock = new Mock<IPumpRepository>();
            Pump = GetMockedPump(Guid.NewGuid(), false);

            MoqRepositoryServices();

            CommandHandler = new SetPumpStatusCommandHandler(PumpRepositoryMock.Object);
        }

        protected virtual Pump GetMockedPump(Guid pumpId, bool status)
        {
            return new Pump(pumpId, 0, status, 0);
        }

        protected virtual void MoqRepositoryServices()
        {
            PumpRepositoryMock.Setup(repo => repo.GetById(Pump.Id)).Returns(Pump);
        }
    }
}
