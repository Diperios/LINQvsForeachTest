using System.Diagnostics;

public class Program
{
    public class Employee
    {
        public int id;
        public string name;
        public string lastname;
        public DateTime dateOfBirth;

        public Employee(int id, string name, string lastname, DateTime dateOfBirth)
        {
            this.id = id;
            this.name = name;
            this.lastname = lastname;
            this.dateOfBirth = dateOfBirth;

        }
    }

    public static void Main()
    {

        Console.WriteLine("Int Test1:");
        StartIntTest(100_000_000);

        Console.WriteLine("Int Test2:");
        StartIntTest(1_000_000_000);

        Console.WriteLine("Object Test:");
        StartObjTest(10_000_000);

        Console.WriteLine("Summation Test1:");
        StartSumTest(100_000_000);

        Console.WriteLine("Summation Test2:");
        StartSumTest(1_000_000_000);
    }



    #region int test

    public static void StartIntTest(int len)
    {

        List<int> items = new List<int>();

        for (int i = 0; i < len; i++)
        {
            items.Add(i);
        }

        Test1(items, items.Count - 100);
        Test2(items, items.Count - 100);

        //Console.Read();
    }

    public static void Test1(List<int> items, int itemToCheck)
    {

        Console.WriteLine("\tForeach Test-");
        Stopwatch s = new Stopwatch();
        s.Start();

        bool exists = false;
        foreach (var item in items)
        {
            if (item == itemToCheck)
            {
                exists = true;
                break;
            }
        }

        Console.WriteLine("\t\tExists=" + exists);
        Console.WriteLine("\t\tTime=" + s.ElapsedMilliseconds + "ms");

    }

    public static void Test2(List<int> items, int itemToCheck)
    {

        Console.WriteLine("\tLINQ Test-");

        Stopwatch s = new Stopwatch();
        s.Start();

        bool exists = items.Contains(itemToCheck);

        Console.WriteLine("\t\tExists=" + exists);
        Console.WriteLine("\t\tTime=" + s.ElapsedMilliseconds + "ms");

    }

    #endregion



    #region object test

    public static void StartObjTest(int len)
    {

        List<Employee> items = new List<Employee>();

        for (int i = 0; i < len; i++)
        {
            items.Add(new Employee(i, "name" + i, "lastname" + i, DateTime.Today));
        }

        Test3(items, items.Count - 100);
        Test4(items, items.Count - 100);

        //Console.Read();
    }


    public static void Test3(List<Employee> items, int idToCheck)
    {

        Console.WriteLine("\tForeach Test");
        Stopwatch s = new Stopwatch();
        s.Start();

        bool exists = false;
        foreach (var item in items)
        {
            if (item.id == idToCheck)
            {
                exists = true;
                break;
            }
        }

        s.Stop();

        Console.WriteLine("\t\tExists=" + exists);
        Console.WriteLine("\t\tTime=" + s.ElapsedMilliseconds + "ms");

    }

    public static void Test4(List<Employee> items, int idToCheck)
    {

        Console.WriteLine("\tLINQ Test");
        Stopwatch s = new Stopwatch();

        s.Start();

        bool exists = items.Exists(e => e.id == idToCheck);

        s.Stop();

        Console.WriteLine("\t\tExists=" + exists);
        Console.WriteLine("\t\tTime=" + s.ElapsedMilliseconds + "ms");

    }

    #endregion



    #region Sum Test

    public static void StartSumTest(int len)
    {

        List<long> items = new List<long>();

        for (long i = 0; i < len; i++)
        {
            items.Add(i);
        }

        Test5(items);
        Test6(items);

    }

    public static void Test5(List<long> items)
    {

        Console.WriteLine("\tForeach Sum Test-");
        Stopwatch s = new Stopwatch();

        s.Start();

        long sum = 0;
        foreach(var item in items)
        {
            sum += item;
        }

        s.Stop();

        Console.WriteLine("\t\tSum=" + sum);
        Console.WriteLine("\t\tTime=" + s.ElapsedMilliseconds + "ms");
    }

    public static void Test6(List<long> items)
    {

        Console.WriteLine("\tLINQ Sum Test-");
        Stopwatch s = new Stopwatch();

        s.Start();

        long sum = 0;
        sum = items.Sum();

        s.Stop();
        
        Console.WriteLine("\t\tSum=" + sum);
        Console.WriteLine("\t\tTime=" + s.ElapsedMilliseconds + "ms");
    }


    #endregion



}