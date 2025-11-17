namespace SpectrumV1.Views.Main.Update
{
	partial class CheckForUpdateForm
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
			this.mainLayout = new DevExpress.XtraLayout.LayoutControl();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lblNewVersionNo = new DevExpress.Utils.Layout.TablePanel();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.lblTitle = new DevExpress.XtraEditors.LabelControl();
			this.lblDownloadUrl = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.btnCheckForUpdate = new DevExpress.XtraEditors.SimpleButton();
			this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
			this.txtDownloadUrl = new DevExpress.XtraEditors.TextEdit();
			this.txtCurrentVersionNo = new DevExpress.XtraEditors.TextEdit();
			this.txtNewVersionNo = new DevExpress.XtraEditors.TextEdit();
			this.lblUpdateResult = new DevExpress.XtraEditors.LabelControl();
			((System.ComponentModel.ISupportInitialize)(this.mainLayout)).BeginInit();
			this.mainLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblNewVersionNo)).BeginInit();
			this.lblNewVersionNo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDownloadUrl.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCurrentVersionNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtNewVersionNo.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// mainLayout
			// 
			this.mainLayout.Controls.Add(this.lblNewVersionNo);
			this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainLayout.Location = new System.Drawing.Point(0, 0);
			this.mainLayout.Name = "mainLayout";
			this.mainLayout.Root = this.Root;
			this.mainLayout.Size = new System.Drawing.Size(770, 305);
			this.mainLayout.TabIndex = 0;
			this.mainLayout.Text = "layoutControl1";
			// 
			// Root
			// 
			this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.Root.GroupBordersVisible = false;
			this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
			this.Root.Name = "Root";
			this.Root.Size = new System.Drawing.Size(770, 305);
			this.Root.TextVisible = false;
			// 
			// lblNewVersionNo
			// 
			this.lblNewVersionNo.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 19.54F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 34.46F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 56F)});
			this.lblNewVersionNo.Controls.Add(this.lblUpdateResult);
			this.lblNewVersionNo.Controls.Add(this.txtNewVersionNo);
			this.lblNewVersionNo.Controls.Add(this.txtCurrentVersionNo);
			this.lblNewVersionNo.Controls.Add(this.txtDownloadUrl);
			this.lblNewVersionNo.Controls.Add(this.btnUpdate);
			this.lblNewVersionNo.Controls.Add(this.btnCheckForUpdate);
			this.lblNewVersionNo.Controls.Add(this.labelControl3);
			this.lblNewVersionNo.Controls.Add(this.labelControl2);
			this.lblNewVersionNo.Controls.Add(this.lblDownloadUrl);
			this.lblNewVersionNo.Controls.Add(this.lblTitle);
			this.lblNewVersionNo.Location = new System.Drawing.Point(14, 14);
			this.lblNewVersionNo.Name = "lblNewVersionNo";
			this.lblNewVersionNo.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 62.79999F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26.8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 29.19999F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 16.40001F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 49.19999F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 52.39998F)});
			this.lblNewVersionNo.Size = new System.Drawing.Size(742, 277);
			this.lblNewVersionNo.TabIndex = 4;
			this.lblNewVersionNo.UseSkinIndents = true;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.lblNewVersionNo;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(746, 281);
			this.layoutControlItem1.TextVisible = false;
			// 
			// lblTitle
			// 
			this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold);
			this.lblTitle.Appearance.Options.UseFont = true;
			this.lblNewVersionNo.SetColumn(this.lblTitle, 0);
			this.lblNewVersionNo.SetColumnSpan(this.lblTitle, 3);
			this.lblTitle.Location = new System.Drawing.Point(15, 27);
			this.lblTitle.Name = "lblTitle";
			this.lblNewVersionNo.SetRow(this.lblTitle, 0);
			this.lblTitle.Size = new System.Drawing.Size(212, 33);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Live update for ";
			// 
			// lblDownloadUrl
			// 
			this.lblNewVersionNo.SetColumn(this.lblDownloadUrl, 0);
			this.lblDownloadUrl.Location = new System.Drawing.Point(15, 80);
			this.lblDownloadUrl.Name = "lblDownloadUrl";
			this.lblNewVersionNo.SetRow(this.lblDownloadUrl, 1);
			this.lblDownloadUrl.Size = new System.Drawing.Size(82, 16);
			this.lblDownloadUrl.TabIndex = 1;
			this.lblDownloadUrl.Text = "Download URL";
			// 
			// labelControl2
			// 
			this.lblNewVersionNo.SetColumn(this.labelControl2, 0);
			this.labelControl2.Location = new System.Drawing.Point(15, 107);
			this.labelControl2.Name = "labelControl2";
			this.lblNewVersionNo.SetRow(this.labelControl2, 2);
			this.labelControl2.Size = new System.Drawing.Size(109, 16);
			this.labelControl2.TabIndex = 2;
			this.labelControl2.Text = "Current Version No";
			// 
			// labelControl3
			// 
			this.lblNewVersionNo.SetColumn(this.labelControl3, 0);
			this.labelControl3.Location = new System.Drawing.Point(15, 134);
			this.labelControl3.Name = "labelControl3";
			this.lblNewVersionNo.SetRow(this.labelControl3, 3);
			this.labelControl3.Size = new System.Drawing.Size(91, 16);
			this.labelControl3.TabIndex = 3;
			this.labelControl3.Text = "New Version No";
			// 
			// btnCheckForUpdate
			// 
			this.btnCheckForUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.btnCheckForUpdate.Appearance.Options.UseFont = true;
			this.lblNewVersionNo.SetColumn(this.btnCheckForUpdate, 1);
			this.btnCheckForUpdate.Location = new System.Drawing.Point(142, 183);
			this.btnCheckForUpdate.Name = "btnCheckForUpdate";
			this.lblNewVersionNo.SetRow(this.btnCheckForUpdate, 5);
			this.btnCheckForUpdate.Size = new System.Drawing.Size(220, 29);
			this.btnCheckForUpdate.TabIndex = 4;
			this.btnCheckForUpdate.Text = "Check For Update";
			this.btnCheckForUpdate.Click += new System.EventHandler(this.btnCheckForUpdate_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Appearance.BackColor = System.Drawing.Color.Blue;
			this.btnUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.btnUpdate.Appearance.Options.UseBackColor = true;
			this.btnUpdate.Appearance.Options.UseFont = true;
			this.lblNewVersionNo.SetColumn(this.btnUpdate, 2);
			this.btnUpdate.Location = new System.Drawing.Point(366, 183);
			this.btnUpdate.Name = "btnUpdate";
			this.lblNewVersionNo.SetRow(this.btnUpdate, 5);
			this.btnUpdate.Size = new System.Drawing.Size(361, 29);
			this.btnUpdate.TabIndex = 5;
			this.btnUpdate.Text = "Download && Update";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// txtDownloadUrl
			// 
			this.lblNewVersionNo.SetColumn(this.txtDownloadUrl, 1);
			this.lblNewVersionNo.SetColumnSpan(this.txtDownloadUrl, 2);
			this.txtDownloadUrl.Location = new System.Drawing.Point(142, 77);
			this.txtDownloadUrl.Name = "txtDownloadUrl";
			this.txtDownloadUrl.Properties.ReadOnly = true;
			this.lblNewVersionNo.SetRow(this.txtDownloadUrl, 1);
			this.txtDownloadUrl.Size = new System.Drawing.Size(585, 22);
			this.txtDownloadUrl.TabIndex = 6;
			// 
			// txtCurrentVersionNo
			// 
			this.lblNewVersionNo.SetColumn(this.txtCurrentVersionNo, 1);
			this.lblNewVersionNo.SetColumnSpan(this.txtCurrentVersionNo, 2);
			this.txtCurrentVersionNo.Location = new System.Drawing.Point(142, 104);
			this.txtCurrentVersionNo.Name = "txtCurrentVersionNo";
			this.txtCurrentVersionNo.Properties.ReadOnly = true;
			this.lblNewVersionNo.SetRow(this.txtCurrentVersionNo, 2);
			this.txtCurrentVersionNo.Size = new System.Drawing.Size(585, 22);
			this.txtCurrentVersionNo.TabIndex = 7;
			// 
			// txtNewVersionNo
			// 
			this.lblNewVersionNo.SetColumn(this.txtNewVersionNo, 1);
			this.lblNewVersionNo.SetColumnSpan(this.txtNewVersionNo, 2);
			this.txtNewVersionNo.Location = new System.Drawing.Point(142, 131);
			this.txtNewVersionNo.Name = "txtNewVersionNo";
			this.txtNewVersionNo.Properties.ReadOnly = true;
			this.lblNewVersionNo.SetRow(this.txtNewVersionNo, 3);
			this.txtNewVersionNo.Size = new System.Drawing.Size(585, 22);
			this.txtNewVersionNo.TabIndex = 8;
			// 
			// lblUpdateResult
			// 
			this.lblUpdateResult.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold);
			this.lblUpdateResult.Appearance.ForeColor = System.Drawing.Color.MediumSeaGreen;
			this.lblUpdateResult.Appearance.Options.UseFont = true;
			this.lblUpdateResult.Appearance.Options.UseForeColor = true;
			this.lblNewVersionNo.SetColumn(this.lblUpdateResult, 1);
			this.lblNewVersionNo.SetColumnSpan(this.lblUpdateResult, 2);
			this.lblUpdateResult.Location = new System.Drawing.Point(142, 229);
			this.lblUpdateResult.Name = "lblUpdateResult";
			this.lblNewVersionNo.SetRow(this.lblUpdateResult, 6);
			this.lblUpdateResult.Size = new System.Drawing.Size(492, 28);
			this.lblUpdateResult.TabIndex = 9;
			this.lblUpdateResult.Text = "Application has been successfully updated";
			// 
			// CheckForUpdateForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(770, 305);
			this.Controls.Add(this.mainLayout);
			this.IconOptions.Image = global::SpectrumV1.Properties.Resources.LiveUpdate;
			this.MaximizeBox = false;
			this.Name = "CheckForUpdateForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Check for update";
			this.Load += new System.EventHandler(this.CheckForUpdateForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.mainLayout)).EndInit();
			this.mainLayout.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblNewVersionNo)).EndInit();
			this.lblNewVersionNo.ResumeLayout(false);
			this.lblNewVersionNo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDownloadUrl.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCurrentVersionNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtNewVersionNo.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl mainLayout;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private DevExpress.Utils.Layout.TablePanel lblNewVersionNo;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraEditors.LabelControl lblTitle;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.LabelControl lblDownloadUrl;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.SimpleButton btnUpdate;
		private DevExpress.XtraEditors.SimpleButton btnCheckForUpdate;
		private DevExpress.XtraEditors.TextEdit txtNewVersionNo;
		private DevExpress.XtraEditors.TextEdit txtCurrentVersionNo;
		private DevExpress.XtraEditors.TextEdit txtDownloadUrl;
		private DevExpress.XtraEditors.LabelControl lblUpdateResult;
	}
}