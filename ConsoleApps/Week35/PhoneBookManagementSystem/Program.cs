using PhoneBookManagementSystem.Interfaces;
using PhoneBookManagementSystem.Services;
using PhoneBookManagementSystem.Constants;

namespace PhoneBookManagementSystem
{
    /// <summary>
    /// Main entry point for the Phone Book Management System application.
    /// This class is responsible for setting up dependency injection,
    /// initializing the application, and handling fatal errors.
    /// 
    /// The application follows the Dependency Inversion Principle by
    /// depending on abstractions (interfaces) rather than concrete implementations.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// This method sets up the application's dependency injection,
        /// initializes the phone book service, and starts the application.
        /// </summary>
        /// <param name="args">Command line arguments (not used in this application).</param>
        /// <remarks>
        /// Application startup process:
        /// 1. Set up dependency injection with concrete implementations
        /// 2. Create the phone book service with all dependencies
        /// 3. Initialize the service (load existing contacts)
        /// 4. Run the main application loop
        /// 5. Handle any fatal errors gracefully
        /// 
        /// Dependency injection setup:
        /// - ContactValidator implements IValidator
        /// - PhoneBookRepository implements IPhoneBookRepository
        /// - ConsoleUserInterface implements IUserInterface
        /// - All dependencies are injected through constructors
        /// </remarks>
        static void Main(string[] args)
        {
            try
            {
                // Set up dependency injection (Simple DI pattern)
                // Create concrete implementations of all interfaces
                IValidator validator = new ContactValidator();
                IPhoneBookRepository repository = new PhoneBookRepository(validator);
                IUserInterface userInterface = new ConsoleUserInterface(validator);
                
                // Use centralized constant for file path
                string filePath = ApplicationConstants.DefaultFileName;
                
                // Create the phone book service with all dependencies injected
                var phoneBookService = new PhoneBookService(repository, userInterface, validator, filePath);
                
                // Initialize the application (load existing contacts from file)
                phoneBookService.Initialize();
                
                // Start the main application loop
                phoneBookService.Run();
            }
            catch (Exception ex)
            {
                // Handle any fatal errors that occur during application startup or execution
                // Display error message to user
                Console.WriteLine(string.Format(ApplicationConstants.FatalError, ex.Message));
                
                // Wait for user acknowledgment before exiting
                Console.WriteLine(ApplicationConstants.PressAnyKeyMessage);
                Console.ReadKey();
            }
        }
    }
}
