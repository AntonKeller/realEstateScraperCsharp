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
            this.OpenProjectFromFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveProjectToFIle = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveInExcelFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveInJSONFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveInXMLFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveInTxtFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.FormToolsBrowserOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.FormToolsBrowserClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.LoadTestData = new System.Windows.Forms.ToolStripMenuItem();
            this.тестыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TestLoadOffers = new System.Windows.Forms.ToolStripMenuItem();
            this.TestLinksGenerate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.TestLoadRegions = new System.Windows.Forms.ToolStripMenuItem();
            this.TestLoadCities = new System.Windows.Forms.ToolStripMenuItem();
            this.TestLoadDistricts = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузкаДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.программаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.FormTitleBrowserStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.FormIntervalElement = new System.Windows.Forms.ToolStripStatusLabel();
            this.FormProgramVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.Table = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.BuildClasses = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.GenerateUrlButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.panel1.SuspendLayout();
            this.BuildClasses.SuspendLayout();
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
            this.OpenProjectFromFile,
            this.SaveProjectToFIle,
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
            // OpenProjectFromFile
            // 
            this.OpenProjectFromFile.Name = "OpenProjectFromFile";
            this.OpenProjectFromFile.Size = new System.Drawing.Size(228, 22);
            this.OpenProjectFromFile.Text = "Открыть";
            this.OpenProjectFromFile.Click += new System.EventHandler(this.OpenProjectFromFile_Click);
            // 
            // SaveProjectToFIle
            // 
            this.SaveProjectToFIle.Name = "SaveProjectToFIle";
            this.SaveProjectToFIle.Size = new System.Drawing.Size(228, 22);
            this.SaveProjectToFIle.Text = "Сохранить";
            this.SaveProjectToFIle.Click += new System.EventHandler(this.SaveProjectToFIle_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveInExcelFile,
            this.SaveInJSONFile,
            this.SaveInXMLFile,
            this.SaveInTxtFile});
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить как";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // SaveInExcelFile
            // 
            this.SaveInExcelFile.Name = "SaveInExcelFile";
            this.SaveInExcelFile.Size = new System.Drawing.Size(246, 22);
            this.SaveInExcelFile.Text = "Сохранить как Excel файл";
            // 
            // SaveInJSONFile
            // 
            this.SaveInJSONFile.Name = "SaveInJSONFile";
            this.SaveInJSONFile.Size = new System.Drawing.Size(246, 22);
            this.SaveInJSONFile.Text = "Сохранить как JSON";
            // 
            // SaveInXMLFile
            // 
            this.SaveInXMLFile.Name = "SaveInXMLFile";
            this.SaveInXMLFile.Size = new System.Drawing.Size(246, 22);
            this.SaveInXMLFile.Text = "Сохранить как XML файл";
            // 
            // SaveInTxtFile
            // 
            this.SaveInTxtFile.Name = "SaveInTxtFile";
            this.SaveInTxtFile.Size = new System.Drawing.Size(246, 22);
            this.SaveInTxtFile.Text = "Сохранить как текстовый файл";
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
            this.TestLinksGenerate,
            this.toolStripMenuItem4,
            this.TestLoadRegions,
            this.TestLoadCities,
            this.TestLoadDistricts,
            this.toolStripMenuItem5});
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
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(203, 6);
            // 
            // TestLoadRegions
            // 
            this.TestLoadRegions.Name = "TestLoadRegions";
            this.TestLoadRegions.Size = new System.Drawing.Size(206, 22);
            this.TestLoadRegions.Text = "Список Регионов";
            this.TestLoadRegions.Click += new System.EventHandler(this.TestLoadRegions_Click);
            // 
            // TestLoadCities
            // 
            this.TestLoadCities.Name = "TestLoadCities";
            this.TestLoadCities.Size = new System.Drawing.Size(206, 22);
            this.TestLoadCities.Text = "Список Городов";
            // 
            // TestLoadDistricts
            // 
            this.TestLoadDistricts.Name = "TestLoadDistricts";
            this.TestLoadDistricts.Size = new System.Drawing.Size(206, 22);
            this.TestLoadDistricts.Text = "Список Дистриктов";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(203, 6);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузкаДанныхToolStripMenuItem,
            this.программаToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // загрузкаДанныхToolStripMenuItem
            // 
            this.загрузкаДанныхToolStripMenuItem.Name = "загрузкаДанныхToolStripMenuItem";
            this.загрузкаДанныхToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.загрузкаДанныхToolStripMenuItem.Text = "Конфигуратор";
            // 
            // программаToolStripMenuItem
            // 
            this.программаToolStripMenuItem.Name = "программаToolStripMenuItem";
            this.программаToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.программаToolStripMenuItem.Text = "Программа";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FormTitleBrowserStatus,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel1,
            this.FormIntervalElement,
            this.FormProgramVersion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 495);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 23);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // FormTitleBrowserStatus
            // 
            this.FormTitleBrowserStatus.Name = "FormTitleBrowserStatus";
            this.FormTitleBrowserStatus.Size = new System.Drawing.Size(112, 18);
            this.FormTitleBrowserStatus.Text = "Браузер: отключен";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(124, 18);
            this.toolStripStatusLabel2.Text = "                                       ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(118, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(103, 18);
            this.toolStripStatusLabel1.Text = "Загрузка: 0 из 728";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click_1);
            // 
            // FormIntervalElement
            // 
            this.FormIntervalElement.Name = "FormIntervalElement";
            this.FormIntervalElement.Size = new System.Drawing.Size(124, 18);
            this.FormIntervalElement.Text = "                                       ";
            // 
            // FormProgramVersion
            // 
            this.FormProgramVersion.Name = "FormProgramVersion";
            this.FormProgramVersion.Size = new System.Drawing.Size(154, 18);
            this.FormProgramVersion.Text = "Версия программы: 1.0.0.1";
            // 
            // Table
            // 
            this.Table.BackgroundColor = System.Drawing.Color.Snow;
            this.Table.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Table.GridColor = System.Drawing.Color.Firebrick;
            this.Table.Location = new System.Drawing.Point(0, 56);
            this.Table.Margin = new System.Windows.Forms.Padding(0);
            this.Table.Name = "Table";
            this.Table.Size = new System.Drawing.Size(784, 439);
            this.Table.TabIndex = 5;
            this.Table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Table_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Firebrick;
            this.panel1.Controls.Add(this.GenerateUrlButton);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 32);
            this.panel1.TabIndex = 6;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Window;
            this.button4.Location = new System.Drawing.Point(741, 4);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Х";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Window;
            this.button3.Location = new System.Drawing.Point(588, 4);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Продолжить";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Window;
            this.button2.Location = new System.Drawing.Point(469, 4);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Загрузить данные";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_4);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(680, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Стоп";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // BuildClasses
            // 
            this.BuildClasses.Controls.Add(this.checkedListBox1);
            this.BuildClasses.Location = new System.Drawing.Point(12, 62);
            this.BuildClasses.Name = "BuildClasses";
            this.BuildClasses.Size = new System.Drawing.Size(99, 134);
            this.BuildClasses.TabIndex = 8;
            this.BuildClasses.TabStop = false;
            this.BuildClasses.Text = "Классы";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Класс A+",
            "Класс A",
            "Класс B+",
            "Класс B",
            "Класс B-",
            "Класс C"});
            this.checkedListBox1.Location = new System.Drawing.Point(6, 19);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(87, 109);
            this.checkedListBox1.TabIndex = 8;
            // 
            // GenerateUrlButton
            // 
            this.GenerateUrlButton.BackColor = System.Drawing.SystemColors.Window;
            this.GenerateUrlButton.Location = new System.Drawing.Point(348, 5);
            this.GenerateUrlButton.Margin = new System.Windows.Forms.Padding(0);
            this.GenerateUrlButton.Name = "GenerateUrlButton";
            this.GenerateUrlButton.Size = new System.Drawing.Size(119, 23);
            this.GenerateUrlButton.TabIndex = 9;
            this.GenerateUrlButton.Text = "Генерация ссылок";
            this.GenerateUrlButton.UseVisualStyleBackColor = false;
            this.GenerateUrlButton.Click += new System.EventHandler(this.GenerateUrlButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 518);
            this.Controls.Add(this.BuildClasses);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Загрузчик";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.panel1.ResumeLayout(false);
            this.BuildClasses.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузкаДанныхToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem LoadTestData;
        private System.Windows.Forms.ToolStripMenuItem тестыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TestLoadOffers;
        private System.Windows.Forms.ToolStripMenuItem TestLinksGenerate;
        private System.Windows.Forms.DataGridView Table;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem TestLoadCities;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem TestLoadDistricts;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem TestLoadRegions;
        private System.Windows.Forms.ToolStripMenuItem SaveInExcelFile;
        private System.Windows.Forms.ToolStripMenuItem SaveInJSONFile;
        private System.Windows.Forms.ToolStripMenuItem SaveInXMLFile;
        private System.Windows.Forms.ToolStripMenuItem SaveInTxtFile;
        private System.Windows.Forms.ToolStripMenuItem OpenProjectFromFile;
        private System.Windows.Forms.ToolStripMenuItem SaveProjectToFIle;
        private System.Windows.Forms.ToolStripProgressBar toolStripStatusLabel3;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.ToolStripMenuItem программаToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox BuildClasses;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button GenerateUrlButton;
    }
}

