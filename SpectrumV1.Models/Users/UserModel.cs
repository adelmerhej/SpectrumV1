using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace SpectrumV1.Models.Users
{
	/// <summary>
	/// Represents a user document in the MongoDB 'Users' collection.
	/// This structure is compatible with custom authentication or a simple ASP.NET Core Identity setup.
	/// </summary>
	public class UserModel
	{
		// Mandatory: MongoDB document primary key
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		// Core identification fields
		[BsonElement("Username")]
		public string Username { get; set; } // Required for login

		[BsonElement("Email")]
		public string Email { get; set; }

		// Security fields
		[BsonElement("PasswordHash")]
		public string PasswordHash { get; set; } // Stores the securely hashed password

		// Used by Identity to manage concurrency and security tokens
		[BsonElement("SecurityStamp")]
		public string SecurityStamp { get; set; } = Guid.NewGuid().ToString();

		// Authorization: Embedding roles for fast lookup (best practice for MongoDB)
		[BsonElement("Roles")]
		public List<string> Roles { get; set; } = new List<string>();

		// Audit fields
		[BsonElement("IsLockedOut")]
		public bool IsLockedOut { get; set; } = false;

		[BsonElement("CreatedAt")]
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	}
}
