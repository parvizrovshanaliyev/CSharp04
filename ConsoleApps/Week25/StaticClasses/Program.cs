namespace StaticClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            TestNoneStaticClass testNoneStaticClass = new TestNoneStaticClass();
            testNoneStaticClass.Test();

            TestStaticClass.Test();

            CommonTask.IsEmpty("Test");
            CommonTask.GetComputerName();


            Console.WriteLine($"Application 1 ID: {UniqueIDGenerator.AppID}");
            Console.WriteLine($"Application 2 ID: {UniqueIDGenerator.AppID}");


            Sample obj1 = new Sample(10);
            Sample obj2 = new Sample(20);
        }
    }

    public static class TestStaticClass
    {
        public static int _number = 10;

        public static void Test()
        {
            Console.WriteLine(_number);
        }
    }

    public class TestNoneStaticClass
    {
        public TestNoneStaticClass()
        {
            Console.WriteLine("None Static Constructor Called!");
        }

        static TestNoneStaticClass()
        {
            Console.WriteLine("Static Constructor Called!");
        }

        public int _number = 10;


        public void Test()
        {
            Console.WriteLine(_number);
        }
    }

    public static class CommonTask
    {

        static CommonTask()
        {
            //Constructor
            Console.WriteLine("Static Constructor Called!");
        }

        public static bool IsEmpty(string value)
        {
            if (value.Length > 0)
            {
                return true;
            }
            return false;
        }
        public static string GetComputerName()
        {
            return System.Environment.MachineName;
        }
    }

    public class Customer
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        private string MachineName = "";

        public Customer(string customerCode)
        {
            CustomerCode = customerCode;
            MachineName = CommonTask.GetComputerName();
        }

        static Customer()
        {
            //Constructor
        }

        public void Insert()
        {
            if (!CommonTask.IsEmpty(CustomerCode) && !CommonTask.IsEmpty(CustomerName))
            {
                //Insert the data
            }
        }

        public static void Display()
        {
            //Display the data
        }
    }

    public class CountryMaster
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        private string ComputerName
        {
            get
            {
                return CommonTask.GetComputerName();
            }
        }
        public void Insert()
        {
            if (!CommonTask.IsEmpty(CountryCode) && !CommonTask.IsEmpty(CountryName))
            {
                //Insert the data
            }
        }
    }

    class UniqueIDGenerator
    {
        public static Guid AppID;

        static UniqueIDGenerator()
        {
            Console.WriteLine("Generating Unique Application ID...");
            AppID = Guid.NewGuid();
        }
    }


    class Sample
    {
        public static int StaticValue;
        public int InstanceValue;

        public const int ConstValue = 10;

        static Sample() // Static Constructor
        {
            Console.WriteLine("Static Constructor Called!");
            StaticValue = 100;
        }

        public Sample(int value) // Instance Constructor
        {
            Console.WriteLine("Instance Constructor Called!");
            InstanceValue = value;
        }
    }
}
