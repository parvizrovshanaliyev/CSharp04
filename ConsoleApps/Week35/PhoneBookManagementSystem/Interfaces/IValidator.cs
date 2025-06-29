using PhoneBookManagementSystem.Enums;

namespace PhoneBookManagementSystem.Interfaces
{
    /// <summary>
    /// Defines the contract for contact validation operations.
    /// This interface provides methods to validate individual contact fields
    /// and complete contact objects, ensuring data integrity throughout the application.
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Validates a contact name according to the application's rules.
        /// </summary>
        /// <param name="name">The name to validate.</param>
        /// <returns>True if the name is valid; false otherwise.</returns>
        /// <remarks>
        /// A valid name must:
        /// - Not be null or empty
        /// - Be between 2 and 50 characters in length
        /// - Not consist only of whitespace
        /// </remarks>
        bool IsValidName(string name);

        /// <summary>
        /// Validates a phone number according to international standards.
        /// </summary>
        /// <param name="phoneNumber">The phone number to validate.</param>
        /// <returns>True if the phone number is valid; false otherwise.</returns>
        /// <remarks>
        /// A valid phone number must:
        /// - Not be null or empty
        /// - Start with an optional plus sign
        /// - Have a first digit between 1-9 (no leading zero)
        /// - Contain 1-15 total digits
        /// - Common separators (spaces, dashes, parentheses) are automatically removed
        /// </remarks>
        bool IsValidPhoneNumber(string phoneNumber);

        /// <summary>
        /// Validates an email address format.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns>True if the email format is valid; false otherwise.</returns>
        /// <remarks>
        /// A valid email must:
        /// - Not be null or empty
        /// - Contain exactly one @ symbol
        /// - Have valid characters before and after the @ symbol
        /// - Have a valid domain structure with at least one dot
        /// </remarks>
        bool IsValidEmail(string email);

        /// <summary>
        /// Validates a contact address.
        /// </summary>
        /// <param name="address">The address to validate.</param>
        /// <returns>True if the address is valid; false otherwise.</returns>
        /// <remarks>
        /// A valid address must:
        /// - Not be null or empty
        /// - Not exceed 200 characters in length
        /// - Not consist only of whitespace
        /// </remarks>
        bool IsValidAddress(string address);

        /// <summary>
        /// Validates all contact fields and returns a descriptive error message if validation fails.
        /// </summary>
        /// <param name="name">The contact name to validate.</param>
        /// <param name="phoneNumber">The phone number to validate.</param>
        /// <param name="email">The email address to validate.</param>
        /// <param name="address">The address to validate.</param>
        /// <returns>A descriptive error message if validation fails; null if all fields are valid.</returns>
        string? GetValidationError(string name, string phoneNumber, string email, string address);

        /// <summary>
        /// Validates all contact fields and returns a specific validation result.
        /// This method provides more granular feedback about which specific field failed validation.
        /// </summary>
        /// <param name="name">The contact name to validate.</param>
        /// <param name="phoneNumber">The phone number to validate.</param>
        /// <param name="email">The email address to validate.</param>
        /// <param name="address">The address to validate.</param>
        /// <returns>A ValidationResult enum value indicating the validation outcome.</returns>
        ValidationResult ValidateContact(string name, string phoneNumber, string email, string address);
    }
} 