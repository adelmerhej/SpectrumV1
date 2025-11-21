using DevExpress.XtraEditors;

namespace SpectrumV1.Views.Main.Connections
{
	public partial class ServerConfigurationForm : XtraForm
	{
		public ServerConfigurationForm()
		{
			InitializeComponent();

			// Prefill
			//txtHost.Text = string.IsNullOrWhiteSpace(host) ? "localhost" : host;
			//txtPort.Value = port == 0 ? 27017 : port;
			//txtDatabase.Text = string.IsNullOrWhiteSpace(dbName) ? "admin" : dbName;
			//txtUsername.Text = user ?? string.Empty;
			//txtPassword.Text = pass ?? string.Empty;
			//txtConnectionString.Text = connString ?? string.Empty;
		}
	}
}