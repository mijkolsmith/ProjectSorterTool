using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
using K3_TOOLS.Properties;

namespace K3_TOOLS
{
	public partial class ProjectSorterForm : Form
	{
        private string baseDirectory;
        public Dictionary<int, FileType> files = new Dictionary<int, FileType>();

        //private List<FileType> files = new List<FileType>();
        private List<FileType> projectFiles = new List<FileType>();
        public List<Label> labels = new List<Label>();
        public List<Button> buttons = new List<Button>();
        private SettingsForm settingsForm;

        private int formWidth;
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            formWidth = Width;
        }

        private const int listLabelHeight = 16;
        public static bool sortExistingFiles;
        public static bool reloadSettings;

        private List<ICommand> commands = new List<ICommand>();
        private int commandIndex = -1;

        public ProjectSorterForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Save User Settings
        /// </summary>
        private void ProjectSorterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Saving...");
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
        }

        /// <summary>
        /// Load User Settings
        /// </summary>
        private void ProjectSorterForm_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Loading...");
            // Set window location
            if (Settings.Default.WindowLocation != new Point(0,0))
            {
                Location = Settings.Default.WindowLocation;
            }
            else
            {
                CenterToScreen();
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

            // Load other settings
            sortExistingFiles = Settings.Default.SortExistingFiles;
        }

        /// <summary>
        /// A function that sorts file types using a collection of File Types
        /// </summary>
        private FileType GetFileType(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            if ((ext == ".jpg") || (ext == ".png") || (ext == ".bmp") || (ext == ".apng") || (ext == ".avif") || (ext == ".gif") || (ext == ".jpeg") || (ext == ".jfif") || (ext == ".pjpeg") || (ext == ".pjp") || (ext == ".webp"))
            {
                return new Image(filePath, Settings.Default.ImageFolderName, Settings.Default.ImagePrefix);
            }
            if ((ext == ".wav") || (ext == ".mp3") || (ext == ".aac") || (ext == ".aiff") || (ext == ".alac") || (ext == ".flac") || (ext == ".m4a") || (ext == ".ogg") || (ext == ".mogg") || (ext == ".oga") || (ext == ".wma"))
            {
                return new Audio(filePath, Settings.Default.AudioFolderName, Settings.Default.AudioPrefix);
            }
            if ((ext == ".mp4") || (ext == ".wmv") || (ext == ".mov") || (ext == ".avi") || (ext == ".avchd") || (ext == ".flv") || (ext == ".f4v") || (ext == ".swf") || (ext == ".mkv") || (ext == ".webm") || (ext == ".html5") || (ext == ".ts") || (ext == ".ts") || (ext == ".amv") || (ext == ".m4v") || (ext == ".m4p") || (ext == ".mpg") || (ext == ".mpeg") || (ext == ".m2v") || (ext == ".mpv") || (ext == ".m4v") || (ext == ".3gp") || (ext == ".3g2"))
            {
                return new Video(filePath, Settings.Default.VideoFolderName, Settings.Default.VideoPrefix);
            }
            if ((ext == ".gtlf") || (ext == ".glb") || (ext == ".fbx") || (ext == ".obj") || (ext == ".usdz") || (ext == ".usd") || (ext == ".stl") || (ext == ".max") || (ext == ".x3d") || (ext == ".vrml") || (ext == ".3mf") || (ext == ".dae"))
            {
                return new Model(filePath, Settings.Default.ModelFolderName, Settings.Default.ModelPrefix);
            }
            if (ext == ".cs")
            {
                return new CSharpScript(filePath, Settings.Default.CSharpScriptFolderName, Settings.Default.CSharpScriptPrefix);
            }
            if ((ext == ".html") || (ext == ".htm") || (ext == ".xhtml") || (ext == ".jhtml"))
            {
                return new HtmlScript(filePath, Settings.Default.HtmlScriptFolderName, Settings.Default.HtmlScriptPrefix);
            }
            if (ext == ".css")
            {
                return new CssScript(filePath, Settings.Default.CssScriptFolderName, Settings.Default.CssScriptPrefix);
            }
            if (ext == ".prefab")
			{
                return new Prefab(filePath, Settings.Default.PrefabFolderName, Settings.Default.PrefabPrefix);
            }
            if (ext == ".mat")
            {
                return new Material(filePath, Settings.Default.MaterialFolderName, Settings.Default.MaterialPrefix);
            }

            /* I decided to leave these extensions out for my tool
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

            else return new GenericFile(filePath, Settings.Default.GenericFolderName, Settings.Default.GenericPrefix);
        }
        
        //https://www.c-sharpcorner.com/blogs/drag-and-drop-file-on-windows-forms1
        private void FileDropPanel_DragDrop(object sender, DragEventArgs e)
        {
            //TODO: implement ctrl+z + ctrl+y (undo/redo Command pattern)
            foreach (string filePath in e.Data.GetData(DataFormats.FileDrop) as string[])
            {
                if (!files.Values.Any(x => x.FilePath == filePath))
                {
                    AddFilePath(filePath);
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
            // Update status display
            if (!Directory.Exists(baseDirectory))
            {
                statusLabel.Text = "Status: Project directory not set";
                return;
            }
            statusLabel.Text = "Status: Sorting...";

            if (sortExistingFiles)
            {
                GetExistingProjectFiles();
                foreach (FileType projectFile in projectFiles)
                {
                    SortFile(projectFile);
                    File.Delete(projectFile.FilePath);
                }
            }

            foreach (FileType file in files.Values)
            {
                Console.Write(Path.GetFileName(file.FilePath));
                SortFile(file);
            }

            // Clear the lists and remove the visuals (Reset the program)
            files.Clear();
            projectFiles.Clear();
			foreach (Label fileLabel in labels)
			{
                fileDropPanel.Controls.Remove(fileLabel);
            }
            labels.Clear();
            foreach (Button button in buttons)
            {
                fileDropPanel.Controls.Remove(button);
            }
            buttons.Clear();
            commands.Clear();

            // Update Status Display
            statusLabel.Text = "Status: Done";
        }

        /// <summary>
        /// Gets all existing project files to the files list and calls AddFile for each one of them
        /// </summary>
        private void GetExistingProjectFiles()
		{
            string[] projectFilePaths = Directory.GetFiles(baseDirectory, "*.*", SearchOption.AllDirectories);
            foreach (var filePath in projectFilePaths)
            {
                FileType file;

                if (files.Values.Where(x => x.FilePath == filePath).FirstOrDefault() == null)
                {
                    file = GetFileType(filePath);
                }
                else
                {
                    file = files.Values.Where(x => x.FilePath == filePath).FirstOrDefault();
                    files.Remove(files.FirstOrDefault(x => x.Value == file).Key);
                }

                projectFiles.Add(file);
            }
		}

        /// <summary>
        /// Adds a new FileType object to files list and a new label object to the program
        /// </summary>
        private void AddFilePath(string filePath)
		{
            if (!Directory.Exists(filePath))
            {
                // Find the key
                bool isKeySet = false;
                int key = 0;
                for (int i = 0; i < files.Count; i++)
                {
                    try
                    {
                        if (files[i] == null) { }
                    }
                    catch (KeyNotFoundException)
                    {
                        key = i;
                        isKeySet = true;
                        break;
                    }
                }

                if (!isKeySet)
                {
                    key = files.Count;
                }

                // Add a FileType to the files list
                FileType file = GetFileType(filePath);

                // Create a label and display it in a list
                var fileLabel = new Label
                {
                    Text = filePath,
                    Height = listLabelHeight,
                    Location = new Point(0, listLabelHeight * key),
                    AutoSize = true
                };

                // Create an x button for the file
                var removeFileButton = new Button
                {
                    BackColor = Color.Transparent,
                    FlatAppearance = { BorderSize = 0,
                                       MouseOverBackColor = Color.Transparent,
                                       MouseDownBackColor = Color.Transparent },
                    Text = "",
                    Image = Resources.delete_button_icon_8,
                    Height = listLabelHeight,
                    Width = listLabelHeight + 1, // HACK: It gets cropped slightly when I do 16x16... 17x16 seems to work fine
                    Location = new Point(formWidth - 40, listLabelHeight * key),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };

                // Add an on click event to the newly created removeFileButton with a delegate so you can send the file, label and button for removal once clicked
                removeFileButton.Click += (sender, e) => RemoveFileButton_Click(sender, e, file, fileLabel, removeFileButton);

                var command = new AddFileCommand(this, file, removeFileButton, fileLabel);
                commands.Add(command);
                command.Execute();
                commandIndex++;

                // Small bugfix for the visual side
                removeFileButton.Anchor = Anchor = AnchorStyles.Right | AnchorStyles.Top;
            }
            else
            {
                foreach(string newFilePath in Directory.GetFiles(filePath))
				{// Recursive method so it easily works for any amount of folders
                    if (!files.Values.Any(x => x.FilePath == newFilePath))
                    {
                        AddFilePath(newFilePath);
                    }
                }
            }
		}

		private void RemoveFileButton_Click(object sender, EventArgs e, FileType file, Label label, Button button)
		{
            fileDropPanel.Controls.Remove(label);
            fileDropPanel.Controls.Remove(button);
            int key = files.FirstOrDefault(x => x.Value == file).Key;
            files.Remove(key);
            commandIndex--;
            commands.Remove(commands[key]);
            labels.Remove(label);
            buttons.Remove(button);
		}

        /// <summary>
        /// This function creates a new folder for a fileType if it doesn't exist.
        /// Sorts the file based on it's type.
        /// </summary>
        private void SortFile(FileType file)
		{
			// Get the destinationPath of the current fileType
			string destinationPath =
				file.GetType() == typeof(GenericFile) ? baseDirectory :
				Path.Combine(baseDirectory, file.FolderName);
            
            string fileName = Path.GetFileNameWithoutExtension(file.FilePath);
            if (!Path.GetFileNameWithoutExtension(file.FilePath).Contains(file.FilePrefix))
			{
                fileName = file.FilePrefix + Path.GetFileNameWithoutExtension(file.FilePath);
            }

                // Create a new directory if it doesn't exist yet
            if (!Directory.Exists(destinationPath))
			{
				Directory.CreateDirectory(destinationPath);
			}

            // Copy the file into the current folder
            try
            {
                File.Copy(file.FilePath, Path.Combine(destinationPath, fileName + Path.GetExtension(file.FilePath)), true);
            }
            catch (IOException) // This exception will occur if the project file already existed at the same location, I can't delete before copying
            {
                try
                {
                    File.Copy(file.FilePath, Path.Combine(destinationPath, fileName + " (Copy)" + Path.GetExtension(file.FilePath)), true);
                }
                catch (IOException) // If this exception occurs twice, it's because a user moved/deleted files
                {
                    throw new IOException("You can't move files while using the program");
                }
            }
		}

        /// <summary>
        /// The OpenFolderDialog interface is awful, so I'm using a CommonOpenFileDialog.
        /// This is integrated in the Microsoft.WindowsAPICodePack.Dialogs API. 
        /// I installed this using https://www.nuget.org/packages/Microsoft-WindowsAPICodePack-Core/ . 
        /// Open View > Package Manager Console and paste this line:
        /// "Install-Package Microsoft-WindowsAPICodePack-Core -Version 1.1.4".
        /// Works for me in Visual Studio 2019 16.11.10.
        /// </summary>
        private void SetFolder_Click(object sender, EventArgs e)
		{
			var dialog = new CommonOpenFileDialog
			{
				InitialDirectory = "C:\\",
				IsFolderPicker = true
			};
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
            settingsForm.FormClosed += new FormClosedEventHandler(ReloadSettings);
            settingsForm.Show(this);
		}

        private void ReloadSettings(object sender, EventArgs e)
		{
            Dictionary<int, FileType> tempFiles = new Dictionary<int, FileType>();
			foreach(int key in files.Keys)
            {
                tempFiles.Add(key, GetFileType(files[key].FilePath));
            }
            files = tempFiles;
		}

        private void Undo()
		{
            if (commandIndex > -1)
            {
                commands[commandIndex].Undo();
                commandIndex--;
            }
        }

        private void Redo()
		{
            if (commandIndex < commands.Count - 1)
            {
                commandIndex++;
                commands[commandIndex].Execute();
            }
        }

		private void ProjectSorterForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control & e.KeyCode == Keys.Z)
			{
                Undo();
                Console.WriteLine("klote z");
			}

			if (e.Control & e.KeyCode == Keys.Y)
            {
                Redo();
            }
        }
	}
}