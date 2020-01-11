using FluentValidation;

namespace Medifii.ReservationService.Queries.GetReservations
{
	public class GetReservationsForPharmacyValidator : AbstractValidator<GetReservationsForPharmacyQuery>
	{
		public GetReservationsForPharmacyValidator()
		{
			RuleFor(r => r.PharmacyId).NotEmpty();
		}
	}
}
