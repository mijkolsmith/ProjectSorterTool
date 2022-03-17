using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace K3_TOOLS
{
	public class AddFileCommand : ICommand
	{
		private FileType file;
		private Button button;
		private Label label;
		private ProjectSorterForm form;

		public AddFileCommand(ProjectSorterForm form, FileType file, Button button, Label label)
		{
			this.file = file;
			this.button = button;
			this.label = label;
			this.form = form;
		}

		public void Execute()
		{
			bool isFileAdded = false;
			for (int i = 0; i < form.files.Count; i++)
			{
				try
				{
					if (form.files[i] == null) { }
				}
				catch (KeyNotFoundException)
				{
					form.files.Add(i, file);
					isFileAdded = true;
					break;
				}
			}

			if (!isFileAdded)
			{
				form.files.Add(form.files.Count, file);
			}

			form.buttons.Add(button);
			form.labels.Add(label);

			// Display the button (first so it displays over the label) and the label and add them to their respective lists
			form.fileDropPanel.Controls.Add(button);
			form.fileDropPanel.Controls.Add(label);
		}

		public void Undo()
		{
			form.fileDropPanel.Controls.Remove(label);
			form.fileDropPanel.Controls.Remove(button);
			form.files.Remove(form.files.FirstOrDefault(x => x.Value == file).Key);
			form.labels.Remove(label);
			form.buttons.Remove(button);
		}

		public void Redo()
		{
			form.fileDropPanel.Controls.Add(button);
			form.fileDropPanel.Controls.Add(label);

			bool isFileAdded = false;
			for (int i = 0; i < form.files.Count; i++)
			{
				try
				{
					if (form.files[i] == null) { }
				}
				catch (KeyNotFoundException)
				{
					form.files.Add(i, file);
					isFileAdded = true;
					break;
				}
			}

			if (!isFileAdded)
			{
				form.files.Add(form.files.Count, file);
			}

			form.labels.Add(label);
			form.buttons.Add(button);
		}
	}
}