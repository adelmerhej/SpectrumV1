
namespace SpectrumV1.Models.Users
{
	public static class CurrentUser
	{
		public static string Access_Token { get; set; }
		public static string HostName { get; set; }
		public static string DatabaseName { get; set; }

		public static int UserId { get; set; }
		public static string UserName { get; set; }

		public static int CompanyId { get; set; }
		public static string CompanyName { get; set; }

		public static int? BranchId { get; set; }
		public static string BranchName { get; set; }
		public static int WorkingYear { get; set; }
	}
}
