using MediatR;
using Medifii.Common.DataAccess;
using Medifii.ReservationService.Api.Context;
using Medifii.ReservationService.Commands;
using Medifii.ReservationService.Dtos;
using Medifii.ReservationService.Entities;
using Medifii.ReservationService.Enums;
using Medifii.ReservationService.Mappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Medifii.ReservationService.Api.Commands
{
	public class CreateReservationHandler : IRequestHandler<CreateReservationCommand, ReservationDto>
	{
		private readonly IUnitOfWork<ReservationsContext> _unitOfWork;

		public CreateReservationHandler(IUnitOfWork<ReservationsContext> unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ReservationDto> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
		{
			var reservationsRepository = _unitOfWork.Repository<Reservation>();

			var reservation = await reservationsRepository.AddAsync(new Reservation()
			{
				UserId = Guid.NewGuid(),
				ProductId = request.ProductId,
				PharmacyId = request.PharmacyId,
				Quantity = request.Quantity,
				PickupTime = request.PickupTime,
				Status = StatusType.WaitingForPickup
			});

			await _unitOfWork.SaveChangesAsync();

			return reservation.ToDto();
		}
	}
}
