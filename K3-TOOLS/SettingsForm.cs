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

		private void SortExistingFilesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			ProjectSorterForm.sortExistingFiles = SortExistingFilesCheckBox.Checked;
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

			// Set saved settings
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

			// Copy settings to app settings
			folderNames.Add("Images", Settings.Default.ImageFolderName);
			folderNames.Add("Audio", Settings.Default.AudioFolderName);
			folderNames.Add("Video", Settings.Default.VideoFolderName);
			folderNames.Add("3D Models", Settings.Default.ModelFolderName);
			folderNames.Add("C# Scripts", Settings.Default.CSharpScriptFolderName);
			folderNames.Add("Html", Settings.Default.HtmlScriptFolderName);
			folderNames.Add("Css", Settings.Default.CssScriptFolderName);

			BindDataSource();

			//I tried using reflection to get the class names.
			/*ProjectSorterForm.sortExistingFiles = Settings.Default.SortExistingFiles;
			SortExistingFilesCheckBox.Checked = ProjectSorterForm.sortExistingFiles;

			var fileTypesFolderNames = new BindingList<KeyValuePair<string, string>>();

			IEnumerable<FileType> typeList = typeof(FileType).Assembly.GetTypes()
				.Where(t => t.IsSubclassOf(typeof(FileType)) && !t.IsAbstract)
				.Select(t => (FileType)Activator.CreateInstance(t, "test", "test"));

			foreach (var type in typeList)
			{
				fileTypesFolderNames.Add(new KeyValuePair<string, string>(type.GetType().Name.ToString(), type.FolderName));
			}*/
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void fileTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			fileTypeIndex = fileTypeComboBox.SelectedIndex;
			folderNameTextBox.Text = ((KeyValuePair<string, string>) fileTypeComboBox.SelectedItem).Value;
		}

		private void folderNameTextBox_TextChanged(object sender, EventArgs e)
		{
			//TODO: fix bug
			fileTypeComboBox.SelectedItem = new KeyValuePair<string, string>(((KeyValuePair<string, string>)fileTypeComboBox.SelectedItem).Key, folderNameTextBox.Text);

			if (folderNames[((KeyValuePair<string, string>)fileTypeComboBox.SelectedItem).Key] != folderNameTextBox.Text)
			{
				folderNames[((KeyValuePair<string, string>)fileTypeComboBox.SelectedItem).Key] = folderNameTextBox.Text;
				BindDataSource();
			}

			Console.WriteLine(folderNameTextBox.Text);
			fileTypeComboBox.SelectedItem = fileTypeIndex;
		}

		private void BindDataSource()
		{
			fileTypeComboBox.DataSource = new BindingSource(folderNames, null);
			fileTypeComboBox.DisplayMember = "Key";
			fileTypeComboBox.ValueMember = "Value";
		}
	}
}