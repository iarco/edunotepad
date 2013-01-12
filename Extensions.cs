using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace EduNotepad
{
	public static class Extensions
	{
		public static string MD5OfText(this TextBox text)
		{
			string returnValue = string.Empty;

			// Создаем объект хэш-функции MD5
			MD5 md5 = MD5.Create();

			// Получаем массив байтов в текстовом поле
			byte[] inputBytes = Encoding.ASCII.GetBytes(text.Text);

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
	}
}
