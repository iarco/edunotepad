using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduNotepad
{
	public partial class FormMain : Form
	{
		private class FileInformation
		{
			public string fileName = string.Empty;
			public Encoding fileEncoding = null;

			public bool Cancel
			{
				get
				{
					return fileName == string.Empty || fileEncoding == null;
				}
			}
		}

		// Переменная для хранения имени файла
		private string fileName = string.Empty;

		// Переменная для хранения кодировки файла
		private Encoding fileEncoding = null;

		// Переменная для хранения хэша от последнего сохранения
		private string saveMD5 = string.Empty;

		// Переменные для форм
		FormEncoding formEncoding = null;

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

			// Обновляем заголовок окна
			this.Text = CreateWindowCaption();
		}

		private void FormMain_Move(object sender, EventArgs e)
		{
			Settings.WindowLocation = this.Location;
		}

		private void menuFileNew_Click(object sender, EventArgs e)
		{
			// TODO: Разобраться с теми изменениями, что мог внести пользователь

			// Обнуляем имя файла
			fileName = string.Empty;

			// Обнуляем кодировку
			fileEncoding = null;

			// Обнуляем хэш
			saveMD5 = string.Empty;

			// Обнуляем текстовое поле
			textMain.Text = string.Empty;

			// Обновляем заголовок окна
			this.Text = CreateWindowCaption();
		}

		private void menuFileOpen_Click(object sender, EventArgs e)
		{
			// TODO: Разобраться с теми изменениями, что мог внести пользователь

			// Спрашиваем у пользователя кодировку и имя файла
			FileInformation fi = GetOpenFileNameAndEncoding();

			if (!fi.Cancel)
			{
 				// Выполняем чтение файла
				PerformFileOpen(fi.fileName, fi.fileEncoding);
			}
		}

		private FileInformation GetOpenFileNameAndEncoding()
		{
			FileInformation returnValue = new FileInformation();

			// Изначально устанавливаем путь в Мои документы
			dialogOpen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

			// Если есть уже открытый файл, то установим его папку
			if (fileName != string.Empty)
			{
				// Проверим, существует ли эта папка?
				string fileFolder = Path.GetDirectoryName(fileName);
				if (Directory.Exists(fileFolder))
				{
					dialogOpen.InitialDirectory = fileFolder;
				}
			}

			// Очищаем предыдущее имя файла
			dialogOpen.FileName = string.Empty;

			if (dialogOpen.ShowDialog() == DialogResult.OK)
			{
 				// Пользователь выбрал файл, начинаем спрашивать у него кодировку

				returnValue.fileName = dialogOpen.FileName;

				// TODO: Попытаться определить кодировку файла по первым 2 или 3 байтам

				// Спрашиваем кодировку
				if (formEncoding == null) formEncoding = new FormEncoding();
				returnValue.fileEncoding = formEncoding.SelectEncoding(null);
			}

			return returnValue;
		}

		public void PerformFileOpen(string file, Encoding encoding)
		{
			try
			{
				// Выполняем чтение файла
				textMain.Text = File.ReadAllText(file, encoding);

				// Ставим курсор в начало файла
				textMain.SelectionStart = 0;

				// Сохраняем в нашей переменной хэш от файла
				saveMD5 = textMain.MD5OfText();

				// Сохраняем в наших переменных имя файла и кодировку
				fileName = file;
				fileEncoding = encoding;

				// Устанавливаем заголовок окна
				this.Text = CreateWindowCaption();

				// Проверяем, не начинается ли файл с .LOG?
				if (textMain.Lines.Length > 0 && textMain.Lines[0].Length > 3 && textMain.Lines[0].Substring(0, 4) == ".LOG")
				{
 					// Да, нужно вставить текущую дату и время
					textMain.Text += string.Format("\r\n{0}\r\n", GetDateTime());

					// Переходим в самый конец файла
					textMain.SelectionStart = textMain.Text.Length;
				}
			}
			catch (Exception e)
			{
				string message = string.Format(Globals.Strings.MESSAGE_ERROR_FILE_OPEN, file, e.Message);
				MessageBox.Show(message, Globals.Strings.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private string GetDateTime()
		{
 			// Возвращаем дату и время в одинаковом формате для .LOG и для меню Правка
			string returnValue = string.Empty;
			
			DateTime dtNow = DateTime.Now;
			returnValue = string.Format("{0} {1}", dtNow.ToShortTimeString(), dtNow.ToShortDateString());
			
			return returnValue;
		}

		private string CreateWindowCaption()
		{
 			// Если файла нет, то мы должны вернуть "Безымянный"
			// Если файл есть, и у него расширение txt, то вернем только имя файла
			// Если файл есть, и у него расширение не txt, то вернем имя файла целиком

			// Изначально считаем, что нет файла
			string returnValue = Globals.Strings.UNTITLED;

			if (fileName != string.Empty)
			{
				if (Path.GetExtension(fileName).ToLower() == ".txt")
				{
 					// Да, расширение файла - txt
					returnValue = Path.GetFileNameWithoutExtension(fileName);
				}
				else
				{
 					// Нет, расширение какое-то другое
					returnValue = Path.GetFileName(fileName);
				}
			}

			// Ну и последнее - добавляем в заголовок название программы
			returnValue = string.Format("{0} - {1}", returnValue, Globals.Strings.APP_NAME);

			return returnValue;
		}

		private void menuFileSave_Click(object sender, EventArgs e)
		{
			// Если есть имя файла - выполняем сохранение
			// Если имени нет - вызываем нажатие Сохранить как...

			if (fileName != string.Empty)
			{
				// TODO: У нас есть имя файла, выполняем запись
			}
			else
			{
 				// Имени файла нет
				menuFileSaveAs_Click(null, null);
			}
		}

		private FileInformation GetSaveFileNameAndEncoding()
		{
			FileInformation returnValue = new FileInformation();

			// Изначально устанавливаем путь в Мои документы
			dialogSave.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

			// Очищаем предыдущее имя файла
			dialogSave.FileName = string.Empty;

			// Если есть уже открытый файл
			if (fileName != string.Empty)
			{
				// Если расширение файла - txt, то имя файла без расширения
				// Если расширение файла другое, то имя файла с расширением

				if (Path.GetExtension(fileName).ToLower() == ".txt")
				{
					dialogSave.FileName = Path.GetFileNameWithoutExtension(fileName);
				}
				else
				{
					dialogSave.FileName = Path.GetFileName(fileName);
				}

				// Проверим, существует ли папка с файлом
				string fileFolder = Path.GetDirectoryName(fileName);
				if (Directory.Exists(fileFolder))
				{
					dialogSave.InitialDirectory = fileFolder;
				}
			}

			if (dialogSave.ShowDialog() == DialogResult.OK)
			{
				// Пользователь выбрал файл, начинаем спрашивать у него кодировку

				returnValue.fileName = dialogSave.FileName;

				// Спрашиваем кодировку
				if (formEncoding == null) formEncoding = new FormEncoding();
				returnValue.fileEncoding = formEncoding.SelectEncoding(fileEncoding);
			}

			return returnValue;
		}

		private void menuFileSaveAs_Click(object sender, EventArgs e)
		{
			FileInformation fi = GetSaveFileNameAndEncoding();
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

			string dateTime = GetDateTime();

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
