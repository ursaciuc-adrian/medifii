using MediatR;
using System;

namespace Medifii.ReservationService.Commands
{
	public class CancelReservationCommand : IRequest
	{
		public Guid Id { get; set; }
	}
}
