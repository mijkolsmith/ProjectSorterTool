
namespace K3_TOOLS
{
	partial class SettingsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.SortExistingFilesCheckBox = new System.Windows.Forms.CheckBox();
			this.fileTypeComboBox = new System.Windows.Forms.ComboBox();
			this.fileTypeLabel = new System.Windows.Forms.Label();
			this.folderNameLabel = new System.Windows.Forms.Label();
			this.folderNameTextBox = new System.Windows.Forms.TextBox();
			this.saveButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// SortExistingFilesCheckBox
			// 
			this.SortExistingFilesCheckBox.AutoSize = true;
			this.SortExistingFilesCheckBox.Location = new System.Drawing.Point(22, 22);
			this.SortExistingFilesCheckBox.Name = "SortExistingFilesCheckBox";
			this.SortExistingFilesCheckBox.Size = new System.Drawing.Size(183, 21);
			this.SortExistingFilesCheckBox.TabIndex = 0;
			this.SortExistingFilesCheckBox.Text = "Sort existing project files";
			this.SortExistingFilesCheckBox.UseVisualStyleBackColor = true;
			this.SortExistingFilesCheckBox.CheckedChanged += new System.EventHandler(this.SortExistingFilesCheckBox_CheckedChanged);
			// 
			// fileTypeComboBox
			// 
			this.fileTypeComboBox.BackColor = System.Drawing.SystemColors.HighlightText;
			this.fileTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.fileTypeComboBox.FormattingEnabled = true;
			this.fileTypeComboBox.Items.AddRange(new object[] {
            "Images",
            "Audio",
            "Video",
            "3D Models",
            "C# Script",
            "Html",
            "Css"});
			this.fileTypeComboBox.Location = new System.Drawing.Point(22, 72);
			this.fileTypeComboBox.Name = "fileTypeComboBox";
			this.fileTypeComboBox.Size = new System.Drawing.Size(121, 24);
			this.fileTypeComboBox.TabIndex = 1;
			this.fileTypeComboBox.DropDown += new System.EventHandler(this.FileTypeComboBox_DropDown);
			this.fileTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.FileTypeComboBox_SelectedIndexChanged);
			// 
			// fileTypeLabel
			// 
			this.fileTypeLabel.AutoSize = true;
			this.fileTypeLabel.Location = new System.Drawing.Point(19, 49);
			this.fileTypeLabel.Name = "fileTypeLabel";
			this.fileTypeLabel.Size = new System.Drawing.Size(61, 17);
			this.fileTypeLabel.TabIndex = 2;
			this.fileTypeLabel.Text = "File type";
			// 
			// folderNameLabel
			// 
			this.folderNameLabel.AutoSize = true;
			this.folderNameLabel.Location = new System.Drawing.Point(147, 49);
			this.folderNameLabel.Name = "folderNameLabel";
			this.folderNameLabel.Size = new System.Drawing.Size(87, 17);
			this.folderNameLabel.TabIndex = 3;
			this.folderNameLabel.Text = "Folder name";
			// 
			// folderNameTextBox
			// 
			this.folderNameTextBox.Location = new System.Drawing.Point(150, 73);
			this.folderNameTextBox.Name = "folderNameTextBox";
			this.folderNameTextBox.Size = new System.Drawing.Size(100, 22);
			this.folderNameTextBox.TabIndex = 4;
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.saveButton.BackColor = System.Drawing.Color.WhiteSmoke;
			this.saveButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.saveButton.Location = new System.Drawing.Point(680, 413);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(108, 25);
			this.saveButton.TabIndex = 8;
			this.saveButton.Text = "Save Settings";
			this.saveButton.UseVisualStyleBackColor = false;
			this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.folderNameTextBox);
			this.Controls.Add(this.folderNameLabel);
			this.Controls.Add(this.fileTypeLabel);
			this.Controls.Add(this.fileTypeComboBox);
			this.Controls.Add(this.SortExistingFilesCheckBox);
			this.Name = "SettingsForm";
			this.Text = "Settings";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
			this.Load += new System.EventHandler(this.SettingsForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox SortExistingFilesCheckBox;
		private System.Windows.Forms.ComboBox fileTypeComboBox;
		private System.Windows.Forms.Label fileTypeLabel;
		private System.Windows.Forms.Label folderNameLabel;
		private System.Windows.Forms.TextBox folderNameTextBox;
		private System.Windows.Forms.Button saveButton;
	}
}