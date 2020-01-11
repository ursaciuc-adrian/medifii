using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Medifii.ReservationService.Commands.CancelReservation;
using Medifii.ReservationService.Commands.CompleteReservation;
using Medifii.ReservationService.Commands.CreateReservation;
using Medifii.ReservationService.Queries.GetReservations;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Medifii.ReservationService.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ReservationsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ReservationsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("{pharmacyId}")]
		public async Task<IActionResult> Get([FromRoute] GetReservationsForPharmacyQuery query)
		{
			var result = await _mediator.Send(query);

			return new JsonResult(result);
		}

		[HttpPost]
		[Route("create")]
		public async Task<IActionResult> Create([FromBody] CreateReservationCommand command)
		{
			var result = await _mediator.Send(command);

			return new JsonResult(result);
		}

		[HttpPost]
		[Route("cancel/{Id}")]
		public async Task<IActionResult> Cancel([FromRoute] CancelReservationCommand command)
		{
			var result = await _mediator.Send(command);

			return new JsonResult(result);
		}

		[HttpPost]
		[Route("complete/{Id}")]
		public async Task<IActionResult> Complete([FromRoute] CompleteReservationCommand command)
		{
			var result = await _mediator.Send(command);

			return new JsonResult(result);
		}
	}
}
