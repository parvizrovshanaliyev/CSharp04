using PhoneBookManagementSystem.Interfaces;
using PhoneBookManagementSystem.Models;
using PhoneBookManagementSystem.Constants;
using PhoneBookManagementSystem.Enums;

namespace PhoneBookManagementSystem.Services
{
    /// <summary>
    /// Provides console-based user interface implementation for the phone book management system.
    /// This class implements the IUserInterface interface and handles all user interactions
    /// through the console, including menu display, input collection, and message output.
    /// 
    /// The interface uses centralized constants for all user-facing text to ensure
    /// consistency and make localization easier in the future.
    /// </summary>
    public class ConsoleUserInterface : IUserInterface
    {
        /// <summary>
        /// The validator instance used for input validation.
        /// This dependency is injected through the constructor to follow
        /// the Dependency Inversion Principle.
        /// </summary>
        private readonly IValidator _validator;

        /// <summary>
        /// Initializes a new instance of the ConsoleUserInterface class.
        /// </summary>
        /// <param name="validator">The validator to use for input validation.</param>
        /// <exception cref="ArgumentNullException">Thrown when validator is null.</exception>
        public ConsoleUserInterface(IValidator validator)
        {
            // Validate dependency injection
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        /// <summary>
        /// Displays the main menu options to the user in a clear, numbered format.
        /// The menu is cleared before display to provide a clean interface.
        /// </summary>
        /// <remarks>
        /// Menu layout:
        /// - Application title at the top
        /// - Numbered options (1-6)
        /// - Input prompt at the bottom
        /// 
        /// All text is retrieved from ApplicationConstants for consistency.
        /// </remarks>
        public void DisplayMenu()
        {
            // Clear the console for a clean display
            Console.Clear();
            
            // Display the application title
            Console.WriteLine(ApplicationConstants.ApplicationTitle);
            
            // Display all menu options using centralized constants
            Console.WriteLine(ApplicationConstants.MenuOption1);
            Console.WriteLine(ApplicationConstants.MenuOption2);
            Console.WriteLine(ApplicationConstants.MenuOption3);
            Console.WriteLine(ApplicationConstants.MenuOption4);
            Console.WriteLine(ApplicationConstants.MenuOption5);
            Console.WriteLine(ApplicationConstants.MenuOption6);
            
            // Display the input prompt
            Console.Write(ApplicationConstants.EnterChoiceMessage);
        }

        /// <summary>
        /// Gets and validates the user's menu choice.
        /// This method handles invalid input gracefully by prompting for valid input.
        /// </summary>
        /// <returns>A valid menu option number (1-6) corresponding to MenuOption enum values.</returns>
        /// <remarks>
        /// Input validation process:
        /// 1. Read user input as string
        /// 2. Parse to integer
        /// 3. Validate range (1-6)
        /// 4. Display error and retry if invalid
        /// 5. Return valid choice when successful
        /// </remarks>
        public int GetUserChoice()
        {
            // Loop until valid input is received
            while (true)
            {
                // Try to parse the user input as an integer
                if (int.TryParse(Console.ReadLine(), out int choice) && 
                    choice >= (int)MenuOption.AddContact && 
                    choice <= (int)MenuOption.SaveAndExit)
                {
                    // Valid choice received, return it
                    return choice;
                }
                
                // Invalid input - display error and prompt again
                DisplayError(ApplicationConstants.InvalidChoiceError);
                Console.Write(ApplicationConstants.EnterChoiceMessage);
            }
        }

        /// <summary>
        /// Prompts the user to enter contact information and returns a new Contact object.
        /// This method collects all required contact fields in a user-friendly manner.
        /// </summary>
        /// <returns>A new Contact object with user-provided information.</returns>
        /// <remarks>
        /// Input collection process:
        /// 1. Prompt for contact name
        /// 2. Prompt for phone number
        /// 3. Prompt for email address
        /// 4. Prompt for physical address
        /// 5. Create and return Contact object
        /// 
        /// All prompts use centralized constants for consistency.
        /// </remarks>
        public Contact GetContactInput()
        {
            // Prompt for contact name
            Console.Write(ApplicationConstants.EnterNamePrompt);
            string name = Console.ReadLine() ?? string.Empty;

            // Prompt for phone number
            Console.Write(ApplicationConstants.EnterPhonePrompt);
            string phoneNumber = Console.ReadLine() ?? string.Empty;

            // Prompt for email address
            Console.Write(ApplicationConstants.EnterEmailPrompt);
            string email = Console.ReadLine() ?? string.Empty;

            // Prompt for physical address
            Console.Write(ApplicationConstants.EnterAddressPrompt);
            string address = Console.ReadLine() ?? string.Empty;

            // Create and return a new Contact object with the collected information
            return new Contact(name, phoneNumber, email, address);
        }

        /// <summary>
        /// Prompts the user to enter contact information with field-by-field validation.
        /// Each field is validated individually, and only invalid fields are re-requested.
        /// This provides a better user experience by preserving valid input.
        /// </summary>
        /// <param name="validator">The validator to use for field validation.</param>
        /// <returns>A new Contact object with validated user-provided information.</returns>
        /// <remarks>
        /// Field-by-field validation process:
        /// 1. Prompt for contact name and validate
        /// 2. If invalid, show error and re-prompt for name only
        /// 3. Prompt for phone number and validate
        /// 4. If invalid, show error and re-prompt for phone only
        /// 5. Continue for email and address
        /// 6. Create and return Contact object when all fields are valid
        /// 
        /// This approach preserves valid input and only re-requests invalid fields.
        /// </remarks>
        public Contact GetContactInputWithValidation(IValidator validator)
        {
            string name, phoneNumber, email, address;

            // Get and validate contact name
            name = GetValidatedField(ApplicationConstants.EnterNamePrompt, 
                                   validator.IsValidName, 
                                   ApplicationConstants.InvalidNameError);

            // Get and validate phone number
            phoneNumber = GetValidatedField(ApplicationConstants.EnterPhonePrompt, 
                                          validator.IsValidPhoneNumber, 
                                          ApplicationConstants.InvalidPhoneError);

            // Get and validate email address
            email = GetValidatedField(ApplicationConstants.EnterEmailPrompt, 
                                    validator.IsValidEmail, 
                                    ApplicationConstants.InvalidEmailError);

            // Get and validate physical address
            address = GetValidatedField(ApplicationConstants.EnterAddressPrompt, 
                                      validator.IsValidAddress, 
                                      ApplicationConstants.InvalidAddressError);

            // Create and return a new Contact object with all validated information
            return new Contact(name, phoneNumber, email, address);
        }

        /// <summary>
        /// Helper method to get and validate a single field with re-prompting on validation failure.
        /// This method ensures that only invalid fields are re-requested, preserving valid input.
        /// </summary>
        /// <param name="prompt">The prompt message to display to the user.</param>
        /// <param name="validationFunc">The validation function to apply to the input.</param>
        /// <param name="errorMessage">The error message to display if validation fails.</param>
        /// <returns>A validated field value.</returns>
        /// <remarks>
        /// Validation process:
        /// 1. Display the prompt message
        /// 2. Read user input
        /// 3. Apply validation function
        /// 4. If valid, return the value
        /// 5. If invalid, display error and repeat from step 1
        /// 
        /// This ensures that users only need to re-enter invalid fields.
        /// </remarks>
        private string GetValidatedField(string prompt, Func<string, bool> validationFunc, string errorMessage)
        {
            string input;
            
            // Loop until valid input is received
            while (true)
            {
                // Display the prompt and get user input
                Console.Write(prompt);
                input = Console.ReadLine() ?? string.Empty;
                
                // Apply validation function
                if (validationFunc(input))
                {
                    // Input is valid, return it
                    return input;
                }
                
                // Input is invalid, display error and continue loop
                DisplayError(errorMessage);
            }
        }

        /// <summary>
        /// Prompts the user to enter a contact name for search, update, or delete operations.
        /// </summary>
        /// <returns>The contact name entered by the user.</returns>
        /// <remarks>
        /// This method is used for:
        /// - Searching for contacts
        /// - Updating existing contacts
        /// - Deleting contacts
        /// 
        /// The prompt text is retrieved from ApplicationConstants.
        /// </remarks>
        public string GetContactName()
        {
            // Display the search prompt and return user input
            Console.Write(ApplicationConstants.SearchNamePrompt);
            return Console.ReadLine() ?? string.Empty;
        }

        /// <summary>
        /// Prompts the user to enter a contact name with validation.
        /// Re-prompts if the name is invalid until a valid name is provided.
        /// </summary>
        /// <param name="validator">The validator to use for name validation.</param>
        /// <returns>A validated contact name.</returns>
        /// <remarks>
        /// Validation process:
        /// 1. Display the search prompt
        /// 2. Read user input
        /// 3. Validate the name using the provided validator
        /// 4. If valid, return the name
        /// 5. If invalid, display error and repeat from step 1
        /// 
        /// This ensures that only valid names are accepted for search operations.
        /// </remarks>
        public string GetContactNameWithValidation(IValidator validator)
        {
            return GetValidatedField(ApplicationConstants.SearchNamePrompt, 
                                   validator.IsValidName, 
                                   ApplicationConstants.InvalidNameError);
        }

        /// <summary>
        /// Displays detailed information about a single contact in a formatted manner.
        /// </summary>
        /// <param name="contact">The contact to display.</param>
        /// <remarks>
        /// Display format:
        /// - "Found contact:" header
        /// - Contact details using Contact.ToString() method
        /// - Proper spacing for readability
        /// </remarks>
        public void DisplayContact(Contact contact)
        {
            // Display the header message
            Console.WriteLine(ApplicationConstants.FoundContactMessage);
            
            // Display the contact information using the Contact's ToString method
            Console.WriteLine(contact.ToString());
        }

        /// <summary>
        /// Displays all contacts in a formatted list with proper handling for empty arrays.
        /// </summary>
        /// <param name="contacts">The array of contacts to display.</param>
        /// <remarks>
        /// Display logic:
        /// - Show title for all contacts
        /// - Display "No contacts found" if array is empty
        /// - List all contacts with proper spacing
        /// - Each contact uses its ToString() method for formatting
        /// </remarks>
        public void DisplayAllContacts(Contact[] contacts)
        {
            // Display the title for all contacts
            Console.WriteLine(ApplicationConstants.AllContactsTitle);
            
            // Check if there are any contacts to display
            if (contacts == null || contacts.Length == 0)
            {
                // Display message for empty array
                Console.WriteLine(ApplicationConstants.NoContactsMessage);
                return;
            }

            // Display each contact in the array
            for (int i = 0; i < contacts.Length; i++)
            {
                Contact contact = contacts[i];
                
                // Use the Contact's ToString method for consistent formatting
                Console.WriteLine(contact.ToString());
                
                // Add spacing between contacts for better readability
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Displays a general message to the user.
        /// Used for success messages, informational text, and general feedback.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <remarks>
        /// Message formatting:
        /// - Adds a newline before the message
        /// - Displays the message as-is
        /// - Used for positive feedback and information
        /// </remarks>
        public void DisplayMessage(string message)
        {
            // Display the message with proper formatting
            Console.WriteLine($"\n{message}");
        }

        /// <summary>
        /// Displays an error message to the user in a clearly identifiable format.
        /// </summary>
        /// <param name="error">The error message to display.</param>
        /// <remarks>
        /// Error message formatting:
        /// - Adds a newline before the message
        /// - Prefixes with "Error:" for clear identification
        /// - Used for validation failures and system errors
        /// </remarks>
        public void DisplayError(string error)
        {
            // Display the error message with clear error prefix
            Console.WriteLine($"\nError: {error}");
        }

        /// <summary>
        /// Waits for user input before continuing execution.
        /// This method pauses the application to allow users to read displayed information.
        /// </summary>
        /// <remarks>
        /// This method is used to:
        /// - Pause after displaying contact information
        /// - Allow users to read error messages
        /// - Provide control over application flow
        /// 
        /// The prompt message is retrieved from ApplicationConstants.
        /// </remarks>
        public void WaitForUserInput()
        {
            // Display the wait message and wait for any key press
            Console.WriteLine(ApplicationConstants.PressAnyKeyMessage);
            Console.ReadKey();
        }

        /// <summary>
        /// Prompts the user for confirmation of an action and returns their response.
        /// </summary>
        /// <param name="message">The confirmation message to display.</param>
        /// <returns>True if the user confirms the action; false otherwise.</returns>
        /// <remarks>
        /// Confirmation process:
        /// 1. Display the confirmation message
        /// 2. Add "(y/n):" suffix
        /// 3. Read user input
        /// 4. Return true for "y" or "yes" (case-insensitive)
        /// 5. Return false for any other input
        /// 
        /// Used for destructive operations like contact deletion.
        /// </remarks>
        public bool ConfirmAction(string message)
        {
            // Display the confirmation message with standard suffix
            Console.Write($"{message}{ApplicationConstants.ConfirmActionMessage}");
            
            // Read user response and convert to lowercase for comparison
            string? response = Console.ReadLine()?.ToLower();
            
            // Return true for "y" or "yes", false for anything else
            return response == "y" || response == "yes";
        }
    }
} 