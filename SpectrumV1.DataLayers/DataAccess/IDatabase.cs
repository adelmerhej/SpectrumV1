using System.Configuration;
using System.Data;

namespace SpectrumV1.DataLayers.DataAccess
{
	public interface IDatabase
	{
		bool AllowCreateDataBase();
		ConnectionState CheckConnection();
		bool CheckDatabaseExists(string connectionString, string databaseName);
		void CreateDatabase(string connectionString, string databaseName);
		Configuration DatabaseConfiguration();
	}
}
