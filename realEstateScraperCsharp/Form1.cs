using Microsoft.Playwright;
using Newtonsoft.Json;
using OfficeOpenXml;
using PlaywrightExtraSharp;
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

namespace realEstateScraperCsharp
{
    
    public partial class Form1 : Form
    {


        private PlaywrightExtra browser;
        IPage page;
        private BrowserSubscriber[] browserSubscribers;

        public void Subscribe(BrowserSubscriber brSubscriber)
        {
            this.browserSubscribers.Append(brSubscriber);
        }

        public void CallBrowserWasOpened()
        {
            foreach (BrowserSubscriber subscriber in browserSubscribers) {
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
            this.page = await this.browser.NewPageAsync();
            await this.page.GotoAsync(formUrlInput.Text);
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
            this.page = await this.browser.NewPageAsync();
            await this.page.GotoAsync("https://www.cian.ru/cat.php?deal_type=sale&engine_version=2&offer_type=offices&office_type%5B0%5D=3&p=2&region=1");
            FormTitleBrowserStatus.Text = "Браузер: запущен";
            FormToolsBrowserClose.Enabled = true;
            FormToolsBrowserOpen.Enabled = false;
        }

        private async void FormToolsBrowserClose_Click(object sender, EventArgs e)
        {
            await this.browser.CloseAsync();
            FormTitleBrowserStatus.Text = "Браузер: отключен";
            FormToolsBrowserClose.Enabled = false;  
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
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

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
                string directory = @"data_result/excel_data_result/";
                string filePath = @"data_result/excel_data_result/File.xlsx";
                var exists = !Directory.Exists(directory);
                var exists2 = Directory.Exists(filePath);
                var exists4 = File.Exists(filePath);
                var files = Directory.GetFiles(directory);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                FileInfo fi = new FileInfo(directory + "File.xlsx");
                excelPackage.SaveAs(fi);
            }
        }

        public class Geo
        {
            public int countryId { get; set; }
            public string userInput { get; set; }

        }

        public class Offer
        {
            public Geo Geo { get; set; }
            public int sdafdafdsafdsaf { get; set; }
            public int Id { get; set; }
            public int CianId { get; set; }
            public string FullUrl { get; set; }
        }

        private async void button3_Click_1(object sender, EventArgs e)
        {
            var response = await this.page.EvaluateAsync(@"
                () => window._cianConfig['legacy-commercial-serp-frontend'].find(item => item.key === 'initialState').value.results.offers
            ");

            string str = response.ToString();
            var jsonData = JsonConvert.DeserializeObject<Offer[]>(str);




            toolStripStatusLabel1.Text = response.GetType().FullName;
            //var json = resp.Value
            Console.WriteLine("");
        }
    }

    public partial class BrowserSubscriber
    {
        public void call(bool BrowserStatus)
        {

        }
    }
}
