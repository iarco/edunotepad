namespace EduNotepad
{
	partial class FormMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuMain = new System.Windows.Forms.MenuStrip();
			this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menuFileNew = new System.Windows.Forms.ToolStripMenuItem();
			this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
			this.menuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.menuFileSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuFilePageSetup = new System.Windows.Forms.ToolStripMenuItem();
			this.menuFilePrint = new System.Windows.Forms.ToolStripMenuItem();
			this.menuFileSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuEditUndo = new System.Windows.Forms.ToolStripMenuItem();
			this.menuEditSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuEditCut = new System.Windows.Forms.ToolStripMenuItem();
			this.menuEditCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.menuEditPaste = new System.Windows.Forms.ToolStripMenuItem();
			this.menuEditDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.menuEditSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.menuEditFind = new System.Windows.Forms.ToolStripMenuItem();
			this.menuEditFindNext = new System.Windows.Forms.ToolStripMenuItem();
			this.menuEditSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.menuEditReplace = new System.Windows.Forms.ToolStripMenuItem();
			this.menuEditGo = new System.Windows.Forms.ToolStripMenuItem();
			this.menuEditSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.menuEditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
			this.menuEditDateTime = new System.Windows.Forms.ToolStripMenuItem();
			this.форматToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.переносПоСловамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuFormatFont = new System.Windows.Forms.ToolStripMenuItem();
			this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.строкаСостоянияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.menuHelpHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.menuHelpSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabelLeft = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabelRight = new System.Windows.Forms.ToolStripStatusLabel();
			this.textMain = new System.Windows.Forms.TextBox();
			this.dialogOpen = new System.Windows.Forms.OpenFileDialog();
			this.dialogSave = new System.Windows.Forms.SaveFileDialog();
			this.dialogPageSetup = new System.Windows.Forms.PageSetupDialog();
			this.dialogPrint = new System.Windows.Forms.PrintDialog();
			this.printDocument = new System.Drawing.Printing.PrintDocument();
			this.dialogFont = new System.Windows.Forms.FontDialog();
			this.menuMain.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuMain
			// 
			this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.форматToolStripMenuItem,
            this.видToolStripMenuItem,
            this.menuHelp});
			this.menuMain.Location = new System.Drawing.Point(0, 0);
			this.menuMain.Name = "menuMain";
			this.menuMain.Size = new System.Drawing.Size(412, 24);
			this.menuMain.TabIndex = 0;
			this.menuMain.Text = "menuStrip1";
			// 
			// menuFile
			// 
			this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileNew,
            this.menuFileOpen,
            this.menuFileSave,
            this.menuFileSaveAs,
            this.menuFileSeparator1,
            this.menuFilePageSetup,
            this.menuFilePrint,
            this.menuFileSeparator2,
            this.menuFileExit});
			this.menuFile.Name = "menuFile";
			this.menuFile.Size = new System.Drawing.Size(48, 20);
			this.menuFile.Text = "Файл";
			// 
			// menuFileNew
			// 
			this.menuFileNew.Name = "menuFileNew";
			this.menuFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.menuFileNew.Size = new System.Drawing.Size(204, 22);
			this.menuFileNew.Text = "Создать";
			this.menuFileNew.Click += new System.EventHandler(this.menuFileNew_Click);
			// 
			// menuFileOpen
			// 
			this.menuFileOpen.Name = "menuFileOpen";
			this.menuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.menuFileOpen.Size = new System.Drawing.Size(204, 22);
			this.menuFileOpen.Text = "Открыть...";
			this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
			// 
			// menuFileSave
			// 
			this.menuFileSave.Name = "menuFileSave";
			this.menuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.menuFileSave.Size = new System.Drawing.Size(204, 22);
			this.menuFileSave.Text = "Сохранить";
			this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
			// 
			// menuFileSaveAs
			// 
			this.menuFileSaveAs.Name = "menuFileSaveAs";
			this.menuFileSaveAs.Size = new System.Drawing.Size(204, 22);
			this.menuFileSaveAs.Text = "Сохранить как...";
			this.menuFileSaveAs.Click += new System.EventHandler(this.menuFileSaveAs_Click);
			// 
			// menuFileSeparator1
			// 
			this.menuFileSeparator1.Name = "menuFileSeparator1";
			this.menuFileSeparator1.Size = new System.Drawing.Size(201, 6);
			// 
			// menuFilePageSetup
			// 
			this.menuFilePageSetup.Name = "menuFilePageSetup";
			this.menuFilePageSetup.Size = new System.Drawing.Size(204, 22);
			this.menuFilePageSetup.Text = "Параметры страницы...";
			this.menuFilePageSetup.Click += new System.EventHandler(this.menuFilePageSetup_Click);
			// 
			// menuFilePrint
			// 
			this.menuFilePrint.Name = "menuFilePrint";
			this.menuFilePrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.menuFilePrint.Size = new System.Drawing.Size(204, 22);
			this.menuFilePrint.Text = "Печать...";
			this.menuFilePrint.Click += new System.EventHandler(this.menuFilePrint_Click);
			// 
			// menuFileSeparator2
			// 
			this.menuFileSeparator2.Name = "menuFileSeparator2";
			this.menuFileSeparator2.Size = new System.Drawing.Size(201, 6);
			// 
			// menuFileExit
			// 
			this.menuFileExit.Name = "menuFileExit";
			this.menuFileExit.Size = new System.Drawing.Size(204, 22);
			this.menuFileExit.Text = "Выход";
			this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
			// 
			// menuEdit
			// 
			this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEditUndo,
            this.menuEditSeparator1,
            this.menuEditCut,
            this.menuEditCopy,
            this.menuEditPaste,
            this.menuEditDelete,
            this.menuEditSeparator2,
            this.menuEditFind,
            this.menuEditFindNext,
            this.menuEditSeparator3,
            this.menuEditReplace,
            this.menuEditGo,
            this.menuEditSeparator4,
            this.menuEditSelectAll,
            this.menuEditDateTime});
			this.menuEdit.Name = "menuEdit";
			this.menuEdit.Size = new System.Drawing.Size(59, 20);
			this.menuEdit.Text = "Правка";
			this.menuEdit.DropDownOpening += new System.EventHandler(this.menuEdit_DropDownOpening);
			// 
			// menuEditUndo
			// 
			this.menuEditUndo.Name = "menuEditUndo";
			this.menuEditUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
			this.menuEditUndo.Size = new System.Drawing.Size(190, 22);
			this.menuEditUndo.Text = "Отменить";
			this.menuEditUndo.Click += new System.EventHandler(this.menuEditUndo_Click);
			// 
			// menuEditSeparator1
			// 
			this.menuEditSeparator1.Name = "menuEditSeparator1";
			this.menuEditSeparator1.Size = new System.Drawing.Size(187, 6);
			// 
			// menuEditCut
			// 
			this.menuEditCut.Name = "menuEditCut";
			this.menuEditCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.menuEditCut.Size = new System.Drawing.Size(190, 22);
			this.menuEditCut.Text = "Вырезать";
			this.menuEditCut.Click += new System.EventHandler(this.menuEditCut_Click);
			// 
			// menuEditCopy
			// 
			this.menuEditCopy.Name = "menuEditCopy";
			this.menuEditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.menuEditCopy.Size = new System.Drawing.Size(190, 22);
			this.menuEditCopy.Text = "Копировать";
			this.menuEditCopy.Click += new System.EventHandler(this.menuEditCopy_Click);
			// 
			// menuEditPaste
			// 
			this.menuEditPaste.Name = "menuEditPaste";
			this.menuEditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.menuEditPaste.Size = new System.Drawing.Size(190, 22);
			this.menuEditPaste.Text = "Вставить";
			this.menuEditPaste.Click += new System.EventHandler(this.menuEditPaste_Click);
			// 
			// menuEditDelete
			// 
			this.menuEditDelete.Name = "menuEditDelete";
			this.menuEditDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.menuEditDelete.Size = new System.Drawing.Size(190, 22);
			this.menuEditDelete.Text = "Удалить";
			this.menuEditDelete.Click += new System.EventHandler(this.menuEditDelete_Click);
			// 
			// menuEditSeparator2
			// 
			this.menuEditSeparator2.Name = "menuEditSeparator2";
			this.menuEditSeparator2.Size = new System.Drawing.Size(187, 6);
			// 
			// menuEditFind
			// 
			this.menuEditFind.Name = "menuEditFind";
			this.menuEditFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
			this.menuEditFind.Size = new System.Drawing.Size(190, 22);
			this.menuEditFind.Text = "Найти...";
			this.menuEditFind.Click += new System.EventHandler(this.menuEditFind_Click);
			// 
			// menuEditFindNext
			// 
			this.menuEditFindNext.Name = "menuEditFindNext";
			this.menuEditFindNext.ShortcutKeys = System.Windows.Forms.Keys.F3;
			this.menuEditFindNext.Size = new System.Drawing.Size(190, 22);
			this.menuEditFindNext.Text = "Найти далее";
			this.menuEditFindNext.Click += new System.EventHandler(this.menuEditFindNext_Click);
			// 
			// menuEditSeparator3
			// 
			this.menuEditSeparator3.Name = "menuEditSeparator3";
			this.menuEditSeparator3.Size = new System.Drawing.Size(187, 6);
			// 
			// menuEditReplace
			// 
			this.menuEditReplace.Name = "menuEditReplace";
			this.menuEditReplace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
			this.menuEditReplace.Size = new System.Drawing.Size(190, 22);
			this.menuEditReplace.Text = "Заменить...";
			this.menuEditReplace.Click += new System.EventHandler(this.menuEditReplace_Click);
			// 
			// menuEditGo
			// 
			this.menuEditGo.Name = "menuEditGo";
			this.menuEditGo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
			this.menuEditGo.Size = new System.Drawing.Size(190, 22);
			this.menuEditGo.Text = "Перейти...";
			this.menuEditGo.Click += new System.EventHandler(this.menuEditGo_Click);
			// 
			// menuEditSeparator4
			// 
			this.menuEditSeparator4.Name = "menuEditSeparator4";
			this.menuEditSeparator4.Size = new System.Drawing.Size(187, 6);
			// 
			// menuEditSelectAll
			// 
			this.menuEditSelectAll.Name = "menuEditSelectAll";
			this.menuEditSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.menuEditSelectAll.Size = new System.Drawing.Size(190, 22);
			this.menuEditSelectAll.Text = "Выделить все";
			this.menuEditSelectAll.Click += new System.EventHandler(this.menuEditSelectAll_Click);
			// 
			// menuEditDateTime
			// 
			this.menuEditDateTime.Name = "menuEditDateTime";
			this.menuEditDateTime.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.menuEditDateTime.Size = new System.Drawing.Size(190, 22);
			this.menuEditDateTime.Text = "Время и дата";
			this.menuEditDateTime.Click += new System.EventHandler(this.menuEditDateTime_Click);
			// 
			// форматToolStripMenuItem
			// 
			this.форматToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.переносПоСловамToolStripMenuItem,
            this.menuFormatFont});
			this.форматToolStripMenuItem.Name = "форматToolStripMenuItem";
			this.форматToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
			this.форматToolStripMenuItem.Text = "Формат";
			// 
			// переносПоСловамToolStripMenuItem
			// 
			this.переносПоСловамToolStripMenuItem.Name = "переносПоСловамToolStripMenuItem";
			this.переносПоСловамToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
			this.переносПоСловамToolStripMenuItem.Text = "Перенос по словам";
			// 
			// menuFormatFont
			// 
			this.menuFormatFont.Name = "menuFormatFont";
			this.menuFormatFont.Size = new System.Drawing.Size(183, 22);
			this.menuFormatFont.Text = "Шрифт...";
			this.menuFormatFont.Click += new System.EventHandler(this.menuFormatFont_Click);
			// 
			// видToolStripMenuItem
			// 
			this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.строкаСостоянияToolStripMenuItem});
			this.видToolStripMenuItem.Name = "видToolStripMenuItem";
			this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.видToolStripMenuItem.Text = "Вид";
			// 
			// строкаСостоянияToolStripMenuItem
			// 
			this.строкаСостоянияToolStripMenuItem.Name = "строкаСостоянияToolStripMenuItem";
			this.строкаСостоянияToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.строкаСостоянияToolStripMenuItem.Text = "Строка состояния";
			// 
			// menuHelp
			// 
			this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpHelp,
            this.menuHelpSeparator1,
            this.menuHelpAbout});
			this.menuHelp.Name = "menuHelp";
			this.menuHelp.Size = new System.Drawing.Size(65, 20);
			this.menuHelp.Text = "Справка";
			// 
			// menuHelpHelp
			// 
			this.menuHelpHelp.Name = "menuHelpHelp";
			this.menuHelpHelp.Size = new System.Drawing.Size(188, 22);
			this.menuHelpHelp.Text = "Посмотреть справку";
			// 
			// menuHelpSeparator1
			// 
			this.menuHelpSeparator1.Name = "menuHelpSeparator1";
			this.menuHelpSeparator1.Size = new System.Drawing.Size(185, 6);
			// 
			// menuHelpAbout
			// 
			this.menuHelpAbout.Name = "menuHelpAbout";
			this.menuHelpAbout.Size = new System.Drawing.Size(188, 22);
			this.menuHelpAbout.Text = "О программе";
			this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelLeft,
            this.toolStripStatusLabelRight});
			this.statusStrip1.Location = new System.Drawing.Point(0, 239);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(412, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusMain";
			// 
			// toolStripStatusLabelLeft
			// 
			this.toolStripStatusLabelLeft.Name = "toolStripStatusLabelLeft";
			this.toolStripStatusLabelLeft.Size = new System.Drawing.Size(347, 17);
			this.toolStripStatusLabelLeft.Spring = true;
			// 
			// toolStripStatusLabelRight
			// 
			this.toolStripStatusLabelRight.AutoSize = false;
			this.toolStripStatusLabelRight.Name = "toolStripStatusLabelRight";
			this.toolStripStatusLabelRight.Size = new System.Drawing.Size(50, 17);
			// 
			// textMain
			// 
			this.textMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textMain.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textMain.Location = new System.Drawing.Point(0, 24);
			this.textMain.Multiline = true;
			this.textMain.Name = "textMain";
			this.textMain.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textMain.Size = new System.Drawing.Size(412, 215);
			this.textMain.TabIndex = 2;
			// 
			// dialogOpen
			// 
			this.dialogOpen.DefaultExt = "txt";
			this.dialogOpen.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы|*.*";
			// 
			// dialogSave
			// 
			this.dialogSave.DefaultExt = "txt";
			this.dialogSave.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы|*.*";
			// 
			// dialogPrint
			// 
			this.dialogPrint.UseEXDialog = true;
			// 
			// printDocument
			// 
			this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
			// 
			// dialogFont
			// 
			this.dialogFont.Color = System.Drawing.SystemColors.ControlText;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(412, 261);
			this.Controls.Add(this.textMain);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuMain);
			this.MainMenuStrip = this.menuMain;
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.Move += new System.EventHandler(this.FormMain_Move);
			this.Resize += new System.EventHandler(this.FormMain_Resize);
			this.menuMain.ResumeLayout(false);
			this.menuMain.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuMain;
		private System.Windows.Forms.ToolStripMenuItem menuFile;
		private System.Windows.Forms.ToolStripMenuItem menuFileNew;
		private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
		private System.Windows.Forms.ToolStripMenuItem menuFileSave;
		private System.Windows.Forms.ToolStripMenuItem menuFileSaveAs;
		private System.Windows.Forms.ToolStripSeparator menuFileSeparator1;
		private System.Windows.Forms.ToolStripMenuItem menuFilePageSetup;
		private System.Windows.Forms.ToolStripMenuItem menuFilePrint;
		private System.Windows.Forms.ToolStripSeparator menuFileSeparator2;
		private System.Windows.Forms.ToolStripMenuItem menuFileExit;
		private System.Windows.Forms.ToolStripMenuItem menuEdit;
		private System.Windows.Forms.ToolStripMenuItem menuEditUndo;
		private System.Windows.Forms.ToolStripSeparator menuEditSeparator1;
		private System.Windows.Forms.ToolStripMenuItem menuEditCut;
		private System.Windows.Forms.ToolStripMenuItem menuEditCopy;
		private System.Windows.Forms.ToolStripMenuItem menuEditPaste;
		private System.Windows.Forms.ToolStripMenuItem menuEditDelete;
		private System.Windows.Forms.ToolStripSeparator menuEditSeparator2;
		private System.Windows.Forms.ToolStripMenuItem menuEditFind;
		private System.Windows.Forms.ToolStripMenuItem menuEditFindNext;
		private System.Windows.Forms.ToolStripSeparator menuEditSeparator3;
		private System.Windows.Forms.ToolStripMenuItem menuEditReplace;
		private System.Windows.Forms.ToolStripMenuItem menuEditGo;
		private System.Windows.Forms.ToolStripSeparator menuEditSeparator4;
		private System.Windows.Forms.ToolStripMenuItem menuEditSelectAll;
		private System.Windows.Forms.ToolStripMenuItem menuEditDateTime;
		private System.Windows.Forms.ToolStripMenuItem форматToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem переносПоСловамToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menuFormatFont;
		private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem строкаСостоянияToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menuHelp;
		private System.Windows.Forms.ToolStripMenuItem menuHelpHelp;
		private System.Windows.Forms.ToolStripSeparator menuHelpSeparator1;
		private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLeft;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRight;
		private System.Windows.Forms.TextBox textMain;
		private System.Windows.Forms.OpenFileDialog dialogOpen;
		private System.Windows.Forms.SaveFileDialog dialogSave;
		private System.Windows.Forms.PageSetupDialog dialogPageSetup;
		private System.Windows.Forms.PrintDialog dialogPrint;
		private System.Drawing.Printing.PrintDocument printDocument;
		private System.Windows.Forms.FontDialog dialogFont;
	}
}

