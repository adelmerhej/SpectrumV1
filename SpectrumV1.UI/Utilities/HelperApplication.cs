using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraSplashScreen;
using SpectrumV1.DataLayers.Administration.Update;
using SpectrumV1.DataLayers.DataAccess;
using SpectrumV1.DataLayers.DataUtilities; // added for MongoDB connection helper & DatabaseSettings
using SpectrumV1.Models.Administration.Connections;
using SpectrumV1.Models.Users;
using SpectrumV1.Properties;
using SpectrumV1.Update.Utilities;
using SpectrumV1.Utilities.Enums;
using SpectrumV1.Views.Main.Connections;    // added for DB settings
using SpectrumV1.Views.Main.Update;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace SpectrumV1.Utilities
{
	public static class HelperApplication
	{
		#region Database Connection Result Types

		/// <summary>
		/// Represents the result of a database connection attempt
		/// </summary>
		private class DatabaseConnectionResult
		{
			public DatabaseConnectionStatus Status { get; set; }
			public ConnectionModel ConnectionModel { get; set; }
			public IDatabase Database { get; set; }
			public string ErrorMessage { get; set; }
		}

		/// <summary>
		/// Represents the status of a database connection attempt
		/// </summary>
		private enum DatabaseConnectionStatus
		{
			Success,
			DatabaseNotFound,
			ConnectionFailed,
			ConfigurationRequired
		}

		#endregion

		#region Check for Application Update

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
		
		#endregion


		#region Database Connection
		public static bool CheckDatabaseConnection()
		{
			const int maxRetryAttempts = 3;
			int currentAttempt = 0;

			while (true)
			{
				try
				{
					currentAttempt++;
					var connectionResult = AttemptDatabaseConnection();

					switch (connectionResult.Status)
					{
						case DatabaseConnectionStatus.Success:
							return true;

						case DatabaseConnectionStatus.DatabaseNotFound:
							if (HandleDatabaseNotFound(connectionResult.ConnectionModel))
								return CheckDatabaseConnection(); // Retry after database creation
							return false;

						case DatabaseConnectionStatus.ConnectionFailed:
							if (currentAttempt >= maxRetryAttempts)
							{
								return HandleConnectionFailure();
							}
							break;

						case DatabaseConnectionStatus.ConfigurationRequired:
							return HandleConfigurationRequired();

						default:
							return false;
					}
				}
				catch (Exception ex)
				{
					if (currentAttempt >= maxRetryAttempts)
					{
						return HandleCriticalError(ex);
					}

					// Log the error for debugging purposes
					System.Diagnostics.Debug.WriteLine($"Database connection attempt {currentAttempt} failed: {ex.Message}");
				}
			}

			return false;
		}

		/// <summary>
		/// Attempts to establish database connection and returns detailed result
		/// </summary>
		private static DatabaseConnectionResult AttemptDatabaseConnection()
		{
			try
			{
				var connectionModel = DatabaseFactory.ConnectionParamsGet();

				if (connectionModel == null || string.IsNullOrWhiteSpace(connectionModel.DatabaseHost))
				{
					return new DatabaseConnectionResult
					{
						Status = DatabaseConnectionStatus.ConfigurationRequired,
						ConnectionModel = connectionModel,
						ErrorMessage = "Database configuration is missing or invalid"
					};
				}

				var database = DatabaseFactory.Get(connectionModel.DatabaseName, connectionModel.DatabaseType,
								connectionModel.DatabaseHost, connectionModel.DatabasePort, connectionModel.DatabaseName,
								connectionModel.DatabaseUser, connectionModel.DatabasePassword);

				var connectionState = database.CheckConnection();

				if (connectionState == ConnectionState.Open)
				{
					if (database.AllowCreateDataBase() && !database.CheckDatabaseExists(connectionModel.DatabaseName))
					{
						return new DatabaseConnectionResult
						{
							Status = DatabaseConnectionStatus.DatabaseNotFound,
							ConnectionModel = connectionModel,
							Database = database
						};
					}

					// Update current user context on successful connection
					UpdateUserContext(connectionModel);

					return new DatabaseConnectionResult
					{
						Status = DatabaseConnectionStatus.Success,
						ConnectionModel = connectionModel,
						Database = database
					};
				}

				return new DatabaseConnectionResult
				{
					Status = DatabaseConnectionStatus.ConnectionFailed,
					ConnectionModel = connectionModel,
					ErrorMessage = $"Connection failed. State: {connectionState}"
				};
			}
			catch (Exception ex)
			{
				return new DatabaseConnectionResult
				{
					Status = DatabaseConnectionStatus.ConnectionFailed,
					ConnectionModel = null,
					ErrorMessage = $"Exception occurred: {ex.Message}"
				};
			}
		}

		/// <summary>
		/// Handles the case when database is not found and prompts user for action
		/// </summary>
		private static bool HandleDatabaseNotFound(ConnectionModel connectionModel)
		{
			var userChoice = SafeShowMessageBox($"The database '{connectionModel.DatabaseName}' could not be found.\n\nWould you like to create it?", 
				"Database Not Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			return false;
		}

		/// <summary>
		/// Handles connection failure by showing configuration dialog
		/// </summary>
		private static bool HandleConnectionFailure()
		{
			SafeShowMessageBox(
				"Unable to connect to the database. Please check your connection settings.",
				"Connection Failed",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error);

			return ShowServerConfigurationDialog();
		}

		/// <summary>
		/// Handles configuration requirement by showing configuration dialog
		/// </summary>
		private static bool HandleConfigurationRequired()
		{
			SafeShowMessageBox(
				"Database configuration is required. Please configure your database settings.",
				"Configuration Required",
				MessageBoxButtons.OK,
				MessageBoxIcon.Warning);

			return ShowServerConfigurationDialog();
		}

		/// <summary>
		/// Handles critical errors during database connection
		/// </summary>
		private static bool HandleCriticalError(Exception ex)
		{
			SafeShowMessageBox(
				$"A critical error occurred while connecting to the database:\n\n{ex.Message}\n\nPlease check your configuration and try again.",
				"Critical Database Error",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error);

			return ShowServerConfigurationDialog();
		}

		/// <summary>
		/// Shows server configuration dialog and returns success status
		/// </summary>
		private static bool ShowServerConfigurationDialog()
		{
			try
			{
					// Fix for CS8370: Use traditional using statement instead of using declaration
				using (var configForm = new ServerConfigurationForm())
				{
					return configForm.ShowDialog() == DialogResult.OK;
				}
			}
			catch (Exception ex)
			{
				SafeShowMessageBox(
					$"Failed to open configuration dialog: {ex.Message}",
					"Configuration Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return false;
			}
		}

		/// <summary>
		/// Updates current user context with connection information
		/// </summary>
		private static void UpdateUserContext(ConnectionModel connectionModel)
		{
			if (connectionModel != null)
			{
				CurrentUser.HostName = connectionModel.DatabaseHost;
				CurrentUser.DatabaseName = connectionModel.DatabaseName;
			}
		}

		#endregion


		public static void ApplyDefaultSettings()
		{

		}

		#region Thread-Safe MessageBox

		/// <summary>
		/// Thread-safe method to show message boxes that can be called from any thread
		/// </summary>
		public static DialogResult SafeShowMessageBox(string message, string caption = "Error", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Error)
		{
			DialogResult result = DialogResult.OK;
			try
			{
				if (Application.OpenForms.Count > 0 && Application.OpenForms[0] != null)
				{
					var mainForm = Application.OpenForms[0];
					if (mainForm.InvokeRequired)
					{
						result = (DialogResult)mainForm.Invoke(new Func<DialogResult>(() =>
						{
							return XtraMessageBox.Show(message, caption, buttons, icon);
						}));
					}
					else
					{
						result = XtraMessageBox.Show(message, caption, buttons, icon);
					}
				}
				else
				{
					// Fallback to standard MessageBox if no forms are available
					result = MessageBox.Show(message, caption, buttons, icon);
				}
			}
			catch (Exception ex)
			{
				// Last resort: use standard MessageBox
				try
				{
					result = MessageBox.Show($@"Error displaying message: {ex.Message}\nOriginal message: {message}",
						@"Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch
				{
					// If even this fails, write to debug output
					System.Diagnostics.Debug.WriteLine($"Critical error: {ex.Message}, Original: {message}");
				}
			}
			return result;
		}

		#endregion

	}
}

