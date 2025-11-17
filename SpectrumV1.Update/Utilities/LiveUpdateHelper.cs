using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Ionic.Zip;

namespace SpectrumV1.Update.Utilities
{
	public class LiveUpdateHelper
	{
		/// <summary>Get update and version information from specified online file - returns a List</summary>
		/// <param name="downloadsUrl">URL to download file from</param>
		/// <param name="versionFile">Name of the pipe| delimited version file to download</param>
		/// <param name="resourceDownloadFolder">Folder on the local machine to download the version file to</param>
		/// <param name="startLine">Line number, of the version file, to read the version information from</param>
		/// <returns>List containing the information from the pipe delimited version file</returns>
		public static List<string> GetUpdateInfo(string downloadsUrl, string versionFile, string resourceDownloadFolder, int startLine)
		{

			bool updateChecked = false;

			//create download folder if it does not exist
			if (!Directory.Exists(resourceDownloadFolder))
			{
				Directory.CreateDirectory(resourceDownloadFolder);
			}

			//let's try and download update information from the web
			updateChecked = WebData.DownloadFromWeb(downloadsUrl, versionFile, resourceDownloadFolder);

			//if the download of the file was successful
			if (updateChecked)
			{
				//get information out of download info file
				return PopulateInfoFromWeb(versionFile, resourceDownloadFolder, startLine);
			}
			//there is a chance that the download of the file was not successful
			else
			{
				return null;
			}
		}

		/// <summary>Download file from the web immediately</summary>
		/// <param name="downloadUrl">URL to download file from</param>
		/// <param name="filename">Name of the file to download</param>
		/// <param name="downloadTo">Folder on the local machine to download the file to</param>
		/// <param name="unzip">Unzip the contents of the file</param>
		/// <returns>Void</returns>
		public static void InstallUpdateNow(string downloadUrl, string filename, string downloadTo, bool unzip)
		{
			bool downloadSuccess = WebData.DownloadFromWeb(downloadUrl, filename, downloadTo);

			if (unzip)
			{
				UnZip(downloadTo + filename, downloadTo);
			}
		}


		/// <summary>Starts the update application passing across relevant information</summary>
		/// <param name="downloadsUrl">URL to download file from</param>
		/// <param name="filename">Name of the file to download</param>
		/// <param name="destinationFolder">Folder on the local machine to download the file to</param>
		/// <param name="processToEnd">Name of the process to end before applying the updates</param>
		/// <param name="postProcess">Name of the process to restart</param>
		/// <param name="startupCommand">Command line to be passed to the process to restart</param>
		/// <param name="updater"></param>
		/// <returns>Void</returns>
		public static void InstallUpdateRestart(string downloadsUrl, string filename, string destinationFolder, string processToEnd, string postProcess, string startupCommand, string updater)
		{
			// Resolve the updater executable path robustly
			if (string.IsNullOrWhiteSpace(updater))
				throw new ArgumentException("Updater path must be provided.", nameof(updater));

			string resolvedUpdater = updater;

			// If relative path, try relative to destination folder first
			if (!Path.IsPathRooted(resolvedUpdater))
			{
				if (!string.IsNullOrEmpty(destinationFolder))
				{
					string candidate = Path.Combine(destinationFolder, updater);
					if (File.Exists(candidate))
					{
						resolvedUpdater = candidate;
					}
				}
			}

			// If still not found and not rooted, try app base directory
			if (!File.Exists(resolvedUpdater))
			{
				string appBaseCandidate = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, updater);
				if (File.Exists(appBaseCandidate))
				{
					resolvedUpdater = appBaseCandidate;
				}
			}

			if (!File.Exists(resolvedUpdater))
			{
				throw new FileNotFoundException("The updater executable could not be found.", resolvedUpdater);
			}

			// Build the argument string
			var sb = new StringBuilder();
			sb.Append("|downloadFile|").Append(filename ?? string.Empty);
			sb.Append("|URL|").Append(downloadsUrl ?? string.Empty);
			sb.Append("|destinationFolder|").Append(destinationFolder ?? string.Empty);
			sb.Append("|processToEnd|").Append(processToEnd ?? string.Empty);
			sb.Append("|postProcess|").Append(postProcess ?? string.Empty);
			sb.Append("|command|").Append(" / ").Append(startupCommand ?? string.Empty);

			var startInfo = new ProcessStartInfo
			{
				FileName = resolvedUpdater,
				Arguments = sb.ToString(),
				UseShellExecute = false,
				WorkingDirectory = Path.GetDirectoryName(resolvedUpdater) ?? Environment.CurrentDirectory
			};

			Process.Start(startInfo);
		}



		private static List<string> PopulateInfoFromWeb(string versionFile, string resourceDownloadFolder, int line)
		{
			List<string> tempList = new List<string>();
			int ln;
			int i;

			ln = 0;

			foreach (string strline in File.ReadAllLines(resourceDownloadFolder + versionFile))
			{
				if (ln == line)
				{
					string[] parts = strline.Split('|');
					foreach (string part in parts)
					{
						tempList.Add(part);
					}

					return tempList;
				}

				ln++;
			}

			return null;
		}

		private static bool UnZip(string file, string unZipTo)//, bool deleteZipOnCompletion)
		{
			try
			{
				// Specifying Console.Out here causes diagnostic msgs to be sent to the Console
				// In a WinForms or WPF or Web app, you could specify nothing, or an alternate
				// TextWriter to capture diagnostic messages. 

				using (ZipFile zip = ZipFile.Read(file))
				{
					// This call to ExtractAll() assumes:
					//   - none of the entries are password-protected.
					//   - want to extract all entries to current working directory
					//   - none of the files in the zip already exist in the directory;
					//     if they do, the method will throw.
					zip.ExtractAll(unZipTo);
				}

				//if (deleteZipOnCompletion) File.Delete(unZipTo + file);

			}
			catch (System.Exception)
			{
				return false;
			}

			return true;
		}

		/// <summary>Updates the update application by renaming prefixed files</summary>
		/// <param name="updaterPrefix">Prefix of files to be renamed</param>
		/// <param name="containingFolder">Folder on the local machine where the prefixed files exist</param>
		/// <returns>Void</returns>
		public static void UpdateMe(string updaterPrefix, string containingFolder)
		{

			DirectoryInfo dInfo = new DirectoryInfo(containingFolder);
			FileInfo[] updaterFiles = dInfo.GetFiles(updaterPrefix + "*");
			int fileCount = updaterFiles.Length;

			foreach (FileInfo file in updaterFiles)
			{
				string newFile = containingFolder + file.Name;
				string origFile = containingFolder + @"\" + file.Name.Substring(updaterPrefix.Length, file.Name.Length - updaterPrefix.Length);

				if (File.Exists(origFile)) { File.Delete(origFile); }

				File.Move(newFile, origFile);
			}
		}
	}

}
