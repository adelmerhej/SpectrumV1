using SpectrumV1.Models.Common.Companies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpectrumV1.DataLayers.Common.Branches; // interface namespace

namespace SpectrumV1.DataLayers.Common.Branches
{
	public class BranchRepository : IBranchRepository, IDisposable
	{
		// Legacy sync stubs
		public IList<BranchModel> SelectBranches()
		{
			throw new NotImplementedException();
		}

		public BranchModel SelectBranchById(string id)
		{
			throw new NotImplementedException();
		}

		public IList<BranchModel> SelectBranchesByName(string name)
		{
			throw new NotImplementedException();
		}

		public string AddNewBranch(BranchModel branch)
		{
			throw new NotImplementedException();
		}

		public bool UpdateBranch(BranchModel branch)
		{
			throw new NotImplementedException();
		}

		public bool DeleteBranch(string id)
		{
			throw new NotImplementedException();
		}

		// Async interface wrappers
		public Task<List<BranchModel>> GetBranchesAsync()
		{
			var list = SelectBranches();
			return Task.FromResult(list == null ? new List<BranchModel>() : new List<BranchModel>(list));
		}

		public Task<BranchModel> GetBranchByIdAsync(string id)
		{
			return Task.FromResult(SelectBranchById(id));
		}

		public Task<string> AddNewBranchAsync(BranchModel branch)
		{
			return Task.FromResult(AddNewBranch(branch));
		}

		public Task<bool> UpdateBranchAsync(BranchModel branch)
		{
			return Task.FromResult(UpdateBranch(branch));
		}

		public Task<bool> DeleteBranchAsync(string id)
		{
			return Task.FromResult(DeleteBranch(id));
		}

		public Task<BranchModel> GetBranchByName(string name)
		{
			var list = SelectBranchesByName(name);
			BranchModel branch = null;
			if (list != null)
			{
				foreach (var b in list)
				{
					branch = b;
					break;
				}
			}
			return Task.FromResult(branch);
		}

		#region Implementation of IDisposable
		public void Dispose()
		{
		}
		#endregion
	}
}
