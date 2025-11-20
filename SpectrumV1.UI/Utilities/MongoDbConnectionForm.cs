using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using SpectrumV1.DataLayers.DataUtilities; // for direct test

namespace SpectrumV1.Utilities
{
	public class MongoDbConnectionForm : XtraForm
	{
		private TextEdit txtHost;
		private SpinEdit spnPort;
		private TextEdit txtDatabase;
		private TextEdit txtUser;
		private TextEdit txtPassword;
		private MemoEdit txtConnString;
		private SimpleButton btnTest;
		private SimpleButton btnOk;
		private SimpleButton btnCancel;
		private LabelControl lblInfo;

		public string Host => txtHost.Text.Trim();
		public int Port => (int)spnPort.Value;
		public string DatabaseName => txtDatabase.Text.Trim();
		public string Username => txtUser.Text.Trim();
		public string Password => txtPassword.Text; // keep as-is
		public string ConnectionString => txtConnString.Text.Trim();

		public MongoDbConnectionForm(string host, int port, string dbName, string user, string pass, string connString)
		{
			Text = "MongoDB Connection";
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			StartPosition = FormStartPosition.CenterParent;
			ClientSize = new Size(520, 420);

			InitializeComponents();

			// Prefill
			txtHost.Text = string.IsNullOrWhiteSpace(host) ? "localhost" : host;
			spnPort.Value = port == 0 ? 27017 : port;
			txtDatabase.Text = string.IsNullOrWhiteSpace(dbName) ? "admin" : dbName;
			txtUser.Text = user ?? string.Empty;
			txtPassword.Text = pass ?? string.Empty;
			txtConnString.Text = connString ?? string.Empty;
		}

		private void InitializeComponents()
		{
			int lblW = 90;
			int top = 15;
			int ctlH = 22;
			int leftCtl = 110;

			// Host
			Controls.Add(new LabelControl { Text = "Host", Location = new Point(15, top + 3), Width = lblW });
			txtHost = new TextEdit { Location = new Point(leftCtl, top), Width = 370, Height = ctlH };
			Controls.Add(txtHost); top += 30;

			// Port
			Controls.Add(new LabelControl { Text = "Port", Location = new Point(15, top + 3), Width = lblW });
			spnPort = new SpinEdit { Location = new Point(leftCtl, top), Width = 120, Height = ctlH };
			spnPort.Properties.MinValue = 1; spnPort.Properties.MaxValue = 65535; spnPort.Properties.IsFloatValue = false; spnPort.Properties.Mask.EditMask = "N0";
			Controls.Add(spnPort); top += 30;

			// Database
			Controls.Add(new LabelControl { Text = "Database", Location = new Point(15, top + 3), Width = lblW });
			txtDatabase = new TextEdit { Location = new Point(leftCtl, top), Width = 370, Height = ctlH };
			Controls.Add(txtDatabase); top += 30;

			// Username
			Controls.Add(new LabelControl { Text = "Username", Location = new Point(15, top + 3), Width = lblW });
			txtUser = new TextEdit { Location = new Point(leftCtl, top), Width = 370, Height = ctlH };
			Controls.Add(txtUser); top += 30;

			// Password
			Controls.Add(new LabelControl { Text = "Password", Location = new Point(15, top + 3), Width = lblW });
			txtPassword = new TextEdit { Location = new Point(leftCtl, top), Width = 370, Height = ctlH, Properties = { PasswordChar = '*' } };
			Controls.Add(txtPassword); top += 30;

			// Connection String (optional override)
			Controls.Add(new LabelControl { Text = "Full Conn String", Location = new Point(15, top + 3), Width = lblW + 20 });
			txtConnString = new MemoEdit { Location = new Point(leftCtl, top), Width = 370, Height = 100 };
			Controls.Add(txtConnString); top += 110;

			lblInfo = new LabelControl
			{
				Location = new Point(15, top),
				Width = 470,
				Height = 40,
				Text = "Provide Host/Port (+ optional credentials) OR full connection string. Test before saving."
			};
			Controls.Add(lblInfo); top += 50;

			btnTest = new SimpleButton { Text = "Test", Location = new Point(15, ClientSize.Height - 50), Width = 80 };
			btnTest.Click += BtnTest_Click;
			Controls.Add(btnTest);

			btnOk = new SimpleButton { Text = "OK", Location = new Point(ClientSize.Width - 180, ClientSize.Height - 50), Width = 80, DialogResult = DialogResult.OK };
			btnOk.Click += (s, e) => { if (!ValidateInputs()) this.DialogResult = DialogResult.None; };
			Controls.Add(btnOk);

			btnCancel = new SimpleButton { Text = "Cancel", Location = new Point(ClientSize.Width - 90, ClientSize.Height - 50), Width = 80, DialogResult = DialogResult.Cancel };
			Controls.Add(btnCancel);

			AcceptButton = btnOk;
			CancelButton = btnCancel;
		}

		private void BtnTest_Click(object sender, EventArgs e)
		{
			if (!ValidateInputs()) return;
			Cursor = Cursors.WaitCursor;
			try
			{
				bool ok = ConnectionHelper.TryConnect(Host, Port, DatabaseName, Username, Password, ConnectionString);
				XtraMessageBox.Show(ok ? "Connection successful." : "Connection failed.", "Test Result", MessageBoxButtons.OK, ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private bool ValidateInputs()
		{
			if (string.IsNullOrWhiteSpace(ConnectionString))
			{
				if (string.IsNullOrWhiteSpace(Host)) { XtraMessageBox.Show("Host required."); return false; }
				if (Port <= 0) { XtraMessageBox.Show("Valid port required."); return false; }
				if (string.IsNullOrWhiteSpace(DatabaseName)) { XtraMessageBox.Show("Database required."); return false; }
			}
			return true;
		}
	}
}
