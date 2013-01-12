using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduNotepad
{
	public static class Globals
	{
		public static class Strings
		{
			// Название приложения
			public const string APP_NAME = "EduNotepad";

			// Заголовки окон
			private const string CAPTION_ABOUT = "О {0}";

			public const string CAPTION_ENCODING = "Выберите кодировку";

			// Прочие строки
			public const string UNTITLED = "Безымянный";

			// Сообщения
			public const string MESSAGE_SAVE_OR_NOT = "Вы хотите сохранить изменения в файле {0}?";
			public const string MESSAGE_ERROR_FILE_OPEN = "Произошла ошибка чтения файла:\r\n\r\n{0}\r\n\r\nПодробнее:\r\n{1}";
			public const string MESSAGE_ERROR_FILE_SAVE = "Произошла ошибка записи файла:\r\n\r\n{0}\r\n\r\nПодробнее:\r\n{1}";
			public const string MESSAGE_ERROR_PRINT = "В процессе печати произошла следующая ошибка:\r\n\r\n{0}";
			public const string MESSAGE_ERROR_PRINT_MARGINS = "Поля документа слишком велики для печати документа.";

			public static string AboutCaption
			{
				get
				{
					return string.Format(Globals.Strings.CAPTION_ABOUT, Globals.Strings.APP_NAME);
				}
			}
		}
	}
}
