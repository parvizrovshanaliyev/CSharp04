using PhoneBookManagementSystem.Models;

namespace PhoneBookManagementSystem.Interfaces
{
    /// <summary>
    /// Interface for phone book service operations
    /// Provides methods for managing contacts in the phone book
    /// Uses non-generic arrays instead of generic collections
    /// </summary>
    public interface IPhoneBookService
    {
        /// <summary>
        /// Adds a new contact to the phone book
        /// </summary>
        /// <param name="contact">The contact to add</param>
        /// <returns>True if contact was added successfully, false otherwise</returns>
        bool AddContact(Contact contact);

        /// <summary>
        /// Updates an existing contact in the phone book
        /// </summary>
        /// <param name="id">The ID of the contact to update</param>
        /// <param name="updatedContact">The updated contact information</param>
        /// <returns>True if contact was updated successfully, false otherwise</returns>
        bool UpdateContact(int id, Contact updatedContact);

        /// <summary>
        /// Searches for contacts by name or phone number
        /// </summary>
        /// <param name="searchTerm">The search term to look for</param>
        /// <returns>Array of contacts matching the search criteria</returns>
        Contact[] SearchContacts(string searchTerm);

        /// <summary>
        /// Gets all contacts in the phone book
        /// </summary>
        /// <returns>Array of all contacts</returns>
        Contact[] GetAllContacts();

        /// <summary>
        /// Gets a specific contact by ID
        /// </summary>
        /// <param name="id">The ID of the contact to retrieve</param>
        /// <returns>The contact if found, null otherwise</returns>
        Contact? GetContactById(int id);

        /// <summary>
        /// Deletes a contact from the phone book
        /// </summary>
        /// <param name="id">The ID of the contact to delete</param>
        /// <returns>True if contact was deleted successfully, false otherwise</returns>
        bool DeleteContact(int id);

        /// <summary>
        /// Saves all contacts to a file
        /// </summary>
        /// <param name="filePath">The path to the file to save to</param>
        /// <returns>True if contacts were saved successfully, false otherwise</returns>
        bool SaveContacts(string filePath);

        /// <summary>
        /// Loads contacts from a file
        /// </summary>
        /// <param name="filePath">The path to the file to load from</param>
        /// <returns>True if contacts were loaded successfully, false otherwise</returns>
        bool LoadContacts(string filePath);

        /// <summary>
        /// Gets the total number of contacts in the phone book
        /// </summary>
        /// <returns>The number of contacts</returns>
        int GetContactCount();

        /// <summary>
        /// Checks if a contact with the given ID exists
        /// </summary>
        /// <param name="id">The ID to check</param>
        /// <returns>True if contact exists, false otherwise</returns>
        bool ContactExists(int id);

        /// <summary>
        /// Checks if a contact with the given phone number exists
        /// </summary>
        /// <param name="phoneNumber">The phone number to check</param>
        /// <returns>True if contact exists, false otherwise</returns>
        bool ContactExistsByPhone(string phoneNumber);

        /// <summary>
        /// Gets the next available ID for a new contact
        /// </summary>
        /// <returns>The next available ID</returns>
        int GetNextId();
    }
} 