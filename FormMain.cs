using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduNotepad
{
	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();
		}

		private void FormMain_Resize(object sender, EventArgs e)
		{
			// TODO: Код для изменения размеров

			Settings.WindowSize = this.Size;
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			// Выставляем размер окна
			this.Size = Settings.WindowSize;

			// Выставляем положение окна
			this.Location = Settings.WindowLocation;

			// TODO: Иногда пропадает курсор
		}

		private void FormMain_Move(object sender, EventArgs e)
		{
			Settings.WindowLocation = this.Location;
		}

		private void menuFileNew_Click(object sender, EventArgs e)
		{
			Console.WriteLine("Создать новый файл");
		}

		private void menuFileOpen_Click(object sender, EventArgs e)
		{
			if (dialogOpen.ShowDialog() == DialogResult.OK)
			{
				// Пользователь выбрал файл

				FormEncoding fe = new FormEncoding();
				Console.WriteLine(fe.ShowDialog());
			}
		}

		private void menuFileSave_Click(object sender, EventArgs e)
		{

		}

		private void menuFileSaveAs_Click(object sender, EventArgs e)
		{

		}

		private void menuFilePageSetup_Click(object sender, EventArgs e)
		{

		}

		private void menuFilePrint_Click(object sender, EventArgs e)
		{

		}

		private void menuFileExit_Click(object sender, EventArgs e)
		{

		}

		private void menuEditUndo_Click(object sender, EventArgs e)
		{
			textMain.Undo();
		}

		private void menuEditCut_Click(object sender, EventArgs e)
		{
			textMain.Cut();
		}

		private void menuEditCopy_Click(object sender, EventArgs e)
		{
			textMain.Copy();
		}

		private void menuEditPaste_Click(object sender, EventArgs e)
		{
			textMain.Paste();
		}

		private void menuEditDelete_Click(object sender, EventArgs e)
		{
			// TODO: Неверно работает Delete
			
			textMain.SelectedText = string.Empty;
		}

		private void menuEditFind_Click(object sender, EventArgs e)
		{
			// TODO: menuEditFind
		}

		private void menuEditFindNext_Click(object sender, EventArgs e)
		{
			// TODO: menuEditFindNext
		}

		private void menuEditReplace_Click(object sender, EventArgs e)
		{
			// TODO: menuEditReplace
		}

		private void menuEditGo_Click(object sender, EventArgs e)
		{
			// TODO: menuEditGo
		}

		private void menuEditSelectAll_Click(object sender, EventArgs e)
		{
			textMain.SelectAll();
		}

		private void menuEditDateTime_Click(object sender, EventArgs e)
		{
			// 15:59 04.01.2013

			// TODO: Не работает Ctrl+Z

			DateTime dtNow = DateTime.Now;
			string dateTime = string.Format("{0} {1}", dtNow.ToShortTimeString(), dtNow.ToShortDateString());

			if (textMain.SelectionLength != 0)
			{
				textMain.SelectedText = dateTime;
			}
			else
			{
				int selectionIndex = textMain.SelectionStart;
				textMain.Text = textMain.Text.Insert(selectionIndex, dateTime);
				textMain.SelectionStart = selectionIndex + dateTime.Length;
			}
		}

		private void menuEdit_DropDownOpening(object sender, EventArgs e)
		{

			// Доступность пункта меню "Отмена"
			menuEditUndo.Enabled = textMain.CanUndo;

			bool hasSelectedText = textMain.SelectionLength != 0;
			menuEditCut.Enabled = hasSelectedText;
			menuEditCopy.Enabled = hasSelectedText;
			menuEditDelete.Enabled = hasSelectedText;

			menuEditPaste.Enabled = Clipboard.ContainsText();

			bool hasText = textMain.TextLength != 0;
			menuEditFind.Enabled = hasText;
			menuEditFindNext.Enabled = hasText;
			menuEditReplace.Enabled = hasText;
			menuEditGo.Enabled = hasText;
			menuEditSelectAll.Enabled = hasText;
		}

		private void menuHelpAbout_Click(object sender, EventArgs e)
		{
			(new FormAbout() { Text = Globals.Strings.AboutCaption }).ShowDialog();
		}
	}
}
