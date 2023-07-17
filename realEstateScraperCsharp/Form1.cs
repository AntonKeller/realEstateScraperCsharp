using Microsoft.Playwright;
using Newtonsoft.Json;
using OfficeOpenXml;
using PlaywrightExtraSharp;
using realEstateScraperCsharp.Modules;
using realEstateScraperCsharp.Modules.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace realEstateScraperCsharp
{

    public partial class Form1 : Form
    {


        private PlaywrightExtra browser;
        IPage Page;
        private BrowserSubscriber[] browserSubscribers;

        public void Subscribe(BrowserSubscriber brSubscriber)
        {
            this.browserSubscribers.Append(brSubscriber);
        }

        public void CallBrowserWasOpened()
        {
            foreach (BrowserSubscriber subscriber in browserSubscribers)
            {
                subscriber.call(true);
            }
        }

        public void CallBrowserWasClosed()
        {
            foreach (BrowserSubscriber subscriber in browserSubscribers)
            {
                subscriber.call(false);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

        }

        private void открытьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {

        }

        private async void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void источникиДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private async void FormToolsBrowserOpen_Click(object sender, EventArgs e)
        {
            this.browser = await MyPlaywrightExtra.OpenBrowser();
            this.Page = await this.browser.NewPageAsync();
            await this.Page.GotoAsync("https://www.cian.ru/cat.php?deal_type=sale&engine_version=2&offer_type=offices&office_type%5B0%5D=3&p=2&region=1");
            FormTitleBrowserStatus.Text = "Браузер: запущен";
            FormToolsBrowserClose.Enabled = true;
            LoadTestData.Enabled = true;
            FormToolsBrowserOpen.Enabled = false;
        }

        private async void FormToolsBrowserClose_Click(object sender, EventArgs e)
        {
            await this.browser.CloseAsync();
            FormTitleBrowserStatus.Text = "Браузер: отключен";
            FormToolsBrowserClose.Enabled = false;
            LoadTestData.Enabled = false;
            FormToolsBrowserOpen.Enabled = true;
        }

        private void toolStripStatusLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void FormListDataLoadedHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {

        }


        public class Offer
        {
            public int sdafdafdsafdsaf { get; set; }
            public int Id { get; private set; }
            public int CianId { get; set; }
            public string FullUrl { get; set; }
        }

        private async void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SaveExcelTestMethod_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "Документ Excel (.xlsx)|*.xlsx";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    string filePath = saveFileDialog.FileName;

                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        excelPackage.Workbook.Properties.Author = "VDWWD";
                        excelPackage.Workbook.Properties.Title = "Title of Document";
                        excelPackage.Workbook.Properties.Subject = "EPPlus demo export data";
                        excelPackage.Workbook.Properties.Created = DateTime.Now;
                        //Create the WorkSheet
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");
                        //Add some text to cell A1
                        worksheet.Cells["A1"].Value = "My first EPPlus spreadsheet!";
                        //You could also use [line, column] notation:
                        worksheet.Cells[1, 2].Value = "This is cell B1!";

                        //Save your file
                        //string directory = @"data_result/excel_data_result/";
                        //string filePath = @"data_result/excel_data_result/File.xlsx";
                        //var exists = !Directory.Exists(directory);
                        //var exists2 = Directory.Exists(filePath);
                        //var exists4 = File.Exists(filePath);
                        //var files = Directory.GetFiles(directory);
                        //if (!Directory.Exists(directory))
                        //{
                        //    Directory.CreateDirectory(directory);
                        //}
                        FileInfo fi = new FileInfo(filePath);
                        excelPackage.SaveAs(fi);
                    }
                }
            }
        }

        private async void LoadTestData_Click(object sender, EventArgs e)
        {
            var response = await this.Page.EvaluateAsync(@"
                () => window._cianConfig['legacy-commercial-serp-frontend'].find(item => item.key === 'initialState').value.results.offers
            ");

            string str = response.ToString();
            var offers = JsonConvert.DeserializeObject<CianOffer[]>(str);

            foreach (var offer in offers)
            {
                //| Протестировать парсинг данных по моедлям ...
                var adapter = new AdapterRealEstateData();
                var completeFields = adapter.TranslateFromCian(offer);
                //| Инициализация полей
                var generalCardFields = new GeneralFields(completeFields);
                var garageFields = new GarageFields(completeFields);
                var officeFields = new OfficeFields(completeFields);
                var landFields = new LandFields(completeFields);
                //| Инициализация карточки
                var officeCard = new OfficeCardModel(generalCardFields, officeFields);
                var garageCard = new GarageCardModel(generalCardFields, garageFields);
                var landCard = new LandCardModel(generalCardFields, landFields);
            }
        }

        private async void button1_Click_2(object sender, EventArgs e)
        {

        }

        private async void button2_Click_3(object sender, EventArgs e)
        {

        }

        private async void TestLinksGenerate_Click(object sender, EventArgs e)
        {
            var api = new CianAPI();
            var generate = await api.PageLinksGenerator(this.Page, "https://www.cian.ru/cat.php?deal_type=rent&engine_version=2&offer_type=offices&office_type%5B0%5D=6&region=1");

            Table.Columns.Add("links", "Ссылки");

            foreach (var link in generate.Links)
            {
                Table.Rows.Add(link);
            }
        }

        private async void TestLoadOffers_Click(object sender, EventArgs e)
        {
            var api = new CianAPI();
            var offers = await api.LoadOffersFromPage(this.Page, "https://www.cian.ru/snyat-garazh/");

            Table.Columns.Add("ID", "ID");
            Table.Columns.Add("CianId", "Циан ID");
            Table.Columns.Add("offerTitle", "Заголовок");
            Table.Columns.Add("AddedTimestamp", "Таймстамп");
            Table.Columns.Add("CadastralNumber", "Кадастрвоый номер");
            Table.Columns.Add("floorNumber", "Этаж");
            Table.Columns.Add("url", "Url");
            Table.Columns.Add("landType", "Тип земли");
            Table.Columns.Add("landArea", "Площадь земли");

            foreach (var offer in offers)
            {
                Table.Rows.Add(
                    offer.ID,
                    offer.CianId,
                    offer.Title,
                    offer.AddedTimestamp,
                    offer.CadastralNumber,
                    offer.floorNumber,
                    offer.FullUrl,
                    offer.Land?.Type,
                    offer.Land?.Area
                );
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            Table.Dock = DockStyle.Fill;
        }

        private async void button1_Click_3(object sender, EventArgs e)
        {

        }

        private void загрузитьСписокРегионовToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void сохранитьВJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void OpenProjectFromFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "(*.json)|";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    string filePath = openFileDialog.FileName;
                }
            }
        }

        private void сохранитьПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SaveProjectToFIle_Click(object sender, EventArgs e)
        {

        }

        private async void TestLoadRegions_Click(object sender, EventArgs e)
        {
            var api = new CianAPI();
            var regions = await api.GetCianRegions();
            var fields = regions[0].GetType().GetFields();
            TableTitle[] titles =
            {
                new TableTitle("Id", "Id"),
                new TableTitle("Name", "Name"),
                new TableTitle("Lat", "IdLat"),
                new TableTitle("Lng", "Lng"),
                new TableTitle("FullName", "FullName"),
                new TableTitle("DisplayName", "DisplayName"),
            };

            foreach (var title in titles)
                Table.Columns.Add(title.Name, title.RuTitle);

            foreach (var region in regions)
                Table.Rows.Add(
                    region.Id,
                    region.Name,
                    region.Lat,
                    region.Lng,
                    region.FullName,
                    region.DisplayName
                    );
        }

        private void Table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_4(object sender, EventArgs e)
        {

        }

        private void GenerateUrlButton_Click(object sender, EventArgs e)
        {
            // ...................................................................................................................
            // Определяем классы помещений
            List<string> PermClasses = new()
            {
            "&building_class_type%5B0%5D=2", // Класс: A+
            "&building_class_type%5B0%5D=1", // Класс: A
            "&building_class_type%5B0%5D=4", // Класс: B+
            "&building_class_type%5B0%5D=3", // Класс: B
            "&building_class_type%5B0%5D=8", // Класс: B-
            "&building_class_type%5B0%5D=5", // Класс: C
            };

            // Определяем категории URL 
            List<string> categoriesURL = new()
            {
                BaseCategories.OFFICE_SALE, // Категория: продажа офисных помещений
                BaseCategories.OFFICE_RENT, // Категория: аренда офисных помещений
            };

            // Определяем генератор ссылок для продажи и аренды офисных помещений
            var generator1 = new SimpleGeneratorURL(
                "Продажа/Аренда Офисов",
                categoriesURL,          // Список базовых ссылок (Включает стандартные параметры: Домен, Движок, Тип предложения, Тип сделки)
                PermClasses,            // Классы помещения
                new Interval(50, null), // Интервал площади помещения
                new Interval(50, null)  // Интервал площади земли
                );

            // ...................................................................................................................


            // ...................................................................................................................
            // Добавляем Генератор в наш "Конфигурационный Store"
            var configStore = new ConfigurationStore();
            // ...................................................................................................................
        }
    }

    class TableTitle
    {
        public string RuTitle { get; set; }
        public string Name { get; set; }
        public TableTitle(string ruTitle, string name)
        {
            this.RuTitle = ruTitle;
            this.Name = name;
        }
    }

    public partial class BrowserSubscriber
    {
        public void call(bool BrowserStatus)
        {

        }
    }
}
