using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaywrightExtraSharp;
using Microsoft.Playwright;
using System.Windows.Forms;

namespace realEstateScraperCsharp.Modules
{
    // Интерфейс
    interface ICompleteFieldsRead
    {
        void ReadByCompleteFields(CompleteFields fields);
    }

    //| Модель "Карточка Офис"
    internal class OfficeCardModel: ICompleteFieldsRead
    {
        public GeneralFields General { get; set; }
        public OfficeFields Office { get; set; }

        // Инициализирует поля, включенные в карточку
        public void ReadByCompleteFields(CompleteFields fields)
        {
            this.General = new GeneralFields(fields);
            this.Office = new OfficeFields(fields);
        }

        public OfficeCardModel(GeneralFields general)
        {
            this.General = new GeneralFields(general);
        }
        public OfficeCardModel(OfficeFields office)
        {
            this.Office = new OfficeFields(office);
        }
        public OfficeCardModel(GeneralFields general, OfficeFields office)
        {
            this.General = new GeneralFields(general);
            this.Office = new OfficeFields(office);
        }
    }

    //| Модель "Карточка Гараж"
    internal class GarageCardModel: ICompleteFieldsRead
    {
        public GeneralFields General { get; set; }
        public GarageFields Garage { get; set; }

        // Инициализирует поля, включенные в карточку
        public void ReadByCompleteFields(CompleteFields fields)
        {
            this.General = new GeneralFields(fields);
            this.Garage = new GarageFields(fields);
        }

        //| ...........................................
        public GarageCardModel(GeneralFields general)
        {
            this.General = new GeneralFields(general);
        }
        public GarageCardModel(GarageFields garage)
        {
            this.Garage = new GarageFields(garage);
        }
        public GarageCardModel(GeneralFields general, GarageFields garage)
        {
            this.General = new GeneralFields(general);
            this.Garage = new GarageFields(garage);
        }
    }

    //| Модель "Карточка Земля"
    internal class LandCardModel: ICompleteFieldsRead
    {
        public GeneralFields General { get; set; }
        public LandFields Land { get; set; }

        // Инициализирует поля, включенные в карточку
        public void ReadByCompleteFields(CompleteFields fields)
        {
            this.General = new GeneralFields(fields);
            this.Land = new LandFields(fields);
        }
        public LandCardModel(GeneralFields general)
        {
            this.General = new GeneralFields(general);
        }
        public LandCardModel(CompleteFields completeFields)
        {
            this.General = new GeneralFields(completeFields);
            this.Land = new LandFields(completeFields);
        }
        public LandCardModel(LandFields land)
        {
            this.Land = new LandFields(land);
        }
        public LandCardModel(GeneralFields general, LandFields land)
        {
            this.General = new GeneralFields(general);
            this.Land = new LandFields(land);
        }
    }
}
