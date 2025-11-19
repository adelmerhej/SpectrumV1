using System.IO;
using System.Windows.Forms;

namespace SpectrumV1.Models.Administration.Update
{
	public class LiveUpdateSettingsModel
	{
		public string UpdaterPrefix { get; set; } = "V1234_";
		public string ProcessToEnd { get; set; } = "SpectrumLive";
		public string PostProcess { get; set; } = null; // derived if null/empty
		public string Updater { get; set; } = null; // derived if null/empty

		public string UpdateSuccess { get; set; } = "SpectrumLive APP has been successfully updated";
		public string UpdateCurrent { get; set; } = "No updates available for SpectrumLive APP ";
		public string UpdateInfoError { get; set; } = "Error in retrieving SpectrumLive APP  information";

		public string UrlLink { get; set; } = "https://www.xolog.com/u/liveupdate/spectrum/";
		public string CurrentVersionNo { get; set; } = "";
		public string NewVersionNo { get; set; } = "";
		public string VersionFilename { get; set; } = "version.txt";

		public static LiveUpdateSettingsModel CreateDefaults(string startupPath)
		{
			var s = new LiveUpdateSettingsModel();
			s.ComputeDerived(startupPath);
			return s;
		}

		public void ComputeDerived(string startupPath)
		{
			var basePath = string.IsNullOrWhiteSpace(startupPath) ? Application.StartupPath : startupPath;

			if (string.IsNullOrWhiteSpace(ProcessToEnd))
				ProcessToEnd = "SpectrumLive";

			if (string.IsNullOrWhiteSpace(PostProcess))
				PostProcess = Path.Combine(basePath, ProcessToEnd + ".exe");

			if (string.IsNullOrWhiteSpace(Updater))
				Updater = Path.Combine(basePath, "LiveUpdate.exe");
		}
	}
}
