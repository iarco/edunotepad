using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EduNotepad
{
	public partial class FormGoTo : Form
	{
		public FormGoTo()
		{
			InitializeComponent();
		}

		private void FormGoTo_Load(object sender, EventArgs e)
		{
			// Устанавливаем заголовок окна
			this.Text = Globals.Strings.CAPTION_GOTO;

			// Скрываем стрелочки в numericUpDown
			numericGoTo.Controls[0].Hide();
		}

		public int GetLine(int currentLine, int totalLines)
		{
			int returnValue = 0;

			// Устанавливаем минимум и максимум
			numericGoTo.Minimum = 1;
			numericGoTo.Maximum = totalLines;

			// Устанавливаем текущую строку
			numericGoTo.Value = currentLine;

			// Показываем окно
			if (this.ShowDialog() == DialogResult.OK)
			{
				returnValue = (int)numericGoTo.Value;
			}

			return returnValue;
		}
	}
}
