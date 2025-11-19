using DevExpress.Data.Utils;
using DevExpress.XtraEditors;
using System;
using System.Reflection;

namespace SpectrumV1.Views.Main
{
	public partial class AboutForm : XtraForm
	{
		public AboutForm()
		{
			InitializeComponent();
			GetInfo();
		}

		private void GetInfo()
		{
			Text = String.Format("About {0}", AssemblyTitle);
			txtProductName.Text = AssemblyProduct;
			txtVersion.Text = String.Format("Version {0}", AssemblyVersion);
			txtCopyright.Text = AssemblyCopyright;
			txtCompanyName.Text = AssemblyCompany;
			txtDescription.Text = AssemblyDescription;
			hypCompanyWebsite.Text = Environment.NewLine + @"Visit our website!";
			hypCompanyWebsite.Tag = "https://spectrumlb.com/";
		}

		#region Assembly Attribute Accessors

		public string AssemblyTitle
		{
			get
			{
				// Get all Title attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				// If there is at least one Title attribute
				if (attributes.Length > 0)
				{
					// Select the first one
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					// If it is not an empty string, return it
					if (titleAttribute.Title != "")
						return titleAttribute.Title;
				}
				// If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		public string AssemblyVersion
		{
			get
			{
				//return Assembly.GetExecutingAssembly().GetName().Version.ToString();   //get assembly version

				System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
				System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
				string version = fvi.FileVersion;  // get file version

				return version;
			}
		}

		public string AssemblyDescription
		{
			get
			{
				// Get all Description attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				// If there aren't any Description attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Description attribute, return its value
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		public string AssemblyProduct
		{
			get
			{
				// Get all Product attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				// If there aren't any Product attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Product attribute, return its value
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		public string AssemblyCopyright
		{
			get
			{
				// Get all Copyright attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				// If there aren't any Copyright attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Copyright attribute, return its value
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		public string AssemblyCompany
		{
			get
			{
				// Get all Company attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				// If there aren't any Company attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Company attribute, return its value
				return ((AssemblyCompanyAttribute)attributes[0]).Company;
			}
		}
		#endregion


		void ExecuteCore(string procName)
		{
			try
			{
				SafeProcess.Start(procName);
			}
			catch
			{
				//
			}
		}

		private void hypCompanyWebsite_Click(object sender, EventArgs e)
		{
			ExecuteCore(hypCompanyWebsite.Tag.ToString());
		}
	}
}