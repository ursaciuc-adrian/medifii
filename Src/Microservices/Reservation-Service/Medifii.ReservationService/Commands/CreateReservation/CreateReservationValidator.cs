using FluentValidation;

namespace Medifii.ReservationService.Commands.CreateReservation
{
	public class CreateReservationValidator : AbstractValidator<CreateReservationCommand>
	{
		public CreateReservationValidator()
		{
			RuleFor(r => r.ProductId).NotEmpty();
			RuleFor(r => r.PharmacyId).NotEmpty();
			RuleFor(r => r.Quantity).NotEmpty();
			RuleFor(r => r.PickupTime).NotEmpty();
		}
	}
}
