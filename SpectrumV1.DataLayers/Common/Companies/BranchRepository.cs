using MongoDB.Bson;
using MongoDB.Driver;
using SpectrumV1.DataLayers.DataAccess.Types;
using SpectrumV1.Models.Common.Companies;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpectrumV1.DataLayers.Common.Branches
{
	public class BranchRepository : IBranchRepository, IDisposable
	{
		private readonly IMongoCollection<BranchModel> _branches;
		private const string CollectionName = "Branches";

		// Constructor for dependency injection
		public BranchRepository()
		{
			var connectionString = MongoDbDatabaseModel.BuildConnectionString();
			var url = new MongoUrl(connectionString);
			// Use database specified in connection string; fall back to "admin" then CollectionName
			var databaseName = string.IsNullOrWhiteSpace(url.DatabaseName) ? "admin" : url.DatabaseName.Trim();

			var client = new MongoClient(url); // reuse parsed settings
			var database = client.GetDatabase(databaseName);
			_branches = database.GetCollection<BranchModel>(CollectionName);
		}

		// Interface async implementations (wrapping legacy sync methods)
		public async Task<List<BranchModel>> GetBranchesAsync()
		{
			return await _branches.Find(branch => true).ToListAsync();
		}

		public async Task<BranchModel> GetBranchByIdAsync(string id)
		{
			var filter = Builders<BranchModel>.Filter.Eq(u => u._id, id);
			return await _branches.Find(filter).FirstOrDefaultAsync();
		}

		public async Task<BranchModel> GetBranchByName(string branchName)
		{
			if (string.IsNullOrWhiteSpace(branchName)) return null;
			var pattern = "^" + Regex.Escape(branchName.Trim()) + "$"; // exact match
			var filter = Builders<BranchModel>.Filter.Regex(u => u.BranchName, new BsonRegularExpression(pattern, "i"));
			return await _branches.Find(filter).FirstOrDefaultAsync();
		}

		/// <summary>
		/// Adds a new branch to the database.
		/// </summary>
		/// <returns>The newly generated Id of the branch.</returns>
		public async Task<string> AddNewBranchAsync(BranchModel branch)
		{
			try
			{
				branch.CreatedAt = DateTime.UtcNow;
				await _branches.InsertOneAsync(branch);
				return branch._id;
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Updates an existing branch document.
		/// </summary>
		public async Task<bool> UpdateBranchAsync(BranchModel branch)
		{
			try
			{
				var result = await _branches.ReplaceOneAsync(u => u._id == branch._id, branch);
				return result.IsAcknowledged && result.ModifiedCount > 0;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<bool> DeleteBranchAsync(string id)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Check if there's records for branch document.
		/// </summary>
		public async Task<long> GetCountAsync()
		{
			return await _branches.CountDocumentsAsync(new BsonDocument());
		}


		#region Implementation of IDisposable
		public void Dispose()
		{
		}
		#endregion
	}
}
