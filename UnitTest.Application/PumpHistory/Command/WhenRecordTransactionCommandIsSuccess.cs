using Application.PumpHistory.Commands;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Application.PumpHistory.Command
{
    public class WhenRecordTransactionCommandIsSuccess: TestForRecordTransactionCommand
    {
        [Fact]
        public async Task TestForRecordTransactionCommandIsSuccess()
        {
            var command = new RecordTransactionCommand { PumpId = Pump.Id, Amount = 100m };
            var result = await CommandHandler.Handle(command, CancellationToken.None);

            Assert.True(result);
            PumpHistoryRepositoryMock.Verify(repo => repo.Add(It.Is<Domain.Entities.PumpHistory>(h => h.PumpId == Pump.Id && h.Amount == 100m && h.PumpNumber == 0)), Times.Once);
        }
    }
}
