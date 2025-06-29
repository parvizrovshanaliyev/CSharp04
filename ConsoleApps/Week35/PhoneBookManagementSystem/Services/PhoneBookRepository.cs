using System.Collections;
using PhoneBookManagementSystem.Interfaces;
using PhoneBookManagementSystem.Models;
using PhoneBookManagementSystem.Constants;

namespace PhoneBookManagementSystem.Services
{
    /// <summary>
    /// Provides data access services for the phone book management system using non-generic SortedList.
    /// This class implements the IPhoneBookRepository interface and manages contact data
    /// with automatic alphabetical sorting by contact names.
    /// 
    /// The repository uses a non-generic SortedList as specified in the requirements,
    /// providing efficient binary search operations and automatic sorting capabilities.
    /// </summary>
    public class PhoneBookRepository : IPhoneBookRepository
    {
        /// <summary>
        /// The underlying data storage using non-generic SortedList.
        /// Keys are contact names (strings), values are Contact objects.
        /// The SortedList automatically maintains alphabetical sorting by keys.
        /// </summary>
        private readonly SortedList _contacts;

        /// <summary>
        /// The validator instance used for contact validation before storage operations.
        /// This dependency is injected through the constructor to follow
        /// the Dependency Inversion Principle.
        /// </summary>
        private readonly IValidator _validator;

        /// <summary>
        /// Initializes a new instance of the PhoneBookRepository class.
        /// </summary>
        /// <param name="validator">The validator to use for contact validation.</param>
        /// <exception cref="ArgumentNullException">Thrown when validator is null.</exception>
        public PhoneBookRepository(IValidator validator)
        {
            // Initialize the SortedList for contact storage
            _contacts = new SortedList();
            
            // Validate and store the validator dependency
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        /// <summary>
        /// Adds a new contact to the phone book with validation and duplicate checking.
        /// The contact will be automatically sorted by name in the underlying SortedList.
        /// </summary>
        /// <param name="contact">The contact to add. Must not be null.</param>
        /// <exception cref="ArgumentNullException">Thrown when contact is null.</exception>
        /// <exception cref="ArgumentException">Thrown when contact validation fails.</exception>
        /// <exception cref="InvalidOperationException">Thrown when a contact with the same name already exists.</exception>
        /// <remarks>
        /// Add operation process:
        /// 1. Validate contact is not null
        /// 2. Validate all contact fields using the validator
        /// 3. Check for duplicate names
        /// 4. Add to SortedList (automatic sorting)
        /// </remarks>
        public void AddContact(Contact contact)
        {
            // Validate that the contact is not null
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            // Validate all contact fields using the injected validator
            var validationError = _validator.GetValidationError(
                contact.Name, contact.PhoneNumber, contact.Email, contact.Address);

            // Throw exception if validation fails
            if (!string.IsNullOrEmpty(validationError))
                throw new ArgumentException(validationError);

            // Check for duplicate contact names
            if (_contacts.ContainsKey(contact.Name))
                throw new InvalidOperationException(string.Format(ApplicationConstants.ContactExistsError, contact.Name));

            // Add the contact to the SortedList (automatic sorting by name)
            _contacts.Add(contact.Name, contact);
        }

        /// <summary>
        /// Updates an existing contact's information with validation and conflict checking.
        /// If the contact name is changed, the contact will be re-sorted in the storage.
        /// </summary>
        /// <param name="name">The current name of the contact to update.</param>
        /// <param name="updatedContact">The updated contact information.</param>
        /// <returns>True if the contact was successfully updated; false if the contact was not found.</returns>
        /// <exception cref="ArgumentException">Thrown when name is null/empty or contact validation fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown when updatedContact is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the new name conflicts with an existing contact.</exception>
        /// <remarks>
        /// Update operation process:
        /// 1. Validate input parameters
        /// 2. Check if contact exists
        /// 3. Validate updated contact data
        /// 4. Handle name changes (remove old, add new)
        /// 5. Update contact information
        /// </remarks>
        public bool UpdateContact(string name, Contact updatedContact)
        {
            // Validate the current name parameter
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(ApplicationConstants.NameEmptyError);

            // Validate the updated contact is not null
            if (updatedContact == null)
                throw new ArgumentNullException(nameof(updatedContact));

            // Check if the contact to update exists
            if (!_contacts.ContainsKey(name))
                return false;

            // Validate the updated contact data
            var validationError = _validator.GetValidationError(
                updatedContact.Name, updatedContact.PhoneNumber, updatedContact.Email, updatedContact.Address);

            // Throw exception if validation fails
            if (!string.IsNullOrEmpty(validationError))
                throw new ArgumentException(validationError);

            // Handle name changes - if the name is being changed, we need special handling
            if (name != updatedContact.Name)
            {
                // Check if the new name conflicts with an existing contact
                if (_contacts.ContainsKey(updatedContact.Name))
                    throw new InvalidOperationException(string.Format(ApplicationConstants.ContactExistsError, updatedContact.Name));

                // Remove the old entry and add the new one (re-sorting will occur automatically)
                _contacts.Remove(name);
                _contacts.Add(updatedContact.Name, updatedContact);
            }
            else
            {
                // Name hasn't changed, just update the contact information
                _contacts[name] = updatedContact;
            }

            return true;
        }

        /// <summary>
        /// Searches for a contact by name using efficient binary search provided by SortedList.
        /// </summary>
        /// <param name="name">The name of the contact to search for.</param>
        /// <returns>The found contact, or null if no contact with the specified name exists.</returns>
        /// <remarks>
        /// Search operation:
        /// - Uses SortedList.ContainsKey() for efficient binary search
        /// - Returns null for null/empty names
        /// - Returns the Contact object if found
        /// - O(log n) time complexity due to binary search
        /// </remarks>
        public Contact? SearchContact(string name)
        {
            // Return null for null or empty names
            if (string.IsNullOrWhiteSpace(name))
                return null;

            // Use SortedList's efficient binary search to find the contact
            return _contacts.ContainsKey(name) ? (Contact)_contacts[name]! : null;
        }

        /// <summary>
        /// Deletes a contact from the phone book.
        /// </summary>
        /// <param name="name">The name of the contact to delete.</param>
        /// <returns>True if the contact was successfully deleted; false if the contact was not found.</returns>
        /// <remarks>
        /// Delete operation:
        /// - Returns false for null/empty names
        /// - Uses SortedList.Remove() for efficient removal
        /// - Returns true if contact was found and removed
        /// - Returns false if contact was not found
        /// </remarks>
        public bool DeleteContact(string name)
        {
            // Return false for null or empty names
            if (string.IsNullOrWhiteSpace(name))
                return false;

            // Check if the contact exists and remove it
            if (_contacts.ContainsKey(name))
            {
                _contacts.Remove(name);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Retrieves all contacts from the phone book in alphabetical order.
        /// Contacts are automatically sorted by name due to the SortedList implementation.
        /// </summary>
        /// <returns>An array of all contacts, sorted by name.</returns>
        /// <remarks>
        /// Retrieval process:
        /// - Iterates through SortedList entries
        /// - Converts DictionaryEntry objects to Contact objects
        /// - Returns contacts in alphabetical order by name
        /// - Handles empty collections gracefully
        /// </remarks>
        public Contact[] GetAllContacts()
        {
            // Create an array to hold all contacts
            Contact[] contacts = new Contact[_contacts.Count];
            int index = 0;
            
            // Iterate through all entries in the SortedList
            foreach (DictionaryEntry entry in _contacts)
            {
                // Cast the value to Contact and add to the array
                contacts[index] = (Contact)entry.Value!;
                index++;
            }
            
            // Return the contacts (already sorted by SortedList)
            return contacts;
        }

        /// <summary>
        /// Saves all contacts to a file in a persistent storage format.
        /// The file format uses pipe-separated values for each contact field.
        /// </summary>
        /// <param name="filePath">The path to the file where contacts will be saved.</param>
        /// <exception cref="IOException">Thrown when file operations fail.</exception>
        /// <remarks>
        /// File format:
        /// - One contact per line
        /// - Fields separated by pipe character (|)
        /// - Format: Name|Phone|Email|Address|LastModified
        /// - Uses centralized FileSeparator constant
        /// - Proper resource disposal with using statement
        /// </remarks>
        public void SaveToFile(string filePath)
        {
            try
            {
                // Use using statement for proper resource disposal
                using var writer = new StreamWriter(filePath);
                
                // Write each contact to the file
                foreach (DictionaryEntry entry in _contacts)
                {
                    var contact = (Contact)entry.Value!;
                    
                    // Format contact data with pipe separators
                    writer.WriteLine($"{contact.Name}{ApplicationConstants.FileSeparator}{contact.PhoneNumber}{ApplicationConstants.FileSeparator}{contact.Email}{ApplicationConstants.FileSeparator}{contact.Address}{ApplicationConstants.FileSeparator}{contact.LastModified:yyyy-MM-dd HH:mm:ss}");
                }
            }
            catch (Exception ex)
            {
                // Wrap the exception with more descriptive message
                throw new IOException(string.Format(ApplicationConstants.FileSaveError, ex.Message), ex);
            }
        }

        /// <summary>
        /// Loads contacts from a file into the phone book.
        /// If the file doesn't exist, no contacts are loaded.
        /// Existing contacts in memory are cleared before loading.
        /// </summary>
        /// <param name="filePath">The path to the file containing contact data.</param>
        /// <exception cref="IOException">Thrown when file operations fail.</exception>
        /// <remarks>
        /// Loading process:
        /// - Checks if file exists (returns early if not)
        /// - Clears existing contacts in memory
        /// - Reads file line by line
        /// - Parses pipe-separated values
        /// - Creates Contact objects and adds to SortedList
        /// - Handles malformed lines gracefully
        /// - Uses centralized FileSeparator constant
        /// </remarks>
        public void LoadFromFile(string filePath)
        {
            // Return early if file doesn't exist
            if (!File.Exists(filePath))
                return;

            try
            {
                // Clear existing contacts before loading
                _contacts.Clear();
                
                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);

                // Process each line in the file
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    
                    // Skip empty lines
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    // Split the line by the file separator
                    string[] parts = line.Split(ApplicationConstants.FileSeparator);
                    
                    // Ensure we have at least the required fields
                    if (parts.Length >= 4)
                    {
                        // Create a new Contact object from the file data
                        var contact = new Contact
                        {
                            Name = parts[0],
                            PhoneNumber = parts[1],
                            Email = parts[2],
                            Address = parts[3],
                            LastModified = parts.Length > 4 && DateTime.TryParse(parts[4], out var date) 
                                ? date 
                                : DateTime.Now
                        };

                        // Add the contact to the SortedList (avoid duplicates)
                        if (!_contacts.ContainsKey(contact.Name))
                        {
                            _contacts.Add(contact.Name, contact);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Wrap the exception with more descriptive message
                throw new IOException(string.Format(ApplicationConstants.FileLoadError, ex.Message), ex);
            }
        }

        /// <summary>
        /// Checks if a contact with the specified name exists in the phone book.
        /// </summary>
        /// <param name="name">The name to check for existence.</param>
        /// <returns>True if a contact with the specified name exists; false otherwise.</returns>
        /// <remarks>
        /// Existence check:
        /// - Returns false for null/empty names
        /// - Uses SortedList.ContainsKey() for efficient lookup
        /// - O(log n) time complexity due to binary search
        /// </remarks>
        public bool ContactExists(string name)
        {
            // Return false for null or empty names
            if (string.IsNullOrWhiteSpace(name))
                return false;

            // Use SortedList's efficient binary search to check existence
            return _contacts.ContainsKey(name);
        }
    }
} 