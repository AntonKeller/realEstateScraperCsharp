using System;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


enum ExcelFormats
{
    _timestamp = 1,   //| мс
    _date = 2,        //| дата от new Date
    _str =  3,        //| строка
    _number = 4,      //| целое число
    _numberX = 5,     //| вещественное число 2 зн. после запятой
    _hyper = 6,       //| гипер ссылка
}

public class CianIdField
{
    private string? value = null;
    private ExcelFormats format;
    private string? ru = null;

    public void setValue(dynamic offer)
    {
        this.value = offer?.cianId;
    }
}

class GeneralParser
{
    private CianIdField cianId;

}

public class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    public Employee(int iD, string name, string address)
    {
        this.ID = iD;
        this.Name = name;
        this.Address = address;
    }

    public static void PrintFull(Employee e)
    {
        Console.WriteLine($"ID: {e.ID}\tName: {e.Name}\tAddress: {e.Address}");
    }
    public string GetPrintLine()
    {
        return $"ID: {this.ID}\tName: {this.Name}\tAddress: {this.Address}";
    }
    public void PrintFull()
    {
        Console.WriteLine($"ID: {this.ID}\tName: {this.Name}\tAddress: {this.Address}");
    }
}

public class Man
{
    public Man(string name)
    {
        this.Name = name;
    }
    public string Name { get; set; }
    public void Go(Car car)
    {
        Console.Write(this.Name + " уехал на ");
        car.Start();
    }
}

public class Car
{
    protected Car(string name)
    {
        this.Name=name;
    }
    public string Name { get; set; }
    public virtual void Start()
    {
        Console.WriteLine(this.Name + "\twrum wrum...");
    }

}

public class FerraryCar: Car
{
    public FerraryCar(string name):base(name) {}
    public override void Start()
    {
        Console.WriteLine(this.Name + "\tYeeeeeeeaaaxxxuuu...");
    }
}

public class TayotaCar : Car
{
    public TayotaCar(string name) : base(name) { }
 
}

public abstract class Weapon
{
    public abstract void Fire();
}

public class AK47 : Weapon
{
    public override void Fire()
    {
        Console.WriteLine("Стреляет из АК47");
    }
}

public class M4A1 : Weapon
{
    public override void Fire()
    {
        Console.WriteLine("Стреляет из M4A1");
    }
}

public class User
{
    public User(string name)
    {
        this.Name = name;
    }
    private string Name;
    public void Fire(Weapon weapon)
    {
        Console.Write(this.Name);
        weapon.Fire();
    }
}

interface IDataProvider
{
    string GetData();
}

interface IDataProcessor
{
    void PrintData(IDataProvider dataProvider);
}

class ConsoleDataProcessor : IDataProcessor
{
    public void PrintData(IDataProvider dataProvider)
    {
        Console.WriteLine(dataProvider.GetData());
    }
}


class DBDataProvider : IDataProvider
{
    public string GetData()
    {
        return "Данные из базы данных";
    }
}

class APIDataProvider : IDataProvider
{
    public string GetData()
    {
        return "Данные из циан api";
    }
}

class Program
{
    static void Main(string[] args)
    {

        IDataProcessor dataProcessor = new ConsoleDataProcessor();
        
        var IDataProvider_1 = new DBDataProvider();
        var IDataProvider_2 = new APIDataProvider();

        dataProcessor.PrintData(IDataProvider_1);
        dataProcessor.PrintData(IDataProvider_2);
        Console.WriteLine("");

        //var ak47 = new AK47();
        //var m4a1 = new M4A1();
        //// ...........

        //var user = new User("Иван\t");

        //user.Fire(m4a1);
        //user.Fire(ak47);
        //Console.WriteLine("");




        //var ferrary = new FerraryCar("Ferrary 814");
        //var tayota = new TayotaCar("Tayota Camry");
        //var man = new Man("Иван");
        //man.Go(tayota);
        //man.Go(ferrary);
        //Console.WriteLine("");

        //Employee[] arr =
        //{
        //    new Employee(123456781, "Ivan", "Полярная 12/7"),
        //    new Employee(123456782, "Максим", "Полярная 12/7"),
        //    new Employee(123456783,"Олег","Пушкинская 3/2"),
        //    new Employee(123456782, "Максим", "Полярная 12/7"),
        //};

        //Dictionary<int, Employee> dictEmployees = new Dictionary<int, Employee>();

        //foreach (var e in arr)
        //{
        //    if (!dictEmployees.ContainsKey(e.ID))
        //    {
        //        dictEmployees.Add(e.ID, e);
        //    }
        //}

        //foreach (var e in dictEmployees)
        //{
        //    Console.WriteLine($"key: {e.Key}  value: ({e.Value.GetPrintLine()})");
        //}

        //string json = JsonConvert.SerializeObject(dictEmployees);
        //Dictionary<int, Employee> dictEmployees_2 = JsonConvert.DeserializeObject<Dictionary<int, Employee>>(json);

        //var employee = new Employee();
        //employee.ID = 1;
        //employee.Name = "Гараж";
        //employee.Address = "Полярная 7/1";
        //Console.WriteLine("employee 1 printing:");
        //employee.PrintFull();
        //string json = JsonConvert.SerializeObject(employee);
        //Employee employee2 = JsonConvert.DeserializeObject<Employee>(json);
        //Console.WriteLine("employee 2 printing:");
        //employee2?.PrintFull();
        Console.WriteLine("");
    }
}

