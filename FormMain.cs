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
	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();
		}

		private void FormMain_Resize(object sender, EventArgs e)
		{
			// TODO: Код для изменения размеров
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			// Выставляем размер окна
			this.Size = Settings.WindowSize;

			// Выставляем положение окна
			this.Location = Settings.WindowLocation;
		}
	}
}
