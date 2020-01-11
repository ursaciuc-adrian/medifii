using System.Threading.Tasks;

namespace Medifii.AuthService.Services
{
	public interface IUserService<T> where T : class
	{
		Task<string> AuthenticateAsync(string email, string password);

		Task<T> CreateAsync(T user, string password);

		Task SignOutAsync();
	}
}
