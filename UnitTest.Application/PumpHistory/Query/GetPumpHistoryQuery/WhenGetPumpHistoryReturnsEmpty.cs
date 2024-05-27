using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Application.PumpHistory.Query
{
    public class WhenGetPumpHistoryReturnsEmpty: TestForGetPumpHistoryQuery
    {
        [Fact]
        public async Task TestForGetPumpHistoryQueryReturnsEmpty()
        {
            var result = await QueryHandler.Handle(Query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        protected override List<Domain.Entities.PumpHistory> GetMockedPumpHistory(Guid pumpId1, Guid pumpId2)
        {
            return new List<Domain.Entities.PumpHistory>();
        }
    }
}
