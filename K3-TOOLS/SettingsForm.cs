using System;
using System.Collections.Generic;
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
		private Dictionary<string, string> folderNames = new Dictionary<string, string>();
		private Dictionary<string, string> filePrefixes = new Dictionary<string, string>();
		private Dictionary<string, string> customStrings = new Dictionary<string, string>();

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
			Settings.Default.PrefabFolderName = folderNames["Prefabs"];
			Settings.Default.MaterialFolderName = folderNames["Materials"];
			Settings.Default.GenericFolderName = folderNames["Other Files"];

			// Save file prefixes
			filePrefixes[((KeyValuePair<string, string>)fileTypeComboBox.SelectedItem).Key] = filePrefixTextBox.Text;

			Settings.Default.ImagePrefix = filePrefixes["Images"];
			Settings.Default.AudioPrefix = filePrefixes["Audio"];
			Settings.Default.VideoPrefix = filePrefixes["Video"];
			Settings.Default.ModelPrefix = filePrefixes["3D Models"];
			Settings.Default.CSharpScriptPrefix = filePrefixes["C# Scripts"];
			Settings.Default.HtmlScriptPrefix = filePrefixes["Html"];
			Settings.Default.CssScriptPrefix = filePrefixes["Css"];
			Settings.Default.PrefabPrefix = filePrefixes["Prefabs"];
			Settings.Default.MaterialPrefix = filePrefixes["Materials"];
			Settings.Default.GenericPrefix = filePrefixes["Other Files"];

			// Save other settings
			Settings.Default.SortExistingFiles = ProjectSorterForm.sortExistingFiles;

			int i = 0;
			foreach (var kvp in customStrings)
			{
				if (Settings.Default.CustomKeyList.Contains(kvp.Key))
				{
					continue;
				}
				Settings.Default.CustomKeyList += kvp.Key + ",";
				Settings.Default.CustomValueList += kvp.Value + ",";
			}
		}

		private void SettingsForm_Load(object sender, EventArgs e)
		{
			Console.WriteLine("Loading Settings...");

			// Set window location
			if (Settings.Default.SettingsWindowLocation != new Point(0, 0))
			{
				Location = Settings.Default.SettingsWindowLocation;
			}
			else
			{
				CenterToParent();
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
			folderNames.Add("Prefabs", Settings.Default.PrefabFolderName);
			folderNames.Add("Materials", Settings.Default.MaterialFolderName);
			folderNames.Add("Other Files", Settings.Default.GenericFolderName);

			//Load file prefixes
			filePrefixes.Add("Images", Settings.Default.ImagePrefix);
			filePrefixes.Add("Audio", Settings.Default.AudioPrefix);
			filePrefixes.Add("Video", Settings.Default.VideoPrefix);
			filePrefixes.Add("3D Models", Settings.Default.ModelPrefix);
			filePrefixes.Add("C# Scripts", Settings.Default.CSharpScriptPrefix);
			filePrefixes.Add("Html", Settings.Default.HtmlScriptPrefix);
			filePrefixes.Add("Css", Settings.Default.CssScriptPrefix);
			filePrefixes.Add("Prefabs", Settings.Default.PrefabPrefix);
			filePrefixes.Add("Materials", Settings.Default.MaterialPrefix);
			filePrefixes.Add("Other Files", Settings.Default.GenericPrefix);

			fileTypeComboBox.Items.Add(folderNames.Keys);
			BindDataSource();

			// Load other settings
			ProjectSorterForm.sortExistingFiles = Settings.Default.SortExistingFiles;
			SortExistingFilesCheckBox.Checked = ProjectSorterForm.sortExistingFiles;

			var keyList = Settings.Default.CustomKeyList.Split(',');
			var valueList = Settings.Default.CustomKeyList.Split(',');

			for (int i = 0; i < keyList.Count(); i++)
			{
				customStrings.Add(keyList[i], valueList[i]);
				customStringComboBox.Items.Add(keyList[i]);
			}
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
			folderNameTextBox.Text = folderNames[((KeyValuePair<string, string>)fileTypeComboBox.SelectedItem).Key];
			filePrefixTextBox.Text = filePrefixes[((KeyValuePair<string, string>)fileTypeComboBox.SelectedItem).Key];
		}

		private void FileTypeComboBox_DropDown(object sender, EventArgs e)
		{
			folderNames[((KeyValuePair<string, string>)fileTypeComboBox.SelectedItem).Key] = folderNameTextBox.Text;
			filePrefixes[((KeyValuePair<string, string>)fileTypeComboBox.SelectedItem).Key] = filePrefixTextBox.Text;
		}

		private void BindDataSource()
		{
			fileTypeComboBox.DataSource = new BindingSource(folderNames, null);
			fileTypeComboBox.DisplayMember = "Key";
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			if (!customStrings.ContainsKey(customStringComboBox.Text))
			{
				customStrings.Add(customStringComboBox.Text, folderName2TextBox.Text);
			}
			else
			{
				customStrings[customStringComboBox.Text] = folderName2TextBox.Text;
			}
			customStringComboBox.Items.Add(customStringComboBox.Text);
		}

		private void CustomStringComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			folderName2TextBox.Text = customStrings[customStringComboBox.Text];
		}

		private void RemoveButton_Click(object sender, EventArgs e)
		{
			folderName2TextBox.Text = "";
			customStringComboBox.Items.Remove(customStringComboBox.Text);
			customStringComboBox.Text = "";
			customStrings.Remove(customStringComboBox.Text);
		}
	}
}