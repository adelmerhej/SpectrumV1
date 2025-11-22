using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using SpectrumV1.DataLayers.Common.Branches;
using SpectrumV1.DataLayers.Common.Companies;
using SpectrumV1.DataLayers.Common.Forms;
using SpectrumV1.DataLayers.Users;
using SpectrumV1.Models.Common.Companies;
using SpectrumV1.Models.Users;
using SpectrumV1.Properties;
using SpectrumV1.Utilities;
using SpectrumV1.Utilities.Layout;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

			StartLoading();
		}

		private async void StartLoading()
		{
			await InitializeBindings();
			WireUpBindings();
			ApplyDefaults();
			ApplyPermissions();

		}

		private void LoginForm_Load(object sender, EventArgs e)
		{
			txtUsername.Focus();
			chkSavePassword.Checked = false;
			cboCompanies.EditValue = Settings.Default.CompanyName;
			if (Settings.Default.SavePassword)
			{
				txtUsername.Text = Settings.Default.UserName;
				txtPassword.Text = Settings.Default.UserPassword;
				chkSavePassword.Checked = Settings.Default.SavePassword;
			}
		}

		private async Task InitializeBindings()
		{
			try
			{
				//	//
				//	_formId = _formRepository.SelectFormByName(_formName);
				//	_userPermission = _userPermissionRepository.SelectUserPermissionById(CurrentUser.UserId, _formId);
				//	if (_userPermission is { Count: > 0 })
				//	{
				//		var isProtected = _userPermission.SingleOrDefault(x => x.ControlName == "IsProtected")?.Value;
				//		if (isProtected != null) _isProtected = (bool)isProtected;
				//	}
				//	//
				_companies = await _companyRepository.GetCompaniesAsync();
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message, @"Error Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
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

		private async void btnLogin_Click(object sender, EventArgs e)
		{
			if (!ValidateData()) return;

			try
			{
				using (var userRepository = new UserRepository())
				{
					var loginService = new SpectrumV1.BusinessLogic.Users.LoginService(userRepository);
					var user = await loginService.AuthenticateAsync(txtUsername.Text.Trim(), txtPassword.Text);

					if (user == null)
					{
						XtraMessageBox.Show(@"Username or Password are incorrect! Please try again.", @"Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						txtPassword.Text = string.Empty;
						txtUsername.Focus();
						return;
					}

					//If user is found, and/or (FirstTimeAccess and must change password on next logon) 
					// open CreateNewPasswordForm and force user to change password
					if (user.ChangePasswordNextLogon)
					{
						using (var changePasswordForm = new CreateNewPasswordForm(user))
						{
							changePasswordForm.SendChangedPassword += RcvChangedPassword;
							var result = changePasswordForm.ShowDialog();

							if (result != DialogResult.OK)
							{
								XtraMessageBox.Show(@"You must change your password before you can continue.", 
									@"Change Password Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								return;
							}
						}
					}


					// Set current user context
					CurrentUser.UserName = user.Username;
					CurrentUser.WorkingYear = DateTime.Now.Year;

					// Resolve selected company context (optional future logic)
					if (cboCompanies.EditValue != null)
					{
						CurrentUser.Company = cboCompanies.EditValue.ToString();
						CurrentUser.CompanyName = cboCompanies.Text;
					}

					// Persist remembered credentials
					CheckAndSaveSettings();

					DialogResult = DialogResult.OK;
				}
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message, @"Error Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private bool ValidateData()
		{
			var validateReturnValue = true;
			//var messageNumber = 0;
			var validateMessage = new StringBuilder();

			if (string.IsNullOrEmpty(txtUsername.Text))
			{
				//messageNumber += 1;
				validateMessage.Append("\n- Username cannot be empty.");
				validateReturnValue = false;
				txtUsername.Focus();
			}

			if (string.IsNullOrEmpty(txtPassword.Text))
			{
				//messageNumber += 1;
				validateMessage.Append("\n- Password cannot be empty.");
				validateReturnValue = false;
				txtPassword.Focus();
			}

			if (string.IsNullOrEmpty(cboCompanies.Text))
			{
				//messageNumber += 1;
				validateMessage.Append("\n- Company cannot be empty.");
				validateReturnValue = false;
				cboCompanies.Focus();
			}

			if (!validateReturnValue)
			{
				validateMessage.Insert(0, "The following need your attention:");
				//if (messageNumber > 1) validateMessage.Replace("following", "followings");
				XtraMessageBox.Show(validateMessage + " \nPlease try again.",
					"Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			return validateReturnValue;
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

		private void CheckAndSaveSettings()
		{
			if (chkSavePassword.Checked)
			{
				Settings.Default.UserName = txtUsername.Text;
				Settings.Default.UserPassword = txtPassword.Text;
			}
			else
			{
				Settings.Default.UserName = string.Empty;
				Settings.Default.UserPassword = string.Empty;
			}

			Settings.Default.SavePassword = chkSavePassword.Checked;
			Settings.Default.CompanyName = cboCompanies.EditValue.ToString();
			Settings.Default.Save();
		}

		private async void lnkChangePassword_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtUsername.Text == "")
				{
					XtraMessageBox.Show(this,
						"You have to authenticate your username to change its password.\nOtherwise contact your system administrator.",
						"Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					txtUsername.Focus();
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
				var changeUserModel = await _userRepository.GetUserByNameAsync(txtUsername.Text.Trim());
				if (txtUsername.Text == string.Empty || changeUserModel == null)
				{
					XtraMessageBox.Show($"Invalid username [ {txtUsername.Text} ].", "Change Password",
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}

				ChangePasswordForm _frm = new ChangePasswordForm(changeUserModel);
				_frm.SendChangedPassword += RcvChangedPassword;

				_frm.ShowDialog();
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
			if (cboCompanies.EditValue != null) CurrentUser.Company = cboCompanies.EditValue.ToString();
		}


	}
}