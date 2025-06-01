using System;
using Practice.Constants;
using Practice.Enums;
using Practice.Models;
using Practice.Services;

namespace Practice.Services
{
    /// <summary>
    /// Handles the user interface and interaction for the Print Job Management System.
    /// This class is responsible for displaying information to the user and processing user input.
    /// </summary>
    public class PrintQueueUIService
    {
        private readonly IPrintQueueService _printQueueService;

        /// <summary>
        /// Initializes a new instance of the PrintQueueUIService.
        /// </summary>
        /// <param name="printQueueService">The print queue service to use for operations.</param>
        public PrintQueueUIService(IPrintQueueService printQueueService)
        {
            _printQueueService = printQueueService;
        }

        /// <summary>
        /// Displays the main menu of the application.
        /// </summary>
        public void DisplayMenu()
        {
            Console.WriteLine($"\n{PrintQueueConstants.MENU_TITLE}");
            Console.WriteLine($"1. Add new print job (Max {PrintQueueConstants.MAX_PRINT_TIME} minutes)");
            Console.WriteLine("2. Process next print job");
            Console.WriteLine("3. View all pending jobs");
            Console.WriteLine("4. Show estimated wait time");
            Console.WriteLine("5. Clear print queue");
            Console.WriteLine("6. Save and exit");
            Console.Write("Enter your choice: ");
        }

        /// <summary>
        /// Processes the user's menu choice and performs the corresponding action.
        /// </summary>
        /// <param name="choice">The user's menu choice.</param>
        public void HandleUserChoice(MenuOption choice)
        {
            try
            {
                switch (choice)
                {
                    case MenuOption.AddJob:
                        AddNewPrintJob();
                        break;
                    case MenuOption.ProcessNextJob:
                        ProcessNextJob();
                        break;
                    case MenuOption.ViewAllJobs:
                        ViewAllJobs();
                        break;
                    case MenuOption.ShowWaitTime:
                        ShowWaitTime();
                        break;
                    case MenuOption.ClearQueue:
                        ClearQueue();
                        break;
                    case MenuOption.SaveAndExit:
                        SaveAndExit();
                        break;
                    default:
                        Console.WriteLine(PrintQueueConstants.MSG_INVALID_CHOICE);
                        break;
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"{PrintQueueConstants.ERROR_PREFIX} {ex.Message}");
            }
            catch (InvalidCastException)
            {
                Console.WriteLine(PrintQueueConstants.MSG_QUEUE_CORRUPTED);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{PrintQueueConstants.ERROR_PREFIX} {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Handles the process of adding a new print job.
        /// Prompts the user for job details and adds the job to the queue.
        /// </summary>
        private void AddNewPrintJob()
        {
            Console.Write("\nEnter job name: ");
            string name = Console.ReadLine();

            Console.Write($"Enter estimated print time ({PrintQueueConstants.MIN_PRINT_TIME}-{PrintQueueConstants.MAX_PRINT_TIME} minutes): ");
            if (!int.TryParse(Console.ReadLine(), out int printTime) ||
                printTime < PrintQueueConstants.MIN_PRINT_TIME ||
                printTime > PrintQueueConstants.MAX_PRINT_TIME)
            {
                throw new ArgumentException(PrintQueueConstants.MSG_INVALID_PRINT_TIME);
            }

            var job = new PrintJob(name, printTime);
            _printQueueService.AddJob(job);
            Console.WriteLine($"{PrintQueueConstants.SUCCESS_PREFIX} {PrintQueueConstants.MSG_JOB_ADDED}");
        }

        /// <summary>
        /// Processes the next job in the queue.
        /// </summary>
        private void ProcessNextJob()
        {
            try
            {
                var job = _printQueueService.ProcessNextJob();
                Console.WriteLine($"\nProcessing: {job}");
                Console.WriteLine($"{PrintQueueConstants.SUCCESS_PREFIX} {PrintQueueConstants.MSG_JOB_COMPLETED}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"\n{PrintQueueConstants.ERROR_PREFIX} {PrintQueueConstants.MSG_NO_JOBS}");
            }
        }

        /// <summary>
        /// Displays all jobs currently in the queue.
        /// </summary>
        private void ViewAllJobs()
        {
            var jobs = _printQueueService.GetAllJobs();
            Console.WriteLine("\nPending Print Jobs:");

            int index = 1;
            foreach (var job in jobs)
            {
                Console.WriteLine($"{index}. {job}");
                index++;
            }

            if (index == 1)
            {
                Console.WriteLine(PrintQueueConstants.MSG_NO_JOBS);
            }
        }

        /// <summary>
        /// Displays the estimated wait time for all jobs in the queue.
        /// </summary>
        private void ShowWaitTime()
        {
            int waitTime = _printQueueService.GetEstimatedWaitTime();
            Console.WriteLine($"\nEstimated wait time: {waitTime} minutes");
        }

        /// <summary>
        /// Clears all jobs from the queue.
        /// </summary>
        private void ClearQueue()
        {
            _printQueueService.ClearQueue();
            Console.WriteLine($"\n{PrintQueueConstants.SUCCESS_PREFIX} {PrintQueueConstants.MSG_QUEUE_CLEARED}");
        }

        /// <summary>
        /// Saves the current queue state and exits the application.
        /// </summary>
        private void SaveAndExit()
        {
            _printQueueService.SaveQueue();
            Console.WriteLine($"\n{PrintQueueConstants.INFO_PREFIX} {PrintQueueConstants.MSG_CHANGES_SAVED}");
            Environment.Exit(0);
        }
    }
}