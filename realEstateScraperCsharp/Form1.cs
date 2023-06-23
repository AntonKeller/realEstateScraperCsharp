using Microsoft.Playwright;
using PlaywrightExtraSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace realEstateScraperCsharp
{

    public partial class Form1 : Form
    {

        private PlaywrightExtra browser;
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
            
            this.browser = await MyPlaywrightExtra.OpenBrowser();
            FormTitleBrowserStatus.Text = "Браузер: запущен";
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
            await this.browser.CloseAsync();
            FormTitleBrowserStatus.Text = "Браузер: отключен";
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            IPage page = await this.browser.NewPageAsync();
            await page.GotoAsync(formUrlInput.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void источникиДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

    public partial class BrowserSubscriber
    {
        public void call(bool BrowserStatus)
        {

        }
    }
}
