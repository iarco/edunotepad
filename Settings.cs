using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
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

		// Размер окна: минимум
		private const int DEFAULT_WIDTH_MINIMUM = 400;
		private const int DEFAULT_HEIGHT_MINIMUM = 300;
		#endregion

		// Положение окна
		private const string REGISTRY_X = "X";
		private const string REGISTRY_Y = "Y";

		// Положение окна: умолчания
		private const int DEFAULT_X = 42;
		private const int DEFAULT_Y = 42;

		// Положение окна: минимум
		private const int DEFAULT_VISIBLE_X = 100;
		private const int DEFAULT_VISIBLE_Y = 100;

		// Шрифт
		private const string REGISTRY_FONT = "Font";

		// Шрифт: умолчания
		private const string DEFAULT_FONT = "Lucida Console; 9,75pt";

		// Перенос по словам
		private const string REGISTRY_WRAP = "Wrap";

		// Перенос по словам: умолчания
		// Функция для чтения вернет false, если нет ключа в реестре

		// Строка состояния
		private const string REGISTRY_STATUSBAR = "StatusBar";

		// Строка состояния: умолчания
		// Функция для чтения вернет false, если нет ключа в реестре

		// Отступ слева
		private const string REGISTRY_MARGIN_LEFT = "MarginLeft";

		// Отступ слева: умолчания
		private const int DEFAULT_MARGIN_LEFT = 200;

		// Отступ справа
		private const string REGISTRY_MARGIN_RIGHT = "MarginRight";

		// Отступ справа: умолчания
		private const int DEFAULT_MARGIN_RIGHT = 200;

		// Отступ сверху
		private const string REGISTRY_MARGIN_TOP = "MarginTop";

		// Отступ сверху: умолчания
		private const int DEFAULT_MARGIN_TOP = 250;

		// Отступ снизу
		private const string REGISTRY_MARGIN_BOTTOM = "MarginBottom";

		// Отступ снизу: умолчания
		private const int DEFAULT_MARGIN_BOTTOM = 250;


		private static RegistryKey CreateOrOpenSettingsSubKey()
		{
			RegistryKey returnValue = null;

			RegistryKey keyCurrentUser = Registry.CurrentUser;

			try
			{
				returnValue = keyCurrentUser.CreateSubKey(SETTINGS_SUBKEY);
			}
			catch (Exception e)
			{
				Debug.Print(e.Message);
				returnValue = null;
			}

			return returnValue;
		}

		private static T ReadValue<T>(string valueName, out bool success)
		{
			success = false;

			object returnValue = null;
			RegistryValueKind rvk = RegistryValueKind.Unknown;

			if (typeof(T) == typeof(string))
			{
 				// Пользователь хочет прочитать настройку типа string
				returnValue = string.Empty;
				rvk = RegistryValueKind.String;
			}
			else if (typeof(T) == typeof(int))
			{
 				// Пользователь хочет прочитать настройку типа int
				returnValue = 0;
				rvk = RegistryValueKind.DWord;
			}
			else if (typeof(T) == typeof(bool))
			{
 				// Пользователь хочет прочитать настройку типа bool
				returnValue = false;
				rvk = RegistryValueKind.DWord;
			}

			RegistryKey keyEdu = Settings.CreateOrOpenSettingsSubKey();

			try
			{
				if (keyEdu != null
					&& keyEdu.GetValueNames().Contains(valueName, StringComparer.OrdinalIgnoreCase)
					&& keyEdu.GetValueKind(valueName) == rvk)
				{
					returnValue = keyEdu.GetValue(valueName);
					success = true;
				}
			}
			catch (Exception e)
			{
				Debug.Print(e.Message);
			}

			if (typeof(T) == typeof(bool))
			{
				returnValue = returnValue.ToString() == "1" ? (object)true : (object)false;
			}

			return (T)(object)returnValue;
		}

		private static void WriteValue(string valueName, object value)
		{
			RegistryValueKind rvk = RegistryValueKind.Unknown;

			if (value is Int32 || value is Boolean)
			{
				rvk = RegistryValueKind.DWord;
			}
			else if (value is String)
			{
				rvk = RegistryValueKind.String;
			}

			if (rvk != RegistryValueKind.Unknown)
			{
				// Нам передали известное нам значение, мы знаем, как его обработать
				RegistryKey keyEdu = CreateOrOpenSettingsSubKey();

				if (keyEdu != null)
				{
 					// Ключ реестра корректно открылся
					try
					{
						keyEdu.SetValue(valueName, value, rvk);
					}
					catch (Exception e) { Debug.WriteLine(e.Message); }
				}
			}
		}

		public static Size MinimumWindowSize
		{
			get
			{
				return new Size(DEFAULT_WIDTH_MINIMUM, DEFAULT_HEIGHT_MINIMUM);
			}
		}

		public static Size WindowSize
		{
			get
			{
				bool success;
				double widthRatio = 0.75;
				double heightRatio = 0.7;

				Size returnValue = new Size(0, 0);

				returnValue.Width = ReadValue<int>(REGISTRY_WIDTH, out success);
				returnValue.Width = success ? returnValue.Width : (int)(Screen.PrimaryScreen.Bounds.Width * widthRatio);
				returnValue.Width = returnValue.Width < Screen.PrimaryScreen.WorkingArea.Width ? returnValue.Width : Screen.PrimaryScreen.WorkingArea.Width;
				returnValue.Width = returnValue.Width > DEFAULT_WIDTH_MINIMUM ? returnValue.Width : DEFAULT_WIDTH_MINIMUM;

				int tempHeight = ReadValue<int>(REGISTRY_HEIGHT, out success);
				returnValue.Height = success ? tempHeight : (int)(Screen.PrimaryScreen.Bounds.Height * heightRatio);
				returnValue.Height = returnValue.Height < Screen.PrimaryScreen.WorkingArea.Height ? returnValue.Height : Screen.PrimaryScreen.WorkingArea.Height;
				returnValue.Height = returnValue.Height > DEFAULT_HEIGHT_MINIMUM ? returnValue.Height : DEFAULT_HEIGHT_MINIMUM;

				return returnValue;
			}
			
			set
			{
				WriteValue(REGISTRY_WIDTH, value.Width);
				WriteValue(REGISTRY_HEIGHT, value.Height);
			}
		}

		public static Point WindowLocation
		{
			get
			{
				Point returnValue = new Point(0, 0);
				bool success;
				int maximumX = Screen.PrimaryScreen.WorkingArea.Width - DEFAULT_VISIBLE_X;
				int maximumY = Screen.PrimaryScreen.WorkingArea.Height - DEFAULT_VISIBLE_Y;

				returnValue.X = ReadValue<int>(REGISTRY_X, out success);
				returnValue.X = success ? returnValue.X : DEFAULT_X;
				returnValue.X = returnValue.X < maximumX ? returnValue.X : maximumX;

				returnValue.Y = ReadValue<int>(REGISTRY_Y, out success);
				returnValue.Y = success ? returnValue.Y : DEFAULT_Y;
				returnValue.Y = returnValue.Y < maximumY ? returnValue.Y : maximumY;

				return returnValue;
			}

			set
			{
				WriteValue(REGISTRY_X, value.X);
				WriteValue(REGISTRY_Y, value.Y);
			}
		}

		public static Font TextBoxFont
		{
			get
			{
				bool success;

				Font returnValue = null;

				string stringFont = ReadValue<string>(REGISTRY_FONT, out success);
				stringFont = success ? stringFont : DEFAULT_FONT;
				returnValue = (Font)(new FontConverter()).ConvertFromString(stringFont);

				return returnValue;
			}

			set
			{
				WriteValue(REGISTRY_FONT, (new FontConverter()).ConvertToString(value));
			}
		}

		public static bool WordWrap
		{
			get
			{
				bool success;
				return ReadValue<bool>(REGISTRY_WRAP, out success);
			}

			set
			{
				WriteValue(REGISTRY_WRAP, value);
			}
		}

		public static bool StatusBar
		{
			get
			{
				bool success;
				return ReadValue<bool>(REGISTRY_STATUSBAR, out success);
			}

			set
			{
				WriteValue(REGISTRY_STATUSBAR, value);
			}
		}

		private static PageSettings _pageSettings = null;
		public static PageSettings PageSettings
		{
			get
			{
				bool success;

				// Суем стандартные настройки
				if (_pageSettings == null) _pageSettings = new PageSettings();

				// Читаем наши значения из реестра
				_pageSettings.Margins.Left = ReadValue<int>(REGISTRY_MARGIN_LEFT, out success);
				_pageSettings.Margins.Left = success ? _pageSettings.Margins.Left : DEFAULT_MARGIN_LEFT;

				_pageSettings.Margins.Right = ReadValue<int>(REGISTRY_MARGIN_RIGHT, out success);
				_pageSettings.Margins.Right = success ? _pageSettings.Margins.Right : DEFAULT_MARGIN_RIGHT;

				_pageSettings.Margins.Top = ReadValue<int>(REGISTRY_MARGIN_TOP, out success);
				_pageSettings.Margins.Top = success ? _pageSettings.Margins.Top : DEFAULT_MARGIN_TOP;

				_pageSettings.Margins.Bottom = ReadValue<int>(REGISTRY_MARGIN_BOTTOM, out success);
				_pageSettings.Margins.Bottom = success ? _pageSettings.Margins.Bottom : DEFAULT_MARGIN_BOTTOM;

				return _pageSettings;
			}

			set
			{
				_pageSettings = value;

				// Сохраняем значения отступов
				WriteValue(REGISTRY_MARGIN_LEFT, value.Margins.Left);
				WriteValue(REGISTRY_MARGIN_RIGHT, value.Margins.Right);
				WriteValue(REGISTRY_MARGIN_TOP, value.Margins.Top);
				WriteValue(REGISTRY_MARGIN_BOTTOM, value.Margins.Bottom);
			}
		}
	}
}
