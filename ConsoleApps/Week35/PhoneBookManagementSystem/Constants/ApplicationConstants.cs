namespace PhoneBookManagementSystem.Constants
{
    /// <summary>
    /// Contains all application-wide constants used throughout the phone book management system.
    /// This class centralizes all string literals, numeric values, and configuration settings
    /// to ensure consistency and make maintenance easier. Following the DRY principle,
    /// all constants are defined here to avoid duplication across the codebase.
    /// </summary>
    public static class ApplicationConstants
    {
        #region File Operations Constants

        /// <summary>
        /// The default filename for storing contact data.
        /// Used when no specific file path is provided.
        /// </summary>
        public const string DefaultFileName = "phonebook.txt";

        /// <summary>
        /// The separator character used in the contact file format.
        /// Used to delimit different fields when reading/writing contact data.
        /// </summary>
        public const string FileSeparator = "|";

        #endregion

        #region Validation Rules Constants

        /// <summary>
        /// Minimum allowed length for contact names.
        /// Names must be at least this many characters long.
        /// </summary>
        public const int MinNameLength = 2;

        /// <summary>
        /// Maximum allowed length for contact names.
        /// Names cannot exceed this many characters.
        /// </summary>
        public const int MaxNameLength = 50;

        /// <summary>
        /// Maximum allowed length for contact addresses.
        /// Addresses cannot exceed this many characters.
        /// </summary>
        public const int MaxAddressLength = 200;

        #endregion

        #region UI Messages Constants

        /// <summary>
        /// The main application title displayed in the console interface.
        /// </summary>
        public const string ApplicationTitle = "=== Phone Book Management System ===";

        /// <summary>
        /// Message displayed when waiting for user input to continue.
        /// </summary>
        public const string PressAnyKeyMessage = "\nPress any key to continue...";

        /// <summary>
        /// Prompt message for user menu selection.
        /// </summary>
        public const string EnterChoiceMessage = "Enter your choice: ";

        /// <summary>
        /// Standard suffix for confirmation prompts.
        /// </summary>
        public const string ConfirmActionMessage = " (y/n): ";

        #endregion

        #region Menu Options Constants

        /// <summary>
        /// Text for menu option 1 - Add new contact.
        /// </summary>
        public const string MenuOption1 = "1. Add new contact";

        /// <summary>
        /// Text for menu option 2 - Update contact.
        /// </summary>
        public const string MenuOption2 = "2. Update contact";

        /// <summary>
        /// Text for menu option 3 - Search contact by name.
        /// </summary>
        public const string MenuOption3 = "3. Search contact by name";

        /// <summary>
        /// Text for menu option 4 - View all contacts.
        /// </summary>
        public const string MenuOption4 = "4. View all contacts";

        /// <summary>
        /// Text for menu option 5 - Delete contact.
        /// </summary>
        public const string MenuOption5 = "5. Delete contact";

        /// <summary>
        /// Text for menu option 6 - Save and exit.
        /// </summary>
        public const string MenuOption6 = "6. Save and exit";

        #endregion

        #region Success Messages Constants

        /// <summary>
        /// Success message displayed when a contact is successfully added.
        /// </summary>
        public const string ContactAddedSuccess = "Contact added successfully.";

        /// <summary>
        /// Success message displayed when a contact is successfully updated.
        /// </summary>
        public const string ContactUpdatedSuccess = "Contact updated successfully.";

        /// <summary>
        /// Success message displayed when a contact is successfully deleted.
        /// </summary>
        public const string ContactDeletedSuccess = "Contact deleted successfully.";

        /// <summary>
        /// Message displayed when changes are saved and application is exiting.
        /// </summary>
        public const string ChangesSavedMessage = "Changes saved. Exiting...";

        #endregion

        #region Error Messages Constants

        /// <summary>
        /// Error message for invalid menu choice input.
        /// </summary>
        public const string InvalidChoiceError = "Please enter a valid number between 1 and 6.";

        /// <summary>
        /// Error message template for when a contact is not found.
        /// Uses string.Format with contact name parameter.
        /// </summary>
        public const string ContactNotFoundError = "Contact '{0}' not found.";

        /// <summary>
        /// Error message template for when a contact with the same name already exists.
        /// Uses string.Format with contact name parameter.
        /// </summary>
        public const string ContactExistsError = "Contact with name '{0}' already exists.";

        /// <summary>
        /// Error message for empty or null contact names.
        /// </summary>
        public const string NameEmptyError = "Name cannot be empty.";

        /// <summary>
        /// Error message for failed contact update operations.
        /// </summary>
        public const string UpdateFailedError = "Failed to update contact.";

        /// <summary>
        /// Error message for failed contact deletion operations.
        /// </summary>
        public const string DeleteFailedError = "Failed to delete contact.";

        /// <summary>
        /// Error message template for file loading errors.
        /// Uses string.Format with error message parameter.
        /// </summary>
        public const string FileLoadError = "Error loading contacts: {0}";

        /// <summary>
        /// Error message template for file saving errors.
        /// Uses string.Format with error message parameter.
        /// </summary>
        public const string FileSaveError = "Error saving contacts: {0}";

        /// <summary>
        /// Error message template for general application errors.
        /// Uses string.Format with error message parameter.
        /// </summary>
        public const string GeneralError = "An error occurred: {0}";

        /// <summary>
        /// Error message template for fatal application errors.
        /// Uses string.Format with error message parameter.
        /// </summary>
        public const string FatalError = "Fatal error: {0}";

        #endregion

        #region Input Prompts Constants

        /// <summary>
        /// Prompt message for entering contact name.
        /// </summary>
        public const string EnterNamePrompt = "\nEnter contact name: ";

        /// <summary>
        /// Prompt message for entering phone number.
        /// </summary>
        public const string EnterPhonePrompt = "Enter phone number: ";

        /// <summary>
        /// Prompt message for entering email address.
        /// </summary>
        public const string EnterEmailPrompt = "Enter email: ";

        /// <summary>
        /// Prompt message for entering address.
        /// </summary>
        public const string EnterAddressPrompt = "Enter address: ";

        /// <summary>
        /// Prompt message for entering search name.
        /// </summary>
        public const string SearchNamePrompt = "\nEnter name to search: ";

        /// <summary>
        /// Message template for updating contact information.
        /// Uses string.Format with contact name parameter.
        /// </summary>
        public const string UpdateContactMessage = "Updating contact: {0}";

        #endregion

        #region Display Messages Constants

        /// <summary>
        /// Header message displayed when showing found contact details.
        /// </summary>
        public const string FoundContactMessage = "\nFound contact:";

        /// <summary>
        /// Header message displayed when showing all contacts.
        /// </summary>
        public const string AllContactsTitle = "\nPhone Book Contacts (Sorted by Name):";

        /// <summary>
        /// Message displayed when no contacts are found in the system.
        /// </summary>
        public const string NoContactsMessage = "No contacts found.";

        /// <summary>
        /// Confirmation message template for contact deletion.
        /// Uses string.Format with contact name parameter.
        /// </summary>
        public const string ConfirmDeleteMessage = "Are you sure you want to delete contact '{0}'?";

        #endregion

        #region Validation Error Messages Constants

        /// <summary>
        /// Error message template for name validation failures.
        /// Uses string.Format with minimum and maximum length parameters.
        /// </summary>
        public const string NameValidationError = "Name must be between {0} and {1} characters and cannot be empty.";

        /// <summary>
        /// Error message for phone number validation failures.
        /// </summary>
        public const string PhoneValidationError = "Phone number must be a valid format (e.g., +1-555-0123 or 15550123).";

        /// <summary>
        /// Error message for email validation failures.
        /// </summary>
        public const string EmailValidationError = "Email must be in a valid format (e.g., user@domain.com).";

        /// <summary>
        /// Error message template for address validation failures.
        /// Uses string.Format with maximum length parameter.
        /// </summary>
        public const string AddressValidationError = "Address cannot be empty and must be less than {0} characters.";

        /// <summary>
        /// Error message for invalid name format.
        /// </summary>
        public const string InvalidNameError = "Invalid name format. Name must be between 2 and 50 characters and contain only letters, spaces, hyphens, apostrophes, and dots.";

        /// <summary>
        /// Error message for invalid phone number format.
        /// </summary>
        public const string InvalidPhoneError = "Invalid phone number format. Please enter a valid international phone number.";

        /// <summary>
        /// Error message for invalid email format.
        /// </summary>
        public const string InvalidEmailError = "Invalid email format. Please enter a valid email address.";

        /// <summary>
        /// Error message for invalid address format.
        /// </summary>
        public const string InvalidAddressError = "Invalid address format. Address cannot be empty and must be less than 200 characters.";

        #endregion
    }
} 