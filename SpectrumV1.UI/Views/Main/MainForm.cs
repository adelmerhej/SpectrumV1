using DevExpress.XtraBars;
using SpectrumV1.Properties;
using SpectrumV1.Utilities;
using SpectrumV1.Views.Main.Update;
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


	}
}