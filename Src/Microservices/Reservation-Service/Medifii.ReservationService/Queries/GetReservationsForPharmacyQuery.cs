using MediatR;
using Medifii.ReservationService.Dtos;
using System;
using System.Collections.Generic;

namespace Medifii.ReservationService.Queries
{
	public class GetReservationsForPharmacyQuery : IRequest<IEnumerable<ReservationDto>>
	{
		public Guid PharmacyId { get; set; }
	}
}
