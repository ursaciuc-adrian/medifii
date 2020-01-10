using MediatR;
using Medifii.ReservationService.Dtos;
using System;

namespace Medifii.ReservationService.Commands
{
	public class CreateReservationCommand : IRequest<ReservationDto>
	{
		public Guid ProductId { get; set; }
		public Guid PharmacyId { get; set; }
		public decimal Quantity { get; set; }
		public DateTime PickupTime { get; set; }
	}
}
