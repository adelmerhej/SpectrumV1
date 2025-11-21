using System.Configuration;
using System.Data;
using System.Threading.Tasks;

namespace SpectrumV1.DataLayers.DataAccess
{
	public interface IDatabase
	{
		bool AllowCreateDataBase();
		ConnectionState CheckConnection();
		bool CheckDatabaseExists(string connectionString, string databaseName);
		Task CreateDatabase(string connectionString, string databaseName);
		Configuration DatabaseConfiguration();
	}
}
