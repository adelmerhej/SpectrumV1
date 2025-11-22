using DevExpress.XtraEditors;
using Microsoft.AspNet.Identity;
using SpectrumV1.DataLayers.Users;
using SpectrumV1.Models.Users;
using SpectrumV1.Utilities;
using SpectrumV1.Utilities.Common;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpectrumV1.Views.Users
{
	public partial class UserEditForm : XtraForm
	{
		private UserModel _userModel = new UserModel();
		private readonly UserRepository _userRepository = new UserRepository();

		private readonly LogInfoRepository _logInfoRepository = new LogInfoRepository();

		//Init permissionvariables
		private bool _canAdd = true;
		private bool _canEdit = true;
		private bool _canDelete = true;
		private bool _canPrint = true;
		private bool _isAdmin = true;
		private bool _isProtected = true;

		public EventHandler SendUpdatedUser;

		public UserEditForm(UserModel model)
		{
			InitializeComponent();

			_userModel = model;
			StartLoading();
		}

		private async void StartLoading()
		{
			await InitializeBindings();
			WireUpBindings();
			ApplyDefaults();
			ApplyPermissions();
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

				_userModel = await _userRepository.GetUserByIdAsync(_userModel._id);
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message, @"Error Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void WireUpBindings()
		{
			bsUser.DataSource = _userModel;
		}

		private void ApplyDefaults()
		{
		}

		private void ApplyPermissions()
		{
			btnSave.Enabled = _isAdmin || _canEdit;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private async void btnSave_Click(object sender, EventArgs e)
		{
			if (!ValidateData()) return;

			try
			{
				BindingContext[bsUser].EndCurrentEdit();
				_userModel = (UserModel)bsUser.Current;

				if (string.IsNullOrEmpty(_userModel._id))
				{
					_logInfoRepository.CreateLogInfo(_userModel);

					SystemUtilities.PasswordHasher = new PasswordHasher();
					_userModel.PasswordHash = SystemUtilities.PasswordHasher.HashPassword(txtPassword.Text);
					_userModel.SecurityStamp = Guid.NewGuid().ToString("D");
					_userModel.FirstTimeAccess = true;

					var newId = await _userRepository.AddNewUserAsync(_userModel);
				}
				else
				{
					_logInfoRepository.UpdateLogInfo(_userModel);
					await _userRepository.UpdateUserAsync(_userModel);
				}

				SendUpdatedUser(_userModel, EventArgs.Empty);
				Close();
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message, @"Error Saving user", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}



		}

		private void changePasswordLink_ClickAsync(object sender, EventArgs e)
		{
			if (_isAdmin) 
			{
				changePasswordLink_Click(sender, e);
			}
		}

		private async void changePasswordLink_Click(object sender, EventArgs e)
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

				var changeUserModel = await _userRepository.GetUserByNameAsync(txtUsername.Text.Trim());
				if (txtUsername.Text == string.Empty || changeUserModel == null)
				{
					XtraMessageBox.Show($"Invalid username [ {txtUsername.Text} ].", "Change Password",
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}

			CreateNewPasswordForm _frm = new CreateNewPasswordForm(changeUserModel);
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
			if (sender == null) return;

			var changedUserModel = (UserModel)sender;
			_userModel.PasswordHash = changedUserModel.PasswordHash;
			txtPassword.Text = _userModel.PasswordHash;
		}

		private bool ValidateData()
		{
			var validateReturnValue = true;
			var messageNumber = 0;
			var validateMessage = new StringBuilder();

			if (txtUsername.Text == "")
			{
				messageNumber += 1;
				validateMessage.Append("\n- Username cannot be empty.");
				validateReturnValue = false;
				txtUsername.Focus();
			}

			if (txtPassword.Text == "")
			{
				messageNumber += 1;
				validateMessage.Append("\n- Password cannot be empty.");
				validateReturnValue = false;
				txtPassword.Focus();
			}

			if (txtEmail.Text == "")
			{
				messageNumber += 1;
				validateMessage.Append("\n- Email cannot be empty.");
				validateReturnValue = false;
				txtEmail.Focus();
			}

			if (!validateReturnValue)
			{
				validateMessage.Insert(0, "The following need your attention:");
				if (messageNumber > 1) validateMessage.Replace("following", "followings");
				XtraMessageBox.Show(validateMessage + " \nPlease try again.",
					"Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			return validateReturnValue;
		}
	}
}