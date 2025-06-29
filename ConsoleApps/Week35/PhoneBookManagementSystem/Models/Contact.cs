using System;

namespace PhoneBookManagementSystem.Models
{
    /// <summary>
    /// Represents a contact in the phone book management system.
    /// This class encapsulates all the information about a person including
    /// their ID, name, phone number, email, address, and when the contact was last modified.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Gets or sets the unique identifier for the contact.
        /// Used for database operations and contact identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the full name of the contact.
        /// Must be between 2 and 50 characters in length.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number of the contact.
        /// Supports international format with optional separators.
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address of the contact.
        /// Must be in a valid email format.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the physical address of the contact.
        /// Maximum length is 200 characters.
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the timestamp when the contact was last modified.
        /// Automatically set to current time when contact is created or updated.
        /// </summary>
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Initializes a new instance of the Contact class with default values.
        /// Sets LastModified to the current date and time.
        /// </summary>
        public Contact()
        {
            Id = 0;
            LastModified = DateTime.Now;
        }

        /// <summary>
        /// Initializes a new instance of the Contact class with specified values.
        /// </summary>
        /// <param name="name">The full name of the contact</param>
        /// <param name="phoneNumber">The phone number of the contact</param>
        /// <param name="email">The email address of the contact</param>
        /// <param name="address">The physical address of the contact</param>
        /// <exception cref="ArgumentNullException">Thrown when any parameter is null</exception>
        public Contact(string name, string phoneNumber, string email, string address)
        {
            // Validate input parameters to ensure they are not null
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            
            // Set default ID and last modified timestamp
            Id = 0;
            LastModified = DateTime.Now;
        }

        /// <summary>
        /// Initializes a new instance of the Contact class with all specified values including ID.
        /// </summary>
        /// <param name="id">The unique identifier for the contact</param>
        /// <param name="name">The full name of the contact</param>
        /// <param name="phoneNumber">The phone number of the contact</param>
        /// <param name="email">The email address of the contact</param>
        /// <param name="address">The physical address of the contact</param>
        /// <exception cref="ArgumentNullException">Thrown when any parameter is null</exception>
        public Contact(int id, string name, string phoneNumber, string email, string address)
        {
            // Validate input parameters to ensure they are not null
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            
            // Set the last modified timestamp to current time
            LastModified = DateTime.Now;
        }

        /// <summary>
        /// Returns a string representation of the contact information.
        /// Formats the contact data in a user-friendly display format.
        /// </summary>
        /// <returns>A formatted string containing all contact information</returns>
        public override string ToString()
        {
            // Format the contact information in a readable format
            // Include all fields with proper labels and formatting
            return $"ID: {Id}\nName: {Name}\nPhone: {PhoneNumber}\nEmail: {Email}\nAddress: {Address}\nLast Modified: {LastModified:yyyy-MM-dd HH:mm:ss}";
        }
    }
} 