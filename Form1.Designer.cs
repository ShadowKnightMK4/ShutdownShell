namespace ShutdownShell
{
	partial class MainForm
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
			this.LogOffButton = new System.Windows.Forms.Button();
			this.HibernateButton = new System.Windows.Forms.Button();
			this.ShutdownButton = new System.Windows.Forms.Button();
			this.CheckBoxTopMost = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// LogOffButton
			// 
			this.LogOffButton.Location = new System.Drawing.Point(12, 12);
			this.LogOffButton.Name = "LogOffButton";
			this.LogOffButton.Size = new System.Drawing.Size(90, 36);
			this.LogOffButton.TabIndex = 0;
			this.LogOffButton.Text = "Log Off";
			this.LogOffButton.UseVisualStyleBackColor = true;
			this.LogOffButton.Click += new System.EventHandler(this.LogOff_ButtonClick);
			// 
			// HibernateButton
			// 
			this.HibernateButton.Location = new System.Drawing.Point(12, 54);
			this.HibernateButton.Name = "HibernateButton";
			this.HibernateButton.Size = new System.Drawing.Size(90, 35);
			this.HibernateButton.TabIndex = 1;
			this.HibernateButton.Text = "Hibernate";
			this.HibernateButton.UseVisualStyleBackColor = true;
			this.HibernateButton.Click += new System.EventHandler(this.HibernateButton_Click);
			// 
			// ShutdownButton
			// 
			this.ShutdownButton.Location = new System.Drawing.Point(12, 95);
			this.ShutdownButton.Name = "ShutdownButton";
			this.ShutdownButton.Size = new System.Drawing.Size(90, 35);
			this.ShutdownButton.TabIndex = 2;
			this.ShutdownButton.Text = "Shutdown";
			this.ShutdownButton.UseVisualStyleBackColor = true;
			this.ShutdownButton.Click += new System.EventHandler(this.ShutdownButton_Click);
			// 
			// CheckBoxTopMost
			// 
			this.CheckBoxTopMost.AutoSize = true;
			this.CheckBoxTopMost.Location = new System.Drawing.Point(109, 12);
			this.CheckBoxTopMost.Name = "CheckBoxTopMost";
			this.CheckBoxTopMost.Size = new System.Drawing.Size(97, 24);
			this.CheckBoxTopMost.TabIndex = 3;
			this.CheckBoxTopMost.Text = "Topmost";
			this.CheckBoxTopMost.UseVisualStyleBackColor = true;
			this.CheckBoxTopMost.CheckedChanged += new System.EventHandler(this.CheckBoxTopMost_Clicked);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(423, 142);
			this.Controls.Add(this.CheckBoxTopMost);
			this.Controls.Add(this.ShutdownButton);
			this.Controls.Add(this.HibernateButton);
			this.Controls.Add(this.LogOffButton);
			this.Name = "MainForm";
			this.Text = "Shutdown Shell Menu";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.LocationChanged += new System.EventHandler(this.Form1_LocationChanged);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button LogOffButton;
		private System.Windows.Forms.Button HibernateButton;
		private System.Windows.Forms.Button ShutdownButton;
		private System.Windows.Forms.CheckBox CheckBoxTopMost;
	}
}

