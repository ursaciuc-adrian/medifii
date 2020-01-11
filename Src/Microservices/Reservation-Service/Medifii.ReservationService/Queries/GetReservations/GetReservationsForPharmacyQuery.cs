using System;
using System.Collections.Generic;
using MediatR;
using Medifii.ReservationService.Dtos;

namespace Medifii.ReservationService.Queries.GetReservations
{
	public class GetReservationsForPharmacyQuery : IRequest<IEnumerable<ReservationDto>>
	{
		public Guid PharmacyId { get; set; }
	}
}
