using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using SpectrumV1.Models.Users;
using SpectrumV1.Properties;
using SpectrumV1.Utilities;
using SpectrumV1.Utilities.Interfaces;
using SpectrumV1.Utilities.Layout;
using SpectrumV1.Views.Main.Update;
using SpectrumV1.Views.Users;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SpectrumV1.Views.Main
{
	public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		private const string _formName = "MainForm";
		private int _formId;




		private bool _isVisible;
		private bool _isActive;
		private bool _isAdmin;

		private bool _resetMenu;
		private readonly bool _logOut;

		public MainForm()
		{
			InitializeComponent();

			InitializeBindings();
			WireUpBindings();
			ApplyPermissions();
			ApplyDefaults();

			UpdateStatus();

			_logOut = true;
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			HelperApplication.CheckForUpdate();
		}
		
		private void MainForm_Activated(object sender, EventArgs e)
		{
			try
			{
				var af = ActiveMdiChild as IFormWithRibbon;
				if (af == null) return;
				ribbonMainForm.SelectedPage = ribbonMainForm.MergedPages[af.DefaultPage.Text];

				UpdateStatus();
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception);
			}
		}

		private void MainForm_MdiChildActivate(object sender, EventArgs e)
		{
			try
			{
				var af = ActiveMdiChild as IFormWithRibbon;
				if (af == null) return;
				ribbonMainForm.SelectedPage = ribbonMainForm.MergedPages[af.DefaultPage.Text];

				UpdateStatus();
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception);
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			var settings = Settings.Default;
			settings.SkinName = UserLookAndFeel.Default.SkinName;
			settings.Palette = UserLookAndFeel.Default.ActiveSvgPaletteName;
			if (!_resetMenu)
			{
				LayoutsStyle.SaveLayoutMenu(mainMenu, CurrentUser.UserName);
			}
		}

		#region Loading Region

		private void InitializeBindings()
		{

		}

		private void WireUpBindings()
		{

		}

		private void ApplyDefaults()
		{

		}

		private void ApplyPermissions()
		{

		}

		private void UpdateStatus()
		{
			//Get HOST NAME
			statusHost.Caption = @"Host: " + CurrentUser.HostName;
			statusDatabase.Caption = @"Database: " + CurrentUser.DatabaseName;
			statusAppName.Caption = @"App: " + HelperApplication.AssemblyDescription;
			statusVersion.Caption = Resources.VERSION + @" " + HelperApplication.AssemblyVersion;

			statusCompanyName.Caption = Resources.COMPANY_NAME + @" " + CurrentUser.CompanyName;
			statusUserName.Caption = Resources.USER_NAME + @" " + CurrentUser.UserName;
			statusDate.Caption = Resources.TODAY + @" " + DateTime.Now.ToLongDateString();
		}

		#endregion

		#region Buttons Event

		private void btnEnd_ItemClick(object sender, ItemClickEventArgs e)
		{
			Application.Exit();
		}

		private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
		{
			ExitAndClean();
		}

		private void btnAbout_ItemClick(object sender, ItemClickEventArgs e)
		{
			AboutForm dForm = new AboutForm();
			dForm.ShowDialog();
		}

		private void btnLiveUpdate_ItemClick(object sender, ItemClickEventArgs e)
		{
			CheckForUpdateForm dForm = new CheckForUpdateForm();
			dForm.ShowDialog();
		}

		private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
		{

		}

		private void btnResetLayout_ItemClick(object sender, ItemClickEventArgs e)
		{

		}

		#endregion

		#region CloseForm
		private void ExitAndClean()
		{
			//main form close
			if (_logOut)
			{
				Settings.Default.ApplicationSkinName = defaultLookAndFeel1.LookAndFeel.SkinName;
				Settings.Default.ApplicationPalette = defaultLookAndFeel1.LookAndFeel.ActiveSvgPaletteName;

				Settings.Default.Save();
				Close();
			}
		}


		#endregion

		private void OpenForm<T>(T myForm, bool isDialog = false) where T : Form
		{
			try
			{
				if (!Application.OpenForms.OfType<T>().Any())
				{
					if (!isDialog) myForm.MdiParent = this;

					myForm.Show();
				}
				else
				{
					Application.OpenForms[myForm.Name]?.Focus();
					//myForm.Focus();
				}
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message, "Main OpenForm Error Message!", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void mnuUsersList_Click(object sender, System.EventArgs e)
		{
			OpenForm(new UsersListForm());
		}


	}
}