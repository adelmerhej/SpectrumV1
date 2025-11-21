using SpectrumV1.DataLayers.DataUtilities;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SpectrumV1.DataLayers.DataAccess.Types
{
	public class SqlServerDatabaseModel : AbstractDatabaseModel
	{
		public static int DefaultPort = 1433;

		private DateTime _datetimeBackupInit;
		private DateTime _datetimeImportInit;

		public string Server { get; set; }
		public int Port { get; set; }
		public string Database { get; set; }
		public string User { get; set; }
		public string Password { get; set; }

		public SqlServerDatabaseModel()
		{
		}
		public SqlServerDatabaseModel(string server, int port, string database, string user, string password)
		{
			Server = server;
			Port = port;
			Database = database;
			User = user;
			Password = password;
		}

		public override ConnectionState CheckConnection()
		{
			string connectionString = ConnectionHelper.BuildConnectionString(false);
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					sqlConnection.Open();
					return sqlConnection.State;
				}
			}
			catch (SqlException ex)
			{
				return ConnectionState.Closed;
			}
		}


		#region Overrides of AbstractDatabaseModel

		public override bool CheckDatabaseExists(string connectionString, string databaseName)
		{
			bool databaseExists;
			string sqlConnectionString = ConnectionHelper.BuildConnectionString(false);
			using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString))
			{
				sqlConnection.Open();
				if (sqlConnection.State != ConnectionState.Open)
				{
					return false;
				}
				else
				{
					using (SqlCommand sqlCommand = new SqlCommand())
					{
						sqlCommand.CommandText =
							string.Concat("SELECT * FROM sys.Databases WHERE Name = '", databaseName, "'");

						sqlCommand.Connection = sqlConnection;
						var result = sqlCommand.ExecuteScalar();
						databaseExists = result != null;
					}
				}
			}
			return databaseExists;
		}

		public override Configuration DatabaseConfiguration()
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
