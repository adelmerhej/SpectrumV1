using System;
using System.Collections.Generic;

namespace SpectrumV1.Utilities.Enums
{
	public enum DatabaseTypes
	{
		MySql,
		MongoDb,
		SqlServer,
	}

	public enum PersonPrefix
	{
		Dr,
		Mr,
		Ms,
		Miss,
		Mrs,
	}
	public enum ChartType
	{
		T = 1,
		R = 2
	}
	public enum EnumDebCred
	{
		D = 1,
		C = 2
	}
	public enum Periodicity
	{
		Monthly,
		Bimonthly,
		Trimonthly,
		Quarterly,
		Annual,
		Daily,
		Weekly,
		Hourly
	}

	public enum PrintAction
	{
		Preview,
		Print
	}

	public enum ImageLocation
	{
		Database,
		SystemFile
	}
	public enum CollectionViewFiltersVisibility
	{
		Visible,
		Minimized,
		Hidden
	}

	public enum EnumPaymentType
	{
		None = 0,
		Receipt = 1,
		Refund = 2,
		PaymentVoucher = 3,
		CreditNote = 4,
		DebitNote = 5
	}

	public enum Gender
	{
		Female,
		Male
	}
}

public enum CollectionViewMasterDetailLayout
{
	Horizontal,
	Vertical,
	DetailHidden,
}
public enum EnumJobStatus
{
	NormalMod = 0,
	ClosedMod = 1,
	EditMod = 2,
	CanceledMod = 3,
	ReOpenedMod = 4,
	NotSelectedMod = 5
}

public enum EnumStatusType
{
	Quoted = 0,
	Requested = 1,
	Booked = 2,
	Lost = 3,
	Canceled = 4,
	NotSelected = 5
}

public enum FileType
{
	Images = 100, // 0x00000064
	Temp = 102, // 0x00000066
	SQL = 103, // 0x00000067
	SqlLog = 104, // 0x00000068
	LocalLog = 105, // 0x00000069
	RequiredDocument = 200, // 0x000000C8
	Layout = 201, // 0x000000C9
	AttachDocument = 202, // 0x000000CA
	AttachDocument2 = 203, // 0x000000CB
	Document = 204, // 0x000000CC
	Report = 205, // 0x000000CD
	XML = 206, // 0x000000CE
	Log = 207, // 0x000000CF
	CurrencyRate = 208, // 0x000000D0
	AddressBookDocument = 209, // 0x000000D1
	JobRequiredDocument = 210, // 0x000000D2
	JobDocument = 211, // 0x000000D3
	Offer = 212, // 0x000000D4
	License = 213, // 0x000000D5
	ProfileImage = 214, // 0x000000D6
	Signature = 215, // 0x000000D7
	CV = 216, // 0x000000D8
	Permit = 217, // 0x000000D9
	Warning = 218, // 0x000000DA
	DependenceDocument = 219, // 0x000000DB
	EmployeeImage = 220, // 0x000000DC
	LicenseDocument = 221, // 0x000000DD
	DoctorReport = 222, // 0x000000DE
	PermitDocument = 223, // 0x000000DF
	WarningDocument = 224, // 0x000000E0
	Backup = 230, // 0x000000E6
	Error = 231, // 0x000000E7
	Customized = 240, // 0x000000F0
	SMS = 250, // 0x000000FA
}


public enum FormatTypeEnum
{
	Numerical,
	DateTime,
	Date,
	Time,
	Other,
	None,
}

public enum FormatEnum
{
	None = 0,
	Numeric = 1,
	Integer = 2,
	Currency = 3,
	Exponential = 4,
	FixedPoint = 5,
	General = 6,
	Percent = 7,
	RoundTrip = 8,
	Hexadecimal = 9,
	IntegerWithSeperator = 10, // 0x0000000A
	MonthName = 100, // 0x00000064
	DateTime = 101, // 0x00000065
	DateTime12 = 102, // 0x00000066
	DateTime24 = 103, // 0x00000067
	Date = 150, // 0x00000096
	Time = 200, // 0x000000C8
	Time12 = 201, // 0x000000C9
	Time24 = 202, // 0x000000CA
	PageNumber = 300, // 0x0000012C
}

public enum StatusEnum
{
	None = 0,
	CustomStatus = 1,
	Ready = 101, // 0x00000065
	NotSaved = 102, // 0x00000066
	SavedSuccessfully = 201, // 0x000000C9
	DeletedSuccessfully = 202, // 0x000000CA
	CopiedSuccessfully = 203, // 0x000000CB
	SavingFailed = 301, // 0x0000012D
	DeletingFailed = 302, // 0x0000012E
	CopyingFailed = 303, // 0x0000012F
	Saving = 401, // 0x00000191
	Copying = 402, // 0x00000192
	Deleting = 403, // 0x00000193
}

public enum DataEntityState
{
	Unchanged,
	Added,
	Changed,
	Deleted,
	Cancel
}

public enum ChequeTypeEnum
{
	PostDated = 1,
	Deposit = 2,
	Returned = 3,
	Valid = 4,
	Paid = 5,
	ForCollection = 6,
	Blocked = 7,
	Cancelled = 8
}


public enum DataJvTypes
{
	OP = 1,
	JV = 2,
	PV = 3,
	RV = 4,
	CR = 5,
	DB = 6,
	PR = 7,
	SV = 8,
	TR = 9,
	DF = 10,
	CK = 11
}


public enum EnumDebCred
{
	D,
	C
}

public enum PostStatus
{
	NotPosted = 0,
	Posted = 1,
	All = 2
}

public enum ChartType
{
	T = 1,
	R = 2
}

public static class Enumeration
{
	public static IDictionary<int, string> GetAll<TEnum>() where TEnum : struct
	{
		var enumerationType = typeof(TEnum);

		if (!enumerationType.IsEnum)
			throw new ArgumentException("Enumeration type is expected.");

		var dictionary = new Dictionary<int, string>();

		foreach (int value in Enum.GetValues(enumerationType))
		{
			var name = Enum.GetName(enumerationType, value);
			dictionary.Add(value, name);
		}

		return dictionary;
	}

}
