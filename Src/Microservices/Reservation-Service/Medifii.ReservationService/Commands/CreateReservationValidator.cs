using FluentValidation;

namespace Medifii.ReservationService.Commands
{
	public class CreateReservationValidator : AbstractValidator<CreateReservationCommand>
	{
		public CreateReservationValidator()
		{
			RuleFor(r => r.PharmacyId).NotEmpty();
		}
	}
}
