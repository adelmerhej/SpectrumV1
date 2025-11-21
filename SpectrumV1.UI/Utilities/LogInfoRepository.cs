using SpectrumV1.Models;
using SpectrumV1.Models.Users;

namespace SpectrumV1.Utilities
{
	internal class LogInfoRepository
	{
		#region Update user activity log
		public void CreateLogInfo<T>(T obj) where T : EntityObject
		{
			obj.CreatedBy = CurrentUser.UserName;
			obj.Company = CurrentUser.Company;
			obj.Branch = CurrentUser.Branch;
		}

		public void UpdateLogInfo<T>(T obj) where T : EntityObject
		{
			obj.LastModifiedBy = CurrentUser.UserName;
			obj.Company = CurrentUser.Company;
			obj.Branch = CurrentUser.Branch;
		}

		#endregion
	}
}
