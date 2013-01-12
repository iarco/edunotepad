namespace EduNotepad
{
	partial class FormFind
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
			this.labelFind = new System.Windows.Forms.Label();
			this.textFind = new System.Windows.Forms.TextBox();
			this.buttonFind = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.checkCase = new System.Windows.Forms.CheckBox();
			this.groupDirection = new System.Windows.Forms.GroupBox();
			this.radioDirectonBackward = new System.Windows.Forms.RadioButton();
			this.radioDirectonForward = new System.Windows.Forms.RadioButton();
			this.groupDirection.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelFind
			// 
			this.labelFind.AutoSize = true;
			this.labelFind.Location = new System.Drawing.Point(3, 13);
			this.labelFind.Name = "labelFind";
			this.labelFind.Size = new System.Drawing.Size(29, 13);
			this.labelFind.TabIndex = 0;
			this.labelFind.Text = "Что:";
			// 
			// textFind
			// 
			this.textFind.Location = new System.Drawing.Point(44, 11);
			this.textFind.Name = "textFind";
			this.textFind.Size = new System.Drawing.Size(227, 20);
			this.textFind.TabIndex = 1;
			this.textFind.TextChanged += new System.EventHandler(this.textFind_TextChanged);
			// 
			// buttonFind
			// 
			this.buttonFind.Location = new System.Drawing.Point(281, 8);
			this.buttonFind.Name = "buttonFind";
			this.buttonFind.Size = new System.Drawing.Size(80, 23);
			this.buttonFind.TabIndex = 2;
			this.buttonFind.Text = "Найти далее";
			this.buttonFind.UseVisualStyleBackColor = true;
			this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(281, 37);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(80, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// checkCase
			// 
			this.checkCase.AutoSize = true;
			this.checkCase.Location = new System.Drawing.Point(6, 68);
			this.checkCase.Name = "checkCase";
			this.checkCase.Size = new System.Drawing.Size(120, 17);
			this.checkCase.TabIndex = 4;
			this.checkCase.Text = "С учетом регистра";
			this.checkCase.UseVisualStyleBackColor = true;
			// 
			// groupDirection
			// 
			this.groupDirection.Controls.Add(this.radioDirectonForward);
			this.groupDirection.Controls.Add(this.radioDirectonBackward);
			this.groupDirection.Location = new System.Drawing.Point(153, 39);
			this.groupDirection.Name = "groupDirection";
			this.groupDirection.Size = new System.Drawing.Size(120, 47);
			this.groupDirection.TabIndex = 5;
			this.groupDirection.TabStop = false;
			this.groupDirection.Text = "Направление";
			// 
			// radioDirectonBackward
			// 
			this.radioDirectonBackward.AutoSize = true;
			this.radioDirectonBackward.Location = new System.Drawing.Point(6, 19);
			this.radioDirectonBackward.Name = "radioDirectonBackward";
			this.radioDirectonBackward.Size = new System.Drawing.Size(55, 17);
			this.radioDirectonBackward.TabIndex = 0;
			this.radioDirectonBackward.TabStop = true;
			this.radioDirectonBackward.Text = "Вверх";
			this.radioDirectonBackward.UseVisualStyleBackColor = true;
			// 
			// radioDirectonForward
			// 
			this.radioDirectonForward.AutoSize = true;
			this.radioDirectonForward.Location = new System.Drawing.Point(67, 19);
			this.radioDirectonForward.Name = "radioDirectonForward";
			this.radioDirectonForward.Size = new System.Drawing.Size(50, 17);
			this.radioDirectonForward.TabIndex = 1;
			this.radioDirectonForward.TabStop = true;
			this.radioDirectonForward.Text = "Вниз";
			this.radioDirectonForward.UseVisualStyleBackColor = true;
			// 
			// FormFind
			// 
			this.AcceptButton = this.buttonFind;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(368, 101);
			this.Controls.Add(this.groupDirection);
			this.Controls.Add(this.checkCase);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonFind);
			this.Controls.Add(this.textFind);
			this.Controls.Add(this.labelFind);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormFind";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "FormFind";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFind_FormClosing);
			this.Load += new System.EventHandler(this.FormFind_Load);
			this.groupDirection.ResumeLayout(false);
			this.groupDirection.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelFind;
		private System.Windows.Forms.TextBox textFind;
		private System.Windows.Forms.Button buttonFind;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.GroupBox groupDirection;
		private System.Windows.Forms.RadioButton radioDirectonForward;
		private System.Windows.Forms.RadioButton radioDirectonBackward;
		public System.Windows.Forms.CheckBox checkCase;
	}
}