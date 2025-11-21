using System.Configuration;
using System.Data;

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

		public abstract bool CheckDatabaseExists(string databaseName);

		public virtual void CreateDatabase(string databaseName)
		{

		}

		public abstract Configuration DatabaseConfiguration();

		#endregion
	}
}
