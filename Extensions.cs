using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace EduNotepad
{
	public static class Extensions
	{
		public static string MD5OfText(this string text)
		{
			string returnValue = string.Empty;

			// Создаем объект хэш-функции MD5
			MD5 md5 = MD5.Create();

			// Получаем массив байтов в текстовом поле
			byte[] inputBytes = Encoding.ASCII.GetBytes(text);

			// Вычисляем хэш
			byte[] hash = md5.ComputeHash(inputBytes);

			// Превращаем наш массив байтов в обычную строку
			StringBuilder sb = new StringBuilder();
			foreach (byte b in hash)
			{
				sb.Append(b.ToString("x2"));
			}

			returnValue = sb.ToString();

			return returnValue;
		}

		public static string ToShortDateAndTimeString(this DateTime date)
		{
			// Возвращаем дату и время в одинаковом формате для .LOG и для меню Правка
			string returnValue = string.Empty;

			returnValue = string.Format("{0} {1}", date.ToShortTimeString(), date.ToShortDateString());

			return returnValue;
		}

		public static int MeasureWidth(this string source, Graphics g, Font f)
		{
			return (int)Math.Ceiling(g.MeasureString(source, f, new PointF(0, 0), new StringFormat(StringFormatFlags.MeasureTrailingSpaces)).Width);
		}

		public static int GetCurrentColumn(this TextBox text)
		{
			return text.SelectionStart - text.GetFirstCharIndexOfCurrentLine() + 1;
		}

		public static int GetCurrentLine(this TextBox text)
		{
			return text.GetLineFromCharIndex(text.SelectionStart) + 1;
		}

		public static void GoTo(this TextBox text, int line, int column)
		{
			if (line < 1 || column < 1 || text.Lines.Count() < line) return;

			text.SelectionStart = text.GetFirstCharIndexFromLine(line - 1) + column - 1;
			text.SelectionLength = 0;
		}

		public static string Replace(this string source, string find, string replace, StringComparison comparison)
		{
			string returnValue = string.Empty;

			StringBuilder sb = new StringBuilder();

			int previousIndex = 0;
			int index = source.IndexOf(find, comparison);
			while (index != -1)
			{
				sb.Append(source.Substring(previousIndex, index - previousIndex));
				sb.Append(replace);
				index += find.Length;

				previousIndex = index;
				index = source.IndexOf(find, index, comparison);
			}
			sb.Append(source.Substring(previousIndex));

			returnValue = sb.ToString();

			return returnValue;
		}
	}
}
