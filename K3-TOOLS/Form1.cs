using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace K3_TOOLS
{
    public enum FileType
    {
        Unknown,
        Images,
        Audio,
        Video,
        Models,
        Prefabs,
        Scripts,
        Cpp,
        Python,
        Html,
        Css,
        JavaScript,
        Php,
        Xml
    }

	public partial class Form1 : Form
	{
        string baseDirectory;
        Dictionary<string, FileType> files = new Dictionary<string, FileType>();
        List<Label> labels = new List<Label>();
        int displayedAmount;

        public Form1()
        {
            InitializeComponent();
        }

        private FileType GetFileType(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            if ((ext == ".jpg") || (ext == ".png") || (ext == ".bmp") || (ext == ".apng") || (ext == ".avif") || (ext == ".gif") || (ext == ".jpeg") || (ext == ".jfif") || (ext == ".pjpeg") || (ext == ".pjp") || (ext == ".webp"))
            {
                return FileType.Images;
            }
            if ((ext == ".wav") || (ext == ".mp3") || (ext == ".aac") || (ext == ".aiff") || (ext == ".alac") || (ext == ".flac") || (ext == ".m4a") || (ext == ".ogg") || (ext == ".mogg") || (ext == ".oga") || (ext == ".wma"))
            {
                return FileType.Audio;
            }
            if ((ext == ".mp4") || (ext == ".wmv") || (ext == ".mov") || (ext == ".avi") || (ext == ".avchd") || (ext == ".flv") || (ext == ".f4v") || (ext == ".swf") || (ext == ".mkv") || (ext == ".webm") || (ext == ".html5") || (ext == ".ts") || (ext == ".ts") || (ext == ".amv") || (ext == ".m4v") || (ext == ".m4p") || (ext == ".mpg") || (ext == ".mpeg") || (ext == ".m2v") || (ext == ".mpv") || (ext == ".m4v") || (ext == ".3gp") || (ext == ".3g2"))
            {
                return FileType.Video;
            }
            if ((ext == ".gtlf") || (ext == ".glb") || (ext == ".fbx") || (ext == ".obj") || (ext == ".usdz") || (ext == ".usd") || (ext == ".stl") || (ext == ".max") || (ext == ".x3d") || (ext == ".vrml") || (ext == ".3mf") || (ext == ".dae"))
            {
                return FileType.Models;
            }
            if (ext == ".cs")
            {
                return FileType.Scripts;
            }
            if ((ext == ".html") || (ext == ".htm") || (ext == ".xhtml") || (ext == ".jhtml"))
            {
                return FileType.Html;
            }
            if (ext == ".css")
            {
                return FileType.Css;
            }
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
			}

            else return FileType.Unknown;
        }
        
        //https://www.c-sharpcorner.com/blogs/drag-and-drop-file-on-windows-forms1
        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            //TODO: Fix so it works for folders (Get files inside of folder?)
            foreach (string file in e.Data.GetData(DataFormats.FileDrop) as string[])
            {
                if (!files.ContainsKey(file))
                {
                    files.Add(file, GetFileType(file));
                    Label fileLabel = new Label();
                    fileLabel.Text = file;
                    fileLabel.Location = new Point(0, 0 + 12 * displayedAmount);
                    fileLabel.AutoSize = true;
                    panel1.Controls.Add(fileLabel);

                    labels.Add(fileLabel);
                    displayedAmount++;
                }
            }
        }

		private void panel1_DragOver(object sender, DragEventArgs e)
		{
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            if (baseDirectory == null)
            {
                testLabel.Text = "Project directory not set";
                return;
            }
            testLabel.Text = "Sorting...";

            SortFiles();

            labels.RemoveAll(x => x.GetType() == typeof(Label));
            labels.Clear();
            displayedAmount = 0;
        }

        //A file sorter. This function creates new folders for every file in files based on their file type and sorts them there.
        private void SortFiles()
		{
            foreach (var fileType in files.Values.ToList())
            {
                var destinationPath = Path.Combine(baseDirectory, fileType.ToString());
                if (!Directory.Exists(destinationPath))
                {
                    Directory.CreateDirectory(Path.Combine(destinationPath)); 
                }
                foreach (string file in files.Keys.Where(x => files[x] == fileType).ToList())
                {
                    File.Copy(file, Path.Combine(destinationPath, Path.GetFileName(file)), true);
                }
            }
		}


        //The OpenFolderDialog interface is awful, so I'm using a CommonOpenFileDialog. This is integrated in Microsoft.WindowsAPICodePack.Dialogs. I installed this using https://www.nuget.org/packages/Microsoft-WindowsAPICodePack-Core/ . Open View > Package Manager Console and paste this line "Install-Package Microsoft-WindowsAPICodePack-Core -Version 1.1.4". Works in Visual Studio 2019 16.11.10.
        private void button1_Click(object sender, EventArgs e)
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
	}
}
