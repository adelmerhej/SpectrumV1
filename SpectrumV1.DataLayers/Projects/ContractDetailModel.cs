using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SpectrumV1.DataLayers.Projects
{
	// Embedded document for contract, financial, and warranty terms
	public class ContractDetailModel
	{// ==========================================================
	 // Contract References & Core Info
	 // ==========================================================

		// Reference to Services lookup collection
		[BsonElement("ServiceId")]
		[BsonRepresentation(BsonType.ObjectId)]
		public string ServiceId { get; set; }

		// Reference to Type lookup collection
		[BsonElement("TypeId")]
		[BsonRepresentation(BsonType.ObjectId)]
		public string TypeId { get; set; }

		// Reference to Sponsor/Funder collection
		[BsonElement("SponsorId")]
		[BsonRepresentation(BsonType.ObjectId)]
		public string SponsorId { get; set; }


		[BsonElement("ContractNumber")]
		public string ContractNumber { get; set; }

		[BsonElement("ContractFileLink")]
		public string ContractFileLink { get; set; }

		[BsonElement("SignatureDate")]
		public DateTime? SignatureDate { get; set; }

		[BsonElement("ContractPeriod")]
		public string ContractPeriod { get; set; }

		[BsonElement("ExtensionDetails")]
		public string ExtensionDetails { get; set; }

		[BsonElement("ActualCompletionDate")]
		public DateTime? ActualCompletionDate { get; set; }

		[BsonElement("ClientContactEmail")]
		public string ClientContactEmail { get; set; }

		[BsonElement("CurrencyCode")]
		public string CurrencyCode { get; set; }

		// ==========================================================
		// Financial Amounts
		// IMPORTANT: Use Decimal128 for precise currency storage in MongoDB
		// ==========================================================

		[BsonRepresentation(BsonType.Decimal128)]
		[BsonElement("DesignFee")]
		public decimal? DesignFee { get; set; }

		[BsonRepresentation(BsonType.Decimal128)]
		[BsonElement("SupervisionFee")]
		public decimal? SupervisionFee { get; set; }

		[BsonRepresentation(BsonType.Decimal128)]
		[BsonElement("InitialContractAmount")]
		public decimal? InitialContractAmount { get; set; }

		[BsonRepresentation(BsonType.Decimal128)]
		[BsonElement("RetentionPercentage")]
		public decimal? RetentionPercentage { get; set; }

		[BsonRepresentation(BsonType.Decimal128)]
		[BsonElement("InitialVatAmount")]
		public decimal? InitialVatAmount { get; set; }

		[BsonRepresentation(BsonType.Decimal128)]
		[BsonElement("InitialTtcAmount")]
		public decimal? InitialTtcAmount { get; set; }

		// ==========================================================
		// Addendums (Could be an Array of Addendum objects for better scalability)
		// For simplicity, sticking to the provided structure.
		// ==========================================================

		[BsonElement("Addendum1Ref")]
		public string Addendum1Ref { get; set; }

		[BsonRepresentation(BsonType.Decimal128)]
		[BsonElement("Addendum1Amount")]
		public decimal? Addendum1Amount { get; set; }

		[BsonRepresentation(BsonType.Decimal128)]
		[BsonElement("Addendum1Vat")]
		public decimal? Addendum1Vat { get; set; }

		[BsonRepresentation(BsonType.Decimal128)]
		[BsonElement("Addendum1Ttc")]
		public decimal? Addendum1Ttc { get; set; }

		[BsonElement("Addendum1BoardDate")]
		public DateTime? Addendum1BoardDate { get; set; }

		[BsonRepresentation(BsonType.Decimal128)]
		[BsonElement("Addendum2Amount")]
		public decimal? Addendum2Amount { get; set; } // Assuming this is Addendum 2 or final adjustment

		[BsonRepresentation(BsonType.Decimal128)]
		[BsonElement("Addendum2Vat")]
		public decimal? Addendum2Vat { get; set; }

		[BsonRepresentation(BsonType.Decimal128)]
		[BsonElement("Addendum2Ttc")]
		public decimal? Addendum2Ttc { get; set; }


		// ==========================================================
		// Warranty / Guarantee
		// ==========================================================

		[BsonElement("WarrantyReference")]
		public string WarrantyReference { get; set; }

		[BsonRepresentation(BsonType.Decimal128)]
		[BsonElement("WarrantyAmount")]
		public decimal? WarrantyAmount { get; set; }

		[BsonElement("WarrantyBank")]
		public string WarrantyBank { get; set; }

		[BsonElement("WarrantyIssuanceDate")]
		public DateTime? WarrantyIssuanceDate { get; set; }

		[BsonElement("WarrantyExpiryDate")]
		public DateTime? WarrantyExpiryDate { get; set; }

		[BsonElement("WarrantyStatus")]
		public string WarrantyStatus { get; set; }
	}
}
