namespace SpectrumV1.Views.Main.Update
{
	partial class LiveUpdateForm
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
			this.lblUpdateResult = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
			this.btnCheckForUpdate = new DevExpress.XtraEditors.SimpleButton();
			this.txtNewVersionNo = new DevExpress.XtraEditors.TextEdit();
			this.txtCurrentVersionNo = new DevExpress.XtraEditors.TextEdit();
			this.txtDownloadUrl = new DevExpress.XtraEditors.TextEdit();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lblDownloadUrl = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lblCurrentVersionNo = new DevExpress.XtraLayout.LayoutControlItem();
			this.lblNewVersionNo = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
			this.lcbtnUpdate = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcUpdateResult = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
			((System.ComponentModel.ISupportInitialize)(this.mainLayout)).BeginInit();
			this.mainLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtNewVersionNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCurrentVersionNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDownloadUrl.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblDownloadUrl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblCurrentVersionNo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblNewVersionNo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcbtnUpdate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcUpdateResult)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
			this.SuspendLayout();
			// 
			// mainLayout
			// 
			this.mainLayout.Controls.Add(this.lblUpdateResult);
			this.mainLayout.Controls.Add(this.lblTitle);
			this.mainLayout.Controls.Add(this.btnUpdate);
			this.mainLayout.Controls.Add(this.btnCheckForUpdate);
			this.mainLayout.Controls.Add(this.txtNewVersionNo);
			this.mainLayout.Controls.Add(this.txtCurrentVersionNo);
			this.mainLayout.Controls.Add(this.txtDownloadUrl);
			this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainLayout.Location = new System.Drawing.Point(0, 0);
			this.mainLayout.Name = "mainLayout";
			this.mainLayout.Root = this.Root;
			this.mainLayout.Size = new System.Drawing.Size(770, 305);
			this.mainLayout.TabIndex = 1;
			this.mainLayout.Text = "layoutControl1";
			// 
			// lblUpdateResult
			// 
			this.lblUpdateResult.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUpdateResult.ForeColor = System.Drawing.Color.MediumSeaGreen;
			this.lblUpdateResult.Location = new System.Drawing.Point(136, 234);
			this.lblUpdateResult.Name = "lblUpdateResult";
			this.lblUpdateResult.Size = new System.Drawing.Size(589, 47);
			this.lblUpdateResult.TabIndex = 13;
			this.lblUpdateResult.Text = "Application has been successfully updated";
			this.lblUpdateResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTitle
			// 
			this.lblTitle.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.Location = new System.Drawing.Point(14, 14);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(711, 62);
			this.lblTitle.TabIndex = 10;
			this.lblTitle.Text = "Live update for ";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnUpdate
			// 
			this.btnUpdate.Appearance.BackColor = System.Drawing.Color.Blue;
			this.btnUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUpdate.Appearance.ForeColor = System.Drawing.Color.Black;
			this.btnUpdate.Appearance.Options.UseBackColor = true;
			this.btnUpdate.Appearance.Options.UseFont = true;
			this.btnUpdate.Appearance.Options.UseForeColor = true;
			this.btnUpdate.Location = new System.Drawing.Point(376, 193);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(349, 27);
			this.btnUpdate.StyleController = this.mainLayout;
			this.btnUpdate.TabIndex = 8;
			this.btnUpdate.Text = "Download && Update";
			// 
			// btnCheckForUpdate
			// 
			this.btnCheckForUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCheckForUpdate.Appearance.Options.UseFont = true;
			this.btnCheckForUpdate.Location = new System.Drawing.Point(136, 193);
			this.btnCheckForUpdate.Name = "btnCheckForUpdate";
			this.btnCheckForUpdate.Size = new System.Drawing.Size(236, 27);
			this.btnCheckForUpdate.StyleController = this.mainLayout;
			this.btnCheckForUpdate.TabIndex = 7;
			this.btnCheckForUpdate.Text = "Check For Update";
			// 
			// txtNewVersionNo
			// 
			this.txtNewVersionNo.Location = new System.Drawing.Point(138, 153);
			this.txtNewVersionNo.Name = "txtNewVersionNo";
			this.txtNewVersionNo.Properties.ReadOnly = true;
			this.txtNewVersionNo.Size = new System.Drawing.Size(587, 22);
			this.txtNewVersionNo.StyleController = this.mainLayout;
			this.txtNewVersionNo.TabIndex = 6;
			this.txtNewVersionNo.TabStop = false;
			// 
			// txtCurrentVersionNo
			// 
			this.txtCurrentVersionNo.Location = new System.Drawing.Point(138, 117);
			this.txtCurrentVersionNo.Name = "txtCurrentVersionNo";
			this.txtCurrentVersionNo.Properties.ReadOnly = true;
			this.txtCurrentVersionNo.Size = new System.Drawing.Size(587, 22);
			this.txtCurrentVersionNo.StyleController = this.mainLayout;
			this.txtCurrentVersionNo.TabIndex = 5;
			this.txtCurrentVersionNo.TabStop = false;
			// 
			// txtDownloadUrl
			// 
			this.txtDownloadUrl.Location = new System.Drawing.Point(138, 80);
			this.txtDownloadUrl.Name = "txtDownloadUrl";
			this.txtDownloadUrl.Properties.ReadOnly = true;
			this.txtDownloadUrl.Size = new System.Drawing.Size(587, 22);
			this.txtDownloadUrl.StyleController = this.mainLayout;
			this.txtDownloadUrl.TabIndex = 4;
			this.txtDownloadUrl.TabStop = false;
			// 
			// Root
			// 
			this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.Root.GroupBordersVisible = false;
			this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lblDownloadUrl,
            this.emptySpaceItem1,
            this.lblCurrentVersionNo,
            this.lblNewVersionNo,
            this.layoutControlItem4,
            this.layoutControlItem7,
            this.lcbtnUpdate,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.emptySpaceItem5,
            this.emptySpaceItem6,
            this.lcUpdateResult,
            this.emptySpaceItem7,
            this.emptySpaceItem8});
			this.Root.Name = "Root";
			this.Root.Size = new System.Drawing.Size(770, 305);
			this.Root.TextVisible = false;
			// 
			// lblDownloadUrl
			// 
			this.lblDownloadUrl.Control = this.txtDownloadUrl;
			this.lblDownloadUrl.Location = new System.Drawing.Point(0, 66);
			this.lblDownloadUrl.Name = "lblDownloadUrl";
			this.lblDownloadUrl.Size = new System.Drawing.Size(715, 26);
			this.lblDownloadUrl.Text = "Download URL";
			this.lblDownloadUrl.TextSize = new System.Drawing.Size(109, 16);
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.Location = new System.Drawing.Point(0, 271);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(715, 10);
			// 
			// lblCurrentVersionNo
			// 
			this.lblCurrentVersionNo.Control = this.txtCurrentVersionNo;
			this.lblCurrentVersionNo.Location = new System.Drawing.Point(0, 103);
			this.lblCurrentVersionNo.Name = "lblCurrentVersionNo";
			this.lblCurrentVersionNo.Size = new System.Drawing.Size(715, 26);
			this.lblCurrentVersionNo.Text = "Current Version No";
			this.lblCurrentVersionNo.TextSize = new System.Drawing.Size(109, 16);
			// 
			// lblNewVersionNo
			// 
			this.lblNewVersionNo.Control = this.txtNewVersionNo;
			this.lblNewVersionNo.Location = new System.Drawing.Point(0, 139);
			this.lblNewVersionNo.Name = "lblNewVersionNo";
			this.lblNewVersionNo.Size = new System.Drawing.Size(715, 26);
			this.lblNewVersionNo.Text = "New Version No";
			this.lblNewVersionNo.TextSize = new System.Drawing.Size(109, 16);
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.btnCheckForUpdate;
			this.layoutControlItem4.Location = new System.Drawing.Point(122, 179);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(240, 31);
			this.layoutControlItem4.TextVisible = false;
			// 
			// layoutControlItem7
			// 
			this.layoutControlItem7.Control = this.lblTitle;
			this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem7.Name = "layoutControlItem7";
			this.layoutControlItem7.Size = new System.Drawing.Size(715, 66);
			this.layoutControlItem7.TextVisible = false;
			// 
			// lcbtnUpdate
			// 
			this.lcbtnUpdate.Control = this.btnUpdate;
			this.lcbtnUpdate.Location = new System.Drawing.Point(362, 179);
			this.lcbtnUpdate.Name = "lcbtnUpdate";
			this.lcbtnUpdate.Size = new System.Drawing.Size(353, 31);
			this.lcbtnUpdate.TextVisible = false;
			this.lcbtnUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.Location = new System.Drawing.Point(0, 179);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(122, 31);
			// 
			// emptySpaceItem3
			// 
			this.emptySpaceItem3.Location = new System.Drawing.Point(715, 0);
			this.emptySpaceItem3.Name = "emptySpaceItem3";
			this.emptySpaceItem3.Size = new System.Drawing.Size(31, 281);
			// 
			// emptySpaceItem4
			// 
			this.emptySpaceItem4.Location = new System.Drawing.Point(0, 92);
			this.emptySpaceItem4.Name = "emptySpaceItem4";
			this.emptySpaceItem4.Size = new System.Drawing.Size(715, 11);
			// 
			// emptySpaceItem5
			// 
			this.emptySpaceItem5.Location = new System.Drawing.Point(0, 129);
			this.emptySpaceItem5.Name = "emptySpaceItem5";
			this.emptySpaceItem5.Size = new System.Drawing.Size(715, 10);
			// 
			// emptySpaceItem6
			// 
			this.emptySpaceItem6.Location = new System.Drawing.Point(0, 165);
			this.emptySpaceItem6.Name = "emptySpaceItem6";
			this.emptySpaceItem6.Size = new System.Drawing.Size(715, 14);
			// 
			// lcUpdateResult
			// 
			this.lcUpdateResult.Control = this.lblUpdateResult;
			this.lcUpdateResult.Location = new System.Drawing.Point(122, 220);
			this.lcUpdateResult.Name = "lcUpdateResult";
			this.lcUpdateResult.Size = new System.Drawing.Size(593, 51);
			this.lcUpdateResult.TextVisible = false;
			this.lcUpdateResult.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
			// 
			// emptySpaceItem7
			// 
			this.emptySpaceItem7.Location = new System.Drawing.Point(0, 210);
			this.emptySpaceItem7.Name = "emptySpaceItem7";
			this.emptySpaceItem7.Size = new System.Drawing.Size(715, 10);
			// 
			// emptySpaceItem8
			// 
			this.emptySpaceItem8.Location = new System.Drawing.Point(0, 220);
			this.emptySpaceItem8.Name = "emptySpaceItem8";
			this.emptySpaceItem8.Size = new System.Drawing.Size(122, 51);
			// 
			// LiveUpdateForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(770, 305);
			this.Controls.Add(this.mainLayout);
			this.IconOptions.Image = global::SpectrumV1.Properties.Resources.LiveUpdate;
			this.MaximizeBox = false;
			this.Name = "LiveUpdateForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Live update";
			((System.ComponentModel.ISupportInitialize)(this.mainLayout)).EndInit();
			this.mainLayout.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtNewVersionNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCurrentVersionNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDownloadUrl.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblDownloadUrl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblCurrentVersionNo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblNewVersionNo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcbtnUpdate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcUpdateResult)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl mainLayout;
		private System.Windows.Forms.Label lblUpdateResult;
		private System.Windows.Forms.Label lblTitle;
		private DevExpress.XtraEditors.SimpleButton btnUpdate;
		private DevExpress.XtraEditors.SimpleButton btnCheckForUpdate;
		private DevExpress.XtraEditors.TextEdit txtNewVersionNo;
		private DevExpress.XtraEditors.TextEdit txtCurrentVersionNo;
		private DevExpress.XtraEditors.TextEdit txtDownloadUrl;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private DevExpress.XtraLayout.LayoutControlItem lblDownloadUrl;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraLayout.LayoutControlItem lblCurrentVersionNo;
		private DevExpress.XtraLayout.LayoutControlItem lblNewVersionNo;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
		private DevExpress.XtraLayout.LayoutControlItem lcbtnUpdate;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
		private DevExpress.XtraLayout.LayoutControlItem lcUpdateResult;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
	}
}