using MediatR;
using Medifii.Common.DataAccess;
using Medifii.ReservationService.Api.Context;
using Medifii.ReservationService.Dtos;
using Medifii.ReservationService.Entities;
using Medifii.ReservationService.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Medifii.ReservationService.Queries.GetReservations;

namespace Medifii.ReservationService.Api.Queries
{
	public class GetReservationsForPharmacyHandler : IRequestHandler<GetReservationsForPharmacyQuery, IEnumerable<ReservationDto>>
	{
		private readonly IUnitOfWork<ReservationsContext> _unitOfWork;

		public GetReservationsForPharmacyHandler(IUnitOfWork<ReservationsContext> unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IEnumerable<ReservationDto>> Handle(GetReservationsForPharmacyQuery request, CancellationToken cancellationToken)
		{
			var reservationsRepository = _unitOfWork.Repository<Reservation>();

			var response = new List<ReservationDto>();
			var reservations = await reservationsRepository.GetWhereAsync(x => x.PharmacyId == request.PharmacyId);

			response.AddRange(reservations.Select(r => r.ToDto()));

			return response;
		}
	}
}
