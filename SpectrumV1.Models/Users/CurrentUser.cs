namespace SpectrumV1.Models.Users
{
	public static class CurrentUser
	{
		public static string Access_Token { get; set; }
		public static string HostName { get; set; }
		public static string DatabaseName { get; set; }
		public static string UserName { get; set; }
		public static string Company { get; set; }
		public static string Branch { get; set; }
		public static int WorkingYear { get; set; }
		public static string CompanyName { get; set; } // Added CompanyName to match usage in LoginForm
	}
}
