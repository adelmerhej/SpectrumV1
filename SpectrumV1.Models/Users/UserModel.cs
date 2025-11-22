using System;
using System.Collections.Generic;

namespace SpectrumV1.Models.Users
{
	/// <summary>
	/// Represents a user document in the MongoDB 'Users' collection.
	/// This structure is compatible with custom authentication or a simple ASP.NET Core Identity setup.
	/// </summary>
	public class UserModel : EntityObject
	{
		public string Username { get; set; } // Required for login

		public string Email { get; set; }

		public string PasswordHash { get; set; } // Stores the securely hashed password

		public string SecurityStamp { get; set; } = Guid.NewGuid().ToString();

		public List<string> Roles { get; set; } = new List<string>();

		public bool IsLockedOut { get; set; } = false;
		public bool ChangePasswordNextLogon { get; set; } = true;
		public bool FirstTimeAccess { get; set; } = true;

	}
}
