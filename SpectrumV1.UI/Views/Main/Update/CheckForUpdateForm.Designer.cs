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
			this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
			this.txtNewVersionNo = new DevExpress.XtraEditors.TextEdit();
			this.txtCurrentVersionNo = new DevExpress.XtraEditors.TextEdit();
			this.txtDownloadUrl = new DevExpress.XtraEditors.TextEdit();
			this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
			this.btnCheckForUpdate = new DevExpress.XtraEditors.SimpleButton();
			this.lblUpdateResult = new DevExpress.XtraEditors.LabelControl();
			this.lblNewVersionNo = new DevExpress.XtraEditors.LabelControl();
			this.lblCurrentVersionNo = new DevExpress.XtraEditors.LabelControl();
			this.lblDownloadUrl = new DevExpress.XtraEditors.LabelControl();
			this.lblTitle = new DevExpress.XtraEditors.LabelControl();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			((System.ComponentModel.ISupportInitialize)(this.mainLayout)).BeginInit();
			this.mainLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
			this.tablePanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtNewVersionNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCurrentVersionNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDownloadUrl.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			this.SuspendLayout();
			// 
			// mainLayout
			// 
			this.mainLayout.Controls.Add(this.tablePanel1);
			this.mainLayout.Controls.Add(this.lblTitle);
			this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainLayout.Location = new System.Drawing.Point(0, 0);
			this.mainLayout.Name = "mainLayout";
			this.mainLayout.Root = this.Root;
			this.mainLayout.Size = new System.Drawing.Size(798, 300);
			this.mainLayout.TabIndex = 1;
			this.mainLayout.Text = "layoutControl1";
			// 
			// tablePanel1
			// 
			this.tablePanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 21.37F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 44.63F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 44F)});
			this.tablePanel1.Controls.Add(this.txtNewVersionNo);
			this.tablePanel1.Controls.Add(this.txtCurrentVersionNo);
			this.tablePanel1.Controls.Add(this.txtDownloadUrl);
			this.tablePanel1.Controls.Add(this.btnUpdate);
			this.tablePanel1.Controls.Add(this.btnCheckForUpdate);
			this.tablePanel1.Controls.Add(this.lblUpdateResult);
			this.tablePanel1.Controls.Add(this.lblNewVersionNo);
			this.tablePanel1.Controls.Add(this.lblCurrentVersionNo);
			this.tablePanel1.Controls.Add(this.lblDownloadUrl);
			this.tablePanel1.Location = new System.Drawing.Point(14, 61);
			this.tablePanel1.Name = "tablePanel1";
			this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 38.80005F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 34.80008F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 38.80008F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 48.40016F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
			this.tablePanel1.Size = new System.Drawing.Size(770, 225);
			this.tablePanel1.TabIndex = 4;
			this.tablePanel1.UseSkinIndents = true;
			// 
			// txtNewVersionNo
			// 
			this.tablePanel1.SetColumn(this.txtNewVersionNo, 1);
			this.tablePanel1.SetColumnSpan(this.txtNewVersionNo, 2);
			this.txtNewVersionNo.Location = new System.Drawing.Point(160, 94);
			this.txtNewVersionNo.Name = "txtNewVersionNo";
			this.txtNewVersionNo.Properties.ReadOnly = true;
			this.tablePanel1.SetRow(this.txtNewVersionNo, 2);
			this.txtNewVersionNo.Size = new System.Drawing.Size(595, 22);
			this.txtNewVersionNo.TabIndex = 9;
			this.txtNewVersionNo.TabStop = false;
			// 
			// txtCurrentVersionNo
			// 
			this.tablePanel1.SetColumn(this.txtCurrentVersionNo, 1);
			this.tablePanel1.SetColumnSpan(this.txtCurrentVersionNo, 2);
			this.txtCurrentVersionNo.Location = new System.Drawing.Point(160, 57);
			this.txtCurrentVersionNo.Name = "txtCurrentVersionNo";
			this.txtCurrentVersionNo.Properties.ReadOnly = true;
			this.tablePanel1.SetRow(this.txtCurrentVersionNo, 1);
			this.txtCurrentVersionNo.Size = new System.Drawing.Size(595, 22);
			this.txtCurrentVersionNo.TabIndex = 8;
			this.txtCurrentVersionNo.TabStop = false;
			// 
			// txtDownloadUrl
			// 
			this.tablePanel1.SetColumn(this.txtDownloadUrl, 1);
			this.tablePanel1.SetColumnSpan(this.txtDownloadUrl, 2);
			this.txtDownloadUrl.Location = new System.Drawing.Point(160, 20);
			this.txtDownloadUrl.Name = "txtDownloadUrl";
			this.txtDownloadUrl.Properties.ReadOnly = true;
			this.tablePanel1.SetRow(this.txtDownloadUrl, 0);
			this.txtDownloadUrl.Size = new System.Drawing.Size(595, 22);
			this.txtDownloadUrl.TabIndex = 7;
			this.txtDownloadUrl.TabStop = false;
			// 
			// btnUpdate
			// 
			this.btnUpdate.Appearance.BackColor = System.Drawing.Color.Blue;
			this.btnUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.btnUpdate.Appearance.Options.UseBackColor = true;
			this.btnUpdate.Appearance.Options.UseFont = true;
			this.tablePanel1.SetColumn(this.btnUpdate, 1);
			this.btnUpdate.Location = new System.Drawing.Point(160, 178);
			this.btnUpdate.Name = "btnUpdate";
			this.tablePanel1.SetRow(this.btnUpdate, 4);
			this.btnUpdate.Size = new System.Drawing.Size(298, 29);
			this.btnUpdate.TabIndex = 6;
			this.btnUpdate.Text = "Download && Update";
			this.btnUpdate.Visible = false;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnCheckForUpdate
			// 
			this.btnCheckForUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.btnCheckForUpdate.Appearance.Options.UseFont = true;
			this.tablePanel1.SetColumn(this.btnCheckForUpdate, 2);
			this.btnCheckForUpdate.Location = new System.Drawing.Point(461, 178);
			this.btnCheckForUpdate.Name = "btnCheckForUpdate";
			this.tablePanel1.SetRow(this.btnCheckForUpdate, 4);
			this.btnCheckForUpdate.Size = new System.Drawing.Size(294, 29);
			this.btnCheckForUpdate.TabIndex = 5;
			this.btnCheckForUpdate.Text = "Check For Update";
			this.btnCheckForUpdate.Click += new System.EventHandler(this.btnCheckForUpdate_Click);
			// 
			// lblUpdateResult
			// 
			this.lblUpdateResult.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold);
			this.lblUpdateResult.Appearance.ForeColor = System.Drawing.Color.MediumSeaGreen;
			this.lblUpdateResult.Appearance.Options.UseFont = true;
			this.lblUpdateResult.Appearance.Options.UseForeColor = true;
			this.tablePanel1.SetColumn(this.lblUpdateResult, 1);
			this.tablePanel1.SetColumnSpan(this.lblUpdateResult, 2);
			this.lblUpdateResult.Location = new System.Drawing.Point(160, 135);
			this.lblUpdateResult.Name = "lblUpdateResult";
			this.tablePanel1.SetRow(this.lblUpdateResult, 3);
			this.lblUpdateResult.Size = new System.Drawing.Size(492, 28);
			this.lblUpdateResult.TabIndex = 4;
			this.lblUpdateResult.Text = "Application has been successfully updated";
			// 
			// lblNewVersionNo
			// 
			this.tablePanel1.SetColumn(this.lblNewVersionNo, 0);
			this.lblNewVersionNo.Location = new System.Drawing.Point(15, 97);
			this.lblNewVersionNo.Name = "lblNewVersionNo";
			this.tablePanel1.SetRow(this.lblNewVersionNo, 2);
			this.lblNewVersionNo.Size = new System.Drawing.Size(91, 16);
			this.lblNewVersionNo.TabIndex = 3;
			this.lblNewVersionNo.Text = "New Version No";
			// 
			// lblCurrentVersionNo
			// 
			this.tablePanel1.SetColumn(this.lblCurrentVersionNo, 0);
			this.lblCurrentVersionNo.Location = new System.Drawing.Point(15, 60);
			this.lblCurrentVersionNo.Name = "lblCurrentVersionNo";
			this.tablePanel1.SetRow(this.lblCurrentVersionNo, 1);
			this.lblCurrentVersionNo.Size = new System.Drawing.Size(109, 16);
			this.lblCurrentVersionNo.TabIndex = 2;
			this.lblCurrentVersionNo.Text = "Current Version No";
			// 
			// lblDownloadUrl
			// 
			this.tablePanel1.SetColumn(this.lblDownloadUrl, 0);
			this.lblDownloadUrl.Location = new System.Drawing.Point(15, 23);
			this.lblDownloadUrl.Name = "lblDownloadUrl";
			this.tablePanel1.SetRow(this.lblDownloadUrl, 0);
			this.lblDownloadUrl.Size = new System.Drawing.Size(82, 16);
			this.lblDownloadUrl.TabIndex = 1;
			this.lblDownloadUrl.Text = "Download URL";
			// 
			// lblTitle
			// 
			this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold);
			this.lblTitle.Appearance.Options.UseFont = true;
			this.lblTitle.Location = new System.Drawing.Point(14, 24);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(562, 33);
			this.lblTitle.StyleController = this.mainLayout;
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Live update for Spectrum App Version 1.0";
			// 
			// Root
			// 
			this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.Root.GroupBordersVisible = false;
			this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
			this.Root.Name = "Root";
			this.Root.Size = new System.Drawing.Size(798, 300);
			this.Root.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.tablePanel1;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 47);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(774, 229);
			this.layoutControlItem1.TextVisible = false;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.lblTitle;
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 10);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(774, 37);
			this.layoutControlItem2.TextVisible = false;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(774, 10);
			// 
			// CheckForUpdateForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(798, 300);
			this.Controls.Add(this.mainLayout);
			this.IconOptions.Image = global::SpectrumV1.Properties.Resources.LiveUpdate;
			this.MaximizeBox = false;
			this.Name = "CheckForUpdateForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Check for update";
			this.Load += new System.EventHandler(this.LiveUpdateForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.mainLayout)).EndInit();
			this.mainLayout.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
			this.tablePanel1.ResumeLayout(false);
			this.tablePanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtNewVersionNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCurrentVersionNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDownloadUrl.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl mainLayout;
		private DevExpress.Utils.Layout.TablePanel tablePanel1;
		private DevExpress.XtraEditors.TextEdit txtNewVersionNo;
		private DevExpress.XtraEditors.TextEdit txtCurrentVersionNo;
		private DevExpress.XtraEditors.TextEdit txtDownloadUrl;
		private DevExpress.XtraEditors.SimpleButton btnUpdate;
		private DevExpress.XtraEditors.SimpleButton btnCheckForUpdate;
		private DevExpress.XtraEditors.LabelControl lblUpdateResult;
		private DevExpress.XtraEditors.LabelControl lblNewVersionNo;
		private DevExpress.XtraEditors.LabelControl lblCurrentVersionNo;
		private DevExpress.XtraEditors.LabelControl lblDownloadUrl;
		private DevExpress.XtraEditors.LabelControl lblTitle;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
	}
}