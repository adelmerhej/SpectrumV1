using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SpectrumV1.Models.Common.Companies
{
	public class BranchModel : EntityObject, ICloneable
	{
		[BsonElement("Name")]
		public string Name { get; set; }


		#region Implementation of ICloneable

		/// <summary>Creates a new object that is a copy of the current instance.</summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone()
		{
			var recordModel = (BranchModel)MemberwiseClone();
			return recordModel;
		}

		#endregion
	}
}
