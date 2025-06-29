using PhoneBookManagementSystem.Interfaces;
using PhoneBookManagementSystem.Models;
using PhoneBookManagementSystem.Constants;
using PhoneBookManagementSystem.Enums;

namespace PhoneBookManagementSystem.Services
{
    /// <summary>
    /// Provides business logic coordination for the phone book management system.
    /// This class orchestrates the interaction between the user interface, data repository,
    /// and validation services to provide a complete phone book management experience.
    /// 
    /// The service layer implements the application's business rules and ensures
    /// proper error handling and user feedback throughout all operations.
    /// </summary>
    public class PhoneBookService : IPhoneBookService
    {
        /// <summary>
        /// The data repository for contact storage and retrieval operations.
        /// This dependency is injected through the constructor to follow
        /// the Dependency Inversion Principle.
        /// </summary>
        private readonly IPhoneBookRepository _repository;

        /// <summary>
        /// The user interface for handling user interactions and display operations.
        /// This dependency is injected through the constructor to follow
        /// the Dependency Inversion Principle.
        /// </summary>
        private readonly IUserInterface _userInterface;

        /// <summary>
        /// The validator for contact data validation operations.
        /// This dependency is injected through the constructor to follow
        /// the Dependency Inversion Principle.
        /// </summary>
        private readonly IValidator _validator;

        /// <summary>
        /// The file path for persistent storage of contact data.
        /// This path is used for both loading and saving contact information.
        /// </summary>
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the PhoneBookService class.
        /// </summary>
        /// <param name="repository">The repository for data access operations.</param>
        /// <param name="userInterface">The user interface for user interactions.</param>
        /// <param name="validator">The validator for contact validation.</param>
        /// <param name="filePath">The file path for persistent storage.</param>
        /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
        /// <remarks>
        /// Constructor validation:
        /// - All dependencies must be provided (not null)
        /// - File path must be specified for persistence
        /// - Dependencies are stored for use throughout the service
        /// </remarks>
        public PhoneBookService(IPhoneBookRepository repository, IUserInterface userInterface, IValidator validator, string filePath)
        {
            // Validate all dependencies are provided
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _userInterface = userInterface ?? throw new ArgumentNullException(nameof(userInterface));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        /// <summary>
        /// Initializes the phone book service by loading existing contacts from file.
        /// This method is called at application startup to restore previous contact data.
        /// </summary>
        /// <remarks>
        /// Initialization process:
        /// - Attempts to load contacts from the specified file path
        /// - Handles file loading errors gracefully
        /// - Displays error messages to the user if loading fails
        /// - Continues operation even if no previous data exists
        /// </remarks>
        public void Initialize()
        {
            try
            {
                // Load existing contacts from the file
                _repository.LoadFromFile(_filePath);
            }
            catch (Exception ex)
            {
                // Display error message to user but continue operation
                _userInterface.DisplayError(string.Format(ApplicationConstants.FileLoadError, ex.Message));
            }
        }

        /// <summary>
        /// Runs the main application loop, handling user menu selections and operations.
        /// This method contains the primary application logic and continues until the user chooses to exit.
        /// </summary>
        /// <remarks>
        /// Main application loop:
        /// - Displays menu and gets user choice
        /// - Routes to appropriate operation based on choice
        /// - Handles exceptions gracefully with user feedback
        /// - Continues until user selects exit option
        /// - Uses enum-based menu selection for type safety
        /// </remarks>
        public void Run()
        {
            // Flag to control the main application loop
            bool exit = false;

            // Main application loop
            while (!exit)
            {
                try
                {
                    // Display the main menu and get user choice
                    _userInterface.DisplayMenu();
                    int choice = _userInterface.GetUserChoice();

                    // Route to appropriate operation based on user choice
                    switch ((MenuOption)choice)
                    {
                        case MenuOption.AddContact:
                            AddContact();
                            break;
                        case MenuOption.UpdateContact:
                            UpdateContact();
                            break;
                        case MenuOption.SearchContact:
                            SearchContact();
                            break;
                        case MenuOption.ViewAllContacts:
                            ViewAllContacts();
                            break;
                        case MenuOption.DeleteContact:
                            DeleteContact();
                            break;
                        case MenuOption.SaveAndExit:
                            SaveAndExit();
                            exit = true;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Handle any unexpected errors gracefully
                    _userInterface.DisplayError(string.Format(ApplicationConstants.GeneralError, ex.Message));
                    _userInterface.WaitForUserInput();
                }
            }
        }

        /// <summary>
        /// Handles the add contact operation, including input collection, validation, and storage.
        /// </summary>
        /// <remarks>
        /// Add contact process:
        /// - Collect contact information from user with field-by-field validation
        /// - Validate contact data using repository
        /// - Display success or error messages
        /// - Wait for user acknowledgment
        /// - Handle validation and duplicate errors
        /// 
        /// Uses field-by-field validation to preserve valid input and only re-request invalid fields.
        /// </remarks>
        private void AddContact()
        {
            // Collect contact information from the user with field-by-field validation
            Contact contact = _userInterface.GetContactInputWithValidation(_validator);
            
            try
            {
                // Add the contact to the repository (includes validation)
                _repository.AddContact(contact);
                
                // Display success message to user
                _userInterface.DisplayMessage(ApplicationConstants.ContactAddedSuccess);
            }
            catch (ArgumentException ex)
            {
                // Handle validation errors
                _userInterface.DisplayError(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                // Handle duplicate contact errors
                _userInterface.DisplayError(ex.Message);
            }

            // Wait for user to acknowledge the result
            _userInterface.WaitForUserInput();
        }

        /// <summary>
        /// Handles the update contact operation, including contact lookup, input collection, and validation.
        /// </summary>
        /// <remarks>
        /// Update contact process:
        /// - Get contact name from user with validation
        /// - Validate name is not empty
        /// - Check if contact exists
        /// - Collect updated contact information with field-by-field validation
        /// - Validate and update contact data
        /// - Display success or error messages
        /// - Handle validation and conflict errors
        /// 
        /// Uses field-by-field validation to preserve valid input and only re-request invalid fields.
        /// </remarks>
        private void UpdateContact()
        {
            // Get the contact name to update with validation
            string name = _userInterface.GetContactNameWithValidation(_validator);
            
            // Check if the contact exists before attempting update
            Contact? existingContact = _repository.SearchContact(name);
            if (existingContact == null)
            {
                _userInterface.DisplayError(string.Format(ApplicationConstants.ContactNotFoundError, name));
                _userInterface.WaitForUserInput();
                return;
            }

            // Inform user about the update operation
            _userInterface.DisplayMessage(string.Format(ApplicationConstants.UpdateContactMessage, name));
            
            // Collect updated contact information with field-by-field validation
            Contact updatedContact = _userInterface.GetContactInputWithValidation(_validator);

            try
            {
                // Attempt to update the contact
                if (_repository.UpdateContact(name, updatedContact))
                {
                    _userInterface.DisplayMessage(ApplicationConstants.ContactUpdatedSuccess);
                }
                else
                {
                    _userInterface.DisplayError(ApplicationConstants.UpdateFailedError);
                }
            }
            catch (ArgumentException ex)
            {
                // Handle validation errors
                _userInterface.DisplayError(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                // Handle conflict errors (e.g., duplicate names)
                _userInterface.DisplayError(ex.Message);
            }

            // Wait for user to acknowledge the result
            _userInterface.WaitForUserInput();
        }

        /// <summary>
        /// Handles the search contact operation, including input collection and result display.
        /// </summary>
        /// <remarks>
        /// Search contact process:
        /// - Get contact name from user with validation
        /// - Search for contact in repository
        /// - Display contact details or "not found" message
        /// - Wait for user acknowledgment
        /// 
        /// Uses validation to ensure only valid names are accepted for search.
        /// </remarks>
        private void SearchContact()
        {
            // Get the contact name to search for with validation
            string name = _userInterface.GetContactNameWithValidation(_validator);

            // Search for the contact in the repository
            Contact? contact = _repository.SearchContact(name);
            if (contact != null)
            {
                // Display the found contact details
                _userInterface.DisplayContact(contact);
            }
            else
            {
                // Display "not found" message
                _userInterface.DisplayMessage(string.Format(ApplicationConstants.ContactNotFoundError, name));
            }

            // Wait for user to acknowledge the result
            _userInterface.WaitForUserInput();
        }

        /// <summary>
        /// Handles the view all contacts operation, displaying all contacts in alphabetical order.
        /// </summary>
        /// <remarks>
        /// View all contacts process:
        /// - Retrieve all contacts from repository (already sorted)
        /// - Display contacts using user interface
        /// - Handle empty contact array gracefully
        /// - Wait for user acknowledgment
        /// </remarks>
        private void ViewAllContacts()
        {
            // Retrieve all contacts from the repository
            Contact[] contacts = _repository.GetAllContacts();
            
            // Display all contacts using the user interface
            _userInterface.DisplayAllContacts(contacts);
            
            // Wait for user to acknowledge the result
            _userInterface.WaitForUserInput();
        }

        /// <summary>
        /// Handles the delete contact operation, including confirmation and removal.
        /// </summary>
        /// <remarks>
        /// Delete contact process:
        /// - Get contact name from user with validation
        /// - Check if contact exists
        /// - Confirm deletion with user
        /// - Delete contact if confirmed
        /// - Display success or error messages
        /// - Wait for user acknowledgment
        /// 
        /// Uses validation to ensure only valid names are accepted for deletion.
        /// </remarks>
        private void DeleteContact()
        {
            // Get the contact name to delete with validation
            string name = _userInterface.GetContactNameWithValidation(_validator);

            // Check if the contact exists before attempting deletion
            if (!_repository.ContactExists(name))
            {
                _userInterface.DisplayError(string.Format(ApplicationConstants.ContactNotFoundError, name));
                _userInterface.WaitForUserInput();
                return;
            }

            // Confirm deletion with the user
            if (_userInterface.ConfirmAction(string.Format(ApplicationConstants.ConfirmDeleteMessage, name)))
            {
                // Attempt to delete the contact
                if (_repository.DeleteContact(name))
                {
                    _userInterface.DisplayMessage(ApplicationConstants.ContactDeletedSuccess);
                }
                else
                {
                    _userInterface.DisplayError(ApplicationConstants.DeleteFailedError);
                }
            }

            // Wait for user to acknowledge the result
            _userInterface.WaitForUserInput();
        }

        /// <summary>
        /// Handles the save and exit operation, persisting data and terminating the application.
        /// </summary>
        /// <remarks>
        /// Save and exit process:
        /// - Save all contacts to file
        /// - Display success message
        /// - Handle file saving errors gracefully
        /// - Wait for user acknowledgment if error occurs
        /// - Application will exit after this method completes
        /// </remarks>
        private void SaveAndExit()
        {
            try
            {
                // Save all contacts to the file
                _repository.SaveToFile(_filePath);
                
                // Display success message
                _userInterface.DisplayMessage(ApplicationConstants.ChangesSavedMessage);
            }
            catch (Exception ex)
            {
                // Handle file saving errors
                _userInterface.DisplayError(string.Format(ApplicationConstants.FileSaveError, ex.Message));
                _userInterface.WaitForUserInput();
            }
        }

        #region IPhoneBookService Implementation

        /// <summary>
        /// Adds a new contact to the phone book
        /// </summary>
        /// <param name="contact">The contact to add</param>
        /// <returns>True if contact was added successfully, false otherwise</returns>
        public bool AddContact(Contact contact)
        {
            try
            {
                _repository.AddContact(contact);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Updates an existing contact in the phone book
        /// </summary>
        /// <param name="id">The ID of the contact to update</param>
        /// <param name="updatedContact">The updated contact information</param>
        /// <returns>True if contact was updated successfully, false otherwise</returns>
        public bool UpdateContact(int id, Contact updatedContact)
        {
            try
            {
                // Find contact by ID first
                Contact? existingContact = GetContactById(id);
                if (existingContact == null)
                    return false;

                return _repository.UpdateContact(existingContact.Name, updatedContact);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Searches for contacts by name or phone number
        /// </summary>
        /// <param name="searchTerm">The search term to look for</param>
        /// <returns>List of contacts matching the search criteria</returns>
        public List<Contact> SearchContacts(string searchTerm)
        {
            var contacts = new List<Contact>();
            var allContacts = _repository.GetAllContacts();
            
            foreach (var contact in allContacts)
            {
                if (contact.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    contact.PhoneNumber.Contains(searchTerm))
                {
                    contacts.Add(contact);
                }
            }
            
            return contacts;
        }

        /// <summary>
        /// Gets all contacts in the phone book
        /// </summary>
        /// <returns>List of all contacts</returns>
        public List<Contact> GetAllContacts()
        {
            return _repository.GetAllContacts().ToList();
        }

        /// <summary>
        /// Gets a specific contact by ID
        /// </summary>
        /// <param name="id">The ID of the contact to retrieve</param>
        /// <returns>The contact if found, null otherwise</returns>
        public Contact? GetContactById(int id)
        {
            var allContacts = _repository.GetAllContacts();
            return allContacts.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Deletes a contact from the phone book
        /// </summary>
        /// <param name="id">The ID of the contact to delete</param>
        /// <returns>True if contact was deleted successfully, false otherwise</returns>
        public bool DeleteContact(int id)
        {
            try
            {
                Contact? contact = GetContactById(id);
                if (contact == null)
                    return false;

                return _repository.DeleteContact(contact.Name);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Saves all contacts to a file
        /// </summary>
        /// <param name="filePath">The path to the file to save to</param>
        /// <returns>True if contacts were saved successfully, false otherwise</returns>
        public bool SaveContacts(string filePath)
        {
            try
            {
                _repository.SaveToFile(filePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Loads contacts from a file
        /// </summary>
        /// <param name="filePath">The path to the file to load from</param>
        /// <returns>True if contacts were loaded successfully, false otherwise</returns>
        public bool LoadContacts(string filePath)
        {
            try
            {
                _repository.LoadFromFile(filePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the total number of contacts in the phone book
        /// </summary>
        /// <returns>The number of contacts</returns>
        public int GetContactCount()
        {
            return _repository.GetAllContacts().Length;
        }

        /// <summary>
        /// Checks if a contact with the given ID exists
        /// </summary>
        /// <param name="id">The ID to check</param>
        /// <returns>True if contact exists, false otherwise</returns>
        public bool ContactExists(int id)
        {
            return GetContactById(id) != null;
        }

        /// <summary>
        /// Checks if a contact with the given phone number exists
        /// </summary>
        /// <param name="phoneNumber">The phone number to check</param>
        /// <returns>True if contact exists, false otherwise</returns>
        public bool ContactExistsByPhone(string phoneNumber)
        {
            var allContacts = _repository.GetAllContacts();
            return allContacts.Any(c => c.PhoneNumber.Equals(phoneNumber, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Gets the next available ID for a new contact
        /// </summary>
        /// <returns>The next available ID</returns>
        public int GetNextId()
        {
            var allContacts = _repository.GetAllContacts();
            return allContacts.Length > 0 ? allContacts.Max(c => c.Id) + 1 : 1;
        }

        #endregion
    }
} 