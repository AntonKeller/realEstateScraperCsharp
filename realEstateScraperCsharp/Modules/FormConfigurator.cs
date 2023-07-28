using realEstateScraperCsharp.Modules.API;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace realEstateScraperCsharp.Modules
{
    public partial class FormConfigurator : Form
    {
        public FormConfigurator()
        {
            InitializeComponent();

            // Записываем в combobox Список категорий на выгрузку
            foreach (var category in ConfigDictionaries.DicCategories)
            {
                comboBoxCategoriesLoad.Items.Add(category.Key);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FormConfigurator_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxCategoriesLoad_SelectedIndexChanged(object sender, EventArgs e)
        {
            var self = (ComboBox)sender;
            //ConstructURL()
        }

        private void checkBoxClassAplus_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxClassAplus.Checked)
            {

            }
        }
    }
}
