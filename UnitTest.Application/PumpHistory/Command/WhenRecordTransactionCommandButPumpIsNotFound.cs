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
    public class WhenRecordTransactionCommandButPumpIsNotFound: TestForRecordTransactionCommand
    {
        [Fact]
        public async Task TestForRecordTransactionCommandButPumpIsNotFound()
        {
            var newGuid = Guid.NewGuid();
            var command = new RecordTransactionCommand { PumpId = newGuid, Amount = 100m };
            var result = await CommandHandler.Handle(command, CancellationToken.None);

            Assert.False(result);
            PumpHistoryRepositoryMock.Verify(repo => repo.Add(It.IsAny<Domain.Entities.PumpHistory>()), Times.Never);
        }
    }
}
