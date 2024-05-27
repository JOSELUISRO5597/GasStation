using Application.Pump.Commands;
using Domain.Entities;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Application.Pumps.Commands.SetPumpPrice
{
    public class WhenSetPumpPriceCommandIsSuccess: TestForSetPumpPriceCommand
    {
        [Fact]
        public async Task TestForSetPumpPriceCommandIsSuccess()
        {
            var newPrice = 100.0m;
            var command = new SetPumpPriceCommand
            {
                PumpId = Pump.Id,
                Price = newPrice
            };

            var result = await CommandHandler.Handle(command, CancellationToken.None);

            Assert.True(result);
            Assert.Equal(newPrice, Pump.CurrentPrice);
            PumpRepositoryMock.Verify(repo => repo.Update(It.Is<Pump>(p => p.Id == Pump.Id && p.CurrentPrice == newPrice)), Times.Once);
        }
    }
}
