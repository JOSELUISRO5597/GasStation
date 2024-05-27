using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Application.Pumps.Query.GetAllPumps
{
    public class WhenGetAllPumpsQueryReturnsException : TestForGetAllPumpsQuery
    {
        private Exception _exception => new Exception("Error message");

        [Fact]
        public async Task TestForGetAllPumpsQueryReturnsExpception()
        {
            ConfigureTest();

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
