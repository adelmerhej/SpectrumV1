using SpectrumV1.DataLayers.Properties;

namespace SpectrumV1.DataLayers.DataUtilities
{
	/// <summary>
	/// Public wrapper around internal auto-generated Settings class to allow other assemblies (UI) to access DB parameters.
	/// </summary>
	public static class DatabaseSettings
	{
		private static Settings S => Settings.Default;

		public static string DatabaseHost { get => S.DatabaseHost; set => S.DatabaseHost = value; }
		public static int DatabasePort { get => S.DatabasePort; set => S.DatabasePort = value; }
		public static string DatabaseName { get => S.DatabaseName; set => S.DatabaseName = value; }
		public static string DatabaseUser { get => S.DatabaseUser; set => S.DatabaseUser = value; }
		public static string DatabasePassword { get => S.DatabasePassword; set => S.DatabasePassword = value; }
		public static string MongoDbConfigString { get => S.MongoDbConfigString; set => S.MongoDbConfigString = value; }
		public static string DatabaseType { get => S.DatabaseType; set => S.DatabaseType = value; }

		public static void Save() => S.Save();
	}
}
