using Application.Pump.Commands;
using Domain.Entities;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Application.Pumps.Commands.SetPumpPrice
{
    public class WhenSetPumpPriceCommandThrowsException: TestForSetPumpPriceCommand
    {
        private Exception _exception = new Exception("Error message");

        [Fact]
        public async Task TestForSetPumpPriceCommandThrowsException()
        {
            var newPrice = 100.0m;
            var command = new SetPumpPriceCommand
            {
                PumpId = Pump.Id,
                Price = newPrice
            };

            var result = await CommandHandler.Handle(command, CancellationToken.None);

            Assert.False(result);
            Assert.NotEqual(newPrice, Pump.CurrentPrice);
            PumpRepositoryMock.Verify(repo => repo.Update(It.Is<Pump>(p => p.Id == Pump.Id && p.CurrentPrice == newPrice)), Times.Never);
        }

        protected override void MoqRepositoryServices()
        {
            PumpRepositoryMock.Setup(repo => repo.GetById(Pump.Id)).Throws(_exception);
        }
    }
}
