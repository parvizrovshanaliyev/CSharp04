namespace OOP.Destructors
{
    class FileHandler
    {
        private string _filePath;

        // Constructor to initialize the file path
        public FileHandler(string path)
        {
            _filePath = path;
            Console.WriteLine($"FileHandler created for {_filePath}");
        }

        // Destructor to clean up resources
        ~FileHandler()
        {
            Console.WriteLine($"Destructor called. Cleaning up {_filePath}");
            // Simulate releasing unmanaged resources
        }

        public void ProcessFile()
        {
            Console.WriteLine($"Processing file: {_filePath}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Destructor Demonstration ===");

            // Create an object of FileHandler
            FileHandler handler = new FileHandler("example.txt");
            handler.ProcessFile();

            Console.WriteLine("Program is ending...");
        }
    }
}
