
using Application.PumpHistory.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GasStation.Controllers
{
    public class PumpHistoryController : Controller
    {
        private readonly IMediator _mediator;

        public PumpHistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> RecordTransaction(Guid pumpId, decimal amount)
        {
            try
            {
                await _mediator.Send(new RecordTransactionCommand { PumpId = pumpId, Amount = amount });
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
