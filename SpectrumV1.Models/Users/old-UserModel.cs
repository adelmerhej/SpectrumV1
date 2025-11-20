using System;
using System.Collections.Generic;

namespace SpectrumV1.Models.Users
{
	public class oldUserModel : EntityObject, ICloneable
	{
		public string UserName { get; set; }
		public string PasswordHash { get; set; }
		public string SecurityStamp { get; set; }
		public string Email { get; set; }
		public bool EmailConfirmed { get; set; }
		public string MobileNumber { get; set; }
		public bool MobileNumberConfirmed { get; set; }
		public bool TwoFactorEnabled { get; set; }
		public DateTime? LockoutEndDate { get; set; }
		public bool LockoutEnabled { get; set; }
		public int AccessFailedCount { get; set; }
		public bool ChangePasswordNextLogon { get; set; }
		public int SecurityLevel { get; set; }
		public bool FirstTimeAccess { get; set; }
		public bool PermissionChanged { get; set; }

		public virtual IList<UserDetailModel> UsersDetail { get; set; } = new List<UserDetailModel>();


		#region Implementation of ICloneable

		/// <summary>Creates a new object that is a copy of the current instance.</summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone()
		{
			var recordModel = (oldUserModel)MemberwiseClone();
			return recordModel;
		}

		#endregion
	}
}
