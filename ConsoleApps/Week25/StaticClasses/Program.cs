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

    public  class TestNoneStaticClass
    {
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

        public Customer()
        {
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
}
