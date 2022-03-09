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
		public int fileTypeIndex;
		Dictionary<string, string> folderNames = new Dictionary<string, string>();

		public SettingsForm()
		{
			InitializeComponent();
		}

		private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Console.WriteLine("Saving Settings...");

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

			// Save folder names
			folderNames[((KeyValuePair<string, string>)fileTypeComboBox.SelectedItem).Key] = folderNameTextBox.Text;

			Settings.Default.ImageFolderName = folderNames["Images"];
			Settings.Default.AudioFolderName = folderNames["Audio"];
			Settings.Default.VideoFolderName = folderNames["Video"];
			Settings.Default.ModelFolderName = folderNames["3D Models"];
			Settings.Default.CSharpScriptFolderName = folderNames["C# Scripts"];
			Settings.Default.HtmlScriptFolderName = folderNames["Html"];
			Settings.Default.CssScriptFolderName = folderNames["Css"];

			// Save other settings
			Settings.Default.SortExistingFiles = ProjectSorterForm.sortExistingFiles;
		}

		private void SettingsForm_Load(object sender, EventArgs e)
		{
			Console.WriteLine("Loading Settings...");

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

			// Load folder names
			folderNames.Add("Images", Settings.Default.ImageFolderName);
			folderNames.Add("Audio", Settings.Default.AudioFolderName);
			folderNames.Add("Video", Settings.Default.VideoFolderName);
			folderNames.Add("3D Models", Settings.Default.ModelFolderName);
			folderNames.Add("C# Scripts", Settings.Default.CSharpScriptFolderName);
			folderNames.Add("Html", Settings.Default.HtmlScriptFolderName);
			folderNames.Add("Css", Settings.Default.CssScriptFolderName);
			
			BindDataSource();

			// Load other settings
			ProjectSorterForm.sortExistingFiles = Settings.Default.SortExistingFiles;
			SortExistingFilesCheckBox.Checked = ProjectSorterForm.sortExistingFiles;
		}

		private void SortExistingFilesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			ProjectSorterForm.sortExistingFiles = SortExistingFilesCheckBox.Checked;
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void FileTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{	
			fileTypeIndex = fileTypeComboBox.SelectedIndex;
			folderNameTextBox.Text = folderNames[((KeyValuePair<string, string>)fileTypeComboBox.SelectedItem).Key];
		}

		private void FileTypeComboBox_DropDown(object sender, EventArgs e)
		{
			folderNames[((KeyValuePair<string, string>)fileTypeComboBox.SelectedItem).Key] = folderNameTextBox.Text;
		}

		private void BindDataSource()
		{
			fileTypeComboBox.DataSource = new BindingSource(folderNames, null);
			fileTypeComboBox.DisplayMember = "Key";
			fileTypeComboBox.ValueMember = "Value";
		}
	}
}