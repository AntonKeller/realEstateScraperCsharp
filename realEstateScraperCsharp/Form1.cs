using Microsoft.Playwright;
using Newtonsoft.Json;
using OfficeOpenXml;
using PlaywrightExtraSharp;
using realEstateScraperCsharp.Modules;
using realEstateScraperCsharp.Modules.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace realEstateScraperCsharp
{
    public partial class Form1 : Form
    {
        private PlaywrightExtra browser;  // Браузерный Движок
        private IPage Page;               // Страница движка
        private StoreType GStore; // Объект текущего проекта, хранилище данных

        public Form1()
        {
            InitializeComponent();

            // ~~~ Работаем со Store
            GStore = new StoreType();

            // Подпишем ListBox с главного меню на Оповещения по изменению списка проектов в нашем Store
            GStore.SetLogerProjectList("Список проектов", new AnyListLoger(ListBoxProjects));

            // Подпишем ListBox с главного меню на Оповещения по изменению списка ссылок в проекте
            // Подпишем ListBox с главного меню на Оповещения по изменению списка данных в проекте
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

        public class Offer
        {
            public int sdafdafdsafdsaf { get; set; }
            public int Id { get; private set; }
            public int CianId { get; set; }
            public string FullUrl { get; set; }
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

        private async void TestLinksGenerate_Click(object sender, EventArgs e)
        {
            var ListURL = await CianAPI.PageLinksGenerator(this.Page, "https://www.cian.ru/cat.php?deal_type=rent&engine_version=2&offer_type=offices&office_type%5B0%5D=6&region=1");
            Table.Columns.Add("links", "Ссылки");
            foreach (var URL in ListURL) Table.Rows.Add(URL.URL);
        }

        private async void TestLoadOffers_Click(object sender, EventArgs e)
        {
            var offers = await CianAPI.LoadOffersFromPage(this.Page, "https://www.cian.ru/snyat-garazh/");

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

        private async void TestLoadRegions_Click(object sender, EventArgs e)
        {
            var regions = await CianAPI.GetCianRegions();
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

        private async void button2_Click_4(object sender, EventArgs e)
        {
            if (this.browser == null)
            {
                this.browser = await MyPlaywrightExtra.OpenBrowser();
            }

            if (this.Page == null)
            {
                this.Page = await this.browser.NewPageAsync();
                FormTitleBrowserStatus.Text = "Браузер: запущен";
                LoadTestData.Enabled = true;
                FormToolsBrowserOpen.Enabled = false;
            }

            var pName = ListBoxProjects.Items[ListBoxProjects.SelectedIndex].ToString();
            List<PageLink> list = GStore.GetProjectByName(pName).GetLinkListData();
            var adapter = new AdapterRealEstateData();
            for (var i = 0; i < list.Count; i++)
            {
                // Загружаем данные с циана
                var offers = await CianAPI.LoadOffersFromPage(this.Page, list[i].URL);

                // Транслируем карточки в формат CompleteFields
                // И добавляем в проект
                foreach (var offer in offers)
                {
                    var fields = adapter.TranslateFromCian(offer);
                    GStore.GetProjectByName(pName).AddCard(fields);
                }

                // Отмечаем ссылку, как завершенную
                list[i].Loaded = true;

                // Сохраняем пакет данных загруженных в проект и ссылки
                GStore.GetProjectByName(pName).SaveLinkListData();
                GStore.GetProjectByName(pName).SaveBufferData();
            }
        }

        private async void GenerateUrlButton_Click(object sender, EventArgs e)
        {
            
            if (this.browser == null)
            {
                this.browser = await MyPlaywrightExtra.OpenBrowser();
            }

            if (this.Page == null)
            {
                this.Page = await this.browser.NewPageAsync();
                FormTitleBrowserStatus.Text = "Браузер: запущен";
                LoadTestData.Enabled = true;
                FormToolsBrowserOpen.Enabled = false;
            }

            // Определяем классы помещений
            List<string> PermClasses = new()
            {
            //"&building_class_type%5B0%5D=2", // Класс: A+
            "&building_class_type%5B0%5D=1", // Класс: A
            //"&building_class_type%5B0%5D=4", // Класс: B+
            //"&building_class_type%5B0%5D=3", // Класс: B
            //"&building_class_type%5B0%5D=8", // Класс: B-
            //"&building_class_type%5B0%5D=5", // Класс: C
            };

            // Определяем категории для загрузки
            List<string> categoriesURL = new()
            {
                BaseCategories.OFFICE_SALE, // Категория: продажа офисных помещений
                //BaseCategories.OFFICE_RENT, // Категория: аренда офисных помещений
            };

            // Определяем генератор ссылок для продажи и аренды офисных помещений
            var generator1 = new SimpleGeneratorURL(
                "Продажа/Аренда Офисов",
                categoriesURL,           // Список базовых ссылок (Включает стандартные параметры: Домен, Движок, Тип предложения, Тип сделки)
                PermClasses,             // Классы помещения
                new Interval(50, null),  // Интервал площади помещения
                new Interval(50, null),  // Интервал площади земли
                1                        // ID региона
                );

            // Добавляем логгер в наш генератор
            var logger = new GeneratorURLLogger();
            logger.SetOutput(FormTitleBrowserStatus);
            generator1.AddLogObserver("logger1", logger);

            // Записываем имя проекта, который вызвал загрузку ссылок
            string targetProjectName = ListBoxProjects.Items[ListBoxProjects.SelectedIndex].ToString();

            // Получим объект проекта
            var project = GStore.GetProjectByName(targetProjectName);

            // Генерируем ссылки
            var generationLinkList = await generator1.Generate(Page);

            // Добавляем ссылки в проект
            foreach(var exLink in generationLinkList)
            {
                project.AddLink(exLink);
            }

            // Сохраняем буффер ссылок
            project.SaveLinkListData();

            // Удаляем логер из нашего генератора
            generator1.RemoveLogObserver("logger1");
        }

        private void TestExcelCreator_Click(object sender, EventArgs e)
        {
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
                        // Создаем Рабочий лист
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("worksheet");

                        //Add some text to cell A1
                        worksheet.Cells["A1"].Value = "My first EPPlus spreadsheet!";
                        //You could also use [line, column] notation:
                        worksheet.Cells[1, 2].Style.Numberformat.Format = "#,##0.00";
                        worksheet.Cells[1, 2].Value = "100000";
                        



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

        private void button5_Click(object sender, EventArgs e)
        {
            // Добавляем новый проект в Store
            if (textBox1.Text.Length > 0)
            {
                GStore.AddProject(textBox1.Text);
            }
        }

        private void ListBoxProjects_Click(object sender, EventArgs e)
        {
            var self = (System.Windows.Forms.ListBox)sender;
            if (self.SelectedIndex != -1)
            {
                var pName = self.Items[self.SelectedIndex].ToString();
                //await GStore.InitializeProject(pName);
                GStore.InitializeProject(pName);
                foreach (var link in GStore.GetProjectByName(pName).GetLinkListData())
                {
                    listBoxLinkList.Items.Add(link.URL);
                }
                foreach (var element in GStore.GetProjectByName(pName).GetBufferData())
                {
                    listBoxBufferListData.Items.Add(element.Address);
                }
            }


            //var self = (System.Windows.Forms.ListBox)sender;
            //if (self.SelectedIndex != -1)
            //{
            //    //Получим имя выбранного проекта
            //    var fileName = self.Items[self.SelectedIndex].ToString();

                //    // Получим проект по имени
                //    var project = GStore.GetProjectByName(fileName);

                //    // Получим список файлов с ссылками
                //    var LinkList = project.GetLinkListData();
                //    listBoxLinkList.Items.Clear();

                //    // Если у проекта есть ссылки -> Запишем их в ListBox
                //    if (LinkList != null)
                //    {
                //        foreach (var elem in LinkList)
                //        {
                //            listBoxLinkList.Items.Add(elem.URL);
                //        }
                //    }
                //}
        }

        private async void yandexApiЗапросПоАдресуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var api = new YandexAPI();
            var YandexResponse = await api.GetInfoByAddress("bd9aa639-828c-4fd1-96ce-fc519d09f7d2", "Москва, Паперника 7 к 2");
            Console.WriteLine("");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormConfigurator form = new ();
            form.ShowDialog();
        }
    }

    public class MyType
    {
        public double? Lat { get; set; }
        public double? Lng { get; set; }
    }

    public class MyType2
    {
        public string FullName { get; set; }
        public MyType myType { get; set; }
    }


    class AnyListLoger: IListLoger
    {
        protected System.Windows.Forms.ListBox _ListBox;
        public AnyListLoger(System.Windows.Forms.ListBox lstBox)
        {
            this._ListBox = lstBox;
        }
        public void SendList(List<string> projectNameList)
        {
            var activeIndex = _ListBox.SelectedIndex;
            _ListBox.Items.Clear();
            foreach (var name in projectNameList)
            {
                _ListBox.Items.Add(name);
            }
            _ListBox.SelectedIndex = activeIndex;
        }
    }


    class GeneratorURLLogger: ILogObserver
    {
        private ToolStripStatusLabel Element;

        public void SetOutput(ToolStripStatusLabel element)
        {
            Element = element;
        }

        void ILogObserver.Update(string txtMsg)
        {
            Element.Text = txtMsg;
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
}
