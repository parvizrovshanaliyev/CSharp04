using PhoneBookManagementSystem.Models;

namespace PhoneBookManagementSystem.Interfaces
{
    /// <summary>
    /// Defines the contract for user interface operations in the phone book management system.
    /// This interface abstracts the user interaction layer, allowing for different
    /// UI implementations (console, GUI, web, etc.) while maintaining consistent
    /// behavior across the application.
    /// </summary>
    public interface IUserInterface
    {
        /// <summary>
        /// Displays the main menu options to the user.
        /// The menu should show all available operations in a clear, numbered format.
        /// </summary>
        void DisplayMenu();

        /// <summary>
        /// Gets the user's menu choice and validates it.
        /// Should handle invalid input gracefully and prompt for valid input.
        /// </summary>
        /// <returns>A valid menu option number (1-6).</returns>
        int GetUserChoice();

        /// <summary>
        /// Prompts the user to enter contact information and returns a new Contact object.
        /// Should collect name, phone number, email, and address from the user.
        /// </summary>
        /// <returns>A new Contact object with user-provided information.</returns>
        Contact GetContactInput();

        /// <summary>
        /// Prompts the user to enter contact information with field-by-field validation.
        /// Each field is validated individually, and only invalid fields are re-requested.
        /// This provides a better user experience by preserving valid input.
        /// </summary>
        /// <param name="validator">The validator to use for field validation.</param>
        /// <returns>A new Contact object with validated user-provided information.</returns>
        Contact GetContactInputWithValidation(IValidator validator);

        /// <summary>
        /// Prompts the user to enter a contact name for search operations.
        /// Used for search, update, and delete operations.
        /// </summary>
        /// <returns>The contact name entered by the user.</returns>
        string GetContactName();

        /// <summary>
        /// Prompts the user to enter a contact name with validation.
        /// Re-prompts if the name is invalid until a valid name is provided.
        /// </summary>
        /// <param name="validator">The validator to use for name validation.</param>
        /// <returns>A validated contact name.</returns>
        string GetContactNameWithValidation(IValidator validator);

        /// <summary>
        /// Displays detailed information about a single contact.
        /// Should format the contact information in a readable, user-friendly manner.
        /// </summary>
        /// <param name="contact">The contact to display.</param>
        void DisplayContact(Contact contact);

        /// <summary>
        /// Displays all contacts in a formatted list.
        /// Should handle empty collections gracefully and show appropriate messages.
        /// </summary>
        /// <param name="contacts">The array of contacts to display.</param>
        void DisplayAllContacts(Contact[] contacts);

        /// <summary>
        /// Displays a general message to the user.
        /// Used for success messages, informational text, and general feedback.
        /// </summary>
        /// <param name="message">The message to display.</param>
        void DisplayMessage(string message);

        /// <summary>
        /// Displays an error message to the user.
        /// Should format error messages in a way that clearly indicates they are errors.
        /// </summary>
        /// <param name="error">The error message to display.</param>
        void DisplayError(string error);

        /// <summary>
        /// Waits for user input before continuing.
        /// Used to pause execution and allow users to read displayed information.
        /// </summary>
        void WaitForUserInput();

        /// <summary>
        /// Prompts the user for confirmation of an action.
        /// Should display the message and wait for yes/no response.
        /// </summary>
        /// <param name="message">The confirmation message to display.</param>
        /// <returns>True if the user confirms the action; false otherwise.</returns>
        bool ConfirmAction(string message);
    }
} 