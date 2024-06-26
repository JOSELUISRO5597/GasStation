﻿using Application.Pump.Commands;
using Domain.Entities;
using Domain.Interfaces;
using Moq;
using System;

namespace UnitTest.Application.Pumps.Commands.SetPumpPrice
{
     public abstract class TestForSetPumpPriceCommand : BasePumpTest
    {
        protected Pump Pump;
        protected SetPumpPriceCommandHandler CommandHandler;

        public TestForSetPumpPriceCommand()
        {
            PumpRepositoryMock = new Mock<IPumpRepository>();
            Pump = GetMockedPump(Guid.NewGuid(), 50.0m);

            MoqRepositoryServices();

            CommandHandler = new SetPumpPriceCommandHandler(PumpRepositoryMock.Object);
        }

        protected virtual Pump GetMockedPump(Guid pumpId, decimal currentPrice)
        {
            return new Pump(pumpId, 0, false, currentPrice);
        }

        protected virtual void MoqRepositoryServices()
        {
            PumpRepositoryMock.Setup(repo => repo.GetById(Pump.Id)).Returns(Pump);
        }
    }
}
