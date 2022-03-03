using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using K3_TOOLS.Properties;

namespace K3_TOOLS
{
	public partial class SettingsForm : Form
	{
		public SettingsForm()
		{
			InitializeComponent();
		}

		private void SortExistingFilesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			ProjectSorterForm.sortExistingFiles = SortExistingFilesCheckBox.Checked;
		}

		private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Copy window location to app settings
			Settings.Default.SettingsWindowLocation = Location;

			// Copy window size to app settings
			if (WindowState == FormWindowState.Normal)
			{
				Settings.Default.SettingsWindowWidth = Width;
				Settings.Default.SettingsWindowHeight = Height;
			}
			else
			{
				Settings.Default.SettingsWindowWidth = RestoreBounds.Width;
				Settings.Default.SettingsWindowHeight = RestoreBounds.Height;
			}

			// Set saved settings
			Settings.Default.SortExistingFiles = ProjectSorterForm.sortExistingFiles;
			
			Console.WriteLine("Saving Settings...");
		}

		private void SettingsForm_Load(object sender, EventArgs e)
		{
			// Set window location
			if (Settings.Default.SettingsWindowLocation != null)
			{
				Location = Settings.Default.SettingsWindowLocation;
			}

			// Set window size
			if (Settings.Default.SettingsWindowWidth != 0 && Settings.Default.SettingsWindowHeight != 0)
			{
				Width = Settings.Default.SettingsWindowWidth;
				Height = Settings.Default.SettingsWindowHeight;
			}

			// Copy settings to app settings
			ProjectSorterForm.sortExistingFiles = Settings.Default.SortExistingFiles;
			SortExistingFilesCheckBox.Checked = ProjectSorterForm.sortExistingFiles;
			
			Console.WriteLine("Loading Settings...");
		}
	}
}
