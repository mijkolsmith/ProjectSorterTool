using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace K3_TOOLS
{
    public enum FileType
    {
        Unknown,
        Image,
        Model,
        Script
    }

	public partial class Form1 : Form
	{
        Dictionary<string, FileType> files;
        bool isImage;

        public Form1()
        {
            InitializeComponent();
        }

        //https://www.c-sharpcorner.com/blogs/drag-and-drop-file-on-windows-forms1
        private FileType GetFileType(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            if ((ext == ".jpg") || (ext == ".png") || (ext == ".bmp"))
            {
                return FileType.Image;
            }
            else return FileType.Unknown;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            foreach (string file in e.Data.GetData("FileDrop") as string[])
            {
                files.Add(file, GetFileType(file));
                Label fileLabel = new Label();
                fileLabel.Text = file;
            }
        }

		private void panel1_DragOver(object sender, DragEventArgs e)
		{
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            testLabel.Text = "sorting...";
        }
    }
}
