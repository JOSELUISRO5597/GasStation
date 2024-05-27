using Application.Pump.Commands;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Application.Pumps.Commands.SetPumpStatus
{
    public class WhenSetPumpStatusThrowsException: TestForSetPumpStatusCommand
    {
        private Exception _exception = new Exception("Error message");

        [Fact]
        public async Task TestForSetPumpPriceCommandThrowsException()
        {
            var newStatus = true;

            var command = new SetPumpStatusCommand
            {
                PumpId = Pump.Id,
                Status = newStatus
            };

            var result = await CommandHandler.Handle(command, CancellationToken.None);

            Assert.False(result);
            Assert.NotEqual(newStatus, Pump.IsLocked);
            PumpRepositoryMock.Verify(repo => repo.Update(It.Is<Pump>(p => p.Id == Pump.Id && p.IsLocked == newStatus)), Times.Never);
        }

        protected override void MoqRepositoryServices()
        {
            PumpRepositoryMock.Setup(repo => repo.GetById(Pump.Id)).Throws(_exception);
        }
    }
}
