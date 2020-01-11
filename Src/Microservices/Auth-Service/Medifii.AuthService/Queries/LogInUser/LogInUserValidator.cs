using FluentValidation;

namespace Medifii.AuthService.Queries.LogInUser
{
	public class LogInUserValidator : AbstractValidator<LogInUserQuery>
	{
		public LogInUserValidator()
		{
		}
	}
}
