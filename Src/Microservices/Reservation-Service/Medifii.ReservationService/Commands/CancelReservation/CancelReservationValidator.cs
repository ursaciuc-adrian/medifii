using FluentValidation;

namespace Medifii.ReservationService.Commands.CancelReservation
{
	public class CancelReservationValidator : AbstractValidator<CancelReservationCommand>
	{
		public CancelReservationValidator()
		{
			RuleFor(r => r.Id).NotEmpty();
		}
	}
}
