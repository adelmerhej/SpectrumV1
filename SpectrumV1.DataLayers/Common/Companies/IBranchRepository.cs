using SpectrumV1.Models.Common.Companies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpectrumV1.DataLayers.Common.Branches
{
	public interface IBranchRepository
	{
		// CRUD Operations
		Task<List<BranchModel>> GetBranchesAsync();
		Task<BranchModel> GetBranchByIdAsync(string id);
		Task<string> AddNewBranchAsync(BranchModel branch);
		Task<bool> UpdateBranchAsync(BranchModel branch);
		Task<bool> DeleteBranchAsync(string id);

		// A custom query example
		Task<BranchModel> GetBranchByName(string name);
		Task<long> GetCountAsync();
	}
}
