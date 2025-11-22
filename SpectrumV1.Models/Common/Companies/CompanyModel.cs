using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SpectrumV1.Models.Common.Companies
{
	public class CompanyModel : EntityObject, ICloneable
	{
		[BsonElement("CompanyName")]
		public string CompanyName { get; set; }

		[BsonElement("ShortName")]
		public string ShortName { get; set; }

		[BsonElement("DirectoryPath")]
		public string DirectoryPath { get; set; }

		[BsonElement("Address")]
		public string Address { get; set; }

		[BsonElement("City")]
		public string City { get; set; }

		[BsonElement("Country")]
		public string Country { get; set; }

		[BsonElement("PhoneNumber1")]
		public string PhoneNumber1 { get; set; }

		[BsonElement("PhoneNumber2")]
		public string PhoneNumber2 { get; set; }

		[BsonElement("PhoneNumber3")]
		public string PhoneNumber3 { get; set; }

		[BsonElement("FaxNumber")]
		public string FaxNumber { get; set; }

		[BsonElement("Email")]
		public string Email { get; set; }

		[BsonElement("Website")]
		public string Website { get; set; }

		[BsonElement("PoBox")]
		public string PoBox { get; set; }

		[BsonElement("CompanyDisclaimer")]
		public string CompanyDisclaimer { get; set; }

		[BsonElement("LocalCurrency")]
		public string LocalCurrency { get; set; }

		[BsonElement("ForeignCurrency")]
		public string ForeignCurrency { get; set; }

		[BsonElement("VatInfo")]
		public string VatInfo { get; set; }

		[BsonElement("BankAccount")]
		public string BankAccount { get; set; }

		[BsonElement("CompanyLogo")]
		public string CompanyLogo { get; set; }

		[BsonElement("ChangeCompanyName")]
		public bool ChangeCompanyName { get; set; } = false;

		#region Implementation of ICloneable

		/// <summary>Creates a new object that is a copy of the current instance.</summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone()
		{
			var recordModel = (CompanyModel)MemberwiseClone();
			return recordModel;
		}

		#endregion
	}
}
