using SpectrumV1.DataLayers.DataAccess;
using SpectrumV1.Models.Administration.Connections;
using SpectrumV1.Utilities.Enums;
using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace SpectrumV1.DataLayers.DataUtilities
{
	internal static class ConnectionHelper
	{
		private static ConnectionModel _connectionModel = new ConnectionModel();

		public static string BuildConnectionString(bool includeDatabaseName = true)
		{
			_connectionModel = DatabaseFactory.ConnectionParamsGet();

			string connectionString = string.Concat("Server=", _connectionModel.DatabaseHost, ";" +
				"User Id=", _connectionModel.DatabaseUser, ";Password=", _connectionModel.DatabasePassword);

			if (includeDatabaseName)
			{
				connectionString = connectionString + ";Database=" + _connectionModel.DatabaseName;
			}
			return connectionString;
		}

		public static DbConnection DataConnection()
		{
			switch ((DatabaseTypes)Enum.Parse(typeof(DatabaseTypes), _connectionModel.DatabaseType))
			{
				case DatabaseTypes.SqlServer:
					return new SqlConnection(BuildConnectionString());

				case DatabaseTypes.MySql:
					return null;

				case DatabaseTypes.SqLite:
					return null;

				case DatabaseTypes.MongoDb:
					return null;

				default:
					return null;
			}
		}
	}
}
