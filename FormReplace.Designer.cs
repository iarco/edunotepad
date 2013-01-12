namespace EduNotepad
{
	partial class FormReplace
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
			this.label2 = new System.Windows.Forms.Label();
			this.textReplace = new System.Windows.Forms.TextBox();
			this.checkCase = new System.Windows.Forms.CheckBox();
			this.buttonFind = new System.Windows.Forms.Button();
			this.buttonReplace = new System.Windows.Forms.Button();
			this.buttonReplaceAll = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelFind
			// 
			this.labelFind.AutoSize = true;
			this.labelFind.Location = new System.Drawing.Point(3, 15);
			this.labelFind.Name = "labelFind";
			this.labelFind.Size = new System.Drawing.Size(29, 13);
			this.labelFind.TabIndex = 0;
			this.labelFind.Text = "Чт&о:";
			// 
			// textFind
			// 
			this.textFind.Location = new System.Drawing.Point(41, 11);
			this.textFind.Name = "textFind";
			this.textFind.Size = new System.Drawing.Size(212, 20);
			this.textFind.TabIndex = 1;
			this.textFind.TextChanged += new System.EventHandler(this.textFind_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Ч&ем:";
			// 
			// textReplace
			// 
			this.textReplace.Location = new System.Drawing.Point(41, 39);
			this.textReplace.Name = "textReplace";
			this.textReplace.Size = new System.Drawing.Size(212, 20);
			this.textReplace.TabIndex = 3;
			// 
			// checkCase
			// 
			this.checkCase.AutoSize = true;
			this.checkCase.Location = new System.Drawing.Point(8, 103);
			this.checkCase.Name = "checkCase";
			this.checkCase.Size = new System.Drawing.Size(120, 17);
			this.checkCase.TabIndex = 4;
			this.checkCase.Text = "С учетом ре&гистра";
			this.checkCase.UseVisualStyleBackColor = true;
			// 
			// buttonFind
			// 
			this.buttonFind.Location = new System.Drawing.Point(264, 7);
			this.buttonFind.Name = "buttonFind";
			this.buttonFind.Size = new System.Drawing.Size(86, 23);
			this.buttonFind.TabIndex = 5;
			this.buttonFind.Text = "&Найти далее";
			this.buttonFind.UseVisualStyleBackColor = true;
			this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
			// 
			// buttonReplace
			// 
			this.buttonReplace.Location = new System.Drawing.Point(264, 34);
			this.buttonReplace.Name = "buttonReplace";
			this.buttonReplace.Size = new System.Drawing.Size(86, 23);
			this.buttonReplace.TabIndex = 6;
			this.buttonReplace.Text = "&Заменить";
			this.buttonReplace.UseVisualStyleBackColor = true;
			this.buttonReplace.Click += new System.EventHandler(this.buttonReplace_Click);
			// 
			// buttonReplaceAll
			// 
			this.buttonReplaceAll.Location = new System.Drawing.Point(264, 62);
			this.buttonReplaceAll.Name = "buttonReplaceAll";
			this.buttonReplaceAll.Size = new System.Drawing.Size(86, 23);
			this.buttonReplaceAll.TabIndex = 7;
			this.buttonReplaceAll.Text = "Заменить &все";
			this.buttonReplaceAll.UseVisualStyleBackColor = true;
			this.buttonReplaceAll.Click += new System.EventHandler(this.buttonReplaceAll_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(264, 89);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(86, 23);
			this.buttonCancel.TabIndex = 8;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// FormReplace
			// 
			this.AcceptButton = this.buttonFind;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(357, 153);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonReplaceAll);
			this.Controls.Add(this.buttonReplace);
			this.Controls.Add(this.buttonFind);
			this.Controls.Add(this.checkCase);
			this.Controls.Add(this.textReplace);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textFind);
			this.Controls.Add(this.labelFind);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormReplace";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "FormReplace";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormReplace_FormClosing);
			this.Load += new System.EventHandler(this.FormReplace_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelFind;
		private System.Windows.Forms.TextBox textFind;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textReplace;
		private System.Windows.Forms.CheckBox checkCase;
		private System.Windows.Forms.Button buttonFind;
		private System.Windows.Forms.Button buttonReplace;
		private System.Windows.Forms.Button buttonReplaceAll;
		private System.Windows.Forms.Button buttonCancel;
	}
}