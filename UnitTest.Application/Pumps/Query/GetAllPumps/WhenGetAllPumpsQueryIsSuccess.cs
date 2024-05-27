
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Application.Pumps.Query.GetAllPumps
{
    public class WhenGetAllPumpsQueryIsSuccess: TestForGetAllPumpsQuery
    {
        [Fact]
        public async Task TestForGetAllPumpsQueryIsSucess()
        {
            ConfigureTest();

            var result = await QueryHandler.Handle(Query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(4, result.Count());
            Assert.Equal(PumpRepositoryMock.Object.GetAll(), result);
        }
    }
}
