using PhoneBookManagementSystem.Models;

namespace PhoneBookManagementSystem.Interfaces
{
    /// <summary>
    /// Defines the contract for phone book data access operations.
    /// This interface abstracts the data storage layer, allowing for different
    /// implementations (file-based, database, etc.) while maintaining consistent
    /// behavior across the application.
    /// </summary>
    public interface IPhoneBookRepository
    {
        /// <summary>
        /// Adds a new contact to the phone book.
        /// The contact will be automatically sorted by name in the underlying storage.
        /// </summary>
        /// <param name="contact">The contact to add. Must not be null.</param>
        /// <exception cref="ArgumentNullException">Thrown when contact is null.</exception>
        /// <exception cref="ArgumentException">Thrown when contact validation fails.</exception>
        /// <exception cref="InvalidOperationException">Thrown when a contact with the same name already exists.</exception>
        void AddContact(Contact contact);

        /// <summary>
        /// Updates an existing contact's information.
        /// If the contact name is changed, the contact will be re-sorted in the storage.
        /// </summary>
        /// <param name="name">The current name of the contact to update.</param>
        /// <param name="updatedContact">The updated contact information.</param>
        /// <returns>True if the contact was successfully updated; false if the contact was not found.</returns>
        /// <exception cref="ArgumentException">Thrown when name is null/empty or contact validation fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown when updatedContact is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the new name conflicts with an existing contact.</exception>
        bool UpdateContact(string name, Contact updatedContact);

        /// <summary>
        /// Searches for a contact by name using efficient binary search.
        /// </summary>
        /// <param name="name">The name of the contact to search for.</param>
        /// <returns>The found contact, or null if no contact with the specified name exists.</returns>
        Contact? SearchContact(string name);

        /// <summary>
        /// Deletes a contact from the phone book.
        /// </summary>
        /// <param name="name">The name of the contact to delete.</param>
        /// <returns>True if the contact was successfully deleted; false if the contact was not found.</returns>
        bool DeleteContact(string name);

        /// <summary>
        /// Retrieves all contacts from the phone book.
        /// Contacts are returned in alphabetical order by name.
        /// </summary>
        /// <returns>An array of all contacts, sorted by name.</returns>
        Contact[] GetAllContacts();

        /// <summary>
        /// Saves all contacts to a file in a persistent storage format.
        /// The file format uses pipe-separated values for each contact field.
        /// </summary>
        /// <param name="filePath">The path to the file where contacts will be saved.</param>
        /// <exception cref="IOException">Thrown when file operations fail.</exception>
        void SaveToFile(string filePath);

        /// <summary>
        /// Loads contacts from a file into the phone book.
        /// If the file doesn't exist, no contacts are loaded.
        /// Existing contacts in memory are cleared before loading.
        /// </summary>
        /// <param name="filePath">The path to the file containing contact data.</param>
        /// <exception cref="IOException">Thrown when file operations fail.</exception>
        void LoadFromFile(string filePath);

        /// <summary>
        /// Checks if a contact with the specified name exists in the phone book.
        /// </summary>
        /// <param name="name">The name to check for existence.</param>
        /// <returns>True if a contact with the specified name exists; false otherwise.</returns>
        bool ContactExists(string name);
    }
} 