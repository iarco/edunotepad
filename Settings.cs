using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
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

		// Шрифт
		private const string REGISTRY_FONT = "Font";

		// Шрифт: умолчания
		private const string DEFAULT_FONT = "Lucida Console; 9,75pt";

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
				returnValue = keyCurrentUser.OpenSubKey(SETTINGS_SUBKEY, true);
			}
			catch (Exception e)
			{
				Debug.Print(e.Message);
				returnValue = null;
			}

			if (returnValue == null)
			{
 				// Ключ с настройками не открылся, создаем его

				try
				{
					returnValue = keyCurrentUser.CreateSubKey(SETTINGS_SUBKEY);
				}
				catch (Exception e)
				{
					Debug.Print(e.Message);
					returnValue = null;
				}
				
			}

			return returnValue;
		}

		private static int ReadValueInt(string name, out bool success)
		{
			int returnValue = 0;
			success = false;

			RegistryKey rk = CreateOrOpenSettingsSubKey();

			if (rk == null)
			{
				// Ключ не открылся, чтение невозможно

				success = false;
				returnValue = 0;
			}
			else
			{
 				// Ключ открылся

				if (rk.GetValueNames().Contains(name, StringComparer.OrdinalIgnoreCase))
				{
					if (rk.GetValueKind(name) == RegistryValueKind.DWord)
					{
						try
						{
							returnValue = (int)rk.GetValue(name);
							success = true;
						}
						catch (Exception e)
						{
							Debug.Print(e.Message);

							returnValue = 0;
							success = false;
						}
					}
				}
			}

			return returnValue;
		}

		private static string ReadValueString(string name, out bool success)
		{
			string returnValue = string.Empty;
			success = false;

			RegistryKey rk = CreateOrOpenSettingsSubKey();

			if (rk == null)
			{
				// Ключ не открылся, чтение невозможно

				success = false;
				returnValue = string.Empty;
			}
			else
			{
				// Ключ открылся

				if (rk.GetValueNames().Contains(name, StringComparer.OrdinalIgnoreCase))
				{
					if (rk.GetValueKind(name) == RegistryValueKind.String)
					{
						try
						{
							returnValue = (string)rk.GetValue(name);
							success = true;
						}
						catch (Exception e)
						{
							Debug.Print(e.Message);

							returnValue = string.Empty;
							success = false;
						}
					}
				}
			}

			return returnValue;
		}

		private static void WriteValueInt(string name, int value)
		{
			RegistryKey rk = CreateOrOpenSettingsSubKey();

			if (rk != null)
			{
 				// Ключ открылся, можем попробовать записать значение

				try
				{
					rk.SetValue(name, (object)value, RegistryValueKind.DWord);
				}
				catch (Exception e) { Debug.Print(e.Message); }
			}
		}

		private static void WriteValueString(string name, string value)
		{
			RegistryKey rk = CreateOrOpenSettingsSubKey();

			if (rk != null)
			{
				// Ключ открылся, можем попробовать записать значение

				try
				{
					rk.SetValue(name, (object)value, RegistryValueKind.String);
				}
				catch (Exception e) { Debug.Print(e.Message); }
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

		public static Font TextBoxFont
		{
			get
			{
				bool success;

				Font returnValue = null;

				string stringFont = ReadValueString(REGISTRY_FONT, out success);
				stringFont = success ? stringFont : DEFAULT_FONT;
				returnValue = (Font)(new FontConverter()).ConvertFromString(stringFont);

				return returnValue;
			}

			set
			{
				WriteValueString(REGISTRY_FONT, (new FontConverter()).ConvertToString(value));
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
				_pageSettings.Margins.Left = ReadValueInt(REGISTRY_MARGIN_LEFT, out success);
				_pageSettings.Margins.Left = success ? _pageSettings.Margins.Left : DEFAULT_MARGIN_LEFT;

				_pageSettings.Margins.Right = ReadValueInt(REGISTRY_MARGIN_RIGHT, out success);
				_pageSettings.Margins.Right = success ? _pageSettings.Margins.Right : DEFAULT_MARGIN_RIGHT;

				_pageSettings.Margins.Top = ReadValueInt(REGISTRY_MARGIN_TOP, out success);
				_pageSettings.Margins.Top = success ? _pageSettings.Margins.Top : DEFAULT_MARGIN_TOP;

				_pageSettings.Margins.Bottom = ReadValueInt(REGISTRY_MARGIN_BOTTOM, out success);
				_pageSettings.Margins.Bottom = success ? _pageSettings.Margins.Bottom : DEFAULT_MARGIN_BOTTOM;

				return _pageSettings;
			}

			set
			{
				_pageSettings = value;

				// Сохраняем значения отступов
				WriteValueInt(REGISTRY_MARGIN_LEFT, value.Margins.Left);
				WriteValueInt(REGISTRY_MARGIN_RIGHT, value.Margins.Right);
				WriteValueInt(REGISTRY_MARGIN_TOP, value.Margins.Top);
				WriteValueInt(REGISTRY_MARGIN_BOTTOM, value.Margins.Bottom);
			}
		}
	}
}
