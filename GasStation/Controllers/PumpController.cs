using Application.Pump.Commands;
using Application.PumpHistory.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GasStation.Controllers
{
    public class PumpController : Controller
    {
        private readonly IMediator _mediator;

        public PumpController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> LockPump(Guid pumpId)
        {
            try
            {
                await _mediator.Send(new SetPumpStatusCommand { PumpId = pumpId, Status = true });

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
                return Json(new { success = false, errorMessage = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UnlockPump(Guid pumpId)
        {
            try
            {
                await _mediator.Send(new SetPumpStatusCommand { PumpId = pumpId , Status = false});

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
                return Json(new { success = false, errorMessage = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> SetPrice(Guid pumpId, decimal price)
        {
            try
            {
                await _mediator.Send(new SetPumpPriceCommand { PumpId = pumpId, Price = price });
                
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
                return Json(new { success = false, errorMessage = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> SpendPrice(Guid pumpId, decimal price)
        {
            try
            {
                await _mediator.Send(new SetPumpPriceCommand { PumpId = pumpId, Price = 0 });
                await _mediator.Send(new RecordTransactionCommand { PumpId = pumpId, Amount = price });

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
                return Json(new { success = false, errorMessage = ex.Message });
            }
        }
    }
}
