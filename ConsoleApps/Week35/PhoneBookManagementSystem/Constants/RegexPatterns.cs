namespace PhoneBookManagementSystem.Constants
{
    /// <summary>
    /// Contains regular expression patterns used for validation throughout the application.
    /// These patterns are centralized to ensure consistency and make maintenance easier.
    /// All regex patterns are compiled for better performance when used repeatedly.
    /// </summary>
    public static class RegexPatterns
    {
        /// <summary>
        /// Regular expression pattern for validating phone numbers.
        /// 
        /// Pattern breakdown:
        /// - ^[\+]? - Start of string, optional plus sign
        /// - [1-9] - First digit must be 1-9 (no leading zero)
        /// - [\d]{0,15} - Followed by 0 to 15 digits
        /// - $ - End of string
        /// 
        /// Examples of valid phone numbers:
        /// - +1234567890
        /// - 1234567890
        /// - +1-555-0123 (after removing separators)
        /// </summary>
        public const string PhoneNumberPattern = @"^[\+]?[1-9][\d]{0,15}$";

        /// <summary>
        /// Regular expression pattern for validating email addresses.
        /// 
        /// Pattern breakdown:
        /// - ^[^@\s]+ - Start of string, one or more characters that are not @ or whitespace
        /// - @ - Literal @ symbol
        /// - [^@\s]+ - One or more characters that are not @ or whitespace (domain name)
        /// - \. - Literal dot
        /// - [^@\s]+ - One or more characters that are not @ or whitespace (top-level domain)
        /// - $ - End of string
        /// 
        /// Examples of valid email addresses:
        /// - user@domain.com
        /// - test.email@subdomain.example.org
        /// - user+tag@domain.co.uk
        /// </summary>
        public const string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
    }
} 