namespace SpectrumV1.Views.Users
{
	partial class CreateNewPasswordForm
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
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewPasswordForm));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
			this.mainLayout = new DevExpress.XtraLayout.LayoutControl();
			this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
			this.txtUsername = new DevExpress.XtraEditors.TextEdit();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.lblConfirmPassword = new DevExpress.XtraEditors.LabelControl();
			this.lblNewPassword = new DevExpress.XtraEditors.LabelControl();
			this.lblUserName = new DevExpress.XtraEditors.LabelControl();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.txtNewPassword = new DevExpress.XtraEditors.ButtonEdit();
			this.txtConfirmPassword = new DevExpress.XtraEditors.ButtonEdit();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.mainLayout)).BeginInit();
			this.mainLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
			this.tablePanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			this.SuspendLayout();
			// 
			// mainLayout
			// 
			this.mainLayout.Controls.Add(this.tablePanel1);
			this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainLayout.Location = new System.Drawing.Point(0, 0);
			this.mainLayout.Name = "mainLayout";
			this.mainLayout.Root = this.Root;
			this.mainLayout.Size = new System.Drawing.Size(529, 234);
			this.mainLayout.TabIndex = 0;
			this.mainLayout.Text = "layoutControl1";
			// 
			// tablePanel1
			// 
			this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 51.94F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 47.06F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 39.08F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 36.56F)});
			this.tablePanel1.Controls.Add(this.txtUsername);
			this.tablePanel1.Controls.Add(this.labelControl4);
			this.tablePanel1.Controls.Add(this.lblConfirmPassword);
			this.tablePanel1.Controls.Add(this.lblNewPassword);
			this.tablePanel1.Controls.Add(this.lblUserName);
			this.tablePanel1.Controls.Add(this.btnSave);
			this.tablePanel1.Controls.Add(this.btnCancel);
			this.tablePanel1.Controls.Add(this.txtNewPassword);
			this.tablePanel1.Controls.Add(this.txtConfirmPassword);
			this.tablePanel1.Location = new System.Drawing.Point(14, 14);
			this.tablePanel1.Name = "tablePanel1";
			this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 45.19998F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 28.40001F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 39.59998F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 31.59999F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
			this.tablePanel1.Size = new System.Drawing.Size(501, 206);
			this.tablePanel1.TabIndex = 4;
			this.tablePanel1.UseSkinIndents = true;
			// 
			// txtUsername
			// 
			this.tablePanel1.SetColumn(this.txtUsername, 1);
			this.tablePanel1.SetColumnSpan(this.txtUsername, 3);
			this.txtUsername.Location = new System.Drawing.Point(156, 23);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Properties.ReadOnly = true;
			this.tablePanel1.SetRow(this.txtUsername, 0);
			this.txtUsername.Size = new System.Drawing.Size(330, 22);
			this.txtUsername.TabIndex = 6;
			this.txtUsername.TabStop = false;
			// 
			// labelControl4
			// 
			this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelControl4.Appearance.ForeColor = System.Drawing.Color.MediumSeaGreen;
			this.labelControl4.Appearance.Options.UseFont = true;
			this.labelControl4.Appearance.Options.UseForeColor = true;
			this.tablePanel1.SetColumn(this.labelControl4, 0);
			this.tablePanel1.SetColumnSpan(this.labelControl4, 4);
			this.labelControl4.Location = new System.Drawing.Point(15, 130);
			this.labelControl4.Name = "labelControl4";
			this.tablePanel1.SetRow(this.labelControl4, 3);
			this.labelControl4.Size = new System.Drawing.Size(187, 21);
			this.labelControl4.TabIndex = 5;
			this.labelControl4.Text = "Message notifications";
			this.labelControl4.Visible = false;
			// 
			// lblConfirmPassword
			// 
			this.lblConfirmPassword.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblConfirmPassword.Appearance.Options.UseFont = true;
			this.tablePanel1.SetColumn(this.lblConfirmPassword, 0);
			this.lblConfirmPassword.Location = new System.Drawing.Point(15, 95);
			this.lblConfirmPassword.Name = "lblConfirmPassword";
			this.tablePanel1.SetRow(this.lblConfirmPassword, 2);
			this.lblConfirmPassword.Size = new System.Drawing.Size(126, 17);
			this.lblConfirmPassword.TabIndex = 4;
			this.lblConfirmPassword.Text = "Confirm Password";
			// 
			// lblNewPassword
			// 
			this.lblNewPassword.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblNewPassword.Appearance.Options.UseFont = true;
			this.tablePanel1.SetColumn(this.lblNewPassword, 0);
			this.lblNewPassword.Location = new System.Drawing.Point(15, 62);
			this.lblNewPassword.Name = "lblNewPassword";
			this.tablePanel1.SetRow(this.lblNewPassword, 1);
			this.lblNewPassword.Size = new System.Drawing.Size(102, 17);
			this.lblNewPassword.TabIndex = 3;
			this.lblNewPassword.Text = "New Password";
			// 
			// lblUserName
			// 
			this.lblUserName.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblUserName.Appearance.Options.UseFont = true;
			this.tablePanel1.SetColumn(this.lblUserName, 0);
			this.lblUserName.Location = new System.Drawing.Point(15, 25);
			this.lblUserName.Name = "lblUserName";
			this.tablePanel1.SetRow(this.lblUserName, 0);
			this.lblUserName.Size = new System.Drawing.Size(69, 17);
			this.lblUserName.TabIndex = 2;
			this.lblUserName.Text = "Username";
			// 
			// btnSave
			// 
			this.tablePanel1.SetColumn(this.btnSave, 2);
			this.btnSave.Location = new System.Drawing.Point(284, 160);
			this.btnSave.Name = "btnSave";
			this.tablePanel1.SetRow(this.btnSave, 4);
			this.btnSave.Size = new System.Drawing.Size(102, 29);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "&Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.tablePanel1.SetColumn(this.btnCancel, 3);
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(391, 160);
			this.btnCancel.Name = "btnCancel";
			this.tablePanel1.SetRow(this.btnCancel, 4);
			this.btnCancel.Size = new System.Drawing.Size(95, 29);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txtNewPassword
			// 
			this.tablePanel1.SetColumn(this.txtNewPassword, 1);
			this.tablePanel1.SetColumnSpan(this.txtNewPassword, 3);
			this.txtNewPassword.Location = new System.Drawing.Point(156, 59);
			this.txtNewPassword.Name = "txtNewPassword";
			editorButtonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("editorButtonImageOptions1.SvgImage")));
			editorButtonImageOptions1.SvgImageSize = new System.Drawing.Size(12, 12);
			this.txtNewPassword.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
			this.txtNewPassword.Properties.PasswordChar = '*';
			this.tablePanel1.SetRow(this.txtNewPassword, 1);
			this.txtNewPassword.Size = new System.Drawing.Size(330, 25);
			this.txtNewPassword.TabIndex = 0;
			this.txtNewPassword.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtNewPassword_ButtonClick);
			this.txtNewPassword.MouseLeave += new System.EventHandler(this.txtNewPassword_MouseLeave);
			// 
			// txtConfirmPassword
			// 
			this.tablePanel1.SetColumn(this.txtConfirmPassword, 1);
			this.tablePanel1.SetColumnSpan(this.txtConfirmPassword, 3);
			this.txtConfirmPassword.Location = new System.Drawing.Point(156, 92);
			this.txtConfirmPassword.Name = "txtConfirmPassword";
			editorButtonImageOptions2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("editorButtonImageOptions2.SvgImage")));
			editorButtonImageOptions2.SvgImageSize = new System.Drawing.Size(12, 12);
			this.txtConfirmPassword.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
			this.txtConfirmPassword.Properties.PasswordChar = '*';
			this.tablePanel1.SetRow(this.txtConfirmPassword, 2);
			this.txtConfirmPassword.Size = new System.Drawing.Size(330, 25);
			this.txtConfirmPassword.TabIndex = 1;
			this.txtConfirmPassword.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtConfirmPassword_ButtonClick);
			this.txtConfirmPassword.MouseLeave += new System.EventHandler(this.txtConfirmPassword_MouseLeave);
			// 
			// Root
			// 
			this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.Root.GroupBordersVisible = false;
			this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
			this.Root.Name = "Root";
			this.Root.Size = new System.Drawing.Size(529, 234);
			this.Root.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.tablePanel1;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(505, 210);
			this.layoutControlItem1.TextVisible = false;
			// 
			// CreateNewPasswordForm
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(529, 234);
			this.Controls.Add(this.mainLayout);
			this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("CreateNewPasswordForm.IconOptions.SvgImage")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CreateNewPasswordForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Create New Password";
			((System.ComponentModel.ISupportInitialize)(this.mainLayout)).EndInit();
			this.mainLayout.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
			this.tablePanel1.ResumeLayout(false);
			this.tablePanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl mainLayout;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private DevExpress.Utils.Layout.TablePanel tablePanel1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraEditors.TextEdit txtUsername;
		private DevExpress.XtraEditors.LabelControl labelControl4;
		private DevExpress.XtraEditors.LabelControl lblConfirmPassword;
		private DevExpress.XtraEditors.LabelControl lblNewPassword;
		private DevExpress.XtraEditors.LabelControl lblUserName;
		private DevExpress.XtraEditors.SimpleButton btnSave;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.ButtonEdit txtNewPassword;
		private DevExpress.XtraEditors.ButtonEdit txtConfirmPassword;
	}
}