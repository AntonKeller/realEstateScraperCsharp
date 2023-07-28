using Microsoft.Playwright;
using realEstateScraperCsharp.Modules.API;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace realEstateScraperCsharp.Modules
{
    interface ILogObserver
    {
        void Update(string txtMsg);
    }


    interface IObservable
    {
        void AddLogObserver(string key, ILogObserver observer);
        void RemoveLogObserver(string key);
        void Notify(string txtMsg);
    }

   
    interface IGenerator
    {
        Task<List<PageLink>> Generate(IPage page);
    }



    /*Генератор призван по запросу сгенерировать URL список, 
    который будет отправлен в загрузчик предложений по этим ссылкам.
    .........................................................
    В конструкторе задаются:
        - Список базовых URL адресов. ( у которых нет параметров (кроме базовых: тип предложения, тип сделки и т.д) )
        - Некоторые ограничения ( Например класс помещений "А+ .. С" ).
    (Базовый URL -> ведет на первую страницу результата поиска по параметрам)
    .........................................................................
    Пример:
        Ссылка: https://www.cian.ru/cat.php?building_class_type%5B0%5D=3&deal_type=rent&engine_version=2&offer_type=offices&office_type%5B0%5D=2&region=1
        Параметры:
            -https://www.cian.ru/cat.php?
            -building_class_type%5B0%5D=3
            -&deal_type=rent
            -&engine_version=2
            -&offer_type=offices
            -&office_type%5B0%5D=2
            -&region=1
    .........................................................................
    ~ На текущем этапе нам не нужен парсер, посколько данный модуль ответственнен исключительно за генерацию URL по параметрам.
    */
    internal class CianUrlGenerator: IGenerator, IObservable
    {
        // Конфигурация | Фильтр
        private RealEstateConfig Config;
        
        // Финальный список ссылок, по которым можно выгружать
        private List<PageLink> FinalListUrl;
        
        // Подписанты на лог генератора
        private Dictionary<string, ILogObserver> Observers;

        // Оповестить наблюдателей журнала
        public void Notify(string txtMsg)
        {
            foreach (var el in Observers) el.Value.Update(txtMsg);
        }

        // Добавить наблюдателя журнала
        public void AddLogObserver(string key, ILogObserver observer)
        {
            Observers.Add(key, observer);
        }

        // Удалить наблюдателя журнала
        public void RemoveLogObserver(string key)
        {
            if (Observers.ContainsKey(key)) Observers.Remove(key);
        }

        // Возвращает список сгененрированных URL
        public List<PageLink> GetListUrl() => new List<PageLink>(this.FinalListUrl);

        // Конструктор 1
        public CianUrlGenerator (RealEstateConfig config, Dictionary<string, ILogObserver> observers = null)
        {
            this.Config = new RealEstateConfig(config);
            this.Observers = new Dictionary<string, ILogObserver>(observers);
            this.FinalListUrl = new List<PageLink>();
        }

        // Функция генерации -> Список ссылок
        public async Task<List<PageLink>> Generate(IPage page)
        {
            // Исключения
            if (page == null) Notify("Ошибка генерации ссылок. page == null");
            if (this.Config == null) Notify("Ошибка генерации ссылок. config == null");

            // Инициализация ограничений площади помещения и площади земли
            Notify("Инициализация...");
            var permAreaMin = Config.PermAreaMin != null ? $"&minarea={Config.PermAreaMin}" : "";
            var permAreaMax = Config.PermAreaMax != null ? $"&minarea={Config.PermAreaMax}" : "";
            var landAreaMin = Config.LandAreaMin != null ? $"&minarea={Config.LandAreaMin}" : "";
            var landAreaMax = Config.LandAreaMax != null ? $"&minarea={Config.LandAreaMax}" : "";

            // Инициализация location
            string location = "";
            location = Config.CityID != null ? $"{location}&region={Config.CityID}" : location;
            location = Config.RegionID != null && Config.RegionID == null ? $"{location}&region={Config.RegionID}" : location;
            location = Config.DistrictID != null ? $"{location}&district={Config.DistrictID}" : location;

            // Проверяем наличие фильтра классов помещений
            // 1 класс (пустой) должен быть в случае отсутствия других
            if (Config.PermClasses.Count > 0)
            {
                var maxCount = Config.PermClasses.Count;

                // Загружаем
                for (var i = 0; i < maxCount; i++)
                {
                    Notify($"Генерация... {i+1}|{maxCount}");
                    var pClass = Config.PermClasses[i];
                    var f = $"{Config.Category}{pClass}{permAreaMin}{permAreaMax}{landAreaMin}{landAreaMax}{location}";
                    List<PageLink> linkListGen = await CianAPI.PageLinksGenerator(page, f);
                    foreach(var item in linkListGen)
                    {
                        FinalListUrl.Add(item);
                    }
                }
            }

            // Возврат
            return this.FinalListUrl;
        }
    }
}
