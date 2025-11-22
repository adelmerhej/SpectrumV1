using Microsoft.AspNet.Identity;
using MongoDB.Bson;
using MongoDB.Driver;
using SpectrumV1.DataLayers.DataAccess.Types;
using SpectrumV1.Models.Common.Companies;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpectrumV1.DataLayers.Common.Companies
{
	public class CompanyRepository : ICompanyRepository, IDisposable
	{
		private readonly IMongoCollection<CompanyModel> _companies;
		private const string CollectionName = "Companies";

		// Constructor for dependency injection
		public CompanyRepository()
		{
			var connectionString = MongoDbDatabaseModel.BuildConnectionString();
			var url = new MongoUrl(connectionString);
			// Use database specified in connection string; fall back to "admin" then CollectionName
			var databaseName = string.IsNullOrWhiteSpace(url.DatabaseName) ? "admin" : url.DatabaseName.Trim();

			var client = new MongoClient(url); // reuse parsed settings
			var database = client.GetDatabase(databaseName);
			_companies = database.GetCollection<CompanyModel>(CollectionName);
		}

		// Interface async implementations (wrapping legacy sync methods)
		public async Task<List<CompanyModel>> GetCompaniesAsync()
		{
			return await _companies.Find(company => true).ToListAsync();
		}

		public async Task<CompanyModel> GetCompanyByIdAsync(string id)
		{
			var filter = Builders<CompanyModel>.Filter.Eq(u => u._id, id);
			return await _companies.Find(filter).FirstOrDefaultAsync();
		}

		public async Task<CompanyModel> GetCompanyByName(string companyName)
		{
			if (string.IsNullOrWhiteSpace(companyName)) return null;
			var pattern = "^" + Regex.Escape(companyName.Trim()) + "$"; // exact match
			var filter = Builders<CompanyModel>.Filter.Regex(u => u.CompanyName, new BsonRegularExpression(pattern, "i"));
			return await _companies.Find(filter).FirstOrDefaultAsync();
		}

		/// <summary>
		/// Adds a new company to the database.
		/// </summary>
		/// <returns>The newly generated Id of the company.</returns>
		public async Task<string> AddNewCompanyAsync(CompanyModel company)
		{
			try
			{
				company.CreatedAt = DateTime.UtcNow;
				await _companies.InsertOneAsync(company);
				return company._id;
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Updates an existing company document.
		/// </summary>
		public async Task<bool> UpdateCompanyAsync(CompanyModel company)
		{
			try
			{
				var result = await _companies.ReplaceOneAsync(u => u._id == company._id, company);
				return result.IsAcknowledged && result.ModifiedCount > 0;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<bool> DeleteCompanyAsync(string id)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Check if there's records for company document.
		/// </summary>
		public async Task<long> GetCountAsync()
		{
			return await _companies.CountDocumentsAsync(new BsonDocument());
		}


		#region Implementation of IDisposable

		public void Dispose()
		{

		}

		#endregion
	}
}
