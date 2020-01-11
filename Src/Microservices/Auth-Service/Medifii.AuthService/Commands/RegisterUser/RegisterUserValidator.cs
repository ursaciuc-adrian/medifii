using FluentValidation;

namespace Medifii.AuthService.Commands.RegisterUser
{
	public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
	{
		public RegisterUserValidator()
		{

		}
	}
}
