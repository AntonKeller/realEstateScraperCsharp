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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveExcelTestMethod = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.LoadTestData = new System.Windows.Forms.ToolStripMenuItem();
            this.тестыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TestLoadOffers = new System.Windows.Forms.ToolStripMenuItem();
            this.TestLinksGenerate = new System.Windows.Forms.ToolStripMenuItem();
            this.Table = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.toolStripMenuItem1,
            this.toolStripMenuItem3,
            this.LoadTestData,
            this.тестыToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьФайлToolStripMenuItem
            // 
            this.открытьФайлToolStripMenuItem.Name = "открытьФайлToolStripMenuItem";
            this.открытьФайлToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.открытьФайлToolStripMenuItem.Text = "Открыть файл";
            this.открытьФайлToolStripMenuItem.Click += new System.EventHandler(this.открытьФайлToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveExcelTestMethod});
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // SaveExcelTestMethod
            // 
            this.SaveExcelTestMethod.Name = "SaveExcelTestMethod";
            this.SaveExcelTestMethod.Size = new System.Drawing.Size(193, 22);
            this.SaveExcelTestMethod.Text = "Сохранить Excel (test)";
            this.SaveExcelTestMethod.Click += new System.EventHandler(this.SaveExcelTestMethod_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(225, 6);
            // 
            // FormToolsBrowserOpen
            // 
            this.FormToolsBrowserOpen.Name = "FormToolsBrowserOpen";
            this.FormToolsBrowserOpen.Size = new System.Drawing.Size(228, 22);
            this.FormToolsBrowserOpen.Text = "Запустить браузер";
            this.FormToolsBrowserOpen.Click += new System.EventHandler(this.FormToolsBrowserOpen_Click);
            // 
            // FormToolsBrowserClose
            // 
            this.FormToolsBrowserClose.Enabled = false;
            this.FormToolsBrowserClose.Name = "FormToolsBrowserClose";
            this.FormToolsBrowserClose.Size = new System.Drawing.Size(228, 22);
            this.FormToolsBrowserClose.Text = "Закрыть браузер";
            this.FormToolsBrowserClose.Click += new System.EventHandler(this.FormToolsBrowserClose_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(225, 6);
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
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(225, 6);
            // 
            // LoadTestData
            // 
            this.LoadTestData.Name = "LoadTestData";
            this.LoadTestData.Size = new System.Drawing.Size(228, 22);
            this.LoadTestData.Text = "Загрузить тестовые дынные";
            this.LoadTestData.Click += new System.EventHandler(this.LoadTestData_Click);
            // 
            // тестыToolStripMenuItem
            // 
            this.тестыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TestLoadOffers,
            this.TestLinksGenerate});
            this.тестыToolStripMenuItem.Name = "тестыToolStripMenuItem";
            this.тестыToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.тестыToolStripMenuItem.Text = "Тесты";
            // 
            // TestLoadOffers
            // 
            this.TestLoadOffers.Name = "TestLoadOffers";
            this.TestLoadOffers.Size = new System.Drawing.Size(206, 22);
            this.TestLoadOffers.Text = "Загрузить предложения";
            this.TestLoadOffers.Click += new System.EventHandler(this.TestLoadOffers_Click);
            // 
            // TestLinksGenerate
            // 
            this.TestLinksGenerate.Name = "TestLinksGenerate";
            this.TestLinksGenerate.Size = new System.Drawing.Size(206, 22);
            this.TestLinksGenerate.Text = "Генерация ссылок";
            this.TestLinksGenerate.Click += new System.EventHandler(this.TestLinksGenerate_Click);
            // 
            // Table
            // 
            this.Table.BackgroundColor = System.Drawing.SystemColors.Window;
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Table.GridColor = System.Drawing.Color.Firebrick;
            this.Table.Location = new System.Drawing.Point(0, 56);
            this.Table.Name = "Table";
            this.Table.Size = new System.Drawing.Size(784, 383);
            this.Table.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Firebrick;
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 32);
            this.panel1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(545, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(626, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(146, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(393, 6);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(146, 21);
            this.comboBox2.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.checkBox1.Location = new System.Drawing.Point(294, 8);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(71, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "...............";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Загрузчик";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.ToolStripStatusLabel FormProgramVersion;
        private System.Windows.Forms.ToolStripStatusLabel FormIntervalElement;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem SaveExcelTestMethod;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem LoadTestData;
        private System.Windows.Forms.ToolStripMenuItem тестыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TestLoadOffers;
        private System.Windows.Forms.ToolStripMenuItem TestLinksGenerate;
        private System.Windows.Forms.DataGridView Table;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

