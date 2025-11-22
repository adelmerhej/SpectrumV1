using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using SpectrumV1.DataLayers.DataAccess.Types;
using SpectrumV1.Models.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson; // for regex
using System.Text.RegularExpressions; // for case-insensitive matching

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
			var url = new MongoUrl(connectionString);
			// Use database specified in connection string; fall back to "admin" then CollectionName
			var databaseName = string.IsNullOrWhiteSpace(url.DatabaseName) ? "admin" : url.DatabaseName.Trim();

			var client = new MongoClient(url); // reuse parsed settings
			var database = client.GetDatabase(databaseName);
			_users = database.GetCollection<UserModel>(CollectionName);
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
		/// Retrieves a user by their Username (case-insensitive, trimmed).
		/// </summary>
		public async Task<UserModel> GetUserByNameAsync(string userName)
		{
			if (string.IsNullOrWhiteSpace(userName)) return null;
			var pattern = "^" + Regex.Escape(userName.Trim()) + "$"; // exact match
			var filter = Builders<UserModel>.Filter.Regex(u => u.Username, new BsonRegularExpression(pattern, "i"));
			return await _users.Find(filter).FirstOrDefaultAsync();
		}

		/// <summary>
		/// Retrieves a user by their email (case-insensitive, trimmed).
		/// </summary>
		public async Task<UserModel> GetUserByEmailAsync(string email)
		{
			if (string.IsNullOrWhiteSpace(email)) return null;
			var pattern = "^" + Regex.Escape(email.Trim()) + "$";
			var filter = Builders<UserModel>.Filter.Regex(u => u.Email, new BsonRegularExpression(pattern, "i"));
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
				user.CreatedAt = DateTime.UtcNow;
				user.SecurityStamp = Guid.NewGuid().ToString();
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
				var result = await _users.ReplaceOneAsync(u => u._id == user._id, user);
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
		public async Task<UserModel> AuthenticateUserAsync(string email, string hashedPassword)
		{
			var user = await GetUserByEmailAsync(email);
			if (user == null) return null;
			return user.PasswordHash == hashedPassword ? user : null;
		}

		#region Implementation of IDisposable
		public void Dispose()
		{
		}
		#endregion
	}
}
