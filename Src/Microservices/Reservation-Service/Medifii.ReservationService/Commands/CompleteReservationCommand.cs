using MediatR;
using System;

namespace Medifii.ReservationService.Commands
{
	public class CompleteReservationCommand : IRequest
	{
		public Guid Id { get; set; }
	}
}
