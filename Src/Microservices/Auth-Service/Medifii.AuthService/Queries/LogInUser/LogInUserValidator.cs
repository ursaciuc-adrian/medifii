using FluentValidation;

namespace Medifii.AuthService.Queries.LogInUser
{
	public class LogInUserValidator : AbstractValidator<LogInUserQuery>
	{
		public LogInUserValidator()
		{
			RuleFor(x => x.Email)
				.NotEmpty()
				.EmailAddress();
			RuleFor(x => x.Password).NotEmpty();
		}
	}
}
