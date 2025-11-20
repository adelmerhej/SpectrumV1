using SpectrumV1.Models;
using SpectrumV1.Models.Users;

namespace SpectrumV1.Utilities
{
	internal class LogInfoRepository
	{
		#region Update user activity log
		public void CreateLogInfo<T>(T obj) where T : EntityObject
		{
			obj.CreatedBy = CurrentUser.UserId;
			obj.CompanyId = CurrentUser.CompanyId;
			if (CurrentUser.BranchId != null) obj.BranchId = (int)CurrentUser.BranchId;
		}

		public void UpdateLogInfo<T>(T obj) where T : EntityObject
		{
			obj.LastModifiedBy = CurrentUser.UserId;
			obj.CompanyId = CurrentUser.CompanyId;
			if (CurrentUser.BranchId != null) obj.BranchId = (int)CurrentUser.BranchId;
		}

		#endregion
	}
}
