using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

			if (args.Length > 0)
			{
				List<string> argsList = new List<string>(args);

				if (args[0].ToLower() == "/p")
				{
					// TODO: Нужно будет сразу отправить файл на печать и завершить работу

					// Нужно собрать имя файла из остальных элементов (кроме первого)
					argsList.RemoveAt(0);
				}

				string fileName = string.Join(" ", argsList);
				
				// TODO: Вызвать код для попытки угадывания кодировки файла
				if (File.Exists(fileName)) formMain.PerformFileOpen(fileName, Encoding.Default);
			}

			Application.Run(formMain);
		}
	}
}
