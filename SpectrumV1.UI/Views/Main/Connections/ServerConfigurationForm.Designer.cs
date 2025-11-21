namespace SpectrumV1.Views.Main.Connections
{
	partial class ServerConfigurationForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerConfigurationForm));
			this.mainLayout = new DevExpress.XtraLayout.LayoutControl();
			this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
			this.lblErrorMessage = new DevExpress.XtraEditors.LabelControl();
			this.lblStatusMessage = new DevExpress.XtraEditors.LabelControl();
			this.txtConnectionString = new DevExpress.XtraEditors.MemoEdit();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.btnTest = new DevExpress.XtraEditors.SimpleButton();
			this.txtPassword = new DevExpress.XtraEditors.TextEdit();
			this.txtUsername = new DevExpress.XtraEditors.TextEdit();
			this.txtDatabase = new DevExpress.XtraEditors.TextEdit();
			this.txtHost = new DevExpress.XtraEditors.TextEdit();
			this.lblConnectionString = new DevExpress.XtraEditors.LabelControl();
			this.lblPassword = new DevExpress.XtraEditors.LabelControl();
			this.lblUsername = new DevExpress.XtraEditors.LabelControl();
			this.lblDatabase = new DevExpress.XtraEditors.LabelControl();
			this.lblPort = new DevExpress.XtraEditors.LabelControl();
			this.lblHost = new DevExpress.XtraEditors.LabelControl();
			this.txtPort = new DevExpress.XtraEditors.SpinEdit();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.mainLayout)).BeginInit();
			this.mainLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
			this.tablePanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtConnectionString.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDatabase.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtHost.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).BeginInit();
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
			this.mainLayout.Size = new System.Drawing.Size(605, 406);
			this.mainLayout.TabIndex = 0;
			this.mainLayout.Text = "layoutControl1";
			// 
			// tablePanel1
			// 
			this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 24.21F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 25.59F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 52.71F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 25.4F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 22.09F)});
			this.tablePanel1.Controls.Add(this.lblErrorMessage);
			this.tablePanel1.Controls.Add(this.lblStatusMessage);
			this.tablePanel1.Controls.Add(this.txtConnectionString);
			this.tablePanel1.Controls.Add(this.btnCancel);
			this.tablePanel1.Controls.Add(this.btnSave);
			this.tablePanel1.Controls.Add(this.btnTest);
			this.tablePanel1.Controls.Add(this.txtPassword);
			this.tablePanel1.Controls.Add(this.txtUsername);
			this.tablePanel1.Controls.Add(this.txtDatabase);
			this.tablePanel1.Controls.Add(this.txtHost);
			this.tablePanel1.Controls.Add(this.lblConnectionString);
			this.tablePanel1.Controls.Add(this.lblPassword);
			this.tablePanel1.Controls.Add(this.lblUsername);
			this.tablePanel1.Controls.Add(this.lblDatabase);
			this.tablePanel1.Controls.Add(this.lblPort);
			this.tablePanel1.Controls.Add(this.lblHost);
			this.tablePanel1.Controls.Add(this.txtPort);
			this.tablePanel1.Location = new System.Drawing.Point(14, 14);
			this.tablePanel1.Name = "tablePanel1";
			this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 49.20002F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 63.60001F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 31.60005F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 34.00005F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
			this.tablePanel1.Size = new System.Drawing.Size(577, 378);
			this.tablePanel1.TabIndex = 4;
			this.tablePanel1.UseSkinIndents = true;
			// 
			// lblErrorMessage
			// 
			this.lblErrorMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblErrorMessage.Appearance.ForeColor = System.Drawing.Color.Red;
			this.lblErrorMessage.Appearance.Options.UseFont = true;
			this.lblErrorMessage.Appearance.Options.UseForeColor = true;
			this.tablePanel1.SetColumn(this.lblErrorMessage, 1);
			this.tablePanel1.SetColumnSpan(this.lblErrorMessage, 4);
			this.lblErrorMessage.Location = new System.Drawing.Point(104, 295);
			this.lblErrorMessage.Name = "lblErrorMessage";
			this.tablePanel1.SetRow(this.lblErrorMessage, 8);
			this.lblErrorMessage.Size = new System.Drawing.Size(135, 18);
			this.lblErrorMessage.TabIndex = 17;
			this.lblErrorMessage.Text = "Connection failed.";
			this.lblErrorMessage.Visible = false;
			// 
			// lblStatusMessage
			// 
			this.lblStatusMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStatusMessage.Appearance.Options.UseFont = true;
			this.tablePanel1.SetColumn(this.lblStatusMessage, 1);
			this.tablePanel1.SetColumnSpan(this.lblStatusMessage, 4);
			this.lblStatusMessage.Location = new System.Drawing.Point(104, 150);
			this.lblStatusMessage.Name = "lblStatusMessage";
			this.tablePanel1.SetRow(this.lblStatusMessage, 5);
			this.lblStatusMessage.Size = new System.Drawing.Size(444, 32);
			this.lblStatusMessage.TabIndex = 16;
			this.lblStatusMessage.Text = "Provide Host/Port (+ optional credentials) OR full connection string. \r\nTest befo" +
    "re saving.";
			// 
			// txtConnectionString
			// 
			this.tablePanel1.SetColumn(this.txtConnectionString, 1);
			this.tablePanel1.SetColumnSpan(this.txtConnectionString, 4);
			this.txtConnectionString.Location = new System.Drawing.Point(104, 193);
			this.txtConnectionString.Name = "txtConnectionString";
			this.tablePanel1.SetRow(this.txtConnectionString, 6);
			this.tablePanel1.SetRowSpan(this.txtConnectionString, 2);
			this.txtConnectionString.Size = new System.Drawing.Size(458, 92);
			this.txtConnectionString.TabIndex = 15;
			// 
			// btnCancel
			// 
			this.tablePanel1.SetColumn(this.btnCancel, 4);
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(485, 328);
			this.btnCancel.Name = "btnCancel";
			this.tablePanel1.SetRow(this.btnCancel, 9);
			this.btnCancel.Size = new System.Drawing.Size(77, 29);
			this.btnCancel.TabIndex = 14;
			this.btnCancel.Text = "&Cancel";
			// 
			// btnSave
			// 
			this.tablePanel1.SetColumn(this.btnSave, 3);
			this.btnSave.Location = new System.Drawing.Point(392, 328);
			this.btnSave.Name = "btnSave";
			this.tablePanel1.SetRow(this.btnSave, 9);
			this.btnSave.Size = new System.Drawing.Size(89, 29);
			this.btnSave.TabIndex = 13;
			this.btnSave.Text = "&Save";
			// 
			// btnTest
			// 
			this.tablePanel1.SetColumn(this.btnTest, 1);
			this.btnTest.Location = new System.Drawing.Point(104, 328);
			this.btnTest.Name = "btnTest";
			this.tablePanel1.SetRow(this.btnTest, 9);
			this.btnTest.Size = new System.Drawing.Size(90, 29);
			this.btnTest.TabIndex = 12;
			this.btnTest.Text = "&Test";
			// 
			// txtPassword
			// 
			this.tablePanel1.SetColumn(this.txtPassword, 1);
			this.tablePanel1.SetColumnSpan(this.txtPassword, 4);
			this.txtPassword.Location = new System.Drawing.Point(104, 118);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Properties.PasswordChar = '*';
			this.tablePanel1.SetRow(this.txtPassword, 4);
			this.txtPassword.Size = new System.Drawing.Size(458, 22);
			this.txtPassword.TabIndex = 10;
			// 
			// txtUsername
			// 
			this.tablePanel1.SetColumn(this.txtUsername, 1);
			this.tablePanel1.SetColumnSpan(this.txtUsername, 4);
			this.txtUsername.Location = new System.Drawing.Point(104, 92);
			this.txtUsername.Name = "txtUsername";
			this.tablePanel1.SetRow(this.txtUsername, 3);
			this.txtUsername.Size = new System.Drawing.Size(458, 22);
			this.txtUsername.TabIndex = 9;
			// 
			// txtDatabase
			// 
			this.tablePanel1.SetColumn(this.txtDatabase, 1);
			this.tablePanel1.SetColumnSpan(this.txtDatabase, 4);
			this.txtDatabase.Location = new System.Drawing.Point(104, 66);
			this.txtDatabase.Name = "txtDatabase";
			this.tablePanel1.SetRow(this.txtDatabase, 2);
			this.txtDatabase.Size = new System.Drawing.Size(458, 22);
			this.txtDatabase.TabIndex = 8;
			// 
			// txtHost
			// 
			this.tablePanel1.SetColumn(this.txtHost, 1);
			this.tablePanel1.SetColumnSpan(this.txtHost, 4);
			this.txtHost.Location = new System.Drawing.Point(104, 14);
			this.txtHost.Name = "txtHost";
			this.tablePanel1.SetRow(this.txtHost, 0);
			this.txtHost.Size = new System.Drawing.Size(458, 22);
			this.txtHost.TabIndex = 6;
			// 
			// lblConnectionString
			// 
			this.tablePanel1.SetColumn(this.lblConnectionString, 0);
			this.lblConnectionString.Location = new System.Drawing.Point(15, 194);
			this.lblConnectionString.Name = "lblConnectionString";
			this.tablePanel1.SetRow(this.lblConnectionString, 6);
			this.lblConnectionString.Size = new System.Drawing.Size(85, 16);
			this.lblConnectionString.TabIndex = 5;
			this.lblConnectionString.Text = "Connection String";
			// 
			// lblPassword
			// 
			this.tablePanel1.SetColumn(this.lblPassword, 0);
			this.lblPassword.Location = new System.Drawing.Point(15, 121);
			this.lblPassword.Name = "lblPassword";
			this.tablePanel1.SetRow(this.lblPassword, 4);
			this.lblPassword.Size = new System.Drawing.Size(55, 16);
			this.lblPassword.TabIndex = 4;
			this.lblPassword.Text = "Password";
			// 
			// lblUsername
			// 
			this.tablePanel1.SetColumn(this.lblUsername, 0);
			this.lblUsername.Location = new System.Drawing.Point(15, 95);
			this.lblUsername.Name = "lblUsername";
			this.tablePanel1.SetRow(this.lblUsername, 3);
			this.lblUsername.Size = new System.Drawing.Size(58, 16);
			this.lblUsername.TabIndex = 3;
			this.lblUsername.Text = "Username";
			// 
			// lblDatabase
			// 
			this.tablePanel1.SetColumn(this.lblDatabase, 0);
			this.lblDatabase.Location = new System.Drawing.Point(15, 69);
			this.lblDatabase.Name = "lblDatabase";
			this.tablePanel1.SetRow(this.lblDatabase, 2);
			this.lblDatabase.Size = new System.Drawing.Size(53, 16);
			this.lblDatabase.TabIndex = 2;
			this.lblDatabase.Text = "Database";
			// 
			// lblPort
			// 
			this.tablePanel1.SetColumn(this.lblPort, 0);
			this.lblPort.Location = new System.Drawing.Point(15, 44);
			this.lblPort.Name = "lblPort";
			this.tablePanel1.SetRow(this.lblPort, 1);
			this.lblPort.Size = new System.Drawing.Size(23, 16);
			this.lblPort.TabIndex = 1;
			this.lblPort.Text = "Port";
			// 
			// lblHost
			// 
			this.tablePanel1.SetColumn(this.lblHost, 0);
			this.lblHost.Location = new System.Drawing.Point(15, 17);
			this.lblHost.Name = "lblHost";
			this.tablePanel1.SetRow(this.lblHost, 0);
			this.lblHost.Size = new System.Drawing.Size(25, 16);
			this.lblHost.TabIndex = 0;
			this.lblHost.Text = "Host";
			// 
			// txtPort
			// 
			this.tablePanel1.SetColumn(this.txtPort, 1);
			this.txtPort.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.txtPort.Location = new System.Drawing.Point(104, 40);
			this.txtPort.Name = "txtPort";
			this.txtPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.txtPort.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
			this.tablePanel1.SetRow(this.txtPort, 1);
			this.txtPort.Size = new System.Drawing.Size(90, 24);
			this.txtPort.TabIndex = 7;
			// 
			// Root
			// 
			this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.Root.GroupBordersVisible = false;
			this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
			this.Root.Name = "Root";
			this.Root.Size = new System.Drawing.Size(605, 406);
			this.Root.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.tablePanel1;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(581, 382);
			this.layoutControlItem1.TextVisible = false;
			// 
			// ServerConfigurationForm
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(605, 406);
			this.Controls.Add(this.mainLayout);
			this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ServerConfigurationForm.IconOptions.SvgImage")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ServerConfigurationForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Database Server Connection";
			((System.ComponentModel.ISupportInitialize)(this.mainLayout)).EndInit();
			this.mainLayout.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
			this.tablePanel1.ResumeLayout(false);
			this.tablePanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtConnectionString.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDatabase.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtHost.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl mainLayout;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private DevExpress.Utils.Layout.TablePanel tablePanel1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraEditors.LabelControl lblConnectionString;
		private DevExpress.XtraEditors.LabelControl lblPassword;
		private DevExpress.XtraEditors.LabelControl lblUsername;
		private DevExpress.XtraEditors.LabelControl lblDatabase;
		private DevExpress.XtraEditors.LabelControl lblPort;
		private DevExpress.XtraEditors.LabelControl lblHost;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.SimpleButton btnSave;
		private DevExpress.XtraEditors.SimpleButton btnTest;
		private DevExpress.XtraEditors.TextEdit txtPassword;
		private DevExpress.XtraEditors.TextEdit txtUsername;
		private DevExpress.XtraEditors.TextEdit txtDatabase;
		private DevExpress.XtraEditors.TextEdit txtHost;
		private DevExpress.XtraEditors.SpinEdit txtPort;
		private DevExpress.XtraEditors.MemoEdit txtConnectionString;
		private DevExpress.XtraEditors.LabelControl lblErrorMessage;
		private DevExpress.XtraEditors.LabelControl lblStatusMessage;
	}
}