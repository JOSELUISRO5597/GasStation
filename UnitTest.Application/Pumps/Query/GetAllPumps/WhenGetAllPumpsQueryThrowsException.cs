using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Application.Pumps.Query.GetAllPumps
{
    public class WhenGetAllPumpsQueryThrowsException : TestForGetAllPumpsQuery
    {
        private Exception _exception => new Exception("Error message");

        [Fact]
        public async Task TestForGetAllPumpsQueryReturnsExpception()
        {
            var result = await QueryHandler.Handle(Query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        protected override void MoqRepositoryServices()
        {
            PumpRepositoryMock.Setup(repo => repo.GetAll()).Throws(_exception);
        }
    }
}
