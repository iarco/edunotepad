using HelpPane;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
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
		public string fileName = string.Empty;

		// Переменная для хранения кодировки файла
		private Encoding fileEncoding = null;

		// Переменная для хранения хэша от последнего сохранения
		private string saveMD5 = string.Empty;

		// Объект для посылаемых на печать строчек
		Queue<string> printLines = new Queue<string>();

		// Переменная для хранения того, что искал пользователь
		public string searchString = string.Empty;

		// Переменная для хранения того, на что заменял пользователь
		public string replaceString = string.Empty;

		// Переменные для форм
		FormEncoding formEncoding = null;
		FormFind formFind = null;
		FormReplace formReplace = null;
		FormGoTo formGoTo = null;

		// TODO: В элементе управления TextBox есть баг:
		// 1. Выключаем перенос по словам, чтобы показался нижний горизонтальный ScrollBar
		// 2. Набираем длинную строку текста с пробелами, чтобы она была очень длинной и чтобы ScrollBar включился
		// 3. Вручную расставляем переносы текста в нашей длинной строке так, чтобы она осталась на экране
		// 4. Обращаем внимание на ScrollBar - он не выключится
		// Спасибо Косте Колганову за нахождение этого бага - в обычном Блокноте он тоже есть :)

		public FormMain()
		{
			InitializeComponent();
		}

		#region События формы

		private void FormMain_Resize(object sender, EventArgs e)
		{
			toolStripStatusLabelRight.Width = (int)(0.25 * this.Width);

			Settings.WindowSize = this.Size;
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			// Выставляем минимальный размер окна
			this.MinimumSize = Settings.MinimumWindowSize;

			// Выставляем размер окна
			this.Size = Settings.WindowSize;

			// Выставляем положение окна
			this.Location = Settings.WindowLocation;

			// Выставляем шрифт
			textMain.Font = Settings.TextBoxFont;

			// TODO: Вызов textMain.WordWrap = false приводит к тому, что текстовое поле теряет фокус (т.е. курсор)
			// Возможно, это какой-то баг, пока непонятно

			// Выставляем перенос по словам
			textMain.WordWrap = Settings.WordWrap;
			menuFormatWordWrap.Checked = Settings.WordWrap;

			if (textMain.WordWrap)
			{
 				// Выключаем панель
				Settings.StatusBar = false;
			}

			StatusBarVisible(Settings.StatusBar);

			// Обновляем заголовок окна
			this.Text = CreateWindowCaption();
		}

		private void FormMain_Move(object sender, EventArgs e)
		{
			// Координаты надо записывать только тогда, когда окно не свернуто или не развернуто (спасибо Диме Крохину)

			if (this.WindowState == FormWindowState.Normal)
			{
				Settings.WindowLocation = this.Location;
			}
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Спрашиваем про имя файла для сохранения только тогда, когда нас закрывает пользователь

			if (e.CloseReason == CloseReason.UserClosing)
			{
				if (!DealWithChanges()) e.Cancel = true;
			}
		}

		private void FormMain_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
		}

		private void FormMain_DragDrop(object sender, DragEventArgs e)
		{
			object dropData = e.Data.GetData(DataFormats.FileDrop);
			string[] files = (string[])dropData;
			string file = files[0];

			if (DealWithChanges())
			{
				if (File.Exists(file))
				{
					// Попытаться определить кодировку файла по первым 2 или 3 байтам
					Encoding fileEncoding = CheckFileEncoding(file);

					// Выполняем открытие файла
					PerformFileOpen(file, fileEncoding);
				}
			}
		}

		#endregion

		#region Файл

		private bool DealWithChanges()
		{
			bool returnValue = false;
			bool haveChanges = false;

			if (saveMD5 != string.Empty)
			{
				// Мы либо уже сохраняли файл, либо работаем с открытым файлом

				// Если есть изменения, то saveMD5 != textMain.MD5OfText()
				haveChanges = saveMD5 != textMain.Text.MD5OfText();
			}
			else
			{
				// Файл не сохранялся, он новый

				// Если есть изменения, то textMain.TextLength != 0
				haveChanges = textMain.TextLength != 0;
			}

			if (!haveChanges)
			{
				// Изменений не было
				returnValue = true;
			}
			else
			{
				// Были изменения, будем разбираться

				// Строим имя файла для отображения
				string fileNameToDisplay = fileName == string.Empty ? Globals.Strings.UNTITLED : fileName;

				DialogResult saveResult = MessageBox.Show(
					string.Format(Globals.Strings.MESSAGE_SAVE_OR_NOT, fileNameToDisplay),
					Globals.Strings.APP_NAME,
					MessageBoxButtons.YesNoCancel,
					MessageBoxIcon.Exclamation);

				switch (saveResult)
				{
					case DialogResult.Yes:
						{
							// Пользователь хочет сохранить изменения

							if (fileName == string.Empty)
							{
								// У нас нет имени файла, надо его спросить

								FileInformation fi = GetSaveFileNameAndEncoding();

								if (!fi.Cancel)
								{
									fileName = fi.fileName;
									fileEncoding = fi.fileEncoding;
								}
							}

							if (fileName == string.Empty)
							{
								// Пользователь где-то нажал "Отмена"
								// Вернем false

								returnValue = false;
							}
							else
							{
								// Вернем результат в зависимости от успешности сохранения

								returnValue = PerformFileSave();
							}

							break;
						}

					case DialogResult.No:
						{
							// Пользователь не хочет ничего сохранять
							// Вернем true, изменения не нужны

							returnValue = true;

							break;
						}

					case DialogResult.Cancel:
						{
							// Пользователь вообще передумал
							// Вернем false, чтобы ничего не произошло далее

							returnValue = false;

							break;
						}

				}
			}

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

		public Encoding CheckFileEncoding(string file)
		{
			Encoding returnValue = Encoding.Default;

			// Unicode = FF FE
			string bomUnicode = "FFFE";

			// Unicode BE = FE FF
			string bomUnicodeBE = "FEFF";

			// UTF-8 = EF BB BF
			string bomUtf8 = "EFBBBF";

			// Создаем буфер для возврата
			byte[] buffer = new byte[3];

			// Создаем объект для файлового потока
			FileStream fs = null;

			// Флаг успешного чтения
			bool success = false;

			try
			{
				fs = new FileStream(file, FileMode.Open, FileAccess.Read);
				fs.Read(buffer, 0, 3);

				// Устанавливаю флаг успешного чтения
				success = true;
			}
			catch (Exception e)
			{
				Debug.Print(e.Message);
			}
			finally
			{
				if (fs != null) fs.Close();
			}

			if (success)
			{
				// Начинаем разбираться, что же мы там прочитали
				string bytes3 = buffer[0].ToString("X2") + buffer[1].ToString("X2") + buffer[2].ToString("X2");
				string bytes2 = buffer[0].ToString("X2") + buffer[1].ToString("X2");

				if (bytes3 == bomUtf8)
				{
					returnValue = Encoding.UTF8;
				}
				else if (bytes2 == bomUnicode)
				{
					returnValue = Encoding.Unicode;
				}
				else if (bytes2 == bomUnicodeBE)
				{
					returnValue = Encoding.BigEndianUnicode;
				}
			}

			return returnValue;
		}

		private void menuFileNew_Click(object sender, EventArgs e)
		{
			if (DealWithChanges())
			{
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
		}

		#region Файл -> Открыть

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

				// Попытаться определить кодировку файла по первым 2 или 3 байтам
				Encoding fileEncoding = CheckFileEncoding(returnValue.fileName);

				// Спрашиваем кодировку
				if (formEncoding == null) formEncoding = new FormEncoding();
				returnValue.fileEncoding = formEncoding.SelectEncoding(fileEncoding);
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
				saveMD5 = textMain.Text.MD5OfText();

				// Сохраняем в наших переменных имя файла и кодировку
				fileName = file;
				fileEncoding = encoding;

				// Устанавливаем заголовок окна
				this.Text = CreateWindowCaption();

				// Проверяем, не начинается ли файл с .LOG?
				if (textMain.Lines.Length > 0 && textMain.Lines[0].Length > 3 && textMain.Lines[0].Substring(0, 4) == ".LOG")
				{
					// Да, нужно вставить текущую дату и время
					textMain.Text += string.Format("\r\n{0}\r\n", DateTime.Now.ToShortDateAndTimeString());

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

		private void menuFileOpen_Click(object sender, EventArgs e)
		{
			if (DealWithChanges())
			{
				// Спрашиваем у пользователя кодировку и имя файла
				FileInformation fi = GetOpenFileNameAndEncoding();

				if (!fi.Cancel)
				{
					// Выполняем чтение файла
					PerformFileOpen(fi.fileName, fi.fileEncoding);
				}
			}
		}

		#endregion

		#region Файл -> Сохранить

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

		private bool PerformFileSave()
		{
			bool returnValue = false;

			try
			{
				// Выполняем запись
				File.WriteAllText(fileName, textMain.Text, fileEncoding);

				// Обновляем хэш
				saveMD5 = textMain.Text.MD5OfText();

				// Строим заголовок окна
				this.Text = CreateWindowCaption();

				// Возвращаемое значение
				returnValue = true;
			}
			catch (Exception e)
			{
				string message = string.Format(Globals.Strings.MESSAGE_ERROR_FILE_SAVE, fileName, e.Message);
				MessageBox.Show(message, Globals.Strings.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return returnValue;
		}

		private void menuFileSave_Click(object sender, EventArgs e)
		{
			// Если есть имя файла - выполняем сохранение
			// Если имени нет - вызываем нажатие Сохранить как...

			if (fileName != string.Empty)
			{
				// Просто выполняем запись файла
				PerformFileSave();
			}
			else
			{
				// Имени файла нет
				menuFileSaveAs_Click(null, null);
			}
		}

		private void menuFileSaveAs_Click(object sender, EventArgs e)
		{
			FileInformation fi = GetSaveFileNameAndEncoding();

			if (!fi.Cancel)
			{
				// Сохраняем значения
				fileName = fi.fileName;
				fileEncoding = fi.fileEncoding;

				// Выполняем запись
				PerformFileSave();
			}
		}

		#endregion

		private void menuFilePageSetup_Click(object sender, EventArgs e)
		{
			// Создаем переменную и в нее кладем текущие настройки
			PageSettings ps = Settings.PageSettings;

			// Передаем настройки диалоговому окну
			dialogPageSetup.PageSettings = ps;
			dialogPageSetup.EnableMetric = false;

			if (dialogPageSetup.ShowDialog() == DialogResult.OK)
			{
				// Пользователь хочет сохранить настройки
				dialogPageSetup.PageSettings.Margins.Left = (int)(Math.Round((double)ps.Margins.Left * 0.254D, 0) * 10D);
				dialogPageSetup.PageSettings.Margins.Right = (int)(Math.Round((double)ps.Margins.Right * 0.254D, 0) * 10D);
				dialogPageSetup.PageSettings.Margins.Top = (int)(Math.Round((double)ps.Margins.Top * 0.254D, 0) * 10D);
				dialogPageSetup.PageSettings.Margins.Bottom = (int)(Math.Round((double)ps.Margins.Bottom * 0.254D, 0) * 10D);

				// Записываем настройки
				Settings.PageSettings = dialogPageSetup.PageSettings;
			}
		}

		#region Файл -> Печать

		private void PreparePrintLines(Graphics g, Rectangle marginBounds)
		{
			string[] lines = textMain.Lines;

			foreach (string line in lines)
			{
				if (line.MeasureWidth(g, Settings.TextBoxFont) <= marginBounds.Width)
				{
					// Наша строчка влезает без изменений, ура!

					// Добавляем ее в список
					printLines.Enqueue(line);
				}
				else
				{
					// Строчка не влезла, придется ее резать

					string[] splitLine = line.Split(new string[] { " " }, StringSplitOptions.None);
					List<string> lineQueue = new List<string>(splitLine);
					string buffer = string.Empty;

					do
					{
						// Очищаем буфер от предыдущих результатов
						buffer = string.Empty;

						// Добавляем в буфер первое слово
						buffer += lineQueue[0].Length == 0 ? " " : lineQueue[0];

						// Проверяем, влезает ли первое слово из строки в ширину листа
						if (buffer.MeasureWidth(g, Settings.TextBoxFont) > marginBounds.Width)
						{
							// Слово не влезло
							string veryLongWord = lineQueue[0];
							string wordBuffer = string.Empty;

							for (int i = 0; i < veryLongWord.Length; i++)
							{
								string newBuffer = wordBuffer + veryLongWord.Substring(i, 1);

								if (newBuffer.MeasureWidth(g, Settings.TextBoxFont) > marginBounds.Width)
								{
									// В newBuffer слишком длинная строка, надо вернуть wordBuffer и прекратить

									// Кладем wordBuffer в наш объект
									printLines.Enqueue(wordBuffer);

									// И теперь обновляем первое слово в нашем массиве слов
									lineQueue[0] = veryLongWord.Substring(i, veryLongWord.Length - i);

									// Прерываем цикл
									break;
								}
								else
								{
									// Продолжаем
									wordBuffer = newBuffer;
								}
							}
						}
						else
						{
							// Слово влезло, можно продолжать

							// Удаляем его из lineQueue
							lineQueue.RemoveAt(0);

							// Запускаем еще один цикл
							while (lineQueue.Count != 0)
							{
								string newBuffer = buffer + " " + lineQueue[0];

								if (newBuffer.MeasureWidth(g, Settings.TextBoxFont) > marginBounds.Width)
								{
									// Мы прибавили одно слово, результат не влез

									// Выходим из цикла
									break;
								}
								else
								{
									// Мы прибавили одно слово, результат влез

									// Удаляем слово из списка
									lineQueue.RemoveAt(0);

									// Изменяем буфер
									buffer = newBuffer;
								}
							}

							// Добавляем буфер в список печати
							printLines.Enqueue(buffer);
						}
					}
					while (lineQueue.Count != 0);
				}
			}
		}

		public void PerformPrint(PrinterSettings printerSettings, PageSettings pageSettings)
		{
			try
			{
				// Выставляем настройки принтера
				printDocument.PrinterSettings = printerSettings;

				// Выставляем ориентацию страницы
				printDocument.DefaultPageSettings.Landscape = pageSettings.Landscape;

				// Выставляем название документа
				printDocument.DocumentName = this.CreateWindowCaption();

				// Выполняем пересчет из миллиметров в доли дюймов
				printDocument.DefaultPageSettings.Margins.Left = (int)(Math.Round((double)pageSettings.Margins.Left / 2.54D, 0));
				printDocument.DefaultPageSettings.Margins.Right = (int)(Math.Round((double)pageSettings.Margins.Right / 2.54D, 0));
				printDocument.DefaultPageSettings.Margins.Top = (int)(Math.Round((double)pageSettings.Margins.Top / 2.54D, 0));
				printDocument.DefaultPageSettings.Margins.Bottom = (int)(Math.Round((double)pageSettings.Margins.Bottom / 2.54D, 0));

				// Отправляем на печать
				printDocument.Print();
			}
			catch (Exception e)
			{
				string message = string.Format(Globals.Strings.MESSAGE_ERROR_PRINT, e.Message);
				MessageBox.Show(message, Globals.Strings.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
		{
			// Нужно понять, нормальная ли площадь осталась для распечатки?
			// Если места недостаточно, то отменяем печать и выходим

			string testString = "ШШ";
			SizeF lineSize = e.Graphics.MeasureString(testString, Settings.TextBoxFont);

			if (lineSize.Width > e.MarginBounds.Width || lineSize.Height > e.MarginBounds.Height)
			{
				// Страница слишком мала для распечатки, выдаем Exception
				Exception e1 = new Exception(Globals.Strings.MESSAGE_ERROR_PRINT_MARGINS);

				// Отменяем печать
				e.Cancel = true;

				// Выкидываем Exception
				throw e1;
			}

			// Готовим объект со строками для распечатки
			if (printLines.Count == 0) PreparePrintLines(e.Graphics, e.MarginBounds);

			float yPos = 0F;
			int count = 0;
			float lineHeight = Settings.TextBoxFont.GetHeight(e.Graphics);

			// Высчитываем количество строк, которое поместится на страницу
			float linesPerPage = e.MarginBounds.Height / lineHeight;

			while (count < linesPerPage && printLines.Count != 0)
			{
				// Получаем строчку для вывода на лист
				string line = printLines.Dequeue();

				yPos = e.MarginBounds.Top + (count * lineHeight);
				e.Graphics.DrawString(line, Settings.TextBoxFont, Brushes.Black, e.MarginBounds.Left, yPos);
				count++;
			}

			e.HasMorePages = printLines.Count != 0;
		}

		private void menuFilePrint_Click(object sender, EventArgs e)
		{
			if (textMain.TextLength != 0)
			{
				if (dialogPrint.ShowDialog() == DialogResult.OK)
				{
					// Выполняем распечатку
					PerformPrint(dialogPrint.PrinterSettings, Settings.PageSettings);

					// Сохраняем настройки для дальнейшей работы - чтобы они были в Параметрах страницы
					Settings.PageSettings.PrinterSettings = dialogPrint.PrinterSettings;
				}
			}
		}

		#endregion

		private void menuFileExit_Click(object sender, EventArgs e)
		{
			if (DealWithChanges())
			{
				Application.Exit();
			}
		}

		#endregion

		#region Правка

		public void PerformSearch(bool caseSensitive, bool forward)
		{
			// Ищем то, что у нас в searchString

			if (searchString != string.Empty)
			{
				StringComparison stringCompare = caseSensitive ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;

				// Храним тут позицию найденного текста (если таковой есть)
				int indexFound = 0;

				if (forward)
				{
					indexFound = textMain.Text.IndexOf(searchString, textMain.SelectionStart + textMain.SelectionLength, stringCompare);
				}
				else
				{
					indexFound = textMain.Text.LastIndexOf(searchString, textMain.SelectionStart, stringCompare);
				}

				if (indexFound < 0)
				{
					// Строчка не нашлась

					// Сообщаем об этом пользователю
					string message = string.Format(Globals.Strings.MESSAGE_STRING_NOT_FOUND, searchString);
					MessageBox.Show(message, Globals.Strings.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					// Выделяем найденный текст
					textMain.SelectionStart = indexFound;
					textMain.SelectionLength = searchString.Length;
				}
			}
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
			textMain.Paste(string.Empty);
		}

		private void menuEditFind_Click(object sender, EventArgs e)
		{
			if (textMain.TextLength == 0) return;

			if (formFind == null) formFind = new FormFind() { Owner = this };
			formFind.Display(this);
		}

		private void menuEditFindNext_Click(object sender, EventArgs e)
		{
			if (textMain.TextLength == 0) return;

			if (searchString == string.Empty) menuEditFind_Click(null, null);
			else
			{
				bool caseSensitive = formFind == null ? false : formFind.checkCase.Checked;

				PerformSearch(caseSensitive, true);
			}
		}

		private void menuEditReplace_Click(object sender, EventArgs e)
		{
			if (textMain.TextLength == 0) return;

			if (formReplace == null) formReplace = new FormReplace() { Owner = this };
			formReplace.Display(this);
		}

		private void menuEditGo_Click(object sender, EventArgs e)
		{
			if (textMain.TextLength == 0 || textMain.WordWrap) return;

			if (formGoTo == null) formGoTo = new FormGoTo();
			int lineNumber = formGoTo.GetLine(textMain.GetCurrentLine(), textMain.Lines.Count());
			if (lineNumber != 0) textMain.GoTo(lineNumber, 1);
		}

		private void menuEditSelectAll_Click(object sender, EventArgs e)
		{
			textMain.SelectAll();
		}

		private void menuEditDateTime_Click(object sender, EventArgs e)
		{
			// 15:59 04.01.2013

			textMain.Paste(DateTime.Now.ToShortDateAndTimeString());
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
			menuEditGo.Enabled = hasText && !textMain.WordWrap;
			menuEditSelectAll.Enabled = hasText;

			// Назначаем кнопку нашему пункту меню
			menuEditDelete.ShortcutKeys = Keys.Delete;
		}

		private void menuEdit_DropDownClosed(object sender, EventArgs e)
		{
			// Доступность пункта меню "Отмена"
			menuEditUndo.Enabled = true;

			menuEditCut.Enabled = true;
			menuEditCopy.Enabled = true;
			menuEditDelete.Enabled = true;

			menuEditPaste.Enabled = true;

			menuEditFind.Enabled = true;
			menuEditFindNext.Enabled = true;
			menuEditReplace.Enabled = true;
			menuEditGo.Enabled = true;
			menuEditSelectAll.Enabled = true;

			menuEditDelete.ShortcutKeys = Keys.None;
		}

		#endregion

		#region Формат

		private void menuFormatWordWrap_Click(object sender, EventArgs e)
		{
			// Переключаем перенос текстового поля
			textMain.WordWrap = !textMain.WordWrap;

			// Рисуем галочку напротив пункта меню
			menuFormatWordWrap.Checked = textMain.WordWrap;

			// Сохраняем в настройках включенный перенос
			Settings.WordWrap = textMain.WordWrap;

			// Выполяем хитрый трюк со строкой состояния
			if (textMain.WordWrap)
			{
				// Пользователь включил перенос по словам

				// Текущее состояние видимости статусной строки надо куда-то сохранить
				menuViewStatusBar.Tag = statusMain.Visible;

				// Нужно скрыть строку состояния
				StatusBarVisible(false);
			}
			else
			{
				// Пользователь выключил перенос по словам

				// Надо посмотреть сохраненное состояние видимости статусной строки
				if (menuViewStatusBar.Tag != null)
				{
					bool statusVisible = (bool)menuViewStatusBar.Tag;

					// При необходимости ее надо показать
					StatusBarVisible(statusVisible);
				}
			}
		}

		private void menuFormatFont_Click(object sender, EventArgs e)
		{
			// Указываем уже выбранный шрифт
			dialogFont.Font = textMain.Font;

			if (dialogFont.ShowDialog() == DialogResult.OK)
			{
				// Выставляем шрифт
				textMain.Font = dialogFont.Font;

				// Сохраняем его в настройках
				Settings.TextBoxFont = textMain.Font;
			}
		}

		#endregion

		#region Вид

		private void StatusBarVisible(bool value)
		{
			// Вызовем событие вручную, чтобы было красиво
			if (value) timerPosition_Tick(null, null);

			statusMain.Visible = value;
			menuViewStatusBar.Checked = value;
			timerPosition.Enabled = value;

			// Сохраняем настройки
			Settings.StatusBar = value;
		}

		private void timerPosition_Tick(object sender, EventArgs e)
		{
			toolStripStatusLabelRight.Text = string.Format(Globals.Strings.STATUSBAR_TEXT, textMain.GetCurrentLine(), textMain.GetCurrentColumn());
		}

		private void menuView_DropDownOpening(object sender, EventArgs e)
		{
			menuViewStatusBar.Enabled = !textMain.WordWrap;
		}

		private void menuViewStatusBar_Click(object sender, EventArgs e)
		{
			StatusBarVisible(!statusMain.Visible);
		}

		#endregion

		#region Справка

		private void menuHelpHelp_Click(object sender, EventArgs e)
		{
			HxHelpPane pHelpPane = new HxHelpPane();
			pHelpPane.DisplayTask("mshelp://windows/?id=5d18d5fb-e737-4a73-b6cc-dccc63720231");
		}

		private void menuHelpAbout_Click(object sender, EventArgs e)
		{
			(new FormAbout() { Text = Globals.Strings.AboutCaption }).ShowDialog();
		}

		#endregion
	}
}
