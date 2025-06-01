using System;
using Practice.Services;
using Practice.Enums;

namespace Practice
{
    /// <summary>
    /// Main program class that demonstrates the usage of the print queue system.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main entry point of the application.
        /// </summary>
        static void Main(string[] args)
        {
            var printQueueService = new PrintQueueService();
            var uiService = new PrintQueueUIService(printQueueService);

            while (true)
            {
                uiService.DisplayMenu();
                if (int.TryParse(Console.ReadLine(), out int choice) && Enum.IsDefined(typeof(MenuOption), choice))
                {
                    uiService.HandleUserChoice((MenuOption)choice);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }
    }
}
