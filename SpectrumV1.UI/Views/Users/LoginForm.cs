using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using SpectrumV1.DataLayers.Common.Companies;
using SpectrumV1.DataLayers.Common.Forms;
using SpectrumV1.DataLayers.Users;
using SpectrumV1.Models.Common.Companies;
using SpectrumV1.Models.Users;
using SpectrumV1.Utilities;
using SpectrumV1.Utilities.Common;
using SpectrumV1.Utilities.Layout;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SpectrumV1.Properties;

namespace SpectrumV1.Views.Users
{
	public partial class LoginForm : XtraForm
	{
		private const string _formName = "LoginForm";
		private int _formId;

		private UserModel _userModel = new UserModel();
		private IList<CompanyModel> _companies = new List<CompanyModel>();

		private CompanyRepository _companyRepository = new CompanyRepository();
		private BranchRepository _branchRepository = new BranchRepository();

		private readonly UserRepository _userRepository = new UserRepository();

		/// <summary>
		/// User Permission Role
		/// </summary>
		private IList<UserPermissionModel> _userPermission = new List<UserPermissionModel>();
		private readonly UserPermissionRepository _userPermissionRepository = new UserPermissionRepository();
		private readonly FormRepository _formRepository = new FormRepository();
		private readonly LogInfoRepository _logInfoRepository = new LogInfoRepository();

		private bool _canEdit;
		private bool _isAdmin;
		private bool _isProtected = false;

		private int _selectedCompany = 0;

		public LoginForm()
		{
			InitializeComponent();

			InitializeBindings();
			WireUpBindings();
			ApplyDefaults();
			ApplyPermissions();
		}

		private void InitializeBindings()
		{
			//try
			//{
			//	//
			//	_formId = _formRepository.SelectFormByName(_formName);
			//	_userPermission = _userPermissionRepository.SelectUserPermissionById(CurrentUser.UserId, _formId);
			//	if (_userPermission is { Count: > 0 })
			//	{
			//		var isProtected = _userPermission.SingleOrDefault(x => x.ControlName == "IsProtected")?.Value;
			//		if (isProtected != null) _isProtected = (bool)isProtected;
			//	}
			//	//
			//	_companies = _companyRepository.SelectCompanies();
			//}
			//catch (Exception ex)
			//{
			//	XtraMessageBox.Show(ex.Message, @"Error Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//}
		}

		private void WireUpBindings()
		{
			cboCompanies.Properties.DataSource = null;
			cboCompanies.Properties.DataSource = _companies;
		}

		private void ApplyDefaults()
		{
			//lnkAbout.Text = $@"About {Settings.Default.ApplicationName.Trim()}";
		}

		private void ApplyPermissions()
		{
			if (_userPermission == null) return;
			if (_userPermission.Count <= 0) return;

			//var canEdit = _userPermission.SingleOrDefault(x => x.ControlName == "CanEdit")?.Value;
			//if (canEdit != null) _canEdit = (bool)canEdit;

			//var isAdmin = _userPermission.SingleOrDefault(x => x.ControlName == "IsAdmin")?.Value;
			//if (isAdmin != null) _isAdmin = (bool)isAdmin;

		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			//if (!ValidateRequiredDataForm()) return;

			//_selectedCompany = (int)cboCompanies.EditValue;
			//if (_selectedCompany != Settings.Default.CompanyId) ChangeConnection();

			DialogResult = DialogResult.OK;
			Close();

			//try
			//{
			//	int companyId = 0;
			//	if (cboCompanies.EditValue != null) companyId = (int)cboCompanies.EditValue;
			//	CurrentUser.CompanyId = companyId;

			//	_userModel = _userRepository.GetUsersByName(txtUserName.Text.Trim(), _isProtected);

			//	if (_userModel == null)
			//	{
			//		XtraMessageBox.Show(@"Invalid user. Contact your System Administrator.", @"Error Login",
			//			MessageBoxButtons.OK, MessageBoxIcon.Error);

			//		return;
			//	}

			//	SystemUtilities.PasswordHasher = new PasswordHasher();

			//	var newPassword = SystemUtilities.PasswordHasher.HashPassword("david");
			//	var varGuid = Guid.NewGuid();

			//	var passwordVerificationResult =
			//		SystemUtilities.PasswordHasher.VerifyHashedPassword(_userModel.PasswordHash, txtPassword.Text);

			//	switch (passwordVerificationResult)
			//	{
			//		case PasswordVerificationResult.Failed:
			//			XtraMessageBox.Show(@"Username or Password are incorrect! Please try again.", @"Error",
			//				MessageBoxButtons.OK, MessageBoxIcon.Error);
			//			txtPassword.Text = "";
			//			txtUserName.Text = "";
			//			txtUserName.Focus();
			//			return;

			//		case PasswordVerificationResult.Success:

			//			break;

			//		case PasswordVerificationResult.SuccessRehashNeeded:

			//			break;
			//	}

			//	CurrentUser.UserId = _userModel.Id;

			//	//TODO: we should assign branch to Company/user or to be selective by permission
			//	//if (cboCompanies.EditValue != null) CurrentUserModel.BranchId = _branchRepository.SelectBranchByCompanyId(CurrentUserModel.CompanyId);
			//	if (cboCompanies.EditValue != null)
			//	{
			//		CurrentUser.CompanyId = (int)cboCompanies.EditValue;
			//		CurrentUser.CompanyName = cboCompanies.Text;

			//		BranchModel branchModel = _branchRepository.SelectBranchByCompanyId(CurrentUser.CompanyId);
			//		if (branchModel != null)
			//		{
			//			CurrentUser.BranchId = _branchRepository.SelectBranchByCompanyId(CurrentUser.CompanyId)?.Id;
			//			CurrentUser.BranchName = _branchRepository.SelectBranchByCompanyId(CurrentUser.CompanyId).Name;
			//		}
			//	}

			//	CurrentUser.UserName = _userModel.UserName;
			//	CurrentUser.WorkingYear = DateTime.Now.Year;

			//	if (_userModel.FirstTimeAccess) ApplyFirstTimeSettings();
			//	if (_userModel.PermissionChanged) RefreshUserPermission();

			//	CheckAndSaveSettings();
			//	DialogResult = DialogResult.OK;
			//}
			//catch (Exception)
			//{
			//	XtraMessageBox.Show(@"Invalid username or password. Please try again.", @"Error Login",
			//		MessageBoxButtons.OK, MessageBoxIcon.Error);
			//}
		}

		private bool ValidateRequiredDataForm()
		{
			if (string.IsNullOrEmpty(txtUserName.Text))
			{
				XtraMessageBox.Show(@"Login Username cannot be empty! Please try again.", @"Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);

				txtUserName.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtPassword.Text))
			{
				XtraMessageBox.Show(@"Login Password cannot be empty! Please try again.", @"Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);

				txtPassword.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(cboCompanies.Text))
			{
				XtraMessageBox.Show(@"Company cannot be empty! Please try again.", @"Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);

				cboCompanies.Focus();
				return false;
			}

			return true;
		}

		private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (DialogResult != DialogResult.OK)
			{
				DialogResult = DialogResult.No;
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
			Close();
		}

		private void LoginForm_Load(object sender, EventArgs e)
		{
			txtUserName.Focus();
			//txtUserName.Text = string.Empty;
			//txtPassword.Text = string.Empty;
			chkSavePassword.Checked = false;
			cboCompanies.EditValue = Settings.Default.CompanyId;
			if (Settings.Default.SavePassword)
			{
				txtUserName.Text = Settings.Default.UserName;
				txtPassword.Text = Settings.Default.UserPassword;
				chkSavePassword.Checked = Settings.Default.SavePassword;
			}
		}
		private void ApplyFirstTimeSettings()
		{
			//if (_userModel.UserName.ToLower() != "admin") return;

			//_userPermissionRepository.SeedUserPermissionsData(_userModel.Id, _userModel.UserName.ToLower() == "admin");
			//_userModel.FirstTimeAccess = false;
			//_userRepository.UpdateUser(_userModel);
		}
		private void RefreshUserPermission()
		{
			LayoutsStyle.ResetLayoutMenu("mainMenu", CurrentUser.UserName);

			//_userModel.PermissionChanged = false;
			//_userRepository.UpdateUser(_userModel);
		}

		private void CheckAndSaveSettings()
		{
			if (chkSavePassword.Checked)
			{
				Settings.Default.UserName = txtUserName.Text;
				Settings.Default.UserPassword = txtPassword.Text;
			}
			else
			{
				Settings.Default.UserName = string.Empty;
				Settings.Default.UserPassword = string.Empty;
			}

			Settings.Default.SavePassword = chkSavePassword.Checked;
			Settings.Default.CompanyId = (int)cboCompanies.EditValue;
			Settings.Default.Save();
		}

		private void lnkChangePassword_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtUserName.Text == "")
				{
					XtraMessageBox.Show(this,
						"You have to authenticate your username to change its password.\nOtherwise contact your system administrator.",
						"Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					txtUserName.Focus();
					return;
				}

				if (cboCompanies.Text == "")
				{
					XtraMessageBox.Show(this,
						"Company name cannot be empty, choose your company.",
						"Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					cboCompanies.Focus();
					return;
				}
				//var changeUserModel = _userRepository.GetUsersByName(txtUserName.Text.Trim());
				//if (txtUserName.Text == string.Empty || changeUserModel == null)
				//{
				//	XtraMessageBox.Show($"Invalid username [ {txtUserName.Text} ].", "Change Password",
				//		MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				//	return;
				//}

				//ChangePasswordForm _frm = new ChangePasswordForm(changeUserModel);
				//_frm.SendChangedPassword += RcvChangedPassword;

				//_frm.ShowDialog();
			}
			catch (Exception exception)
			{
				XtraMessageBox.Show(exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void RcvChangedPassword(object sender, EventArgs e)
		{
			var newUserModel = sender as UserModel;

			if (sender == null) return;
			if (newUserModel != null)
			{
				txtPassword.Text = "";
			}
		}

		private void txtPassword_ButtonClick(object sender, ButtonPressedEventArgs e)
		{
			ButtonEdit edit = sender as ButtonEdit;
			if (edit != null) edit.Properties.PasswordChar = (edit.Properties.PasswordChar == '*') ? '\0' : '*';
		}

		private void txtPassword_MouseLeave(object sender, EventArgs e)
		{
			ButtonEdit edit = sender as ButtonEdit;
			if (edit != null) edit.Properties.PasswordChar = edit.Properties.PasswordChar = '*';
		}
		private void ChangeConnection()
		{
			//var connectionModel = DatabaseFactory.ConnectionParamsGet();

			//var companyDb = new CompanyRepository().SelectCompanyById(_selectedCompany)
			//	?.DirectoryPath;
			//if (companyDb == null)
			//{
			//	XtraMessageBox.Show("Invalid Company or Company DB not set.\nPlease contact your system administrator.", @"Error Login",
			//		MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	return;
			//}
			//connectionModel.DatabaseName = companyDb;
			//DatabaseFactory.ConnectionParamsSet(connectionModel);

			//Settings.Default.UpgradeRequired = true;
			//Settings.Default.Save();
		}

		private void cboCompanies_EditValueChanged(object sender, EventArgs e)
		{
			if (cboCompanies.EditValue != null) CurrentUser.CompanyId = (int)cboCompanies.EditValue;
		}


	}
}