using MongoDB.Bson;
using MongoDB.Driver;
using SpectrumV1.Models.Administration.Connections;
using SpectrumV1.Utilities.Enums;
using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace SpectrumV1.DataLayers.DataAccess.Types
{
	public class MongoDbDatabaseModel
	{
		private static readonly object _syncRoot = new object();
		private static MongoClient _cachedClient;
		private static string _cachedClientKey;
		private static ConnectionModel _connectionModel = new ConnectionModel();

		/// <summary>
		/// Creates (and caches) a Mongo client for the given connection parameters.
		/// Default host is "mongodb://localhost:27017/".
		/// If username and password are provided, credential-based authentication is used (default auth DB = "admin").
		/// </summary>
		/// <param name="host">MongoDB connection string or host (e.g., "mongodb://localhost:27017/").</param>
		/// <param name="username">Optional username.</param>
		/// <param name="password">Optional password.</param>
		/// <param name="authDatabase">Authentication database name. Defaults to "admin".</param>
		/// <returns>Mongo client instance.</returns>
		public static MongoClient GetClient(string host = "mongodb://localhost:27017/", string username = null, string password = null, string authDatabase = "admin")
		{
			var key = BuildClientKey(host, username, password, authDatabase);

			if (_cachedClient != null && string.Equals(_cachedClientKey, key, StringComparison.Ordinal))
				return _cachedClient;

			lock (_syncRoot)
			{
				if (_cachedClient != null && string.Equals(_cachedClientKey, key, StringComparison.Ordinal))
					return _cachedClient;

				MongoClient client;
				var mongoUrl = new MongoUrl(host);

				if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
				{
					var settings = MongoClientSettings.FromUrl(mongoUrl);
					settings.Credential = MongoCredential.CreateCredential(string.IsNullOrEmpty(authDatabase) ? "admin" : authDatabase, username, password);
					client = new MongoClient(settings);
				}
				else
				{
					client = new MongoClient(mongoUrl);
				}

				_cachedClient = client;
				_cachedClientKey = key;
				return client;
			}
		}

		/// <summary>
		/// Gets a database reference using the provided client parameters.
		/// </summary>
		public static IMongoDatabase GetDatabase(string databaseName, string host = "mongodb://localhost:27017/", string username = null, string password = null, string authDatabase = "admin")
		{
			if (string.IsNullOrWhiteSpace(databaseName))
				throw new ArgumentException("Database name must be provided.", nameof(databaseName));

			var client = GetClient(host, username, password, authDatabase);
			return ((MongoClient)client).GetDatabase(databaseName);
		}

		/// <summary>
		/// Pings the MongoDB server to verify connectivity.
		/// </summary>
		public static bool TryPing(MongoClient client, string databaseName = "admin")
		{
			try
			{
				var db = client.GetDatabase(string.IsNullOrEmpty(databaseName) ? "admin" : databaseName);
				db.RunCommand<BsonDocument>(new BsonDocument("ping", 1));
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// High-level convenience method to test connectivity given discrete params or a full connection string.
		/// </summary>
		public static bool TryConnect(string host, int port, string databaseName, string username, string password, string fullConn)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(fullConn))
				{
					var url = new MongoUrl(fullConn.Trim());
					var client = GetClient(url.ToString());
					var dbName = !string.IsNullOrWhiteSpace(databaseName) ? databaseName : (url.DatabaseName ?? "admin");
					return TryPing(client, dbName);
				}
				else
				{
					string baseHost = string.IsNullOrWhiteSpace(host) ? "localhost" : host.Trim();
					string mongoHost = $"mongodb://{baseHost}:{(port <= 0 ? 27017 : port)}/";
					MongoClient client;
					if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
						client = GetClient(mongoHost, username, password, "admin");
					else
						client = GetClient(mongoHost);
					return TryPing(client, string.IsNullOrWhiteSpace(databaseName) ? "admin" : databaseName);
				}
			}
			catch
			{
				return false;
			}
		}

		private static string BuildClientKey(string host, string username, string password, string authDb)
		{
			return $"{host}|{username}|{(string.IsNullOrEmpty(password) ? string.Empty : "***")}|{authDb}";
		}

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

				case DatabaseTypes.MongoDb:
					return null;

				default:
					return null;
			}
		}
	}
}
