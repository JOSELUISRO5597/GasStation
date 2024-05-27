using Domain.Entities;
using System;

namespace UnitTest.Application
{
    public abstract class BaseUnitTest
    {
        protected virtual Pump GetMockedPump(Guid pumpId, int number = 0, bool status = false, decimal currentPrice = 0)
        {
            return new Pump(pumpId, number, status, currentPrice);
        }
    }
}
