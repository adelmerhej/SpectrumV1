using SpectrumV1.Models.Common.Companies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpectrumV1.DataLayers.Common.Companies
{
	public class CompanyRepository : ICompanyRepository, IDisposable
	{
		// Legacy synchronous methods (kept for existing callers)
		public IList<CompanyModel> SelectCompanies()
		{
			throw new NotImplementedException();
		}

		public IList<CompanyModel> SelectCompaniesByName(string name)
		{
			throw new NotImplementedException();
		}

		public CompanyModel SelectCompanyById(string id)
		{
			throw new NotImplementedException();
		}
		public string AddNewCompany(CompanyModel company)
		{
			throw new NotImplementedException();
		}

		public bool UpdateCompany(CompanyModel company)
		{
			throw new NotImplementedException();
		}

		public bool DeleteCompany(string id)
		{
			throw new NotImplementedException();
		}

		// Interface async implementations (wrapping legacy sync methods)
		public Task<List<CompanyModel>> GetcompaniesAsync()
		{
			var list = SelectCompanies();
			return Task.FromResult(list == null ? new List<CompanyModel>() : new List<CompanyModel>(list));
		}

		public Task<CompanyModel> GetCompanyByIdAsync(string id)
		{
			return Task.FromResult(SelectCompanyById(id));
		}

		public Task<string> AddNewCompanyAsync(CompanyModel company)
		{
			return Task.FromResult(AddNewCompany(company));
		}

		public Task<bool> UpdateCompanyAsync(CompanyModel company)
		{
			return Task.FromResult(UpdateCompany(company));
		}

		public Task<bool> DeleteCompanyAsync(string id)
		{
			return Task.FromResult(DeleteCompany(id));
		}

		public Task<CompanyModel> GetCompanyByName(string name)
		{
			var list = SelectCompaniesByName(name);
			CompanyModel company = null;
			if (list != null)
			{
				foreach (var c in list)
				{
					company = c; // choose first; break optionally
					break;
				}
			}
			return Task.FromResult(company);
		}

		#region Implementation of IDisposable

		public void Dispose()
		{

		}

		#endregion
	}
}
