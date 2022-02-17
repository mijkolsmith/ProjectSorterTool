
namespace K3_TOOLS
{
	partial class Form1
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
			this.testLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.baseDirectoryLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// sortButton
			// 
			this.sortButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.sortButton.Location = new System.Drawing.Point(192, 603);
			this.sortButton.Name = "sortButton";
			this.sortButton.Size = new System.Drawing.Size(75, 23);
			this.sortButton.TabIndex = 1;
			this.sortButton.Text = "Sort";
			this.sortButton.UseVisualStyleBackColor = true;
			this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
			// 
			// testLabel
			// 
			this.testLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.testLabel.AutoSize = true;
			this.testLabel.Location = new System.Drawing.Point(190, 629);
			this.testLabel.Name = "testLabel";
			this.testLabel.Size = new System.Drawing.Size(77, 17);
			this.testLabel.TabIndex = 2;
			this.testLabel.Text = "Not sorting";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.label1.Location = new System.Drawing.Point(916, 647);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(134, 17);
			this.label1.TabIndex = 5;
			this.label1.Text = "made by mijkolsmith";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.AllowDrop = true;
			this.panel1.AutoScroll = true;
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1062, 540);
			this.panel1.TabIndex = 6;
			this.panel1.TabStop = true;
			this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
			this.panel1.DragOver += new System.Windows.Forms.DragEventHandler(this.panel1_DragOver);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button1.Location = new System.Drawing.Point(22, 603);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(148, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Set Project Directory";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
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
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1062, 673);
			this.Controls.Add(this.baseDirectoryLabel);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.testLabel);
			this.Controls.Add(this.sortButton);
			this.Controls.Add(this.panel1);
			this.Name = "Form1";
			this.Text = "Project Sorter Tool";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button sortButton;
		private System.Windows.Forms.Label testLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label baseDirectoryLabel;
	}
}

