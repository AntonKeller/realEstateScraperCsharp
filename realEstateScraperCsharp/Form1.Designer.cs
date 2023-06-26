namespace realEstateScraperCsharp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.FormToolsBrowserOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.FormToolsBrowserClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузкаДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.форматToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обработкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.FormTitleBrowserStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.FormIntervalElement = new System.Windows.Forms.ToolStripStatusLabel();
            this.FormProgramVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.formUrlInput = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FormListDataLoadedHistory = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(140, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Открыть страницу";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 413);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(784, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьФайлToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.toolStripMenuItem2,
            this.FormToolsBrowserOpen,
            this.FormToolsBrowserClose,
            this.toolStripMenuItem1});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьФайлToolStripMenuItem
            // 
            this.открытьФайлToolStripMenuItem.Name = "открытьФайлToolStripMenuItem";
            this.открытьФайлToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.открытьФайлToolStripMenuItem.Text = "Открыть файл";
            this.открытьФайлToolStripMenuItem.Click += new System.EventHandler(this.открытьФайлToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(173, 6);
            // 
            // FormToolsBrowserOpen
            // 
            this.FormToolsBrowserOpen.Name = "FormToolsBrowserOpen";
            this.FormToolsBrowserOpen.Size = new System.Drawing.Size(176, 22);
            this.FormToolsBrowserOpen.Text = "Запустить браузер";
            this.FormToolsBrowserOpen.Click += new System.EventHandler(this.FormToolsBrowserOpen_Click);
            // 
            // FormToolsBrowserClose
            // 
            this.FormToolsBrowserClose.Enabled = false;
            this.FormToolsBrowserClose.Name = "FormToolsBrowserClose";
            this.FormToolsBrowserClose.Size = new System.Drawing.Size(176, 22);
            this.FormToolsBrowserClose.Text = "Закрыть браузер";
            this.FormToolsBrowserClose.Click += new System.EventHandler(this.FormToolsBrowserClose_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(173, 6);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузкаДанныхToolStripMenuItem,
            this.обработкаToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // загрузкаДанныхToolStripMenuItem
            // 
            this.загрузкаДанныхToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.форматToolStripMenuItem});
            this.загрузкаДанныхToolStripMenuItem.Name = "загрузкаДанныхToolStripMenuItem";
            this.загрузкаДанныхToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.загрузкаДанныхToolStripMenuItem.Text = "Загрузка данных";
            // 
            // форматToolStripMenuItem
            // 
            this.форматToolStripMenuItem.Name = "форматToolStripMenuItem";
            this.форматToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.форматToolStripMenuItem.Text = "Формат";
            // 
            // обработкаToolStripMenuItem
            // 
            this.обработкаToolStripMenuItem.Name = "обработкаToolStripMenuItem";
            this.обработкаToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.обработкаToolStripMenuItem.Text = "Обработка";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FormTitleBrowserStatus,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1,
            this.FormIntervalElement,
            this.FormProgramVersion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // FormTitleBrowserStatus
            // 
            this.FormTitleBrowserStatus.Name = "FormTitleBrowserStatus";
            this.FormTitleBrowserStatus.Size = new System.Drawing.Size(112, 17);
            this.FormTitleBrowserStatus.Text = "Браузер: отключен";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(124, 17);
            this.toolStripStatusLabel2.Text = "                                       ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(103, 17);
            this.toolStripStatusLabel1.Text = "Загрузка: 0 из 728";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click_1);
            // 
            // FormIntervalElement
            // 
            this.FormIntervalElement.Name = "FormIntervalElement";
            this.FormIntervalElement.Size = new System.Drawing.Size(124, 17);
            this.FormIntervalElement.Text = "                                       ";
            // 
            // FormProgramVersion
            // 
            this.FormProgramVersion.Name = "FormProgramVersion";
            this.FormProgramVersion.Size = new System.Drawing.Size(154, 17);
            this.FormProgramVersion.Text = "Версия программы: 1.0.0.1";
            // 
            // formUrlInput
            // 
            this.formUrlInput.Location = new System.Drawing.Point(140, 99);
            this.formUrlInput.Name = "formUrlInput";
            this.formUrlInput.Size = new System.Drawing.Size(168, 20);
            this.formUrlInput.TabIndex = 6;
            this.formUrlInput.Text = "https://www.cian.ru/cat.php?deal_type=sale&engine_version=2&offer_type=offices&of" +
    "fice_type%5B0%5D=3&p=2&region=1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FormListDataLoadedHistory);
            this.groupBox1.Location = new System.Drawing.Point(565, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 368);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Текущие данные";
            // 
            // FormListDataLoadedHistory
            // 
            this.FormListDataLoadedHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormListDataLoadedHistory.FormattingEnabled = true;
            this.FormListDataLoadedHistory.ItemHeight = 16;
            this.FormListDataLoadedHistory.Items.AddRange(new object[] {
            "1/Аренда,Продажа/Гаражи,Офисы,Склады/A+,A,B+,B/21.06.2023",
            "2/Продажа/Офисы/21.06.2023",
            "3/Аренда,Продажа/Склады/A+,A,B+,B/21.06.2023",
            "4/Аренда/Офисы,Склады/A+,A,B+,B/21.06.2023"});
            this.FormListDataLoadedHistory.Location = new System.Drawing.Point(6, 19);
            this.FormListDataLoadedHistory.Name = "FormListDataLoadedHistory";
            this.FormListDataLoadedHistory.Size = new System.Drawing.Size(195, 340);
            this.FormListDataLoadedHistory.TabIndex = 9;
            this.FormListDataLoadedHistory.SelectedIndexChanged += new System.EventHandler(this.FormListDataLoadedHistory_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(257, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Создать файл";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(140, 154);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(168, 24);
            this.button3.TabIndex = 9;
            this.button3.Text = "Загрузить предложения";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.formUrlInput);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Загрузчик";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузкаДанныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem форматToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обработкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel FormTitleBrowserStatus;
        private System.Windows.Forms.ToolStripMenuItem FormToolsBrowserOpen;
        private System.Windows.Forms.ToolStripMenuItem FormToolsBrowserClose;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.TextBox formUrlInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox FormListDataLoadedHistory;
        private System.Windows.Forms.ToolStripStatusLabel FormProgramVersion;
        private System.Windows.Forms.ToolStripStatusLabel FormIntervalElement;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

