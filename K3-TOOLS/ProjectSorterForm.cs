using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;
using K3_TOOLS.Properties;

namespace K3_TOOLS
{
	public partial class ProjectSorterForm : Form
	{
        private string baseDirectory;
        private Dictionary<string, FileType> files = new Dictionary<string, FileType>();
        private List<Label> labels = new List<Label>();
        private int displayedAmount;
        private SettingsForm settingsForm;

        public static bool sortExistingFiles;

        public ProjectSorterForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Save User Settings
        /// </summary>
        private void ProjectSorterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Copy window location to app settings
            Settings.Default.WindowLocation = Location;

            // Copy window size to app settings
            if (WindowState == FormWindowState.Normal)
            {
                Settings.Default.WindowWidth = Width;
                Settings.Default.WindowHeight = Height;
            }
            else
            {
                Settings.Default.WindowWidth = RestoreBounds.Width;
                Settings.Default.WindowHeight = RestoreBounds.Height;
            }

            // Copy base directory to app settings
            Settings.Default.BaseDirectory = baseDirectory;

            // Save app settings
            Settings.Default.Save();
            Console.WriteLine("Saving...");
        }

        /// <summary>
        /// Load User Settings
        /// </summary>
        private void ProjectSorterForm_Load(object sender, EventArgs e)
        {
            // Set window location
            if (Settings.Default.WindowLocation != null)
            {
                Location = Settings.Default.WindowLocation;
            }

            // Set window size
            if (Settings.Default.WindowWidth != 0 && Settings.Default.WindowHeight != 0)
            {
                Width = Settings.Default.WindowWidth;
                Height = Settings.Default.WindowHeight;
            }

            // Set saved base directory
            if (Settings.Default.BaseDirectory != null)
			{
                baseDirectory = Settings.Default.BaseDirectory;
                baseDirectoryLabel.Text = baseDirectory;
            }

            Console.WriteLine("Loading...");
        }

        /// <summary>
        /// A function that sorts file types using a collection of File Types
        /// </summary>
        private FileType GetFileType(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            if ((ext == ".jpg") || (ext == ".png") || (ext == ".bmp") || (ext == ".apng") || (ext == ".avif") || (ext == ".gif") || (ext == ".jpeg") || (ext == ".jfif") || (ext == ".pjpeg") || (ext == ".pjp") || (ext == ".webp"))
            {
                return new Image();
            }
            if ((ext == ".wav") || (ext == ".mp3") || (ext == ".aac") || (ext == ".aiff") || (ext == ".alac") || (ext == ".flac") || (ext == ".m4a") || (ext == ".ogg") || (ext == ".mogg") || (ext == ".oga") || (ext == ".wma"))
            {
                return new Audio();
            }
            if ((ext == ".mp4") || (ext == ".wmv") || (ext == ".mov") || (ext == ".avi") || (ext == ".avchd") || (ext == ".flv") || (ext == ".f4v") || (ext == ".swf") || (ext == ".mkv") || (ext == ".webm") || (ext == ".html5") || (ext == ".ts") || (ext == ".ts") || (ext == ".amv") || (ext == ".m4v") || (ext == ".m4p") || (ext == ".mpg") || (ext == ".mpeg") || (ext == ".m2v") || (ext == ".mpv") || (ext == ".m4v") || (ext == ".3gp") || (ext == ".3g2"))
            {
                return new Video();
            }
            if ((ext == ".gtlf") || (ext == ".glb") || (ext == ".fbx") || (ext == ".obj") || (ext == ".usdz") || (ext == ".usd") || (ext == ".stl") || (ext == ".max") || (ext == ".x3d") || (ext == ".vrml") || (ext == ".3mf") || (ext == ".dae"))
            {
                return new Model();
            }
            if (ext == ".cs")
            {
                return new CSharpScript();
            }
            if ((ext == ".html") || (ext == ".htm") || (ext == ".xhtml") || (ext == ".jhtml"))
            {
                return new HtmlScript();
            }
            if (ext == ".css")
            {
                return new CssScript();
            }/*
            if (ext == ".js")
            {
                return FileType.JavaScript;
            }
            if ((ext == ".php") || (ext == ".php4") || (ext == ".php3") || (ext == ".phtml"))
            {
                return FileType.Php;
            }
            if ((ext == ".xml") || (ext == ".rss") || (ext == ".svg"))
            {
                return FileType.Xml;
            }
            if ((ext == ".xml") || (ext == ".rss") || (ext == ".svg"))
            {
                return FileType.Xml;
            }
            if ((ext == ".cc") || (ext == ".cpp") || (ext == ".h"))
			{
                return FileType.Cpp;
			}
            if ((ext == ".py") || (ext == ".pyc") || (ext == ".pyo") || (ext == ".pyd"))
			{
                return FileType.Python;
			}*/

            else return new GenericFile();
        }
        
        //https://www.c-sharpcorner.com/blogs/drag-and-drop-file-on-windows-forms1
        private void FileDropPanel_DragDrop(object sender, DragEventArgs e)
        {
            //TODO: Fix so it works for folders (Get files inside of folder?)
            foreach (string file in e.Data.GetData(DataFormats.FileDrop) as string[])
            {
                if (!files.ContainsKey(file))
                {
                    files.Add(file, GetFileType(file));
                    Label fileLabel = new Label();
                    fileLabel.Text = file;
                    fileLabel.Height = 16;
                    fileLabel.Location = new Point(0, 0 + fileLabel.Height * displayedAmount);
                    fileLabel.AutoSize = true;
                    FileDropPanel.Controls.Add(fileLabel);

                    labels.Add(fileLabel);
                    displayedAmount++;
                }
            }
        }

		private void FileDropPanel_DragOver(object sender, DragEventArgs e)
		{
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            if (baseDirectory == null)
            {
                statusLabel.Text = "Status: Project directory not set";
                return;
            }
            statusLabel.Text = "Status: Sorting...";

            if (sortExistingFiles)
                GetExistingProjectFiles();

            SortFiles();

            labels.RemoveAll(x => x.GetType() == typeof(Label));
            labels.Clear();
            displayedAmount = 0;
        }

        /// <summary>
        /// Adds all existing project files to the files list
        /// </summary>
        private void GetExistingProjectFiles()
		{
            //TODO: Add existing project files to the files list
            Console.WriteLine("getting existing project files");
		}

        /// <summary>
        /// A file sorter algorithm.
        /// This function creates new folders for every file in the files list based on their file type and sorts them there.
        /// </summary>
        private void SortFiles()
		{
            foreach (var fileType in files.Values.ToList())
            {
                // Get the destinationPath of the current fileType
                string destinationPath =
                    fileType.GetType() == typeof(GenericFile) ? baseDirectory : 
                    Path.Combine(baseDirectory, fileType.FolderName);

                // Create a new directory if it doesn't exist yet
                if (Directory.Exists(destinationPath))
                {
                    Directory.CreateDirectory(destinationPath);
                }

                // For all files of this fileType
                foreach (string filePath in files.Keys.Where(x => files[x] == fileType).ToList())
                { //Copy the file into the current folder
                    File.Copy(filePath, Path.Combine(destinationPath, Path.GetFileName(fileType.FilePath)), true);
                }
            }
		}


        //The OpenFolderDialog interface is awful, so I'm using a CommonOpenFileDialog. This is integrated in Microsoft.WindowsAPICodePack.Dialogs. I installed this using https://www.nuget.org/packages/Microsoft-WindowsAPICodePack-Core/ . Open View > Package Manager Console and paste this line "Install-Package Microsoft-WindowsAPICodePack-Core -Version 1.1.4". Works in Visual Studio 2019 16.11.10.
        private void SetFolder_Click(object sender, EventArgs e)
		{
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\";
            dialog.IsFolderPicker = true;
            CommonFileDialogResult result = dialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                baseDirectory = dialog.FileName;
                baseDirectoryLabel.Text = baseDirectory;
            }
        }

		private void SettingsButton_Click(object sender, EventArgs e)
		{
            settingsForm = new SettingsForm();
            settingsForm.Show();

            //TODO: Edit fileType/folderNames combinations
		}
	}
}
