﻿namespace EduNotepad
{
	partial class FormAbout
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
			this.labelName = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelName
			// 
			this.labelName.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelName.Location = new System.Drawing.Point(12, 9);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(260, 49);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "EduNotepad";
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(197, 226);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			// 
			// FormAbout
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonOK;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.labelName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormAbout";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormAbout";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.Button buttonOK;
	}
}