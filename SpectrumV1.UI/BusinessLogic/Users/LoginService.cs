using Microsoft.AspNet.Identity;
using SpectrumV1.DataLayers.Users;
using SpectrumV1.Models.Users;
using SpectrumV1.Utilities.Common;
using System.Threading.Tasks;

namespace SpectrumV1.BusinessLogic.Users
{
	/// <summary>
	/// Service responsible for user authentication logic.
	/// Accepts a username or email and a plain text password, validates credentials, and returns the user.
	/// Pattern: Service depends on repository interface (IUserRepository) and contains business rules / validation.
	/// Other services can follow this template: inject repository, expose async methods, keep UI concerns outside.
	/// </summary>
	public class LoginService : ILoginService
	{
		private readonly IUserRepository _userRepository;
		private readonly PasswordHasher _passwordHasher = new PasswordHasher();

		public LoginService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		/// <summary>
		/// Attempts login using username or email plus a plain text password.
		/// Returns authenticated user or null.
		/// </summary>
		public async Task<UserModel> AuthenticateAsync(string usernameOrEmail, string plainTextPassword)
		{
			if (string.IsNullOrWhiteSpace(usernameOrEmail) || string.IsNullOrWhiteSpace(plainTextPassword))
				return null;

			// Try email first then username
			var user = await _userRepository.GetUserByEmailAsync(usernameOrEmail) ??
					   await _userRepository.GetUserByNameAsync(usernameOrEmail);

			if (user == null || string.IsNullOrWhiteSpace(user.PasswordHash))
				return null;

			var result = _passwordHasher.VerifyHashedPassword(user.PasswordHash, plainTextPassword);
			if (result == PasswordVerificationResult.Success)
				return user;

			if (result == PasswordVerificationResult.SuccessRehashNeeded)
			{
				// Rehash and persist (optional improvement for future algorithm upgrades)
				var newHash = _passwordHasher.HashPassword(plainTextPassword);
				user.PasswordHash = newHash;
				await _userRepository.UpdateUserAsync(user);
				return user;
			}

			return null;
		}

		/// <summary>
		/// Helper to hash a password for new user creation.
		/// </summary>
		public string HashPassword(string password)
		{
			return string.IsNullOrWhiteSpace(password) ? null : _passwordHasher.HashPassword(password.Trim());
		}
	}

	public interface ILoginService
	{
		Task<UserModel> AuthenticateAsync(string usernameOrEmail, string plainTextPassword);
		string HashPassword(string password);
	}
}
