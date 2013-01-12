namespace EduNotepad
{
	partial class FormGoTo
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
			this.label1 = new System.Windows.Forms.Label();
			this.numericGoTo = new System.Windows.Forms.NumericUpDown();
			this.buttonGoTo = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericGoTo)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "&Номер строки";
			// 
			// numericGoTo
			// 
			this.numericGoTo.Location = new System.Drawing.Point(12, 28);
			this.numericGoTo.Name = "numericGoTo";
			this.numericGoTo.Size = new System.Drawing.Size(227, 20);
			this.numericGoTo.TabIndex = 1;
			// 
			// buttonGoTo
			// 
			this.buttonGoTo.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonGoTo.Location = new System.Drawing.Point(81, 54);
			this.buttonGoTo.Name = "buttonGoTo";
			this.buttonGoTo.Size = new System.Drawing.Size(75, 23);
			this.buttonGoTo.TabIndex = 2;
			this.buttonGoTo.Text = "Переход";
			this.buttonGoTo.UseVisualStyleBackColor = true;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(162, 54);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// FormGoTo
			// 
			this.AcceptButton = this.buttonGoTo;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(249, 98);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonGoTo);
			this.Controls.Add(this.numericGoTo);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormGoTo";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormGoTo";
			this.Load += new System.EventHandler(this.FormGoTo_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericGoTo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericGoTo;
		private System.Windows.Forms.Button buttonGoTo;
		private System.Windows.Forms.Button buttonCancel;
	}
}