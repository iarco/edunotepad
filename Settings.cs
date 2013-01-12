using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduNotepad
{
	public static class Settings
	{
		// Блокнот хранит настройки в HKCU\Software\Microsoft\Notepad
		// Наши настройки в HKCU\Software\EduNotepad

		private const string SETTINGS_SUBKEY = "Software\\EduNotepad";

		#region Размер окна
		private const string REGISTRY_WIDTH		= "Width";
		private const string REGISTRY_HEIGHT	= "Height";

		// Размер окна: умолчания
		// Высчитываются автоматически из размера экрана
		#endregion

		// Положение окна
		private const string REGISTRY_X = "X";
		private const string REGISTRY_Y = "Y";

		// Положение окна: умолчания
		private const int DEFAULT_X = 42;
		private const int DEFAULT_Y = 42;


		private static int ReadValueInt(string name, out bool success)
		{
			// TODO: ReadValueInt

			// HACK: Это надо переписать!
			success = false;
			return 0;
		}

		private static void WriteValueInt(string name, int value)
		{
			// TODO: WriteValueInt
		}

		public static Size WindowSize
		{
			get
			{
				bool success;
				double widthRatio = 0.75;
				double heightRatio = 0.7;

				Size returnValue = new Size(0, 0);

				returnValue.Width = ReadValueInt(REGISTRY_WIDTH, out success);
				returnValue.Width = success ? returnValue.Width : (int)(Screen.PrimaryScreen.Bounds.Width * widthRatio);

				int tempHeight = ReadValueInt(REGISTRY_HEIGHT, out success);
				returnValue.Height = success ? tempHeight : (int)(Screen.PrimaryScreen.Bounds.Height * heightRatio);

				return returnValue;
			}
			
			set
			{
				WriteValueInt(REGISTRY_WIDTH, value.Width);
				WriteValueInt(REGISTRY_HEIGHT, value.Height);
			}
		}

		public static Point WindowLocation
		{
			get
			{
				Point returnValue = new Point(0, 0);
				bool success;

				returnValue.X = ReadValueInt(REGISTRY_X, out success);
				returnValue.X = success ? returnValue.X : DEFAULT_X;

				returnValue.Y = ReadValueInt(REGISTRY_Y, out success);
				returnValue.Y = success ? returnValue.Y : DEFAULT_Y;

				return returnValue;
			}

			set
			{
				WriteValueInt(REGISTRY_X, value.X);
				WriteValueInt(REGISTRY_Y, value.Y);
			}
		}
	}
}
