using Application.PumpHistory.Commands;
using Domain.Entities;
using Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Application.PumpHistory.Command
{
    public abstract class TestForRecordTransactionCommand : BasePumpHistoryTest
    {
        protected Pump Pump;
        protected List<Domain.Entities.PumpHistory> PumpHistory;
        protected RecordTransactionCommandHandler CommandHandler;

        public TestForRecordTransactionCommand()
        {
            PumpHistoryRepositoryMock = new Mock<IPumpHistoryRepository>();
            PumpRepositoryMock = new Mock<IPumpRepository>();

            var pumpId1 = Guid.NewGuid();
            var pumpId2 = Guid.NewGuid();

            PumpHistory = GetMockedPumpHistory(pumpId1, pumpId2);
            Pump = GetMockedPump(pumpId1);

            MoqRepositoryServices();

            CommandHandler = new RecordTransactionCommandHandler(PumpHistoryRepositoryMock.Object, PumpRepositoryMock.Object);
        }

        protected virtual void MoqRepositoryServices()
        {
            PumpRepositoryMock.Setup(repo => repo.GetById(Pump.Id)).Returns(Pump);
            PumpHistoryRepositoryMock.Setup(repo => repo.GetAll()).Returns(PumpHistory);
        }
    }
}
