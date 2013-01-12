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
	public partial class FormReplace : Form
	{
		private FormMain formMain = null;

		public FormReplace()
		{
			InitializeComponent();
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
			textReplace.Text = formMain.replaceString;
			textFind_TextChanged(null, null);

			// Ищем всегда без учета регистра
			checkCase.Checked = false;

			// Весь текст в текстовом поле должен быть выделен
			textFind.SelectAll();

			// В этом поле должен стоять курсор
			textFind.Focus();

			// Показываем окно
			this.Visible = true;
		}

		private void FormReplace_Load(object sender, EventArgs e)
		{
			this.Text = Globals.Strings.CAPTION_REPLACE;
		}

		private void FormReplace_FormClosing(object sender, FormClosingEventArgs e)
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

		private void textFind_TextChanged(object sender, EventArgs e)
		{
			bool buttonEnabled = textFind.TextLength != 0;

			buttonFind.Enabled = buttonEnabled;
			buttonReplace.Enabled = buttonEnabled;
			buttonReplaceAll.Enabled = buttonEnabled;
		}

		private void buttonFind_Click(object sender, EventArgs e)
		{
			// Сохраняем текст поиска
			formMain.searchString = textFind.Text;

			// Сохраняем текст замены
			formMain.replaceString = textReplace.Text;

			// Выполняем поиск
			formMain.PerformSearch(checkCase.Checked, true);
		}

		private void buttonReplace_Click(object sender, EventArgs e)
		{
			// Если есть выделенный текст и он подходит под условия поиска, он заменяется
			// Если есть выделенный текст и он не подходит, то ничего не делается
			// Если нет выделеного текста, то ничего не делается
			// Обязательно нажимается "Найти далее"

			if (formMain.textMain.SelectionLength != 0)
			{
				if (string.Compare(formMain.textMain.SelectedText, textFind.Text, !checkCase.Checked) == 0)
				{
					formMain.textMain.Paste(textReplace.Text);
				}
			}

			// Нажимаем "Найти далее"
			buttonFind_Click(null, null);
		}

		private void buttonReplaceAll_Click(object sender, EventArgs e)
		{
			// Сохраняем текст поиска
			formMain.searchString = textFind.Text;

			// Сохраняем текст замены
			formMain.replaceString = textReplace.Text;

			// А теперь выполняем замену
			StringComparison stringCompare = checkCase.Checked ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;
			string newText = formMain.textMain.Text.Replace(textFind.Text, textReplace.Text, stringCompare);

			if (newText.MD5OfText() != formMain.textMain.Text.MD5OfText())
			{
				// Да, что-то изменилось
				formMain.textMain.SelectAll();
				formMain.textMain.Paste(newText);
			}
		}
	}
}
