using SpectrumV1.DataLayers.DataAccess.Types;
using SpectrumV1.DataLayers.Properties;
using SpectrumV1.Models.Administration.Connections;
using SpectrumV1.Utilities.Enums;
using System;

namespace SpectrumV1.DataLayers.DataAccess
{
	public class DatabaseFactory
	{
		public static IDatabase Get(string application, string databaseType, string databaseHost, int databasePort,
			string databaseName, string databaseUser, string databasePassword)
		{
			switch ((DatabaseTypes)Enum.Parse(typeof(DatabaseTypes), databaseType))
			{
				case DatabaseTypes.MySql:
					//return new MySQLDatabaseModel()
					//{
					//    Server = databaseHost,
					//    Port = databasePort,
					//    Database = databaseName,
					//    User = databaseUser,
					//    Password = databasePassword
					//};

					return null;

				case DatabaseTypes.MongoDb:
					return (IDatabase)new MongoDbDatabaseModel()
					{
						
					};

				case DatabaseTypes.SqlServer:
					return new SqlServerDatabaseModel()
					{
						Server = databaseHost,
						Database = databaseName,
						User = databaseUser,
						Password = databasePassword
					};

				default:
					return null;
			}
		}

		public static void ConnectionParamsSet(ConnectionModel connection)
		{
			Settings.Default.DatabaseType = connection.DatabaseType;
			Settings.Default.DatabaseHost = connection.DatabaseHost;
			Settings.Default.DatabasePort = connection.DatabasePort;
			Settings.Default.DatabaseName = connection.DatabaseName;
			Settings.Default.DatabaseUser = connection.DatabaseUser;
			Settings.Default.DatabasePassword = connection.DatabasePassword;
			Settings.Default.DatabaseConnectionString = connection.DatabaseConnectionString;

			Settings.Default.Save();
		}

		public static ConnectionModel ConnectionParamsGet()
		{
			ConnectionModel connection = new ConnectionModel();

			connection.DatabaseType = Settings.Default.DatabaseType;
			connection.DatabaseHost = Settings.Default.DatabaseHost;
			connection.DatabasePort = Settings.Default.DatabasePort;
			connection.DatabaseName = Settings.Default.DatabaseName;
			connection.DatabaseUser = Settings.Default.DatabaseUser;
			connection.DatabasePassword = Settings.Default.DatabasePassword;
			connection.DatabaseConnectionString = Settings.Default.DatabaseConnectionString;

			return connection;
		}
	}
}
