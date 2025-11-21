using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SpectrumV1.DataLayers.Projects
{
	// Embedded document for grouping links to physical files/folders
	public class ProjectDocumentsModel
	{ 
		// Preliminary Handing Over
		[BsonElement("PreliminaryHandoverLink")]
		public string PreliminaryHandoverLink { get; set; }

		[BsonElement("PreliminaryHandoverDate")]
		public DateTime? PreliminaryHandoverDate { get; set; }

		// Final Handing Over
		[BsonElement("FinalHandoverLink")]
		public string FinalHandoverLink { get; set; }

		[BsonElement("FinalHandoverDate")]
		public DateTime? FinalHandoverDate { get; set; }

		// Certificate of Completion
		[BsonElement("CompletionCertificateLink")]
		public string CompletionCertificateLink { get; set; }

		[BsonElement("CompletionCertificateDate")]
		public DateTime? CompletionCertificateDate { get; set; }
	}
}
