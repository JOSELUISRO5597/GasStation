using Application.PumpHistory.Commands;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Application.PumpHistory.Command
{
    public class WhenRecordTransactionCommandThrowsException : TestForRecordTransactionCommand
    {
        private Exception _exception = new Exception("Error message");

        [Fact]
        public async Task TestForRecordTransactionCommandThrowsException()
        {
            var command = new RecordTransactionCommand { PumpId = Pump.Id, Amount = 100m };
            var result = await CommandHandler.Handle(command, CancellationToken.None);

            Assert.False(result);
            PumpHistoryRepositoryMock.Verify(repo => repo.Add(It.IsAny<Domain.Entities.PumpHistory>()), Times.Never);
        }

        protected override void MoqRepositoryServices()
        {
            PumpRepositoryMock.Setup(repo => repo.GetById(Pump.Id)).Throws(_exception);
        }
    }
}
