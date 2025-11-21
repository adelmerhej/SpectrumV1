namespace SpectrumV1.Models.Administration.Connections
{
	public class ConnectionModel
	{
		public string DatabaseType { get; set; }
		public string DatabaseHost { get; set; }
		public int DatabasePort { get; set; }
		public string DatabaseName { get; set; }
		public string DatabaseUser { get; set; }
		public string DatabasePassword { get; set; }

		public string DatabaseConnectionString { get; set; }
	}
}
