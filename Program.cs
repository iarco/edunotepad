using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EduNotepad
{
	static class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			FormMain formMain = new FormMain();

			bool printAndExit = false;

			if (args.Length > 0)
			{
				List<string> argsList = new List<string>(args);

				if (args[0].ToLower() == "/p")
				{
					// Нужно будет сразу отправить файл на печать и завершить работу
					printAndExit = true;

					// Нужно собрать имя файла из остальных элементов (кроме первого)
					argsList.RemoveAt(0);
				}

				string fileName = string.Join(" ", argsList.ToArray());

				Encoding fileEncoding = formMain.CheckFileEncoding(fileName);
				if (File.Exists(fileName)) formMain.PerformFileOpen(fileName, fileEncoding);
			}

			if (printAndExit)
			{
				// Надо выполнить распечатку и свалить
				if (formMain.fileName != string.Empty)
				{
 					// Файл открылся, отправляем его на печать
					formMain.PerformPrint(Settings.PageSettings.PrinterSettings, Settings.PageSettings);
				}
			}
			else
			{
 				// Надо просто запустить приложение
				Application.Run(formMain);
			}
		}
	}
}
