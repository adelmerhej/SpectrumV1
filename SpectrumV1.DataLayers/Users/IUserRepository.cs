using SpectrumV1.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpectrumV1.DataLayers.Users
{
	public interface IUserRepository
	{
		Task<List<UserModel>> GetUsersAsync();
		Task<UserModel> GetUserByIdAsync(string id);
		Task<UserModel> GetUserByEmailAsync(string email);
		Task<string> AddNewUserAsync(UserModel user);
		Task<bool> UpdateUserAsync(UserModel user);
		Task<bool> DeleteUserAsync(string id);
		Task<UserModel> AuthenticateUserAsync(string email, string hashedPassword);

		// A custom query example
		Task<UserModel> GetUserByNameAsync(string userName);
	}
}
