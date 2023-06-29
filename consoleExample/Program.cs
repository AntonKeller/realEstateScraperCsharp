using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
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


public class Ex1
{
    public string A { get; set; }
    public int B { get; set; }
    public Ex1(string a, int b)
    {
        this.A = a; this.B = b;
    }
    public Ex1(Ex1 e)
    {
        this.A = e.A; 
        this.B = e.B;
    }
}
public class Ex2
{
    public string C { get; set; }
    public int D { get; set; }
    public Ex2(string c, int d)
    {
        this.C = c; this.D = d;
    }
    public Ex2(Ex2 e)
    {
        this.C = e.C;
        this.D = e.D;
    }
}

class All
{
    public Ex1 ex1 { get; set; }
    public Ex2 ex2 { get; set; }
    public All(Ex1 e1, Ex2 e2)
    {
        this.ex1 = new Ex1(e1);
        this.ex2 = new Ex2(e2);
    }
}

interface ITranslateAll
{
    void Translate(All allFields);
}

class Model1 : ITranslateAll
{
    public string A { get; set; }
    public int D { get; set; }
    public void Translate(All allFields)
    {
        this.A = allFields.ex1.A;
        this.D = allFields.ex2.D;
    }
}



class Human
{
    protected int height;
    protected int weight;
}

class CMan : Human
{
    private string FirstName;
    private string LastName;
}

class CWoman : Human
{
    private string FirstName;
    private string LastName;
}

class Printer
{
    public void Print(Human human)
    {
        Console.WriteLine(human);
    }
}

class Dog
{
    public int Age { get; set; }
    public string Name { get; set; }
    public bool IsHungry { get; set; }
    public Dog(int age = 0, string name = "Бобик", bool isHungry = false)
    {
        Age = age;
        Name = name;
        IsHungry = isHungry;
    }
}

class ManMan
{
    public int Age { get; set; }
    public bool IsHungry { get; set; }
    public void PrintName()
    {
        Console.WriteLine("");
    }
}


class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("start");
        //Dog bobik = new Dog();
        //ManMan manMan = new ManMan();

        //CopyData(manMan, bobik);

        //foreach (FieldInfo field in bobik.GetType().GetFields())
        //{
        //    Console.WriteLine($"Field type: {field.FieldType} |Field name: {field.Name}");
        //    Console.WriteLine($"Get property: {bobik.GetType().GetProperty(field.Name)}");
        //}
        //Console.WriteLine("");

        //var woman = new CWoman();
        //var man = new CMan();


        //IDataProcessor dataProcessor = new ConsoleDataProcessor();

        //var IDataProvider_1 = new DBDataProvider();
        //var IDataProvider_2 = new APIDataProvider();

        //dataProcessor.PrintData(IDataProvider_1);
        //dataProcessor.PrintData(IDataProvider_2);
        //Console.WriteLine("");

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

    static void CopyData(object source, object destination)
    {
        Type sourceType = source.GetType();
        Type destinationType = destination.GetType();

        PropertyInfo[] sourceProperties = sourceType.GetProperties();
        PropertyInfo[] destinationProperties = destinationType.GetProperties();

        foreach (PropertyInfo sourceProperty in sourceProperties)
        {
            foreach (PropertyInfo destinationProperty in destinationProperties)
            {
                if (sourceProperty.Name == destinationProperty.Name && sourceProperty.PropertyType == destinationProperty.PropertyType)
                {
                    object value = sourceProperty.GetValue(source);
                    destinationProperty.SetValue(destination, value);
                    break;
                }
            }
        }
    }
}

