using System;
using MediatR;

namespace Medifii.ReservationService.Commands.CancelReservation
{
	public class CancelReservationCommand : IRequest
	{
		public Guid Id { get; set; }
	}
}
