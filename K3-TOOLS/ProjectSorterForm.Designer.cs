
namespace K3_TOOLS
{
	partial class ProjectSorterForm
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
			this.sortButton = new System.Windows.Forms.Button();
			this.statusLabel = new System.Windows.Forms.Label();
			this.makerLabel = new System.Windows.Forms.Label();
			this.FileDropPanel = new System.Windows.Forms.Panel();
			this.setFolderButton = new System.Windows.Forms.Button();
			this.baseDirectoryLabel = new System.Windows.Forms.Label();
			this.settingsButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// sortButton
			// 
			this.sortButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.sortButton.BackColor = System.Drawing.Color.WhiteSmoke;
			this.sortButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.sortButton.Location = new System.Drawing.Point(192, 603);
			this.sortButton.Name = "sortButton";
			this.sortButton.Size = new System.Drawing.Size(75, 25);
			this.sortButton.TabIndex = 1;
			this.sortButton.Text = "Sort";
			this.sortButton.UseVisualStyleBackColor = false;
			this.sortButton.Click += new System.EventHandler(this.SortButton_Click);
			// 
			// statusLabel
			// 
			this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.statusLabel.AutoSize = true;
			this.statusLabel.Location = new System.Drawing.Point(190, 629);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(125, 17);
			this.statusLabel.TabIndex = 2;
			this.statusLabel.Text = "Status: Not sorting";
			// 
			// makerLabel
			// 
			this.makerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.makerLabel.AutoSize = true;
			this.makerLabel.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.makerLabel.Location = new System.Drawing.Point(916, 647);
			this.makerLabel.Name = "makerLabel";
			this.makerLabel.Size = new System.Drawing.Size(134, 17);
			this.makerLabel.TabIndex = 5;
			this.makerLabel.Text = "made by mijkolsmith";
			this.makerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FileDropPanel
			// 
			this.FileDropPanel.AllowDrop = true;
			this.FileDropPanel.AutoScroll = true;
			this.FileDropPanel.BackColor = System.Drawing.Color.LightGray;
			this.FileDropPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.FileDropPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.FileDropPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.FileDropPanel.Location = new System.Drawing.Point(0, 0);
			this.FileDropPanel.Margin = new System.Windows.Forms.Padding(0);
			this.FileDropPanel.Name = "FileDropPanel";
			this.FileDropPanel.Size = new System.Drawing.Size(1062, 540);
			this.FileDropPanel.TabIndex = 6;
			this.FileDropPanel.TabStop = true;
			this.FileDropPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileDropPanel_DragDrop);
			this.FileDropPanel.DragOver += new System.Windows.Forms.DragEventHandler(this.FileDropPanel_DragOver);
			// 
			// setFolderButton
			// 
			this.setFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.setFolderButton.BackColor = System.Drawing.Color.WhiteSmoke;
			this.setFolderButton.Location = new System.Drawing.Point(22, 603);
			this.setFolderButton.Name = "setFolderButton";
			this.setFolderButton.Size = new System.Drawing.Size(148, 25);
			this.setFolderButton.TabIndex = 0;
			this.setFolderButton.Text = "Set Project Directory";
			this.setFolderButton.UseVisualStyleBackColor = false;
			this.setFolderButton.Click += new System.EventHandler(this.SetFolder_Click);
			// 
			// baseDirectoryLabel
			// 
			this.baseDirectoryLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.baseDirectoryLabel.AutoSize = true;
			this.baseDirectoryLabel.Location = new System.Drawing.Point(435, 550);
			this.baseDirectoryLabel.Name = "baseDirectoryLabel";
			this.baseDirectoryLabel.Size = new System.Drawing.Size(192, 17);
			this.baseDirectoryLabel.TabIndex = 3;
			this.baseDirectoryLabel.Text = "Project Directory Placeholder";
			// 
			// settingsButton
			// 
			this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.settingsButton.BackColor = System.Drawing.Color.WhiteSmoke;
			this.settingsButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.settingsButton.Location = new System.Drawing.Point(975, 603);
			this.settingsButton.Name = "settingsButton";
			this.settingsButton.Size = new System.Drawing.Size(75, 25);
			this.settingsButton.TabIndex = 7;
			this.settingsButton.Text = "Settings";
			this.settingsButton.UseVisualStyleBackColor = false;
			this.settingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
			// 
			// ProjectSorterForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(1062, 673);
			this.Controls.Add(this.settingsButton);
			this.Controls.Add(this.baseDirectoryLabel);
			this.Controls.Add(this.setFolderButton);
			this.Controls.Add(this.makerLabel);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.sortButton);
			this.Controls.Add(this.FileDropPanel);
			this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::K3_TOOLS.Properties.Settings.Default, "WindowLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Location = global::K3_TOOLS.Properties.Settings.Default.WindowLocation;
			this.Name = "ProjectSorterForm";
			this.Text = "Project Sorter Tool";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjectSorterForm_FormClosing);
			this.Load += new System.EventHandler(this.ProjectSorterForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button sortButton;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Label makerLabel;
		private System.Windows.Forms.Panel FileDropPanel;
		private System.Windows.Forms.Button setFolderButton;
		private System.Windows.Forms.Label baseDirectoryLabel;
		private System.Windows.Forms.Button settingsButton;
	}
}

