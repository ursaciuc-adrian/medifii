using System;
using MediatR;
using Medifii.ReservationService.Dtos;

namespace Medifii.ReservationService.Commands.CreateReservation
{
	public class CreateReservationCommand : IRequest<ReservationDto>
	{
		public Guid ProductId { get; set; }
		public Guid PharmacyId { get; set; }
		public decimal Quantity { get; set; }
		public DateTime PickupTime { get; set; }
	}
}
