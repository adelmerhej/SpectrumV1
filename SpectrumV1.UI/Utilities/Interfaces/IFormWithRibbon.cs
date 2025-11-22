using DevExpress.XtraBars.Ribbon;

namespace SpectrumV1.Utilities.Interfaces
{
	public interface IFormWithRibbon
	{
		RibbonControl MainRibbon { get; }
		RibbonPage DefaultPage { get; }
	}
}
