using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduNotepad
{
	public partial class FormEncoding : Form
	{
		public FormEncoding()
		{
			InitializeComponent();
		}

		private void FormEncoding_Load(object sender, EventArgs e)
		{
			this.Text = Globals.Strings.CAPTION_ENCODING;
		}

		public Encoding SelectEncoding(Encoding currentEncoding)
		{
			Encoding returnValue = null;

			if (currentEncoding != null)
			{
				switch (currentEncoding.WebName)
				{
					case "utf-16":
						{
							comboEncoding.SelectedIndex = 1;
							break;
						}
					case "utf-16BE":
						{
							comboEncoding.SelectedIndex = 2;
							break;
						}
					case "utf-8":
						{
							comboEncoding.SelectedIndex = 3;
							break;
						}
					default:
						{
							comboEncoding.SelectedIndex = 0;
							break;
						}
				}
			}
			else
			{
				// Нам не передали никакой кодировки, выберем первую
				comboEncoding.SelectedIndex = 0;
			}

			if (this.ShowDialog() == DialogResult.OK)
			{
				switch (comboEncoding.SelectedIndex)
				{
					case 0: returnValue = Encoding.Default; break;
					case 1: returnValue = Encoding.Unicode; break;
					case 2: returnValue = Encoding.BigEndianUnicode; break;
					case 3: returnValue = Encoding.UTF8; break;
				}
			}

			// В returnValue будет null, поскольку код выше сработает только по нажатию OK

			return returnValue;
		}
	}
}
