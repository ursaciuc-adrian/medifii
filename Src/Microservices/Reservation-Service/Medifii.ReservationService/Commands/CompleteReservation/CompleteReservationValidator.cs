using FluentValidation;

namespace Medifii.ReservationService.Commands.CompleteReservation
{
	public class CompleteReservationValidator : AbstractValidator<CompleteReservationCommand>
	{
		public CompleteReservationValidator()
		{
			RuleFor(r => r.Id).NotEmpty();
		}
	}
}
