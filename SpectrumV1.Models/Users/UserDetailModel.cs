using System;

namespace SpectrumV1.Models.Users
{
	public class UserDetailModel : EntityObject, ICloneable
	{
		public int UserId { get; set; }
		public int Title { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public bool IsSales { get; set; }
		public int SalesContractId { get; set; }
		public string Address { get; set; }
		public int CountryId { get; set; }
		public int CityId { get; set; }
		public int DistrictId { get; set; }
		public int ProvinceId { get; set; }
		public DateTime? BirthDate { get; set; }

		#region Implementation of ICloneable

		/// <summary>Creates a new object that is a copy of the current instance.</summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone()
		{
			var recordModel = (UserDetailModel)MemberwiseClone();
			return recordModel;
		}

		#endregion
	}
}
