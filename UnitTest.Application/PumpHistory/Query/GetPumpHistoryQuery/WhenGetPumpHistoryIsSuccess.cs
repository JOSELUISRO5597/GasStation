using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Application.PumpHistory.Query
{
    public class WhenGetPumpHistoryIsSuccess: TestForGetPumpHistoryQuery
    {
        [Fact]
        public async Task TestForGetPumpHistoryQueryIsSucess()
        {
            var result = await QueryHandler.Handle(Query, CancellationToken.None);

            var resultList = result.ToList();
            Assert.Equal(2, resultList.Count);

            Assert.Equal(PumpHistory[1].PumpId, resultList[0].PumpId);
            Assert.Equal(250, resultList[0].Amount);
            Assert.Equal(new DateTime(2024, 5, 4), resultList[0].DateTime);

            Assert.Equal(PumpHistory[0].PumpId, resultList[1].PumpId);
            Assert.Equal(250, resultList[1].Amount);
            Assert.Equal(new DateTime(2024, 5, 3), resultList[1].DateTime);
        }
    }
}
