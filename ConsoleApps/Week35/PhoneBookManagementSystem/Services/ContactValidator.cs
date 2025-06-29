using System.Text.RegularExpressions;
using PhoneBookManagementSystem.Interfaces;
using PhoneBookManagementSystem.Constants;
using PhoneBookManagementSystem.Enums;

namespace PhoneBookManagementSystem.Services
{
    /// <summary>
    /// Provides validation services for contact information in the phone book management system.
    /// This class implements the IValidator interface and provides comprehensive validation
    /// for all contact fields including names, phone numbers, email addresses, and addresses.
    /// 
    /// The validator uses regular expressions for pattern matching and centralized constants
    /// for validation rules, ensuring consistency across the application.
    /// </summary>
    public class ContactValidator : IValidator
    {
        /// <summary>
        /// Compiled regular expression for validating phone numbers.
        /// This regex pattern is compiled once for better performance when used repeatedly.
        /// </summary>
        private readonly Regex _phoneRegex = new Regex(RegexPatterns.PhoneNumberPattern, RegexOptions.Compiled);

        /// <summary>
        /// Compiled regular expression for validating email addresses.
        /// This regex pattern is compiled once for better performance when used repeatedly.
        /// </summary>
        private readonly Regex _emailRegex = new(RegexPatterns.EmailPattern, RegexOptions.Compiled);

        /// <summary>
        /// Validates a contact name according to the application's business rules.
        /// </summary>
        /// <param name="name">The name to validate.</param>
        /// <returns>True if the name is valid; false otherwise.</returns>
        /// <remarks>
        /// Validation rules for names:
        /// - Must not be null, empty, or whitespace-only
        /// - Must be between 2 and 50 characters in length
        /// - Length limits are defined in ApplicationConstants
        /// </remarks>
        public bool IsValidName(string name)
        {
            // Check for null, empty, or whitespace-only strings
            if (string.IsNullOrWhiteSpace(name))
                return false;

            // Validate length constraints using centralized constants
            return name.Length >= ApplicationConstants.MinNameLength && 
                   name.Length <= ApplicationConstants.MaxNameLength;
        }

        /// <summary>
        /// Validates a phone number according to international standards.
        /// </summary>
        /// <param name="phoneNumber">The phone number to validate.</param>
        /// <returns>True if the phone number is valid; false otherwise.</returns>
        /// <remarks>
        /// Phone number validation process:
        /// 1. Check for null or empty input
        /// 2. Remove common separators (spaces, dashes, parentheses)
        /// 3. Apply regex pattern validation
        /// 4. Ensure proper international format
        /// </remarks>
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            // Early validation: check for null or empty input
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            // Remove common separators that users might include
            // This makes the validation more user-friendly
            var cleanPhone = phoneNumber.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "");
            
            // Apply the compiled regex pattern for validation
            return _phoneRegex.IsMatch(cleanPhone);
        }

        /// <summary>
        /// Validates an email address format using regex pattern matching.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns>True if the email format is valid; false otherwise.</returns>
        /// <remarks>
        /// Email validation checks:
        /// - Not null or empty
        /// - Contains exactly one @ symbol
        /// - Valid characters before and after @
        /// - Proper domain structure
        /// </remarks>
        public bool IsValidEmail(string email)
        {
            // Check for null or empty input first
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Apply the compiled regex pattern for email validation
            return _emailRegex.IsMatch(email);
        }

        /// <summary>
        /// Validates a contact address according to length and content rules.
        /// </summary>
        /// <param name="address">The address to validate.</param>
        /// <returns>True if the address is valid; false otherwise.</returns>
        /// <remarks>
        /// Address validation rules:
        /// - Must not be null, empty, or whitespace-only
        /// - Must not exceed maximum length (200 characters)
        /// - Length limit is defined in ApplicationConstants
        /// </remarks>
        public bool IsValidAddress(string address)
        {
            // Check for null, empty, or whitespace-only strings
            if (string.IsNullOrWhiteSpace(address))
                return false;

            // Validate length constraint using centralized constant
            return address.Length <= ApplicationConstants.MaxAddressLength;
        }

        /// <summary>
        /// Validates all contact fields and returns a descriptive error message if validation fails.
        /// This method provides user-friendly error messages for validation failures.
        /// </summary>
        /// <param name="name">The contact name to validate.</param>
        /// <param name="phoneNumber">The phone number to validate.</param>
        /// <param name="email">The email address to validate.</param>
        /// <param name="address">The address to validate.</param>
        /// <returns>A descriptive error message if validation fails; null if all fields are valid.</returns>
        /// <remarks>
        /// Validation order:
        /// 1. Name validation (most critical)
        /// 2. Phone number validation
        /// 3. Email validation
        /// 4. Address validation
        /// 
        /// Returns the first validation error encountered.
        /// </remarks>
        public string? GetValidationError(string name, string phoneNumber, string email, string address)
        {
            // Validate name first as it's the primary identifier
            if (!IsValidName(name))
            {
                return string.Format(ApplicationConstants.NameValidationError, 
                    ApplicationConstants.MinNameLength, ApplicationConstants.MaxNameLength);
            }

            // Validate phone number format
            if (!IsValidPhoneNumber(phoneNumber))
            {
                return ApplicationConstants.PhoneValidationError;
            }

            // Validate email format
            if (!IsValidEmail(email))
            {
                return ApplicationConstants.EmailValidationError;
            }

            // Validate address length and content
            if (!IsValidAddress(address))
            {
                return string.Format(ApplicationConstants.AddressValidationError, ApplicationConstants.MaxAddressLength);
            }

            // All validations passed
            return null;
        }

        /// <summary>
        /// Validates all contact fields and returns a specific validation result enum.
        /// This method provides more granular feedback about which specific field failed validation.
        /// </summary>
        /// <param name="name">The contact name to validate.</param>
        /// <param name="phoneNumber">The phone number to validate.</param>
        /// <param name="email">The email address to validate.</param>
        /// <param name="address">The address to validate.</param>
        /// <returns>A ValidationResult enum value indicating the validation outcome.</returns>
        /// <remarks>
        /// This method is useful for:
        /// - Programmatic validation handling
        /// - Detailed error reporting
        /// - Conditional logic based on specific validation failures
        /// - Unit testing validation scenarios
        /// </remarks>
        public ValidationResult ValidateContact(string name, string phoneNumber, string email, string address)
        {
            // Check for empty input first (most general validation failure)
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phoneNumber) || 
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(address))
            {
                return ValidationResult.EmptyInput;
            }

            // Validate each field individually and return specific failure type
            if (!IsValidName(name))
                return ValidationResult.InvalidName;

            if (!IsValidPhoneNumber(phoneNumber))
                return ValidationResult.InvalidPhoneNumber;

            if (!IsValidEmail(email))
                return ValidationResult.InvalidEmail;

            if (!IsValidAddress(address))
                return ValidationResult.InvalidAddress;

            // All validations passed
            return ValidationResult.Valid;
        }
    }
} 