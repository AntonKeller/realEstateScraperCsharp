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
            foreach (var category in Collector.Categories)
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
    }

    class Collector
    {
        public static Dictionary<string, string> Categories = new()
        {
            ["Продажа офисов"] = BaseCategories.OFFICE_SALE,
            ["Аренда офисов"] = BaseCategories.OFFICE_RENT,
            ["Продажа гаражей"] = BaseCategories.GARAGE_SALE,
            ["Аренда гаражей"] = BaseCategories.GARAGE_RENT,
            ["Продажа складов"] = BaseCategories.WAREHOUSE_SALE,
            ["Аренда складов"] = BaseCategories.WAREHOUSE_RENT,
            ["Продажа торговых площадей"] = BaseCategories.TRADE_AREA_SALE,
            ["Аренда торговых площадей"] = BaseCategories.TRADE_AREA_RENT,
            ["Продажа ПСН."] = BaseCategories.VACANT_PERM_SALE,
            ["Аренда ПСН."] = BaseCategories.VACANT_PERM_RENT,
            ["Продажа земли"] = BaseCategories.LAND_SALE,
            ["Аренда земли"] = BaseCategories.LAND_RENT,
        };

        public static Dictionary<string, string> ClassesPerm = new()
        {
            ["A+"] = "&building_class_type%5B0%5D=2",
            ["A"] = "&building_class_type%5B0%5D=1",
            ["B+"] = "&building_class_type%5B0%5D=4",
            ["B"] = "&building_class_type%5B0%5D=3",
            ["B-"] = "&building_class_type%5B0%5D=8",
            ["C"] = "&building_class_type%5B0%5D=5",
        };

        public string ActiveCategory = null;
        List<string> PermClasses = new();

        public string ConstructURL()
        {
            string resultString = ".........................";
            
            if (
                ActiveCategory != null && Categories.ContainsKey(ActiveCategory) &&
                PermClasses.Count > 0
                )
            {
                resultString = $"{Categories[ActiveCategory]}";
            }
            
            return resultString;
        }
    }
}
