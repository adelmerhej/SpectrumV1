using DevExpress.LookAndFeel;
using DevExpress.Utils.Taskbar;
using DevExpress.XtraEditors;
using SpectrumV1.Properties;
using SpectrumV1.Views.Main;
using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using SpectrumV1.Utilities;
using SpectrumV1.Views.Users;

namespace SpectrumV1
{
	internal static class Program
	{
		private static Mutex _appMutex;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			SetDpiScaling();

			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
			Application.ThreadException += Application_ThreadException;

			string appGuid = GetApplicationGuid();
			_appMutex = new Mutex(true, $"{{{appGuid}}}", out var createdNew);

			if (!createdNew)
			{
				XtraMessageBox.Show("Another instance is already running.", "Multi-Instance Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				Application.Exit();
				return;
			}

			try
			{
				DevExpress.UserSkins.BonusSkins.Register();
				DevExpress.Skins.SkinManager.EnableFormSkins();

				TaskbarAssistant.Default.Initialize();
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				UserLookAndFeel.Default.SetSkinStyle(Settings.Default.ApplicationSkinName, Settings.Default.ApplicationPalette);

				if (!LoadingProcessAsync().Result)
				{
					Application.Exit();
					return;
				}

				using (var loginForm = new LoginForm())
				{
					if (loginForm.ShowDialog() == DialogResult.No)
					{
						Application.Exit();
						return;
					}
				}

				Thread.CurrentThread.Name = "ThreadMain";
				Application.Run(new MainForm());
			}
			catch (Exception ex)
			{
				HandleCriticalError(ex);
			}
			finally
			{
				GC.KeepAlive(_appMutex); // Prevent premature disposal
			}
		}

		private static async Task<bool> LoadingProcessAsync()
		{
			try
			{
				var options = new FluentSplashScreenOptions
				{
					Title = "When Only The Best Will Do",
					Subtitle = Settings.Default.ApplicationName,
					LeftFooter = $"Copyright © {DateTime.Now.Year} {Settings.Default.CompanyName}{Environment.NewLine}All Rights Reserved.",
					RightFooter = "Starting...",
					LoadingIndicatorType = FluentLoadingIndicatorType.Dots,
					OpacityColor = Color.FromArgb(16, 110, 190),
					Opacity = 130
				};

				SplashScreenManager.ShowFluentSplashScreen(options, useFadeIn: true, useFadeOut: true);

				//Check for application updates
				options.RightFooter = "Finishing...";
				SplashScreenManager.Default.SendCommand(FluentSplashScreenCommand.UpdateOptions, options);
				HelperApplication.CheckForLiveUpdate();
				await Task.Delay(200); // Simulate async delay

				options.RightFooter = "Checking Database Connection...";
				SplashScreenManager.Default.SendCommand(FluentSplashScreenCommand.UpdateOptions, options);
				if (!await Task.Run(() => HelperApplication.CheckDatabaseConnection()))
				{
					goto CleanAndExit;
				}

				options.RightFooter = "Applying Default Settings...";
				SplashScreenManager.Default.SendCommand(FluentSplashScreenCommand.UpdateOptions, options);
				await Task.Run(() => HelperApplication.ApplyDefaultSettings());

				options.RightFooter = "Finalizing Initialization...";
				SplashScreenManager.Default.SendCommand(FluentSplashScreenCommand.UpdateOptions, options);
				await Task.Delay(200); // Simulate async delay

				return true;
			}
			catch (Exception ex)
			{
				HandleCriticalError(ex);
				return false;
			}
			finally
			{
				SplashScreenManager.CloseForm();
			}

			CleanAndExit:
			SplashScreenManager.CloseForm();
			return false;
		}

		private static string GetApplicationGuid()
		{
			object[] attributes = Assembly.GetEntryAssembly()?.GetCustomAttributes(typeof(GuidAttribute), false);
			if (attributes != null && attributes.Length > 0)
				return ((GuidAttribute)attributes[0]).Value;

			// Fallback: use assembly name or version
			return Assembly.GetEntryAssembly()?.GetName().Name;
		}

		private static void SetDpiScaling()
		{
			if (!SystemInformation.TerminalServerSession && Screen.AllScreens.Length > 1)
			{
				WindowsFormsSettings.SetPerMonitorDpiAware();
			}
			else
			{
				WindowsFormsSettings.SetDPIAware();
			}
		}

		private static void HandleCriticalError(Exception ex)
		{
			XtraMessageBox.Show(
				$"Program Main Error: {ex.Message}{Environment.NewLine}StackTrace: {ex.StackTrace}",
				"Critical Error",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error
			);

			NotificationException(ex);
			Application.Exit();
		}

		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			XtraMessageBox.Show(e.Exception.Message, "Unhandled Thread Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
			NotificationException(e.Exception);
		}

		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			var ex = e.ExceptionObject as Exception;
			XtraMessageBox.Show(ex?.Message ?? "Unknown exception", "Unhandled UI Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
			NotificationException(ex);
		}

		private static void NotificationException(Exception ex)
		{
			Task.Run(() =>
			{
				try
				{
					// Log to file, DB, or external service
					// _logger.Error($"Unhandled Exception: {ex.Message}{Environment.NewLine}StackTrace: {ex.StackTrace}");
				}
				catch
				{
					// Ignore logging errors
				}
			});
		}
	}
}
