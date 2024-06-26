﻿using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Application.Pumps.Query.GetAllPumps
{
    public class WhenGetAllPumpsQueryReturnsEmpty : TestForGetAllPumpsQuery
    {
        [Fact]
        public async Task TestForGetAllPumpsQueryReturnsEmpty()
        {
            var result = await QueryHandler.Handle(Query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.Equal(PumpRepositoryMock.Object.GetAll(), result);
        }

        protected override List<Pump> GetAllMockedPumps()
        {
            return new List<Pump>();
        }
    }
}
