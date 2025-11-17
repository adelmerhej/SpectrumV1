using System.IO;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using static System.Environment;

namespace SpectrumV1.Utilities.Layout
{
	public static class LayoutsStyle
	{
		public static bool ResetLayoutMenu(string accordion, string userName)
		{
			//Form form = FindForm(grid);
			if (accordion == null) return false;

			// Prepare directory
			string directoryPath =
				string.Concat(string.Concat(GetFolderPath(SpecialFolder.ApplicationData), "\\VExpAcc\\Layouts\\"),
					userName + "\\");
			if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
			string controlName = string.Concat(directoryPath, accordion, ".xml");

			//accordion.SaveLayoutToXml(controlName);
			File.Delete(controlName);

			return true;
		}

		public static bool ResetLayoutMenu(AccordionControl accordion, string userName)
		{
			//Form form = FindForm(grid);
			if (accordion == null) return false;

			// Prepare directory
			string directoryPath =
				string.Concat(string.Concat(GetFolderPath(SpecialFolder.ApplicationData), "\\VExpAcc\\Layouts\\"),
					userName + "\\");
			if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
			string controlName = string.Concat(directoryPath, accordion.Name, ".xml");

			//accordion.SaveLayoutToXml(controlName);
			File.Delete(controlName);

			return true;
		}
		public static bool SaveLayoutMenu(AccordionControl accordion, string userName)
		{
			//Form form = FindForm(grid);
			if (accordion == null) return false;

			// Prepare directory
			string directoryPath =
				string.Concat(string.Concat(GetFolderPath(SpecialFolder.ApplicationData), "\\VExpAcc\\Layouts\\"),
					userName + "\\");
			if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
			string controlName = string.Concat(directoryPath, accordion.Name, ".xml");

			accordion.SaveLayoutToXml(controlName);

			return true;
		}

		public static bool LoadLayoutMenu(AccordionControl accordion, string userName)
		{
			//Form form = FindForm(grid);
			if (accordion == null) return false;

			// Prepare directory
			string directoryPath =
				string.Concat(string.Concat(GetFolderPath(SpecialFolder.ApplicationData), "\\VExpAcc\\Layouts\\"),
					userName + "\\");

			string controlName = string.Concat(directoryPath, accordion.Name, ".xml");
			if (!File.Exists(controlName)) return false;

			accordion.RestoreLayoutFromXml(controlName);

			return true;
		}

		public static bool SaveLayoutGrid(GridView grid, string userName)
		{
			//Form form = FindForm(grid);
			if (grid == null) return false;

			// Prepare directory
			string directoryPath =
				string.Concat(string.Concat(GetFolderPath(SpecialFolder.ApplicationData), "\\VExpAcc\\Layouts\\"),
					 userName + "\\");
			if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
			string gridName = string.Concat(directoryPath, grid.Name, ".xml");

			grid.SaveLayoutToXml(gridName);

			return true;
		}
		public static bool SaveLayoutTreeList(TreeList grid, string userName)
		{
			//Form form = FindForm(grid);
			if (grid == null) return false;

			// Prepare directory
			string directoryPath =
				string.Concat(string.Concat(GetFolderPath(SpecialFolder.ApplicationData), "\\VExpAcc\\Layouts\\"),
					userName + "\\");
			if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
			string gridName = string.Concat(directoryPath, grid.Name, ".xml");

			grid.SaveLayoutToXml(gridName);

			return true;
		}
		public static bool LoadLayoutGrid(GridView grid, string userName)
		{
			//Form form = FindForm(grid);
			if (grid == null) return false;

			// Prepare directory
			string directoryPath =
				string.Concat(string.Concat(GetFolderPath(SpecialFolder.ApplicationData), "\\VExpAcc\\Layouts\\"),
					userName + "\\");

			string gridName = string.Concat(directoryPath, grid.Name, ".xml");
			if (!File.Exists(gridName)) return false;

			grid.RestoreLayoutFromXml(gridName);

			return true;
		}
		public static bool LoadLayoutTreeList(TreeList grid, string userName)
		{
			//Form form = FindForm(grid);
			if (grid == null) return false;

			// Prepare directory
			string directoryPath =
				string.Concat(string.Concat(GetFolderPath(SpecialFolder.ApplicationData), "\\VExpAcc\\Layouts\\"),
					userName + "\\");

			string gridName = string.Concat(directoryPath, grid.Name, ".xml");
			if (!File.Exists(gridName)) return false;

			grid.RestoreLayoutFromXml(gridName);

			return true;
		}

		//Reset Grid view
		public static bool ResetLayoutGrid(GridView grid, string userName)
		{
			//Form form = FindForm(grid);
			if (grid == null) return false;

			// Prepare directory
			string directoryPath =
				string.Concat(string.Concat(GetFolderPath(SpecialFolder.ApplicationData), "\\VExpAcc\\Layouts\\"),
					userName + "\\");

			string gridName = string.Concat(directoryPath, grid.Name, ".xml");
			if (!File.Exists(gridName)) return false;

			File.Delete(gridName);

			return true;
		}

		//Reset Layout view
		public static bool ResetLayoutTreeList(TreeList grid, string userName)
		{
			//Form form = FindForm(grid);
			if (grid == null) return false;

			// Prepare directory
			string directoryPath =
				string.Concat(string.Concat(GetFolderPath(SpecialFolder.ApplicationData), "\\VExpAcc\\Layouts\\"),
					userName + "\\");

			string gridName = string.Concat(directoryPath, grid.Name, ".xml");
			if (!File.Exists(gridName)) return false;

			File.Delete(gridName);

			return true;
		}
	}
}
