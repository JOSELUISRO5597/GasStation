using Application.PumpHistory.Models;
using System.Collections.Generic;

namespace GasStation.ViewModel
{
    public class RankingViewModel
    {
        public IEnumerable<PumpHistoryViewModel> PumpHistory;

        public RankingViewModel(IEnumerable<PumpHistoryViewModel> pumpHistory)
        {
            PumpHistory = pumpHistory;
        }
    }
}
