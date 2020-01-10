using Medifii.ReservationService.Enums;
using System;

namespace Medifii.ReservationService.Dtos
{
	public class ReservationDto
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public Guid ProductId { get; set; }
		public Guid PharmacyId { get; set; }
		
		public decimal Quantity { get; set; }
		public DateTime PickupTime { get; set; }
		public StatusType Status { get; set; }
	}
}
