using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SpectrumV1.DataLayers.Projects
{
	public class ProjectModel
	{  // Mandatory: MongoDB document primary key
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		// ==========================================================
		// 1. Project Information (References and Core Data)
		// ==========================================================

		// References: Storing IDs for related collections (Area, Engineer, Client, etc.).
		// Use string for MongoDB ObjectId references.

		[BsonElement("AreaId")]
		[BsonRepresentation(BsonType.ObjectId)]
		public string AreaId { get; set; }

		[BsonElement("EngineerId")]
		[BsonRepresentation(BsonType.ObjectId)]
		public string EngineerId { get; set; }

		[BsonElement("ClientId")]
		[BsonRepresentation(BsonType.ObjectId)]
		public string ClientId { get; set; }

		// Assuming this ProjectName references a lookup/master Project name list.
		[BsonElement("ProjectNameId")]
		[BsonRepresentation(BsonType.ObjectId)]
		public string ProjectNameId { get; set; }

		// Reference to the Quotation document
		[BsonElement("QuotationReferenceId")]
		[BsonRepresentation(BsonType.ObjectId)]
		public string QuotationReferenceId { get; set; }

		// Core Project Fields
		[BsonElement("IsActive")]
		public bool IsActive { get; set; } = true;

		[BsonElement("IssuanceYear")]
		public int IssuanceYear { get; set; } // date.year()

		[BsonElement("Description")]
		public string Description { get; set; }


		// ==========================================================
		// 2. Embedded Sub-Documents
		// ==========================================================

		// EMBEDDED: Groups all document links and dates specific to this project
		[BsonElement("Documents")]
		public ProjectDocumentsModel Documents { get; set; } = new ProjectDocumentsModel();

		// EMBEDDED: Groups all contract, financial, and warranty details
		[BsonElement("ContractDetails")]
		public ContractDetailModel ContractDetails { get; set; } = new ContractDetailModel();
	}
}
