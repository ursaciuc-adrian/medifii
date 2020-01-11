using MediatR;
using Medifii.Common.DataAccess;
using Medifii.ReservationService.Api.Context;
using Medifii.ReservationService.Entities;
using Medifii.ReservationService.Enums;
using System.Threading;
using System.Threading.Tasks;
using Medifii.ReservationService.Commands.CancelReservation;

namespace Medifii.ReservationService.Api.Commands
{
	public class CancelReservationHandler : IRequestHandler<CancelReservationCommand>
	{
		private readonly IUnitOfWork<ReservationsContext> _unitOfWork;

		public CancelReservationHandler(IUnitOfWork<ReservationsContext> unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(CancelReservationCommand request, CancellationToken cancellationToken)
		{
			var reservationsRepository = _unitOfWork.Repository<Reservation>();

			var reservation = await reservationsRepository.GetByIdAsync(request.Id);

			if(reservation != null)
			{
				reservation.Status = StatusType.Canceled;
				await reservationsRepository.UpdateAsync(reservation);

				await _unitOfWork.SaveChangesAsync();
			}

			return Unit.Value;
		}
	}
}
