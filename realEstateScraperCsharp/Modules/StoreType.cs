using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace realEstateScraperCsharp.Modules
{

    class XMLProcessor<T>
    {
        public T Read(string path)
        {
            using (FileStream fstream = System.IO.File.OpenRead(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                //T newCoordinates = (T)serializer.Deserialize(fstream);
                return (T)serializer.Deserialize(fstream);
            }
        }
        public void Write(string path, T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, obj);
            writer.Close();
        }
    }


    class StaticMethods
    {
        async public static Task<string> LoadFile(string path)
        {
            using (FileStream fstream = System.IO.File.OpenRead(path))
            {
                byte[] buffer = new byte[fstream.Length];
                await fstream.ReadAsync(buffer, 0, buffer.Length);
                return Encoding.Default.GetString(buffer);
            }
        }

        async public static Task SaveFile(string path, object data)
        {
            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.Default.GetBytes(JsonConvert.SerializeObject(data));
                await fstream.WriteAsync(buffer, 0, buffer.Length);
            }
        }
    }

   
    /* Объект ссылка на страницу предложений */
    public class PageLink
    {
        public string URL;
        public int? OfferCount;
        public bool? Loaded;


        public PageLink() { }

        [JsonConstructor]
        public PageLink(string URL, int? OfferCount, bool? Loaded)
        {
            this.URL = URL;
            this.OfferCount = OfferCount;
            this.Loaded = Loaded;
        }

        // Конструктор 1
        public PageLink(string url, bool? loaded = false, int? offerCount = null)
        {
            this.URL = url;
            this.OfferCount = offerCount;
            this.Loaded = loaded;
        }
        
        // Конструктор 2
        public PageLink(PageLink self)
        {
            this.URL = self.URL;
            this.OfferCount = self.OfferCount;
            this.Loaded = self.Loaded;
        }
    }


    /* Объект: Project Хранит информацию о проекте */
    class MyProject
    {
        private Dictionary<string, AnyListLoger> ProjectListLogerList = new(); // Словарь логеров
        public string _Name;      // Наименование текущего проекта
        public string MainFolder; // Директория текущего проекта
        string ImagesFolder;      // Директория со скриншотами (images)
        string ResultFolder;      // Директория Хранения Результата (results) (.xlsx Files)
        string LinkListPath;      // Файл буффера данных (linkList.json)
        string BufferPath;        // Файл буффера данных (buffer.json)
        bool DataModified;        // Флаг модификации данных
        List<PageLink> FileLinkList;         // Список файлов с ссылками
        List<CompleteFields> FileBufferData; // Список файлов карточек

        // Инициализация объекта "Project"
        public MyProject(string projectName, string path)
        {
            // Инициализируем маршрут проекта
            this._Name = projectName;
            this.MainFolder = path;
            this.ImagesFolder = Path.Combine(this.MainFolder, "images");
            this.ResultFolder = Path.Combine(this.MainFolder, "results");
            this.LinkListPath = Path.Combine(this.MainFolder, "linkList.xml");
            this.BufferPath = Path.Combine(this.MainFolder, "buffer.xml");
        }


        // Инициализация папок и файлов объекта "Project"
        //public async Task Initialize()
        public void Initialize()
        {
            // Создаем директории при их отсутствии
            if (!Directory.Exists(this.ImagesFolder)) Directory.CreateDirectory(this.ImagesFolder);
            if (!Directory.Exists(this.ResultFolder)) Directory.CreateDirectory(this.ResultFolder);

            // 1. Загружаем имеющийся или создаем новый буффер ссылок
            if (System.IO.File.Exists(this.LinkListPath))
            {
                //var fileStrBuff = await StaticMethods.LoadFile(this.LinkListPath);
                //var json = JsonConvert.DeserializeObject<List<PageLink>>(fileStrBuff);
                //if (json != null) this.FileLinkList = json;
                //else this.FileLinkList = new();

                XMLProcessor<List<PageLink>> processor = new();
                var fromXml = processor.Read(this.LinkListPath);
                if (fromXml != null) this.FileLinkList = fromXml;
                else this.FileLinkList = new();
            }
            else this.FileLinkList = new();


            // 2. Загружаем имеющийся или создаем новый буффер данных
            if (System.IO.File.Exists(this.BufferPath))
            {
                //var fileStrBuff = await StaticMethods.LoadFile(this.BufferPath);
                //var json = JsonConvert.DeserializeObject<List<CompleteFields>>(fileStrBuff);
                //if (json != null) this.FileBufferData = json;
                //else this.FileBufferData = new();

                XMLProcessor<List<CompleteFields>> processor = new();
                var fromXml = processor.Read(this.BufferPath);
                if (fromXml != null) this.FileBufferData = fromXml;
                else this.FileBufferData = new();

            } 
            else this.FileBufferData = new();
        }


        // Читает список файлов "Images" из папки (Формат png|jpeg)
        public List<string> GetImagesList()
        {
            List<string> bList = new();
            DirFilesToList(this.ImagesFolder, bList);
            return bList;
        }


        // Читает список файлов "Results" из папки (Формат xlsx)
        public List <string> GetXLSXResultFileList()
        {
            List<string> bList = new();
            DirFilesToList(this.ResultFolder, bList);
            return bList;
        }


        // Получает список файлов с ссылками
        public List<PageLink> GetLinkListData() => this.FileLinkList;


        // Получает список файлов с загруженными данными проекта
        public List<CompleteFields> GetBufferData() => this.FileBufferData;


        // Добавляет ссылку в список и сохраняет.
        public void AddLink(PageLink exLinkData)
        {
            this.FileLinkList.Add(exLinkData);
            this.DataModified = true;
        }


        // Добавляет карточку в список, сохраняет.
        public void AddCard(CompleteFields cCard)
        {
            this.FileBufferData.Add(cCard);
            this.DataModified = true;
        }


        // Сохраняет буффер ссылок
        //public async Task SaveLinkListData()
        public void SaveLinkListData()
        {
            //await StaticMethods.SaveFile(this.LinkListPath, this.FileLinkList);
            XMLProcessor<List<PageLink>> processor = new();
            processor.Write(this.LinkListPath, this.FileLinkList);

        }


        // Сохраняет буффер данных
        //public async Task SaveBufferData()
        public void SaveBufferData()
        {
            //await StaticMethods.SaveFile(this.BufferPath, this.FileBufferData);
            XMLProcessor<List<CompleteFields>> processor = new();
            processor.Write(this.BufferPath, this.FileBufferData);
        }

        // Получаем список файлов из папки
        private void DirFilesToList(string path, List<string> list)
        {
            foreach (var filePath in Directory.GetFiles(path))
            {
                list.Add(filePath);
            }
        }
    }


    // Логеры для Porject List Класса Store
    interface IListLoger
    {
        void SendList(List<string> projectNameList);
    }


    /*
        Объект содержит базовую информацию о папке с проектами, настройками.
        Методы:
            1. Загрузка списка проектов.
            2. Выгрузка файла конфигурации программы с настройками.
            3. Загрузка файла конфигурации программы с настройками.
    */
    internal class StoreType
    {
        private Dictionary<string, IListLoger> ProjectListLogerList = new();
        private string _Dir; // Рабочая директория
        private string DirProjects; // Директория с файлами настроек
        private Dictionary<string, MyProject> ProjectList; // Список проектов  словаре


        // Конструктор 1
        public StoreType()
        {
            this.ProjectList = new Dictionary<string, MyProject>();
            this._Dir = Directory.GetCurrentDirectory();
            this.DirProjects = Path.Combine(this._Dir, "projects");

            // Инициализация Store проектами
            InitializeProjects();
        }


        public void SetLogerProjectList(string logerName, IListLoger loger)
        {
            this.ProjectListLogerList.Add(logerName, loger);
            NotifySub();
        }


        private void NotifySub()
        {
            // Создаем список
            List<string> lst = new List<string>();

            // Записываем список проектов
            foreach (var dicProj in this.ProjectList)
            {
                lst.Add(dicProj.Value._Name);
            }

            // Отправляем подписчикам список с проектами
            foreach (var dicSub in this.ProjectListLogerList)
            {
                dicSub.Value.SendList(lst);
            }
        }


        public MyProject GetProjectByName(string projectName) => this.ProjectList[projectName];


        public List<string> GetProjectNameList()
        {// Считываем список проектов из словаря и возвращаем список имен проектов
            List<string> lst = new();
            foreach(var dicElProject in this.ProjectList)
            {
                lst.Add(dicElProject.Value._Name);
            }
            return lst;
        }


        //public async Task InitializeProject(string name)
        public void InitializeProject(string name)
        {
            if (this.ProjectList.ContainsKey(name))
            {
                this.ProjectList[name].Initialize();
            }
            else
            {
                throw new Exception($"Проект ({name}) отсутствует в программе");
            }
        }

        // Функция запускает метод DataLoad у проекта по наименованию.
        // Проекты сканируют свои папки и загружают необходимые им файлы
        private void InitializeProjects()
        {
            // Создаем директорию проектов при отсутствии
            if (!Directory.Exists(this.DirProjects))
            {
                Directory.CreateDirectory(this.DirProjects);
            }
            // Грузим список проектов и создаем объекты проектов
            else
            {
                foreach (string dirName in Directory.GetDirectories(this.DirProjects))
                {
                    AddProject(new DirectoryInfo(dirName).Name);
                }
            }
        }


        // Создаем объект -> Инициализируем -> Добавляем в список проектов
        public void AddProject(string projectName)
        {
            
            if (!this.ProjectList.ContainsKey(projectName))
            {
                var newProject = new MyProject(projectName, Path.Combine(this.DirProjects, projectName));
                //await newProject.Initialize();
                this.ProjectList.Add(projectName, newProject);
                NotifySub();
            }
            // Вызываем исключение при наличии указанного проекта в списке проектов
            else
            {
                new Exception($"Такое имя проекта: ({projectName}) уже зарегистрировано. Используйте другое!");
            }
        }


        // Очищаем файлы проекта -> удаляем проект из списка
        public void RemoveProject(string projectName)
        {
            if (this.ProjectList.ContainsKey(projectName))
            {
                Directory.Delete(this.ProjectList[projectName].MainFolder, true);
                this.ProjectList.Remove(projectName);
            }
            // Вызываем исключение при отсутствии указанного проекта в списке проектов
            else
            {
                throw new Exception($"Проект{projectName} отсутствует в программе!");
            }
        }
    }
}
