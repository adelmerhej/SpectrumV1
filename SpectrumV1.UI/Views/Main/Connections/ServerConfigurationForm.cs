using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using SpectrumV1.DataLayers.DataAccess;
using SpectrumV1.Models.Administration.Connections;
using System;
using System.Windows.Forms;

namespace SpectrumV1.Views.Main.Connections
{
	public partial class ServerConfigurationForm : XtraForm
	{
		private ConnectionModel _connectionModel = new ConnectionModel();
		private const string _databaseType = "MongoDb";
		private const string _authDb = "admin";

		public ServerConfigurationForm()
		{
			InitializeComponent();

			ConnectionParams();
			InitializeBindings();
			WireUpBindings();
		}

		#region Init preloading Methods
		private void ConnectionParams()
		{
			_connectionModel = DatabaseFactory.ConnectionParamsGet();
		}

		private void InitializeBindings()
		{

		}

		private void WireUpBindings()
		{
			txtHost.Text = string.IsNullOrWhiteSpace(_connectionModel.DatabaseHost) ? "localhost" : _connectionModel.DatabaseHost;
			txtPort.Value = _connectionModel.DatabasePort == 0 ? 27017 : _connectionModel.DatabasePort;
			txtDatabase.Text = string.IsNullOrWhiteSpace(_connectionModel.DatabaseName) ? "spectrumdb" : _connectionModel.DatabaseName;
			txtUsername.Text = _connectionModel.DatabaseUser ?? string.Empty;
			txtPassword.Text = _connectionModel.DatabasePassword ?? string.Empty;
			txtConnectionString.Text = _connectionModel.DatabaseConnectionString ?? string.Empty;
		}


		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				int.TryParse(txtPort.Text, out var result);

				_connectionModel.DatabaseHost = txtHost.Text.Trim();
				_connectionModel.DatabasePort = result;
				_connectionModel.DatabaseType = _databaseType;
				_connectionModel.DatabaseName = txtDatabase.Text.Trim();
				_connectionModel.DatabaseUser = txtUsername.Text.Trim();
				_connectionModel.DatabasePassword = txtPassword.Text;

				_connectionModel.DatabaseConnectionString = txtConnectionString.Text.Trim();

				DatabaseFactory.ConnectionParamsSet(_connectionModel);

				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception)
			{
				DialogResult = DialogResult.Cancel;
			}
		}

		private void btnTest_Click(object sender, System.EventArgs e)
		{
			try
			{
				//test connection
				bool isConnected = DatabaseFactory.TestDatabaseConnection(txtConnectionString.Text.Trim(), txtDatabase.Text.Trim());

				if (isConnected)
				{
					XtraMessageBox.Show("Connection Successful!", "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					XtraMessageBox.Show("Connection Failed!", "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				//log error
				XtraMessageBox.Show(ex.Message, @"Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

		private void txtHost_EditValueChanged(object sender, EventArgs e)
		{
			BuildAndUpdateConnectionString();
		}


		private void BuildAndUpdateConnectionString()
		{
			int.TryParse(txtPort.Text, out var result);
			var host = string.IsNullOrWhiteSpace(txtHost.Text) ? "localhost" : txtHost.Text.Trim();
			var port = result == 0 ? 27017 : result;
			var database = string.IsNullOrWhiteSpace(txtDatabase.Text) ? "spectrumdb" : txtDatabase.Text.Trim();
			var username = txtUsername.Text.Trim();
			var password = txtPassword.Text;
			string connectionString;
			if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
			{
				connectionString = $"mongodb://{username}:{password}@{host}:{port}/{database}?authSource={_authDb}";
			}
			else
			{
				connectionString = $"mongodb://{host}:{port}/{database}";
			}
			txtConnectionString.Text = connectionString;

		}

		private void txtPort_EditValueChanged(object sender, EventArgs e)
		{
			BuildAndUpdateConnectionString();
		}

		private void txtDatabase_EditValueChanged(object sender, EventArgs e)
		{
			BuildAndUpdateConnectionString();
		}

		private void txtUsername_EditValueChanged(object sender, EventArgs e)
		{
			BuildAndUpdateConnectionString();
		}

		private void txtPassword_EditValueChanged(object sender, EventArgs e)
		{
			BuildAndUpdateConnectionString();
		}
	}
}