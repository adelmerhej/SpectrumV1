namespace SpectrumV1.Views.Users
{
	partial class ChangePasswordForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
			this.lblNewPassword = new DevExpress.XtraEditors.LabelControl();
			this.lblUserName = new DevExpress.XtraEditors.LabelControl();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.txtConfirmPassword = new DevExpress.XtraEditors.TextEdit();
			this.txtNewPassword = new DevExpress.XtraEditors.TextEdit();
			this.txtOldPassword = new DevExpress.XtraEditors.TextEdit();
			this.txtUsername = new DevExpress.XtraEditors.TextEdit();
			this.lblOldPassword = new DevExpress.XtraEditors.LabelControl();
			this.lblConfirmPassword = new DevExpress.XtraEditors.LabelControl();
			this.tpChangePassword = new DevExpress.Utils.Layout.TablePanel();
			((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tpChangePassword)).BeginInit();
			this.tpChangePassword.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblNewPassword
			// 
			this.lblNewPassword.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblNewPassword.Appearance.Options.UseFont = true;
			this.tpChangePassword.SetColumn(this.lblNewPassword, 1);
			this.lblNewPassword.Location = new System.Drawing.Point(20, 96);
			this.lblNewPassword.Margin = new System.Windows.Forms.Padding(4);
			this.lblNewPassword.Name = "lblNewPassword";
			this.tpChangePassword.SetRow(this.lblNewPassword, 2);
			this.lblNewPassword.Size = new System.Drawing.Size(102, 17);
			this.lblNewPassword.TabIndex = 7;
			this.lblNewPassword.Text = "New Password";
			// 
			// lblUserName
			// 
			this.lblUserName.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblUserName.Appearance.Options.UseFont = true;
			this.tpChangePassword.SetColumn(this.lblUserName, 1);
			this.lblUserName.Location = new System.Drawing.Point(20, 12);
			this.lblUserName.Margin = new System.Windows.Forms.Padding(4);
			this.lblUserName.Name = "lblUserName";
			this.tpChangePassword.SetRow(this.lblUserName, 0);
			this.lblUserName.Size = new System.Drawing.Size(69, 17);
			this.lblUserName.TabIndex = 6;
			this.lblUserName.Text = "Username";
			// 
			// btnCancel
			// 
			this.tpChangePassword.SetColumn(this.btnCancel, 4);
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(357, 175);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
			this.btnCancel.Name = "btnCancel";
			this.tpChangePassword.SetRow(this.btnCancel, 4);
			this.btnCancel.Size = new System.Drawing.Size(94, 30);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.tpChangePassword.SetColumn(this.btnSave, 3);
			this.btnSave.Location = new System.Drawing.Point(254, 175);
			this.btnSave.Margin = new System.Windows.Forms.Padding(4);
			this.btnSave.Name = "btnSave";
			this.tpChangePassword.SetRow(this.btnSave, 4);
			this.btnSave.Size = new System.Drawing.Size(95, 30);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "&Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// txtConfirmPassword
			// 
			this.tpChangePassword.SetColumn(this.txtConfirmPassword, 2);
			this.tpChangePassword.SetColumnSpan(this.txtConfirmPassword, 3);
			this.txtConfirmPassword.Location = new System.Drawing.Point(203, 136);
			this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(4);
			this.txtConfirmPassword.Name = "txtConfirmPassword";
			this.txtConfirmPassword.Properties.UseSystemPasswordChar = true;
			this.tpChangePassword.SetRow(this.txtConfirmPassword, 3);
			this.txtConfirmPassword.Size = new System.Drawing.Size(248, 22);
			this.txtConfirmPassword.TabIndex = 3;
			// 
			// txtNewPassword
			// 
			this.tpChangePassword.SetColumn(this.txtNewPassword, 2);
			this.tpChangePassword.SetColumnSpan(this.txtNewPassword, 3);
			this.txtNewPassword.Location = new System.Drawing.Point(203, 94);
			this.txtNewPassword.Margin = new System.Windows.Forms.Padding(4);
			this.txtNewPassword.Name = "txtNewPassword";
			this.txtNewPassword.Properties.UseSystemPasswordChar = true;
			this.tpChangePassword.SetRow(this.txtNewPassword, 2);
			this.txtNewPassword.Size = new System.Drawing.Size(248, 22);
			this.txtNewPassword.TabIndex = 2;
			// 
			// txtOldPassword
			// 
			this.tpChangePassword.SetColumn(this.txtOldPassword, 2);
			this.tpChangePassword.SetColumnSpan(this.txtOldPassword, 3);
			this.txtOldPassword.Location = new System.Drawing.Point(203, 52);
			this.txtOldPassword.Margin = new System.Windows.Forms.Padding(4);
			this.txtOldPassword.Name = "txtOldPassword";
			this.txtOldPassword.Properties.PasswordChar = '*';
			this.txtOldPassword.Properties.UseSystemPasswordChar = true;
			this.tpChangePassword.SetRow(this.txtOldPassword, 1);
			this.txtOldPassword.Size = new System.Drawing.Size(248, 22);
			this.txtOldPassword.TabIndex = 1;
			// 
			// txtUsername
			// 
			this.tpChangePassword.SetColumn(this.txtUsername, 2);
			this.tpChangePassword.SetColumnSpan(this.txtUsername, 3);
			this.txtUsername.Location = new System.Drawing.Point(203, 10);
			this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Properties.ReadOnly = true;
			this.tpChangePassword.SetRow(this.txtUsername, 0);
			this.txtUsername.Size = new System.Drawing.Size(248, 22);
			this.txtUsername.TabIndex = 0;
			this.txtUsername.TabStop = false;
			// 
			// lblOldPassword
			// 
			this.lblOldPassword.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblOldPassword.Appearance.Options.UseFont = true;
			this.tpChangePassword.SetColumn(this.lblOldPassword, 1);
			this.lblOldPassword.Location = new System.Drawing.Point(20, 54);
			this.lblOldPassword.Margin = new System.Windows.Forms.Padding(4);
			this.lblOldPassword.Name = "lblOldPassword";
			this.tpChangePassword.SetRow(this.lblOldPassword, 1);
			this.lblOldPassword.Size = new System.Drawing.Size(94, 17);
			this.lblOldPassword.TabIndex = 7;
			this.lblOldPassword.Text = "Old Password";
			// 
			// lblConfirmPassword
			// 
			this.lblConfirmPassword.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblConfirmPassword.Appearance.Options.UseFont = true;
			this.tpChangePassword.SetColumn(this.lblConfirmPassword, 1);
			this.lblConfirmPassword.Location = new System.Drawing.Point(20, 138);
			this.lblConfirmPassword.Margin = new System.Windows.Forms.Padding(4);
			this.lblConfirmPassword.Name = "lblConfirmPassword";
			this.tpChangePassword.SetRow(this.lblConfirmPassword, 3);
			this.lblConfirmPassword.Size = new System.Drawing.Size(126, 17);
			this.lblConfirmPassword.TabIndex = 7;
			this.lblConfirmPassword.Text = "Confirm Password";
			// 
			// tpChangePassword
			// 
			this.tpChangePassword.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 10.4F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 117.32F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 32.82F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 66.12F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 65.37F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 7.97F)});
			this.tpChangePassword.Controls.Add(this.lblNewPassword);
			this.tpChangePassword.Controls.Add(this.lblUserName);
			this.tpChangePassword.Controls.Add(this.btnCancel);
			this.tpChangePassword.Controls.Add(this.btnSave);
			this.tpChangePassword.Controls.Add(this.txtConfirmPassword);
			this.tpChangePassword.Controls.Add(this.txtNewPassword);
			this.tpChangePassword.Controls.Add(this.txtOldPassword);
			this.tpChangePassword.Controls.Add(this.txtUsername);
			this.tpChangePassword.Controls.Add(this.lblOldPassword);
			this.tpChangePassword.Controls.Add(this.lblConfirmPassword);
			this.tpChangePassword.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tpChangePassword.Location = new System.Drawing.Point(0, 0);
			this.tpChangePassword.Margin = new System.Windows.Forms.Padding(4);
			this.tpChangePassword.Name = "tpChangePassword";
			this.tpChangePassword.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F)});
			this.tpChangePassword.Size = new System.Drawing.Size(467, 212);
			this.tpChangePassword.TabIndex = 4;
			this.tpChangePassword.TabStop = true;
			// 
			// ChangePasswordForm
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(467, 212);
			this.Controls.Add(this.tpChangePassword);
			this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ChangePasswordForm.IconOptions.SvgImage")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ChangePasswordForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Change Password";
			((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tpChangePassword)).EndInit();
			this.tpChangePassword.ResumeLayout(false);
			this.tpChangePassword.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.LabelControl lblNewPassword;
		private DevExpress.Utils.Layout.TablePanel tpChangePassword;
		private DevExpress.XtraEditors.LabelControl lblUserName;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.SimpleButton btnSave;
		private DevExpress.XtraEditors.TextEdit txtConfirmPassword;
		private DevExpress.XtraEditors.TextEdit txtNewPassword;
		private DevExpress.XtraEditors.TextEdit txtOldPassword;
		private DevExpress.XtraEditors.TextEdit txtUsername;
		private DevExpress.XtraEditors.LabelControl lblOldPassword;
		private DevExpress.XtraEditors.LabelControl lblConfirmPassword;
	}
}