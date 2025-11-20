using DevExpress.XtraEditors;
using SpectrumV1.DataLayers.Administration.Update;
using SpectrumV1.Models.Administration.Update;
using SpectrumV1.Properties;
using SpectrumV1.Update.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SpectrumV1.Views.Main.Update
{
	public partial class CheckForUpdateForm : XtraForm
	{
		private LiveUpdateSettingsModel _settings;
		private string _fileName = "";

		public static List<string> Info = new List<string>();

		public CheckForUpdateForm()
		{
			InitializeComponent();
		}

		private void LiveUpdateForm_Load(object sender, EventArgs e)
		{
			// Load settings from DB (with safe defaults)
			_settings = LiveUpdateSettingsProvider.LoadOrDefault(Application.StartupPath);

			lblTitle.Text = Settings.Default.ApplicationName;

			// Apply to UI
			txtDownloadUrl.Text = _settings.UrlLink;
			txtCurrentVersionNo.Text = GetExternalFileVersion("SpectrumLive.exe");
			txtNewVersionNo.Text = "";

			// Use settings
			LiveUpdateHelper.UpdateMe(_settings.UpdaterPrefix, Application.StartupPath + @"\");
			lblUpdateResult.Visible = false;
			btnUpdate.Visible = false;
			UnpackCommandline();
			CheckForUpdate();
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			LiveUpdateHelper.InstallUpdateRestart(
				_settings.UrlLink,
				_fileName,
				"\"" + Application.StartupPath + "\\",
				_settings.ProcessToEnd,
				_settings.PostProcess,
				"updated",
				_settings.Updater);

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
					lblUpdateResult.Visible = true;
					lblUpdateResult.Text = _settings.UpdateSuccess;
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
			Info = LiveUpdateHelper.GetUpdateInfo(
				_settings.UrlLink,
				_settings.VersionFilename,
				Application.StartupPath + @"\",
				0);

			if (Info == null)
			{
				btnUpdate.Visible = false;
				lblUpdateResult.Text = _settings.UpdateInfoError;
				lblUpdateResult.Visible = true;
			}
			else
			{
				// current version comes from settings if provided; otherwise from detected file version
				string currentVersion = string.IsNullOrWhiteSpace(_settings.CurrentVersionNo)
					? txtCurrentVersionNo.Text
					: _settings.CurrentVersionNo;

				string newerVersion = Info[0];
				txtNewVersionNo.Text = Info[0];

				if (IsNewerVersion(currentVersion, newerVersion))
				{
					btnUpdate.Visible = true;
					lblUpdateResult.Visible = false;

					_fileName = $"update.{newerVersion}.zip";
				}
				else
				{
					btnUpdate.Visible = false;
					lblUpdateResult.Visible = true;
					lblUpdateResult.Text = _settings.UpdateCurrent;
				}
			}
		}
	}
}