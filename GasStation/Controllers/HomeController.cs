using Application.GasStation.Commands;
using Application.Pump.Query;
using Domain.Entities;
using GasStation.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GasStation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _mediator.Send(new GetAllPumpsQuery());

                if (result == null || (result as List<Domain.Entities.Pump>).Count == 0)
                {
                    result = await _mediator.Send(new GasStationInitializerCommand());
                }

                return View(new IndexViewModel(result));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
                return View(new IndexViewModel(new List<Pump>()));
            }
        }
    }
}
