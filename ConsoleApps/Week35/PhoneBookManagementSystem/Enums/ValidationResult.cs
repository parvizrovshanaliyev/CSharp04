namespace PhoneBookManagementSystem.Enums
{
    /// <summary>
    /// Represents the result of contact validation operations.
    /// This enum provides detailed feedback about what specific validation failed,
    /// allowing for more precise error handling and user feedback.
    /// </summary>
    public enum ValidationResult
    {
        /// <summary>
        /// Indicates that all validation checks passed successfully.
        /// The contact data is valid and can be processed.
        /// </summary>
        Valid,

        /// <summary>
        /// Indicates that the contact name failed validation.
        /// Usually means the name is too short, too long, or empty.
        /// </summary>
        InvalidName,

        /// <summary>
        /// Indicates that the phone number failed validation.
        /// Usually means the format is not recognized as a valid phone number.
        /// </summary>
        InvalidPhoneNumber,

        /// <summary>
        /// Indicates that the email address failed validation.
        /// Usually means the email format is not valid.
        /// </summary>
        InvalidEmail,

        /// <summary>
        /// Indicates that the address failed validation.
        /// Usually means the address is empty or too long.
        /// </summary>
        InvalidAddress,

        /// <summary>
        /// Indicates that one or more required fields are empty or null.
        /// This is a general validation failure for missing data.
        /// </summary>
        EmptyInput
    }
} 