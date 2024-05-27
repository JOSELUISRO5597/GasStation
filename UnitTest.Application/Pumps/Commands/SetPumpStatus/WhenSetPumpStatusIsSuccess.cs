using Application.Pump.Commands;
using Domain.Entities;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Application.Pumps.Commands.SetPumpStatus
{
    public class WhenSetPumpStatusIsSuccess: TestForSetPumpStatusCommand
    {
        [Fact]
        public async Task TestForSetPumpStatusCommandIsSuccess()
        {
            var newStatus = true;

            var command = new SetPumpStatusCommand
            {
                PumpId = Pump.Id,
                Status = newStatus
            };

            var result = await CommandHandler.Handle(command, CancellationToken.None);

            Assert.True(result);
            Assert.True(Pump.IsLocked);
            PumpRepositoryMock.Verify(repo => repo.Update(It.Is<Pump>(p => p.Id == Pump.Id && p.IsLocked == newStatus)), Times.Once);
        }
    }
}
