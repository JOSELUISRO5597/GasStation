using Domain.Entities;
using System.Collections.Generic;

namespace GasStation.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<Pump> Pumps;

        public IndexViewModel(IEnumerable<Pump> _pumps)
        {
            Pumps = _pumps;
        }
    }
}
