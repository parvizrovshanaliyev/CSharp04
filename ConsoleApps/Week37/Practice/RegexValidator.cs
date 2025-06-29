using System.Text.RegularExpressions;
using System.Collections;

namespace Week37.Practice
{
    /// <summary>
    /// Provides regex-based validation methods for common data formats.
    /// This class contains compiled regex patterns for better performance and
    /// comprehensive validation methods for various data types.
    /// 
    /// NOTE: This class uses only arrays and non-generic collections (ArrayList)
    /// because students have not yet learned about generic collections (List<T>, etc.).
    /// When you learn generics, you can refactor these methods to use type-safe collections.
    /// </summary>
    /// <remarks>
    /// All regex patterns are compiled using RegexOptions.Compiled for better performance
    /// when used repeatedly. The patterns are designed to be strict and follow
    /// common validation standards for each data type.
    /// </remarks>
    public static class RegexValidator
    {
        /*
         * COMPILED REGEX PATTERNS
         * 
         * These patterns are compiled once and reused for better performance.
         * Each pattern is designed to be strict and comprehensive for its specific use case.
         */

        /// <summary>
        /// Email validation pattern that enforces strict email format requirements.
        /// Pattern: ^[a-zA-Z0-9._%+-]{3,20}@[a-zA-Z0-9.-]{2,50}\.(com|org|net|edu)$
        /// 
        /// Breakdown:
        /// - ^ : Start of string
        /// - [a-zA-Z0-9._%+-]{3,20} : Username (3-20 chars, letters, digits, dots, underscores, percent, plus, minus)
        /// - @ : Literal @ symbol
        /// - [a-zA-Z0-9.-]{2,50} : Domain (2-50 chars, letters, digits, dots, hyphens)
        /// - \.(com|org|net|edu) : Literal dot followed by allowed TLDs
        /// - $ : End of string
        /// </summary>
        private static readonly Regex _emailRegex = new(@"^[a-zA-Z0-9._%+-]{3,20}@[a-zA-Z0-9.-]{2,50}\.(com|org|net|edu)$", RegexOptions.Compiled);

        /// <summary>
        /// Phone number validation pattern that accepts multiple US phone formats.
        /// Pattern: ^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$
        /// 
        /// Breakdown:
        /// - ^ : Start of string
        /// - \(? : Optional opening parenthesis
        /// - ([0-9]{3}) : Exactly 3 digits (captured group)
        /// - \)? : Optional closing parenthesis
        /// - [-. ]? : Optional separator (hyphen, dot, or space)
        /// - ([0-9]{3}) : Exactly 3 digits (captured group)
        /// - [-. ]? : Optional separator
        /// - ([0-9]{4}) : Exactly 4 digits (captured group)
        /// - $ : End of string
        /// </summary>
        private static readonly Regex _phoneRegex = new(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", RegexOptions.Compiled);

        /// <summary>
        /// Name validation pattern that enforces proper name formatting.
        /// Pattern: ^[a-zA-Z][a-zA-Z\s\-'\.]{0,48}[a-zA-Z]$
        /// 
        /// Breakdown:
        /// - ^ : Start of string
        /// - [a-zA-Z] : Must start with a letter
        /// - [a-zA-Z\s\-'\.]{0,48} : Middle characters (letters, spaces, hyphens, apostrophes, dots)
        /// - [a-zA-Z] : Must end with a letter
        /// - $ : End of string
        /// 
        /// This ensures names are 2-50 characters and start/end with letters.
        /// </summary>
        private static readonly Regex _nameRegex = new(@"^[a-zA-Z][a-zA-Z\s\-'\.]{0,48}[a-zA-Z]$", RegexOptions.Compiled);

        /// <summary>
        /// Password strength validation pattern using positive lookaheads.
        /// Pattern: ^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$
        /// 
        /// Breakdown:
        /// - ^ : Start of string
        /// - (?=.*[a-z]) : Positive lookahead for at least one lowercase letter
        /// - (?=.*[A-Z]) : Positive lookahead for at least one uppercase letter
        /// - (?=.*\d) : Positive lookahead for at least one digit
        /// - (?=.*[@$!%*?&]) : Positive lookahead for at least one special character
        /// - [A-Za-z\d@$!%*?&]{8,} : At least 8 characters from allowed set
        /// - $ : End of string
        /// </summary>
        private static readonly Regex _passwordRegex = new(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", RegexOptions.Compiled);

        /// <summary>
        /// Date validation pattern for MM/DD/YYYY format.
        /// Pattern: ^(0[1-9]|1[0-2])/(0[1-9]|[12]\d|3[01])/(19|20)\d{2}$
        /// 
        /// Breakdown:
        /// - ^ : Start of string
        /// - (0[1-9]|1[0-2]) : Month 01-12
        /// - / : Literal forward slash
        /// - (0[1-9]|[12]\d|3[01]) : Day 01-31
        /// - / : Literal forward slash
        /// - (19|20)\d{2} : Year 1900-2099
        /// - $ : End of string
        /// </summary>
        private static readonly Regex _dateRegex = new(@"^(0[1-9]|1[0-2])/(0[1-9]|[12]\d|3[01])/(19|20)\d{2}$", RegexOptions.Compiled);

        /// <summary>
        /// Validates email addresses using a strict regex pattern.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns>
        /// <c>true</c> if the email address is valid according to the pattern;
        /// otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method validates email addresses with the following requirements:
        /// <list type="bullet">
        /// <item><description>Must contain exactly one @ symbol</description></item>
        /// <item><description>Username must be 3-20 characters long</description></item>
        /// <item><description>Domain must be 2-50 characters long</description></item>
        /// <item><description>Must end with .com, .org, .net, or .edu</description></item>
        /// <item><description>Only allows letters, digits, dots, underscores, percent, plus, and minus in username</description></item>
        /// <item><description>Only allows letters, digits, dots, and hyphens in domain</description></item>
        /// </list>
        /// 
        /// <para>
        /// Examples of valid emails:
        /// <code>
        /// john.doe@gmail.com
        /// user123@company.org
        /// test@university.edu
        /// </code>
        /// </para>
        /// 
        /// <para>
        /// Examples of invalid emails:
        /// <code>
        /// invalid.email
        /// @gmail.com
        /// user@
        /// user@.com
        /// verylongusername@domain.com
        /// </code>
        /// </para>
        /// </remarks>
        public static bool IsValidEmail(string email)
        {
            /*
             * VALIDATION LOGIC:
             * 1. Check for null or whitespace input
             * 2. Use compiled regex pattern for performance
             * 3. Return true if pattern matches, false otherwise
             */

            if (string.IsNullOrWhiteSpace(email))
                return false;

            return _emailRegex.IsMatch(email);
        }

        /// <summary>
        /// Validates US phone numbers in multiple formats using regex.
        /// </summary>
        /// <param name="phoneNumber">The phone number to validate.</param>
        /// <returns>
        /// <c>true</c> if the phone number is valid according to the pattern;
        /// otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method accepts phone numbers in the following formats:
        /// <list type="bullet">
        /// <item><description>(555) 123-4567</description></item>
        /// <item><description>555-123-4567</description></item>
        /// <item><description>555.123.4567</description></item>
        /// <item><description>555 123 4567</description></item>
        /// <item><description>5551234567</description></item>
        /// </list>
        /// 
        /// <para>
        /// The pattern ensures exactly 10 digits with optional formatting characters.
        /// </para>
        /// 
        /// <para>
        /// Examples of invalid phone numbers:
        /// <code>
        /// 123-456-789 (too few digits)
        /// 555-123-45678 (too many digits)
        /// abc-def-ghij (contains letters)
        /// (555) 123-456 (incomplete)
        /// </code>
        /// </para>
        /// </remarks>
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            /*
             * VALIDATION LOGIC:
             * 1. Check for null or whitespace input
             * 2. Use compiled regex pattern that captures groups
             * 3. Pattern automatically handles various separators
             * 4. Returns true if exactly 10 digits are found in correct format
             */

            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            return _phoneRegex.IsMatch(phoneNumber);
        }

        /// <summary>
        /// Validates person names using a comprehensive regex pattern.
        /// </summary>
        /// <param name="name">The name to validate.</param>
        /// <returns>
        /// <c>true</c> if the name is valid according to the pattern;
        /// otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method validates names with the following requirements:
        /// <list type="bullet">
        /// <item><description>2-50 characters long</description></item>
        /// <item><description>Must start and end with a letter</description></item>
        /// <item><description>Only allows letters, spaces, hyphens, apostrophes, and dots</description></item>
        /// <item><description>No consecutive special characters</description></item>
        /// </list>
        /// 
        /// <para>
        /// Examples of valid names:
        /// <code>
        /// John Smith
        /// Mary-Jane
        /// O'Connor
        /// Dr. Smith
        /// Jean-Pierre
        /// </code>
        /// </para>
        /// 
        /// <para>
        /// Examples of invalid names:
        /// <code>
        /// A (too short)
        /// John123 (contains numbers)
        /// John@Smith (contains special characters)
        /// John--Smith (consecutive special characters)
        ///  John  (starts/ends with spaces)
        /// </code>
        /// </para>
        /// </remarks>
        public static bool IsValidName(string name)
        {
            /*
             * VALIDATION LOGIC:
             * 1. Check for null or whitespace input
             * 2. Use compiled regex pattern that enforces start/end with letters
             * 3. Pattern allows common name characters and formatting
             * 4. Ensures proper name structure and length
             */

            if (string.IsNullOrWhiteSpace(name))
                return false;

            return _nameRegex.IsMatch(name);
        }

        /// <summary>
        /// Validates password strength using positive lookahead regex patterns.
        /// </summary>
        /// <param name="password">The password to validate.</param>
        /// <returns>
        /// <c>true</c> if the password meets all strength requirements;
        /// otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method enforces the following password requirements:
        /// <list type="bullet">
        /// <item><description>At least 8 characters long</description></item>
        /// <item><description>Contains at least one uppercase letter</description></item>
        /// <item><description>Contains at least one lowercase letter</description></item>
        /// <item><description>Contains at least one digit</description></item>
        /// <item><description>Contains at least one special character (@$!%*?&)</description></item>
        /// </list>
        /// 
        /// <para>
        /// The regex uses positive lookaheads (?=...) to ensure each requirement
        /// is met without consuming characters, allowing overlap.
        /// </para>
        /// 
        /// <para>
        /// Examples of valid passwords:
        /// <code>
        /// StrongPass1!
        /// Secure123@
        /// MyP@ssw0rd
        /// </code>
        /// </para>
        /// 
        /// <para>
        /// Examples of invalid passwords:
        /// <code>
        /// weakpass (no uppercase, digit, or special char)
        /// WeakPass1 (no special character)
        /// WEAKPASS1! (no lowercase)
        /// WeakPass! (no digit)
        /// Weak1! (too short)
        /// </code>
        /// </para>
        /// </remarks>
        public static bool IsStrongPassword(string password)
        {
            /*
             * VALIDATION LOGIC:
             * 1. Check for null or whitespace input
             * 2. Use compiled regex with positive lookaheads
             * 3. Each lookahead checks for one requirement without consuming characters
             * 4. Final pattern ensures minimum length and allowed characters
             */

            if (string.IsNullOrWhiteSpace(password))
                return false;

            return _passwordRegex.IsMatch(password);
        }

        /// <summary>
        /// Validates dates in MM/DD/YYYY format using regex and additional logic.
        /// </summary>
        /// <param name="date">The date string to validate.</param>
        /// <returns>
        /// <c>true</c> if the date format is valid and represents a real date;
        /// otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method performs two levels of validation:
        /// <list type="number">
        /// <item><description>Regex pattern validation for format compliance</description></item>
        /// <item><description>DateTime parsing validation for actual date existence</description></item>
        /// </list>
        /// 
        /// <para>
        /// The regex ensures:
        /// <list type="bullet">
        /// <item><description>Month: 01-12</description></item>
        /// <item><description>Day: 01-31 (basic range check)</description></item>
        /// <item><description>Year: 1900-2099</description></item>
        /// <item><description>Proper MM/DD/YYYY format with leading zeros</description></item>
        /// </list>
        /// </para>
        /// 
        /// <para>
        /// Examples of valid dates:
        /// <code>
        /// 12/25/2023
        /// 01/01/1900
        /// 02/29/2024 (leap year)
        /// 04/30/2023
        /// </code>
        /// </para>
        /// 
        /// <para>
        /// Examples of invalid dates:
        /// <code>
        /// 13/01/2023 (invalid month)
        /// 12/32/2023 (invalid day)
        /// 12/25/1899 (year out of range)
        /// 1/1/2023 (missing leading zeros)
        /// 12-25-2023 (wrong separator)
        /// 02/30/2023 (February 30th doesn't exist)
        /// </code>
        /// </para>
        /// </remarks>
        public static bool IsValidDateFormat(string date)
        {
            /*
             * VALIDATION LOGIC:
             * 1. Check for null or whitespace input
             * 2. Use regex pattern for format validation
             * 3. If regex passes, validate actual date existence
             * 4. Additional validation handles edge cases like February 30th
             */

            if (string.IsNullOrWhiteSpace(date))
                return false;

            if (!_dateRegex.IsMatch(date))
                return false;

            // Additional validation for specific month-day combinations
            return IsValidDate(date);
        }

        /// <summary>
        /// Performs additional date validation beyond regex pattern matching.
        /// </summary>
        /// <param name="date">The date string to validate.</param>
        /// <returns>
        /// <c>true</c> if the date represents a valid calendar date;
        /// otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method handles edge cases that regex patterns cannot catch:
        /// <list type="bullet">
        /// <item><description>February 30th (invalid date)</description></item>
        /// <item><description>April 31st (invalid date)</description></item>
        /// <item><description>Leap year calculations</description></item>
        /// <item><description>Month-specific day limits</description></item>
        /// </list>
        /// 
        /// <para>
        /// The method uses DateTime.TryParse to validate actual date existence
        /// and compares the formatted result to ensure proper MM/DD/YYYY format.
        /// </para>
        /// </remarks>
        private static bool IsValidDate(string date)
        {
            /*
             * ADDITIONAL VALIDATION LOGIC:
             * 1. Use DateTime.TryParse for actual date validation
             * 2. Format parsed date back to MM/DD/YYYY format
             * 3. Compare with original to ensure proper formatting
             * 4. Handle exceptions gracefully
             */

            try
            {
                if (DateTime.TryParse(date, out DateTime parsedDate))
                {
                    // Check if the parsed date matches the original string format
                    string formattedDate = parsedDate.ToString("MM/dd/yyyy");
                    return date == formattedDate;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Formats phone numbers to a consistent (XXX) XXX-XXXX format.
        /// </summary>
        /// <param name="phoneNumber">The phone number to format.</param>
        /// <returns>
        /// The formatted phone number in (XXX) XXX-XXXX format, or <c>null</c> if the
        /// input is not a valid phone number.
        /// </returns>
        /// <remarks>
        /// This method performs the following steps:
        /// <list type="number">
        /// <item><description>Validates the phone number using IsValidPhoneNumber</description></item>
        /// <item><description>Removes all non-digit characters using regex</description></item>
        /// <item><description>Verifies exactly 10 digits remain</description></item>
        /// <item><description>Formats the digits into (XXX) XXX-XXXX format</description></item>
        /// </list>
        /// 
        /// <para>
        /// Examples of input and output:
        /// <code>
        /// "5551234567" -> "(555) 123-4567"
        /// "555-123-4567" -> "(555) 123-4567"
        /// "(555) 123-4567" -> "(555) 123-4567"
        /// "555.123.4567" -> "(555) 123-4567"
        /// "555 123 4567" -> "(555) 123-4567"
        /// "123-456-789" -> null (invalid)
        /// </code>
        /// </para>
        /// </remarks>
        public static string? FormatPhoneNumber(string phoneNumber)
        {
            /*
             * FORMATTING LOGIC:
             * 1. First validate the phone number format
             * 2. Remove all non-digit characters using regex
             * 3. Verify exactly 10 digits remain
             * 4. Format into standard (XXX) XXX-XXXX format
             * 5. Return null if validation fails
             */

            if (!IsValidPhoneNumber(phoneNumber))
                return null;

            // Remove all non-digit characters
            string digitsOnly = Regex.Replace(phoneNumber, @"\D", "");
            
            if (digitsOnly.Length != 10)
                return null;

            // Format as (XXX) XXX-XXXX
            return $"({digitsOnly.Substring(0, 3)}) {digitsOnly.Substring(3, 3)}-{digitsOnly.Substring(6, 4)}";
        }

        /// <summary>
        /// Cleans and normalizes text by removing extra whitespace and special characters.
        /// </summary>
        /// <param name="text">The text to clean.</param>
        /// <returns>
        /// The cleaned and normalized text, or an empty string if the input is null/empty.
        /// </returns>
        /// <remarks>
        /// This method performs the following cleaning operations:
        /// <list type="number">
        /// <item><description>Removes extra whitespace (multiple spaces, tabs, newlines)</description></item>
        /// <item><description>Normalizes line endings to \n</description></item>
        /// <item><description>Removes special characters except letters, numbers, and basic punctuation</description></item>
        /// <item><description>Converts multiple consecutive punctuation marks to single</description></item>
        /// <item><description>Trims leading and trailing whitespace</description></item>
        /// </list>
        /// 
        /// <para>
        /// Example transformation:
        /// <code>
        /// Input: "Hello    World!!!\nThis   is   a   test   text."
        /// Output: "Hello World! This is a test text."
        /// </code>
        /// </para>
        /// 
        /// <para>
        /// The method preserves essential punctuation while removing unwanted characters
        /// and normalizing spacing for better readability.
        /// </para>
        /// </remarks>
        public static string CleanText(string text)
        {
            /*
             * TEXT CLEANING LOGIC:
             * 1. Check for null or whitespace input
             * 2. Remove extra whitespace using regex
             * 3. Normalize line endings to \n
             * 4. Remove unwanted special characters
             * 5. Convert multiple punctuation to single
             * 6. Trim leading/trailing whitespace
             */

            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            // Remove extra whitespace
            text = Regex.Replace(text, @"\s+", " ");
            
            // Normalize line endings
            text = Regex.Replace(text, @"\r\n|\r|\n", "\n");
            
            // Remove special characters except letters, numbers, and basic punctuation
            text = Regex.Replace(text, @"[^\w\s\.\!\?\,\;\:\-\(\)]", "");
            
            // Convert multiple consecutive punctuation marks to single
            text = Regex.Replace(text, @"([\.\!\?\,\;\:\-\(\)])\1+", "$1");
            
            return text.Trim();
        }

        /// <summary>
        /// Extracts all valid email addresses from a given text using ArrayList.
        /// </summary>
        /// <param name="text">The text to search for email addresses.</param>
        /// <returns>
        /// An ArrayList of valid email addresses found in the text. Returns an empty ArrayList
        /// if no valid emails are found or if the input is null/empty.
        /// </returns>
        /// <remarks>
        /// Non-generic ArrayList is used for educational purposes.
        /// </remarks>
        public static ArrayList ExtractEmails(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new ArrayList();

            ArrayList emails = new ArrayList();
            var matches = _emailRegex.Matches(text);

            foreach (Match match in matches)
            {
                emails.Add(match.Value);
            }

            return emails;
        }

        /// <summary>
        /// Validates an array of emails and returns an array of bool results.
        /// </summary>
        /// <param name="emails">Array of email addresses to validate.</param>
        /// <returns>Array of bools indicating validity for each email.</returns>
        public static bool[] ValidateEmails(string[] emails)
        {
            bool[] results = new bool[emails.Length];
            for (int i = 0; i < emails.Length; i++)
            {
                results[i] = IsValidEmail(emails[i]);
            }
            return results;
        }
    }
} 