using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraPrinting.Native.WebClientUIControl;
using DevExpress.XtraSplashScreen;
using SpectrumV1.DataLayers.Administration.Update;
using SpectrumV1.Properties;
using SpectrumV1.Update.Utilities;
using SpectrumV1.Utilities.Enums;
using SpectrumV1.Views.Main.Update;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using SpectrumV1.DataLayers.DataUtilities; // added for MongoDB connection helper & DatabaseSettings
using SpectrumV1.DataLayers.Properties;    // added for DB settings

namespace SpectrumV1.Utilities
{
	public static class HelperApplication
	{
		private static bool _changeDatabase = false;

		public static void InitDefaultStyle()
		{
			WindowsFormsSettings.DefaultLookAndFeel.SetSkinStyle(Settings.Default.ApplicationSkinName, Settings.Default.ApplicationPalette);

			//      WindowsFormsSettings.EnableFormSkins();
			//         WindowsFormsSettings.ForceDirectXPaint();
			////WindowsFormsSettings.DefaultLookAndFeel.SetSkinStyle(SkinStyle.Office2019Colorful);
			////WindowsFormsSettings.DefaultRibbonStyle = DefaultRibbonControlStyle.Office2019;
			//WindowsFormsSettings.FindPanelBehavior = FindPanelBehavior.Search;
			//         WindowsFormsSettings.FilterCriteriaDisplayStyle = FilterCriteriaDisplayStyle.Visual;
			//         //WindowsFormsSettings.AllowPixelScrolling = DefaultBoolean.True;
			//         AppearanceObject.DefaultFont = new Font("Segoe UI", GetDefaultSize());

			//         WindowsFormsSettings.ScrollUIMode = ScrollUIMode.Touch;
			//         WindowsFormsSettings.CustomizationFormSnapMode = SnapMode.OwnerControl;
			//         WindowsFormsSettings.ColumnFilterPopupMode = ColumnFilterPopupMode.Excel;
			//         WindowsFormsSettings.AllowSkinEditorAttach = DefaultBoolean.True;
		}

		public static float GetDefaultSize()
		{
			return 8.25F;
		}

		public static void InitTitleComboBox(RepositoryItemImageComboBox edit)
		{
			var iCollection = new SvgImageCollection();
			iCollection.Add(Resources.Doctor);
			iCollection.Add(Resources.Miss);
			iCollection.Add(Resources.Mr);
			iCollection.Add(Resources.Mrs);
			iCollection.Add(Resources.Ms);
			iCollection.Add(Resources.Professor);
			edit.Items.Add(new ImageComboBoxItem(GetTitleNameByContactTitle(PersonPrefix.Dr), PersonPrefix.Dr, 0));
			edit.Items.Add(new ImageComboBoxItem(GetTitleNameByContactTitle(PersonPrefix.Miss), PersonPrefix.Miss, 1));
			edit.Items.Add(new ImageComboBoxItem(GetTitleNameByContactTitle(PersonPrefix.Mr), PersonPrefix.Mr, 2));
			edit.Items.Add(new ImageComboBoxItem(GetTitleNameByContactTitle(PersonPrefix.Mrs), PersonPrefix.Mrs, 3));
			edit.Items.Add(new ImageComboBoxItem(GetTitleNameByContactTitle(PersonPrefix.Ms), PersonPrefix.Ms, 4));
			edit.SmallImages = iCollection;
		}
		public static string GetTitleNameByContactTitle(PersonPrefix title)
		{
			switch (title)
			{
				case PersonPrefix.Dr: return Resources.ContactTitleDr;
				case PersonPrefix.Miss: return Resources.ContactTitleMiss;
				case PersonPrefix.Mr: return Resources.ContactTitleMr;
				case PersonPrefix.Mrs: return Resources.ContactTitleMrs;
				case PersonPrefix.Ms: return Resources.ContactTitleMs;
			}
			return string.Empty;
		}

		public static void CheckForUpdate()
		{
			// Called on MainForm_Load after successful login.
			// If newer version available, display LiveUpdateForm so user can decide.
			try
			{
				// Load settings (from DB or defaults)
				var settings = LiveUpdateSettingsProvider.LoadOrDefault(Application.StartupPath);

				// Determine current version (from settings override or executable version)
				string processExe = settings.ProcessToEnd + ".exe";
				string currentVersion = string.IsNullOrWhiteSpace(settings.CurrentVersionNo)
					? GetExternalFileVersion(processExe)
					: settings.CurrentVersionNo;

				// Fetch update info (version.txt |pipe delimited| first field expected = version)
				List<string> info = LiveUpdateHelper.GetUpdateInfo(
					settings.UrlLink,
					settings.VersionFilename,
					Application.StartupPath + @"\",
					0);

				if (info == null || info.Count == 0) return; // Nothing retrieved

				string availableVersion = info[0];

				if (!IsNewerVersion(currentVersion, availableVersion)) return; // Up to date

				// Show update dialog (user can choose to update). Using ShowDialog to block until decision.
				using (var frm = new CheckForUpdateForm())
				{
					frm.ShowDialog();
				}
			}
			catch (Exception ex)
			{
				// Swallow non-critical errors; optionally notify user silently.
				System.Diagnostics.Debug.WriteLine("CheckForUpdate error: " + ex.Message);
			}
		}
		public static void CheckForLiveUpdate()
		{
			// Silently update LiveUpdate.exe (the updater engine) if a newer version exists.
			// Uses remote file 'live.version.txt' (pipe-delimited, first segment = version)
			// Expected archive naming convention: LiveUpdate.<version>.zip containing new engine (optionally prefixed files).
			try
			{
				var settings = LiveUpdateSettingsProvider.LoadOrDefault(Application.StartupPath);
				string engineVersionFile = "live.version.txt"; // remote version descriptor for updater engine

				// Current engine version
				string currentEngineVersion = GetExternalFileVersion("LiveUpdate.exe");

				// Fetch remote engine version info
				List<string> info = LiveUpdateHelper.GetUpdateInfo(
					settings.UrlLink,
					engineVersionFile,
					Application.StartupPath + @"\",
					0);

				if (info == null || info.Count == 0) return; // No info retrieved
				string availableEngineVersion = info[0];

				if (!IsNewerVersion(currentEngineVersion, availableEngineVersion)) return; // Already latest

				// Build expected zip filename
				string zipName = $"LiveUpdate.{availableEngineVersion}.zip";

				// Download and unzip silently
				LiveUpdateHelper.InstallUpdateNow(settings.UrlLink, zipName, Application.StartupPath + @"\", true);

				// Rename any prefixed files to original names (e.g. V1234_LiveUpdate.exe -> LiveUpdate.exe)
				LiveUpdateHelper.UpdateMe(settings.UpdaterPrefix, Application.StartupPath + @"\");

				// Optional: verify and log
				string newVersion = GetExternalFileVersion("LiveUpdate.exe");
				System.Diagnostics.Debug.WriteLine($"LiveUpdate engine updated silently from {currentEngineVersion} to {newVersion}");
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine("Silent LiveUpdate engine update failed: " + ex.Message);
			}
		}

		// Helper copied from LiveUpdateForm (public here for reuse)
		private static bool IsNewerVersion(string current, string available)
		{
			if (Version.TryParse(current, out var cur) && Version.TryParse(available, out var avail))
			{
				return avail > cur;
			}

			// Fallback manual comparison
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
			return false;
		}

		private static string GetExternalFileVersion(string fileName)
		{
			try
			{
				string fullPath = Path.Combine(Application.StartupPath, fileName);
				if (!File.Exists(fullPath)) return "0.0.0.0";
				var fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(fullPath);
				string ver = !string.IsNullOrWhiteSpace(fvi.ProductVersion) ? fvi.ProductVersion : fvi.FileVersion;
				return ver ?? "0.0.0.0";
			}
			catch
			{
				return "0.0.0.0";
			}
		}

		public static bool CheckDatabaseConnection()
		{
			try
			{
				// Use public wrapper to access DataLayers settings
				string host = DatabaseSettings.DatabaseHost;
				int port = DatabaseSettings.DatabasePort;
				string dbName = DatabaseSettings.DatabaseName;
				string user = DatabaseSettings.DatabaseUser;
				string pass = DatabaseSettings.DatabasePassword;
				string fullConn = DatabaseSettings.MongoDbConfigString;

				bool connected = ConnectionHelper.TryConnect(host, port, dbName, user, pass, fullConn);
				if (connected) return true;

				using (var frm = new MongoDbConnectionForm(host, port, dbName, user, pass, fullConn))
				{
					if (frm.ShowDialog() != DialogResult.OK)
						return false;

					DatabaseSettings.DatabaseHost = frm.Host;
					DatabaseSettings.DatabasePort = frm.Port;
					DatabaseSettings.DatabaseName = frm.DatabaseName;
					DatabaseSettings.DatabaseUser = frm.Username;
					DatabaseSettings.DatabasePassword = frm.Password;
					DatabaseSettings.MongoDbConfigString = frm.ConnectionString ?? string.Empty;
					DatabaseSettings.Save();
				}

				return ConnectionHelper.TryConnect(DatabaseSettings.DatabaseHost,
					DatabaseSettings.DatabasePort,
					DatabaseSettings.DatabaseName,
					DatabaseSettings.DatabaseUser,
					DatabaseSettings.DatabasePassword,
					DatabaseSettings.MongoDbConfigString);
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show("Database connection failed: " + ex.Message, "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		public static void ApplyDefaultSettings()
		{

		}

		public static void CheckDefaultFolderStructure()
		{

		}

		//public static string SaveJsonFilterList(IList<InitDataModelExtended> filterList)
		//{
		//	var json = new List<InitDataModelExtended>();

		//	// Write MemberType List from listbox to json array
		//	foreach (var filter in filterList)
		//	{
		//		json.Add(new InitDataModelExtended
		//		{
		//			Name = filter.Name,
		//			Value = filter.Value,
		//			ValuesList = filter.ValuesList
		//		});
		//	}
		//	string jsonString = JsonConvert.SerializeObject(json, Formatting.None,
		//		new JsonSerializerSettings
		//		{ NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented });

		//	return jsonString;
		//}

		//public static IList<InitDataModelExtended> ReadJsonFilterList(string filterList)
		//{
		//	var filterDataList = new List<InitDataModelExtended>();
		//	var jsonList = JsonConvert.DeserializeObject<IList<InitDataModelExtended>>(filterList);

		//	//if (jsonList != null)
		//	//{
		//	//    foreach (var json in jsonList)
		//	//    {
		//	//        jsonList.Add(new InitDataModel{Name = json.Name, Value = json.Value});
		//	//    }
		//	//}
		//	return jsonList;
		//}

		#region Assembly Attribute Accessors

		public static string AssemblyTitle
		{
			get
			{
				// Get all Title attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				// If there is at least one Title attribute
				if (attributes.Length > 0)
				{
					// Select the first one
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					// If it is not an empty string, return it
					if (titleAttribute.Title != "")
						return titleAttribute.Title;
				}
				// If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		public static string AssemblyVersion
		{
			get
			{
				//return Assembly.GetExecutingAssembly().GetName().Version.ToString();   //get assembly version

				System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
				System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
				string version = fvi.FileVersion;  // get file version

				return version;
			}
		}

		public static string AssemblyDescription
		{
			get
			{
				// Get all Description attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				// If there aren't any Description attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Description attribute, return its value
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		public static string AssemblyProduct
		{
			get
			{
				// Get all Product attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				// If there aren't any Product attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Product attribute, return its value
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		public static string AssemblyCopyright
		{
			get
			{
				// Get all Copyright attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				// If there aren't any Copyright attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Copyright attribute, return its value
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		public static string AssemblyCompany
		{
			get
			{
				// Get all Company attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				// If there aren't any Company attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Company attribute, return its value
				return ((AssemblyCompanyAttribute)attributes[0]).Company;
			}
		}
		#endregion

		#region Email Notifications

		public static void NotifyByEmail(string subject, string body)
		{
			try
			{
				//NoReplyMailMessage noReply = new NoReplyMailMessage();

				//noReply.SendEmail(new NoReplyMailModel
				//{
				//	MailFrom = "noreply@xolog.com",
				//	MailDisplayNameFrom = "no-reply",
				//	MailTo = "audit@xolog.com",
				//	MailDisplayNameTo = "Audit",
				//	MailSubject = subject,
				//	MailBody = body,
				//	MailOutgoingPort = 587,
				//	MailHost = "mail.xolog.com",
				//	MailUserName = "noreply@xolog.com",
				//	MailPassword = "Parallax#16"
				//});
			}
			catch (Exception exception)
			{
				XtraMessageBox.Show(exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		public static void SaveCustomFilter(string filterName, string jSonToString)
		{
			try
			{
				if (jSonToString == "")
				{
					throw new Exception("Error while saving content filter. \nPlease contact your system administrator!");
				}
				string filePath = Path.Combine(Path.GetTempPath(), filterName) + ".json";

				if (File.Exists(filePath))
				{
					File.SetAttributes(filePath, FileAttributes.Normal);
					File.Delete(filePath);
				}

				File.WriteAllText(filePath, jSonToString);

				File.SetAttributes(filePath, FileAttributes.Hidden);
				//File.Delete(filePath);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void DeleteCustomFilter(string filterName)
		{
			try
			{
				string filePath = Path.Combine(Path.GetTempPath(), filterName) + ".json";
				//File.SetAttributes(filePath, FileAttributes.Normal);
				File.Delete(filePath);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		public class DetailControlTypeFormatter : IFormatProvider, ICustomFormatter
		{
			public object GetFormat(System.Type formatType)
			{
				if (formatType == typeof(ICustomFormatter))
					return this;
				else
					return null;
			}

			public string Format(string format, object arg, IFormatProvider formatProvider)
			{
				if (arg == null) return String.Empty;
				EnumDebCred value = (EnumDebCred)arg;

				switch (value)
				{
					case EnumDebCred.D:
						return "Debit";
					case EnumDebCred.C:
						return "Credit";
				}

				return string.Empty;
			}

			public enum WorkingYearPeriod
			{
				Year2016 = 2016,
				Year2017 = 2017,
				Year2018 = 2018,
				Year2019 = 2019,
				Year2020 = 2020,
				Year2021 = 2021,
				Year2022 = 2022,
				Year2023 = 2023,
				Year2024 = 2024,
				Year2025 = 2025,
				Year2026 = 2026,
				//Year2027 = 2027,
				//Year2028 = 2028,
				//Year2029 = 2029,
				//Year2030 = 2030,
			}
		}
	}
	public static class SplashScreenHelper
	{
		public static void UpdateFooter(string text)
		{
			var options = new FluentSplashScreenOptions { RightFooter = text };
			SplashScreenManager.Default.SendCommand(FluentSplashScreenCommand.UpdateOptions, options);
		}
	}

}

