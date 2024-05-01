using Application.PumpHistory.Models;
using Application.PumpHistory.Query;
using GasStation.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GasStation.Controllers
{
    public class RankingController : Controller
    {
        private readonly IMediator _mediator;

        public RankingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _mediator.Send(new GetPumpHistoryQuery());

                return View(new RankingViewModel(result));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
                return View(new RankingViewModel(new List<PumpHistoryViewModel>()));
            }
        }
    }
}
