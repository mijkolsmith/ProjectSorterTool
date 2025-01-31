﻿
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
			this.filePrefixTextBox = new System.Windows.Forms.TextBox();
			this.filePrefixLabel = new System.Windows.Forms.Label();
			this.customStringLabel = new System.Windows.Forms.Label();
			this.folderNameLabel2 = new System.Windows.Forms.Label();
			this.folderName2TextBox = new System.Windows.Forms.TextBox();
			this.addButton = new System.Windows.Forms.Button();
			this.customStringComboBox = new System.Windows.Forms.ComboBox();
			this.removeButton = new System.Windows.Forms.Button();
			this.addedLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// SortExistingFilesCheckBox
			// 
			this.SortExistingFilesCheckBox.AutoSize = true;
			this.SortExistingFilesCheckBox.Location = new System.Drawing.Point(16, 18);
			this.SortExistingFilesCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.SortExistingFilesCheckBox.Name = "SortExistingFilesCheckBox";
			this.SortExistingFilesCheckBox.Size = new System.Drawing.Size(139, 17);
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
			this.fileTypeComboBox.Location = new System.Drawing.Point(16, 58);
			this.fileTypeComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.fileTypeComboBox.Name = "fileTypeComboBox";
			this.fileTypeComboBox.Size = new System.Drawing.Size(92, 21);
			this.fileTypeComboBox.TabIndex = 1;
			this.fileTypeComboBox.DropDown += new System.EventHandler(this.FileTypeComboBox_DropDown);
			this.fileTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.FileTypeComboBox_SelectedIndexChanged);
			// 
			// fileTypeLabel
			// 
			this.fileTypeLabel.AutoSize = true;
			this.fileTypeLabel.Location = new System.Drawing.Point(14, 40);
			this.fileTypeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.fileTypeLabel.Name = "fileTypeLabel";
			this.fileTypeLabel.Size = new System.Drawing.Size(46, 13);
			this.fileTypeLabel.TabIndex = 2;
			this.fileTypeLabel.Text = "File type";
			// 
			// folderNameLabel
			// 
			this.folderNameLabel.AutoSize = true;
			this.folderNameLabel.Location = new System.Drawing.Point(110, 40);
			this.folderNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.folderNameLabel.Name = "folderNameLabel";
			this.folderNameLabel.Size = new System.Drawing.Size(65, 13);
			this.folderNameLabel.TabIndex = 3;
			this.folderNameLabel.Text = "Folder name";
			// 
			// folderNameTextBox
			// 
			this.folderNameTextBox.Location = new System.Drawing.Point(112, 59);
			this.folderNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.folderNameTextBox.Name = "folderNameTextBox";
			this.folderNameTextBox.Size = new System.Drawing.Size(76, 20);
			this.folderNameTextBox.TabIndex = 4;
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.saveButton.BackColor = System.Drawing.Color.WhiteSmoke;
			this.saveButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.saveButton.Location = new System.Drawing.Point(510, 336);
			this.saveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(82, 24);
			this.saveButton.TabIndex = 8;
			this.saveButton.Text = "Save Settings";
			this.saveButton.UseVisualStyleBackColor = false;
			this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// filePrefixTextBox
			// 
			this.filePrefixTextBox.Location = new System.Drawing.Point(192, 59);
			this.filePrefixTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.filePrefixTextBox.Name = "filePrefixTextBox";
			this.filePrefixTextBox.Size = new System.Drawing.Size(76, 20);
			this.filePrefixTextBox.TabIndex = 10;
			// 
			// filePrefixLabel
			// 
			this.filePrefixLabel.AutoSize = true;
			this.filePrefixLabel.Location = new System.Drawing.Point(190, 40);
			this.filePrefixLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.filePrefixLabel.Name = "filePrefixLabel";
			this.filePrefixLabel.Size = new System.Drawing.Size(51, 13);
			this.filePrefixLabel.TabIndex = 9;
			this.filePrefixLabel.Text = "File prefix";
			// 
			// customStringLabel
			// 
			this.customStringLabel.AutoSize = true;
			this.customStringLabel.Location = new System.Drawing.Point(14, 84);
			this.customStringLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.customStringLabel.Name = "customStringLabel";
			this.customStringLabel.Size = new System.Drawing.Size(70, 13);
			this.customStringLabel.TabIndex = 12;
			this.customStringLabel.Text = "Custom string";
			// 
			// folderNameLabel2
			// 
			this.folderNameLabel2.AutoSize = true;
			this.folderNameLabel2.Location = new System.Drawing.Point(110, 87);
			this.folderNameLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.folderNameLabel2.Name = "folderNameLabel2";
			this.folderNameLabel2.Size = new System.Drawing.Size(65, 13);
			this.folderNameLabel2.TabIndex = 13;
			this.folderNameLabel2.Text = "Folder name";
			// 
			// folderName2TextBox
			// 
			this.folderName2TextBox.Location = new System.Drawing.Point(112, 102);
			this.folderName2TextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.folderName2TextBox.Name = "folderName2TextBox";
			this.folderName2TextBox.Size = new System.Drawing.Size(76, 20);
			this.folderName2TextBox.TabIndex = 14;
			// 
			// addButton
			// 
			this.addButton.BackColor = System.Drawing.Color.WhiteSmoke;
			this.addButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.addButton.Location = new System.Drawing.Point(192, 96);
			this.addButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(38, 24);
			this.addButton.TabIndex = 15;
			this.addButton.Text = "Add";
			this.addButton.UseVisualStyleBackColor = false;
			this.addButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// customStringComboBox
			// 
			this.customStringComboBox.FormattingEnabled = true;
			this.customStringComboBox.Location = new System.Drawing.Point(16, 101);
			this.customStringComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.customStringComboBox.Name = "customStringComboBox";
			this.customStringComboBox.Size = new System.Drawing.Size(92, 21);
			this.customStringComboBox.TabIndex = 16;
			this.customStringComboBox.DropDown += new System.EventHandler(this.CustomStringComboBox_DropDown);
			this.customStringComboBox.SelectedIndexChanged += new System.EventHandler(this.CustomStringComboBox_SelectedIndexChanged);
			// 
			// removeButton
			// 
			this.removeButton.BackColor = System.Drawing.Color.WhiteSmoke;
			this.removeButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.removeButton.Location = new System.Drawing.Point(235, 96);
			this.removeButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.removeButton.Name = "removeButton";
			this.removeButton.Size = new System.Drawing.Size(55, 24);
			this.removeButton.TabIndex = 17;
			this.removeButton.Text = "Remove";
			this.removeButton.UseVisualStyleBackColor = false;
			this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
			// 
			// addedLabel
			// 
			this.addedLabel.AutoSize = true;
			this.addedLabel.Location = new System.Drawing.Point(290, 101);
			this.addedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.addedLabel.Name = "addedLabel";
			this.addedLabel.Size = new System.Drawing.Size(0, 13);
			this.addedLabel.TabIndex = 18;
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(600, 366);
			this.Controls.Add(this.addedLabel);
			this.Controls.Add(this.removeButton);
			this.Controls.Add(this.customStringComboBox);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.folderName2TextBox);
			this.Controls.Add(this.folderNameLabel2);
			this.Controls.Add(this.customStringLabel);
			this.Controls.Add(this.filePrefixTextBox);
			this.Controls.Add(this.filePrefixLabel);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.folderNameTextBox);
			this.Controls.Add(this.folderNameLabel);
			this.Controls.Add(this.fileTypeLabel);
			this.Controls.Add(this.fileTypeComboBox);
			this.Controls.Add(this.SortExistingFilesCheckBox);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
		private System.Windows.Forms.TextBox filePrefixTextBox;
		private System.Windows.Forms.Label filePrefixLabel;
		private System.Windows.Forms.Label customStringLabel;
		private System.Windows.Forms.Label folderNameLabel2;
		private System.Windows.Forms.TextBox folderName2TextBox;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.ComboBox customStringComboBox;
		private System.Windows.Forms.Button removeButton;
		private System.Windows.Forms.Label addedLabel;
	}
}