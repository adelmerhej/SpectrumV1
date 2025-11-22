using MongoDB.Driver;
using SpectrumV1.DataLayers.DataAccess.Types;
using SpectrumV1.Models.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpectrumV1.DataLayers.Users
{
	public class UserRepository : IUserRepository, IDisposable
	{
		private readonly IMongoCollection<UserModel> _users;
		private const string CollectionName = "Users";

		// Constructor for dependency injection
		public UserRepository()
		{
			var connectionString = MongoDbDatabaseModel.BuildConnectionString();
			var databaseName = CollectionName;

			var client = new MongoClient(connectionString);
			var database = client.GetDatabase(databaseName);
			_users = database.GetCollection<UserModel>(databaseName);
		}

		/// <summary>
		/// Retrieves all users.
		/// </summary>
		public async Task<List<UserModel>> GetUsersAsync()
		{
			return await _users.Find(user => true).ToListAsync();
		}

		/// <summary>
		/// Retrieves a user by their id.
		/// </summary>
		public async Task<UserModel> GetUserByIdAsync(string id)
		{
			var filter = Builders<UserModel>.Filter.Eq(u => u._id, id);
			return await _users.Find(filter).FirstOrDefaultAsync();
		}

		/// <summary>
		/// Retrieves a user by their userName.
		/// </summary>
		public async Task<UserModel> GetUserByNameAsync(string userName)
		{
			var filter = Builders<UserModel>.Filter.Eq(u => u.Username, userName);
			return await _users.Find(filter).FirstOrDefaultAsync();
		}

		/// <summary>
		/// Retrieves a user by their email.
		/// </summary>
		public async Task<UserModel> GetUserByEmailAsync(string email)
		{
			// Use a case-insensitive match for email lookup
			var filter = Builders<UserModel>.Filter.Eq(u => u.Email, email.ToLower());
			return await _users.Find(filter).FirstOrDefaultAsync();
		}

		/// <summary>
		/// Adds a new user to the database.
		/// </summary>
		/// <returns>The newly generated Id of the user.</returns>
		public async Task<string> AddNewUserAsync(UserModel user)
		{
			try
			{
				// Ensure necessary default fields are set before insert
				user.CreatedAt = System.DateTime.UtcNow;
				user.SecurityStamp = System.Guid.NewGuid().ToString();

				await _users.InsertOneAsync(user);
				return user._id;
			}
			catch (Exception)
			{
				throw;
			}

		}

		/// <summary>
		/// Updates an existing user document.
		/// </summary>
		public async Task<bool> UpdateUserAsync(UserModel user)
		{
			try
			{
				var result = await _users.ReplaceOneAsync(u => u._id == user._id, // Filter by Id
									user // The new document to replace the old one
									);

				return result.IsAcknowledged && result.ModifiedCount > 0;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<bool> DeleteUserAsync(string id)
		{
			throw new NotImplementedException();
		}

		// --- Authentication Logic ---
		/// <summary>
		/// Authenticates a user based on email and a pre-hashed password.
		/// </summary>
		/// <param name="email">The user's email.</param>
		/// <param name="hashedPassword">The already hashed password provided by the caller.</param>
		/// <returns>The authenticated ApplicationUser or null if authentication fails.</returns>
		public async Task<UserModel> AuthenticateUserAsync(string email, string hashedPassword)
		{
			// 1. Find the user by email (case-insensitive)
			var user = await GetUserByEmailAsync(email);

			if (user == null)
			{
				return null; // User not found
			}

			// 2. Check the stored PasswordHash against the provided hashed password
			// IMPORTANT: In a real application, you must use a proper password hashing library 
			// (like BCrypt or Argon2) and use a separate method to VERIFY the password 
			// hash, not a direct string comparison like this.
			if (user.PasswordHash == hashedPassword)
			{
				// Authentication successful
				return user;
			}

			return null; // Password mismatch
		}

		#region Implementation of IDisposable

		public void Dispose()
		{

		}

		#endregion
	}
}
