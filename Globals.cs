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
			public const string APP_NAME = "EduNotepad";

			public const string ABOUT_CAPTION = "О {0}";

			public const string ENCODING_CAPTION = "Выберите кодировку";

			public static string AboutCaption
			{
				get
				{
					return string.Format(Globals.Strings.ABOUT_CAPTION, Globals.Strings.APP_NAME);
				}
			}
		}
	}
}
