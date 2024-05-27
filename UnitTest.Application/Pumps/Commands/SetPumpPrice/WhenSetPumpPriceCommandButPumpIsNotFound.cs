using Application.Pump.Commands;
using Domain.Entities;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Application.Pumps.Commands.SetPumpPrice
{
    public class WhenSetPumpPriceCommandButPumpIsNotFound : TestForSetPumpPriceCommand
    {
        [Fact]
        public async Task TestForSetPumpPriceCommandButPumpIsNotFound()
        {
            var newId = Guid.NewGuid();
            var newPrice = 100.0m;

            var command = new SetPumpPriceCommand
            {
                PumpId = newId,
                Price = newPrice
            };

            var result = await CommandHandler.Handle(command, CancellationToken.None);

            Assert.False(result);
            Assert.NotEqual(newPrice, Pump.CurrentPrice);
            PumpRepositoryMock.Verify(repo => repo.Update(It.Is<Pump>(p => p.Id == Pump.Id && p.CurrentPrice == newPrice)), Times.Never);
        }
    }
}
