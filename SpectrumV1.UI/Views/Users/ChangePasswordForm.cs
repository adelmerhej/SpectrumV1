using DevExpress.XtraEditors;
using Microsoft.AspNet.Identity;
using SpectrumV1.DataLayers.Users;
using SpectrumV1.Models.Users;
using SpectrumV1.Utilities.Common;
using System;
using System.Text;
using System.Windows.Forms;

namespace SpectrumV1.Views.Users
{
	public partial class ChangePasswordForm : XtraForm
	{
		private UserModel _userModel = new UserModel();
		private readonly UserRepository _userRepository = new UserRepository();

		public event EventHandler SendChangedPassword;

		public ChangePasswordForm(UserModel model)
		{
			InitializeComponent();

			_userModel = model;

			InitializeBindings();
			WireUpBindings();
			ApplyDefaults();
			ApplyPermissions();
		}

		private void InitializeBindings()
		{
		}
		private void WireUpBindings()
		{
		}

		private void ApplyDefaults()
		{
			txtUsername.Text = _userModel.Username;
		}

		private void ApplyPermissions()
		{
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if (!ValidateForm()) return;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private bool ValidateForm()
		{
			var validateReturnValue = true;
			var messageNumber = 0;
			var validateMessage = new StringBuilder();

			if (txtConfirmPassword.Text == "")
			{
				messageNumber += 1;
				validateMessage.Append("\n- Confirm Password cannot be empty.");
				validateReturnValue = false;
				txtConfirmPassword.Focus();
			}

			if (txtNewPassword.Text == "")
			{
				messageNumber += 1;
				validateMessage.Append("\n- New Password cannot be empty.");
				validateReturnValue = false;
				txtNewPassword.Focus();
			}

			if (txtOldPassword.Text == "")
			{
				messageNumber += 1;
				validateMessage.Append("\n- Old Password cannot be empty.");
				validateReturnValue = false;
				txtOldPassword.Focus();
			}

			if (txtUsername.Text == "")
			{
				messageNumber += 1;
				validateMessage.Append("\n- Username cannot be empty.");
				validateReturnValue = false;
				txtUsername.Focus();
			}

			if (txtNewPassword.Text == txtOldPassword.Text)
			{
				messageNumber += 1;
				validateMessage.Append("\n- New Password and old Password cannot be the same.");
				validateReturnValue = false;
				txtNewPassword.Focus();
			}

			if (txtNewPassword.Text != txtConfirmPassword.Text)
			{
				messageNumber += 1;
				validateMessage.Append("\n- New Password and Confirm Password do not match.");
				validateReturnValue = false;
				txtConfirmPassword.Focus();
			}

			if (txtNewPassword.Text != txtConfirmPassword.Text)
			{
				messageNumber += 1;
				validateMessage.Append("\n- New Password and Confirm Password do not match.");
				validateReturnValue = false;
				txtConfirmPassword.Focus();
			}

			#region Check username in database
			//_userModel = _userRepository.GetUsersByName(_userModel.Username, _isProtected);

			SystemUtilities.PasswordHasher = new PasswordHasher();
			var passwordVerificationResult =
				SystemUtilities.PasswordHasher.VerifyHashedPassword(_userModel.PasswordHash, txtOldPassword.Text);

			if (_userModel == null || _userModel.Username != txtUsername.Text ||
				passwordVerificationResult == PasswordVerificationResult.Failed)
			{
				messageNumber += 1;
				validateMessage.Append("\n- User Name or password are not correct.");
				validateReturnValue = false;
				txtUsername.Focus();
			}

			#endregion

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