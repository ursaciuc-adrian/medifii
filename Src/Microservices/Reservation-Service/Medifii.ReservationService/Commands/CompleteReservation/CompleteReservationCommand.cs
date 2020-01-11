using System;
using MediatR;

namespace Medifii.ReservationService.Commands.CompleteReservation
{
	public class CompleteReservationCommand : IRequest
	{
		public Guid Id { get; set; }
	}
}
