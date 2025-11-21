using System.Configuration;
using System.Data;
using System.Threading.Tasks;

namespace SpectrumV1.DataLayers.DataAccess
{
	public abstract class AbstractDatabaseModel : IDatabase
	{
		#region Implementation of IDatabase

		public virtual bool AllowCreateDataBase() => true;

		public virtual ConnectionState CheckConnection()
		{
			ConnectionState state = ConnectionState.Closed;
			return state;
		}

		public abstract bool CheckDatabaseExists(string connectionString, string databaseName);

		public virtual async Task CreateDatabase(string connectionString, string databaseName)
		{
			// This method is intentionally left empty in the base class.
			// To avoid CS1998, return a completed task.
			await Task.CompletedTask;
		}

		public abstract Configuration DatabaseConfiguration();

		#endregion
	}
}
