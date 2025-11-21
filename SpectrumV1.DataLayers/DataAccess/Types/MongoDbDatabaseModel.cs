using MongoDB.Bson;
using MongoDB.Driver;
using SpectrumV1.Models.Administration.Connections;
using SpectrumV1.Utilities.Enums;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SpectrumV1.DataLayers.DataAccess.Types
{
	public class MongoDbDatabaseModel : AbstractDatabaseModel
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

			//string connectionString = string.Concat("Server=", _connectionModel.DatabaseHost, ";" +
			//	"User Id=", _connectionModel.DatabaseUser, ";Password=", _connectionModel.DatabasePassword);

			//if (includeDatabaseName)
			//{
			//	connectionString = connectionString + ";Database=" + _connectionModel.DatabaseName;
			//}
			return _connectionModel.DatabaseConnectionString;
		}

		public override ConnectionState CheckConnection()
		{
			ConnectionModel connectionModel = DatabaseFactory.ConnectionParamsGet();

			if (string.Equals(connectionModel.DatabaseType, DatabaseTypes.MongoDb.ToString(), StringComparison.OrdinalIgnoreCase))
			{
				return CheckMongoConnection(connectionModel.DatabaseConnectionString);
			}
			else // Assuming default is SQL Server or other type
			{
				// Keep the original SQL Server logic (or move it to a separate method)
				return CheckSqlConnection(connectionModel.DatabaseConnectionString);
			}
		}

		// Separate method for checking SQL connection (from your original code)
		private ConnectionState CheckSqlConnection(string connectionString)
		{
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
				// Log the exception details if needed
				return ConnectionState.Closed;
			}
		}

		// New method for checking MongoDB connection
		private ConnectionState CheckMongoConnection(string connectionString)
		{
			try
			{
				// 1. Create the MongoDB Client
				var client = new MongoClient(connectionString);

				// 2. Attempt a fast, simple operation (e.g., pinging the server).
				// The GetDatabase call itself doesn't connect, but PingAsync does.
				var database = client.GetDatabase("admin"); // You can use any database name

				// Use a short timeout for the check if possible (not directly available 
				// on the standard PingAsync call, but the overall operation will timeout 
				// based on the connection string settings).

				// This command ensures the driver attempts to connect to the server.
				// It returns a BsonDocument, but we only care if it succeeds or throws.
				database.RunCommandAsync((Command<MongoDB.Bson.BsonDocument>)"{ping:1}").Wait();

				// If the Wait() call completes without throwing an exception, the connection is valid.
				return ConnectionState.Open;
			}
			catch (MongoException ex)
			{
				// Catch specific MongoDB exceptions (e.g., connection errors, authentication failures)
				// Log the exception details if needed
				return ConnectionState.Closed;
			}
			catch (Exception ex)
			{
				// Catch other potential exceptions
				// Log the exception details if needed
				return ConnectionState.Closed;
			}
		}

		/// <summary>
		/// Checks if a database with the given name exists on the MongoDB server.
		/// </summary>
		/// <param name="connectionString">The MongoDB connection string.</param>
		/// <param name="databaseName">The name of the database to check.</param>
		/// <returns>True if the database exists; otherwise, false.</returns>
		public override bool CheckDatabaseExists(string connectionString, string databaseName)
		{
			if (string.IsNullOrWhiteSpace(connectionString) || string.IsNullOrWhiteSpace(databaseName))
			{
				return false;
			}

			try
			{
				var client = new MongoClient(connectionString);

				// Get the list of all databases on the server.
				// We use .Result to make the async call synchronous (since the return is synchronous).
				var databaseNames = client.ListDatabaseNames().ToList();

				// Check if our specific database name exists in the list (case-sensitive check is default)
				return databaseNames.Any(name =>
					name.Equals(databaseName, StringComparison.OrdinalIgnoreCase));
			}
			catch (MongoException ex)
			{
				// Handle connection or authentication errors.
				// If this fails, we assume the connection is bad or the database can't be listed.
				// You might want to log this error instead of returning false silently.
				return false;
			}
			catch (Exception ex)
			{
				// Handle other exceptions
				return false;
			}
		}

		public override void CreateDatabase(string connectionString, string databaseName)
		{
			try
			{
				var client = new MongoClient(connectionString);
				var database = client.GetDatabase(databaseName);

				// Define the collection name
				string collectionName = "Users";

				// 1. Get a reference to the collection
				var usersCollection = database.GetCollection<BsonDocument>(collectionName);

				// 2. Define the index keys (e.g., index on the 'Email' field)
				var indexKeys = Builders<BsonDocument>.IndexKeys.Ascending("Email");

				// 3. Define the index options (e.g., enforce uniqueness)
				var indexOptions = new CreateIndexOptions
				{
					Name = "EmailUniqueIndex",
					Unique = true // This ensures no two documents have the same Email
				};

				// 4. Create the index using CreateIndexModel (recommended and non-obsolete)
				var indexModel = new CreateIndexModel<BsonDocument>(indexKeys, indexOptions);
				usersCollection.Indexes.CreateOne(indexModel);

				Console.WriteLine($"Index 'EmailUniqueIndex' created/verified on collection '{collectionName}'.");
			}
			catch (MongoException ex)
			{
				throw new InvalidOperationException("Failed to create index in MongoDB.", ex);
			}
		}

		public override Configuration DatabaseConfiguration()
		{
			throw new NotImplementedException();
		}
	}
}
