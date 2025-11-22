using System;

namespace SpectrumV1.Models.Common.Companies
{
	public class CompanyModel : EntityObject, ICloneable
	{
		public string CompanyName { get; set; }
		public string ShortName { get; set; }
		public string DirectoryPath { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
		public string PhoneNumber1 { get; set; }
		public string PhoneNumber2 { get; set; }
		public string PhoneNumber3 { get; set; }
		public string FaxNumber { get; set; }
		public string Email { get; set; }
		public string Website { get; set; }
		public string PoBox { get; set; }
		public string CompanyDisclaimer { get; set; }
		public string LocalCurrency { get; set; }
		public string ForeignCurrency { get; set; }
		public string VatInfo { get; set; }
		public string BankAccount { get; set; }
		public string CompanyLogo { get; set; }
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
