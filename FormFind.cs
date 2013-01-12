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
	public partial class FormFind : Form
	{
		public FormFind()
		{
			InitializeComponent();
		}

		private FormMain formMain = null;

		private void FormFind_Load(object sender, EventArgs e)
		{
			this.Text = Globals.Strings.CAPTION_FIND;
		}

		private void FormFind_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Если нас закрывает пользователь (а не операционная система или еще что)
			// То мы просто скрываем форму
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;

				this.Visible = false;
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			// Скрываем форму
			this.Visible = false;

			// Вытаскиваем родительскую форму наверх
			formMain.BringToFront();
		}

		public void Display(FormMain main)
		{
			// Сохраняем ссылку на главную форму
			formMain = main;

			// Нам нужно расположить окно посередине родителя
			int x = formMain.Left + ((formMain.Width - this.Width) / 2);
			int y = formMain.Top + ((formMain.Height - this.Height) / 2);

			this.Location = new Point(x, y);

			// Восстанавливаем текст в текстовом поле
			textFind.Text = formMain.searchString;
			textFind_TextChanged(null, null);

			// Ищем всегда "Вниз"
			radioDirectonForward.Checked = true;

			// Ищем всегда без учета регистра
			checkCase.Checked = false;

			// Весь текст в текстовом поле должен быть выделен
			textFind.SelectAll();

			// В этом поле должен стоять курсор
			textFind.Focus();

			// Показываем окно
			this.Visible = true;
		}

		private void textFind_TextChanged(object sender, EventArgs e)
		{
			buttonFind.Enabled = textFind.TextLength != 0;
		}

		private void buttonFind_Click(object sender, EventArgs e)
		{
			// Сохраняем то, что хочет найти пользователь
			formMain.searchString = textFind.Text;

			// Вызываем поиск
			formMain.PerformSearch(checkCase.Checked, radioDirectonForward.Checked);
		}
	}
}
