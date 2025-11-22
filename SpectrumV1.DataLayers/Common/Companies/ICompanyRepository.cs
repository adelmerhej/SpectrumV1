using SpectrumV1.Models.Common.Companies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpectrumV1.DataLayers.Common.Companies
{
	public interface ICompanyRepository
	{
		// CRUD Operations
		Task<List<CompanyModel>> GetcompaniesAsync();
		Task<CompanyModel> GetCompanyByIdAsync(string id);
		Task<string> AddNewCompanyAsync(CompanyModel company);
		Task<bool> UpdateCompanyAsync(CompanyModel company);
		Task<bool> DeleteCompanyAsync(string id);

		// A custom query example
		Task<CompanyModel> GetCompanyByName(string name);
	}
}
