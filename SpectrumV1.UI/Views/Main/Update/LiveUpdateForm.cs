using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using SpectrumV1.Update.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SpectrumV1.Views.Main.Update
{
	public partial class LiveUpdateForm : XtraForm
	{
		public const string UpdaterPrefix = "V1234_";
		private static string _processToEnd = "MISlive";
		private static string _postProcess = Application.StartupPath + @"\" + _processToEnd + ".exe";
		public static string Updater = Application.StartupPath + @"\LiveUpdate.exe";

		public const string UpdateSuccess = "MISlive has been successfully updated";
		public const string UpdateCurrent = "No updates available for MISlive";
		public const string UpdateInfoError = "Error in retrieving MISlive information";

		private readonly string _urlLink = "https://www.xolog.com/u/liveupdate/mislive/";
		private readonly string _currentVersionNo = "";
		private readonly string _newVersionNo = "";
		private readonly string _versionFilename = "version.txt";
		private string _fileName = "";

		public static List<string> Info = new List<string>();

		public LiveUpdateForm()
		{
			InitializeComponent();
		}

		private void LiveUpdateForm_Load(object sender, EventArgs e)
		{
			txtDownloadUrl.Text = _urlLink;
			txtCurrentVersionNo.Text = GetExternalFileVersion("MISLive.exe");
			txtNewVersionNo.Text = "";

			LiveUpdateHelper.UpdateMe(UpdaterPrefix, Application.StartupPath + @"\");
			lcUpdateResult.Visibility = LayoutVisibility.Never;
			lcbtnUpdate.Visibility = LayoutVisibility.Never;
			UnpackCommandline();
			CheckForUpdate();
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			LiveUpdateHelper.InstallUpdateRestart(_urlLink, _fileName, "\"" + Application.StartupPath + "\\", _processToEnd, _postProcess, "updated", Updater);
			Close();
		}

		// Get the version of an external file
		private static string GetExternalFileVersion(string fileName)
		{
			try
			{
				string fullPath = Path.Combine(Application.StartupPath, fileName);
				if (!File.Exists(fullPath)) return "0.000";
				var fvi = FileVersionInfo.GetVersionInfo(fullPath);
				string ver = !string.IsNullOrWhiteSpace(fvi.ProductVersion) ? fvi.ProductVersion : fvi.FileVersion;
				return ver ?? "0.000";
			}
			catch
			{
				return "0.000";
			}
		}

		// Unpack any command line arguments
		private void UnpackCommandline()
		{
			bool commandPresent = false;
			string tempStr = "";

			foreach (string arg in Environment.GetCommandLineArgs())
			{

				if (!commandPresent)
				{
					commandPresent = arg.Trim().StartsWith("/");
				}

				if (commandPresent)
				{
					tempStr += arg;
				}
			}

			if (commandPresent)
			{
				if (tempStr.Remove(0, 2) == "updated")
				{
					lcUpdateResult.Visibility = LayoutVisibility.Always;
					lblUpdateResult.Text = UpdateSuccess;
				}
			}
		}

		// Helper to compare dotted version strings (e.g.2.0.1.7)
		private static bool IsNewerVersion(string current, string available)
		{
			if (Version.TryParse(current, out var cur) && Version.TryParse(available, out var avail))
			{
				return avail > cur; // uses built-in comparison of Version
			}

			// Fallback: manual segment comparison
			var curParts = current.Split('.');
			var availParts = available.Split('.');
			int max = Math.Max(curParts.Length, availParts.Length);
			for (int i = 0; i < max; i++)
			{
				int curVal = i < curParts.Length && int.TryParse(curParts[i], out var c) ? c : 0;
				int availVal = i < availParts.Length && int.TryParse(availParts[i], out var a) ? a : 0;
				if (availVal > curVal) return true;
				if (availVal < curVal) return false;
			}
			return false; // equal
		}

		private void btnCheckForUpdate_Click(object sender, EventArgs e)
		{
			CheckForUpdate();
		}

		private void CheckForUpdate()
		{
			Info = LiveUpdateHelper.GetUpdateInfo(txtDownloadUrl.Text, _versionFilename, Application.StartupPath + @"\", 0);

			if (Info == null)
			{
				lcbtnUpdate.Visibility = LayoutVisibility.Never;
				lblUpdateResult.Text = UpdateInfoError;
				lcUpdateResult.Visibility = LayoutVisibility.Always;
			}
			else
			{
				string currentVersion = _currentVersionNo;
				string newerVersion = Info[0];
				txtNewVersionNo.Text = Info[0];

				if (IsNewerVersion(currentVersion, newerVersion))
				{
					lcbtnUpdate.Visibility = LayoutVisibility.Always;
					lcUpdateResult.Visibility = LayoutVisibility.Never;

					_fileName = $"update.{newerVersion}.zip";
				}
				else
				{
					lcbtnUpdate.Visibility = LayoutVisibility.Never;
					lcUpdateResult.Visibility = LayoutVisibility.Always;
					lblUpdateResult.Text = UpdateCurrent;
				}
			}
		}
	}
}