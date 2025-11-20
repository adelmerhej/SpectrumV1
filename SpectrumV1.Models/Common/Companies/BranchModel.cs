using SpectrumV1.Models;
using System;

namespace SpectrumV1.Models.Common.Companies
{
	public class BranchModel : EntityObject, ICloneable
	{
		public string Name { get; set; }


		#region Implementation of ICloneable

		/// <summary>Creates a new object that is a copy of the current instance.</summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone()
		{
			var companyModel = (BranchModel)MemberwiseClone();
			return companyModel;
		}

		#endregion
	}
}
