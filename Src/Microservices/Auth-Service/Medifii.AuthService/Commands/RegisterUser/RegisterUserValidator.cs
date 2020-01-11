using FluentValidation;

namespace Medifii.AuthService.Commands.RegisterUser
{
	public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
	{
		public RegisterUserValidator()
		{
			RuleFor(x => x.PharmacyId).NotEmpty();
			RuleFor(x => x.FirstName).NotEmpty();
			RuleFor(x => x.LastName).NotEmpty();
			RuleFor(x => x.Email)
				.NotEmpty()
				.EmailAddress();
			RuleFor(x => x.Password).NotEmpty();
			RuleFor(x => x.ConfirmPassword)
				.NotEmpty()
				.Equal(x => x.Password);
		}
	}
}
