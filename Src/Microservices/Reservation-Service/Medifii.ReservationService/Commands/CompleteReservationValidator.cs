using FluentValidation;

namespace Medifii.ReservationService.Commands
{
	public class CompleteReservationValidator : AbstractValidator<CompleteReservationCommand>
	{
		public CompleteReservationValidator()
		{
			RuleFor(r => r.Id).NotEmpty();
		}
	}
}
