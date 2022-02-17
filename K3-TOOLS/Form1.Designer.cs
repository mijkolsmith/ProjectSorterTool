
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
			this.SuspendLayout();
			// 
			// sortButton
			// 
			this.sortButton.Location = new System.Drawing.Point(146, 412);
			this.sortButton.Name = "sortButton";
			this.sortButton.Size = new System.Drawing.Size(75, 23);
			this.sortButton.TabIndex = 0;
			this.sortButton.Text = "Sort";
			this.sortButton.UseVisualStyleBackColor = true;
			this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
			// 
			// testLabel
			// 
			this.testLabel.AutoSize = true;
			this.testLabel.Location = new System.Drawing.Point(154, 445);
			this.testLabel.Name = "testLabel";
			this.testLabel.Size = new System.Drawing.Size(58, 17);
			this.testLabel.TabIndex = 1;
			this.testLabel.Text = "testText";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(884, 483);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(134, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "made by mijkolsmith";
			// 
			// panel1
			// 
			this.panel1.AllowDrop = true;
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(50, 50, 0, 0);
			this.panel1.Size = new System.Drawing.Size(1030, 400);
			this.panel1.TabIndex = 3;
			this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
			this.panel1.DragOver += new System.Windows.Forms.DragEventHandler(this.panel1_DragOver);
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1030, 509);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.testLabel);
			this.Controls.Add(this.sortButton);
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
	}
}

