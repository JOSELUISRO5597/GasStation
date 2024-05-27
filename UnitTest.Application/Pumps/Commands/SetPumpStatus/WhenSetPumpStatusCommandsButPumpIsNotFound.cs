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
    public class WhenSetPumpStatusCommandsButPumpIsNotFound: TestForSetPumpStatusCommand
    {
        [Fact]
        public async Task TestForSetPumpStatusCommandButPumpIsNotFound()
        {
            var newId = Guid.NewGuid();
            var newStatus = true;

            var command = new SetPumpStatusCommand
            {
                PumpId = newId,
                Status = newStatus
            };

            var result = await CommandHandler.Handle(command, CancellationToken.None);

            Assert.False(result);
            Assert.NotEqual(newStatus, Pump.IsLocked);
            PumpRepositoryMock.Verify(repo => repo.Update(It.Is<Pump>(p => p.Id == Pump.Id && p.IsLocked == newStatus)), Times.Never);
        }
    }
}
