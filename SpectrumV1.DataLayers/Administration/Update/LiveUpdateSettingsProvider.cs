using SpectrumV1.Models.Administration.Update;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace SpectrumV1.DataLayers.Administration.Update
{
	public static class LiveUpdateSettingsProvider
	{
		// Attempts to read from DB (AppSettings table, group = 'LiveUpdate').
		// Falls back to defaults on any failure/missing connection string.
		public static LiveUpdateSettingsModel LoadOrDefault(string startupPath)
		{
			var settings = LiveUpdateSettingsModel.CreateDefaults(startupPath);

			try
			{
				var cs = ConfigurationManager.ConnectionStrings["AppDb"];
				if (cs == null || string.IsNullOrWhiteSpace(cs.ConnectionString))
					return settings;

				using (var conn = new SqlConnection(cs.ConnectionString))
				using (var cmd = new SqlCommand(
					"SELECT SettingKey, SettingValue FROM AppSettings WHERE SettingGroup = @grp", conn))
				{
					cmd.Parameters.AddWithValue("@grp", "LiveUpdate");
					conn.Open();
					using (var rdr = cmd.ExecuteReader())
					{
						var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
						while (rdr.Read())
						{
							var key = rdr["SettingKey"] as string;
							var val = rdr["SettingValue"] as string;
							if (!string.IsNullOrWhiteSpace(key))
								dict[key] = val ?? string.Empty;
						}
						Apply(dict, settings);
					}
				}
			}
			catch
			{
				// Swallow and keep defaults to avoid breaking startup if DB is unavailable
			}

			settings.ComputeDerived(startupPath);
			return settings;
		}

		private static void Apply(IDictionary<string, string> kv, LiveUpdateSettingsModel s)
		{
			if (kv == null) return;

			if (kv.TryGetValue("UpdaterPrefix", out var v)) s.UpdaterPrefix = v;
			if (kv.TryGetValue("ProcessToEnd", out v)) s.ProcessToEnd = v;
			if (kv.TryGetValue("PostProcess", out v)) s.PostProcess = v;
			if (kv.TryGetValue("Updater", out v)) s.Updater = v;

			if (kv.TryGetValue("UpdateSuccess", out v)) s.UpdateSuccess = v;
			if (kv.TryGetValue("UpdateCurrent", out v)) s.UpdateCurrent = v;
			if (kv.TryGetValue("UpdateInfoError", out v)) s.UpdateInfoError = v;

			if (kv.TryGetValue("UrlLink", out v)) s.UrlLink = v;
			if (kv.TryGetValue("CurrentVersionNo", out v)) s.CurrentVersionNo = v;
			if (kv.TryGetValue("NewVersionNo", out v)) s.NewVersionNo = v;
			if (kv.TryGetValue("VersionFilename", out v)) s.VersionFilename = v;
		}
	}

}
