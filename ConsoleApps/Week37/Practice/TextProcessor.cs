using System.Text.RegularExpressions;
using System.Collections;

namespace Week37.Practice
{
    /// <summary>
    /// Provides advanced text processing methods using regex patterns.
    /// This class contains specialized methods for parsing, validating, and transforming
    /// various data formats commonly encountered in real-world applications.
    /// 
    /// NOTE: This class uses only arrays and non-generic collections (ArrayList, Hashtable)
    /// because students have not yet learned about generic collections (List<T>, Dictionary<K,V>, etc.).
    /// When you learn generics, you can refactor these methods to use type-safe collections.
    /// </summary>
    /// <remarks>
    /// The TextProcessor class focuses on complex text processing tasks that go beyond
    /// simple validation. It includes methods for parsing structured data, extracting
    /// information from text, and performing advanced transformations.
    /// 
    /// <para>
    /// All regex patterns are compiled for performance and include comprehensive
    /// validation logic for edge cases and real-world scenarios.
    /// </para>
    /// </remarks>
    public static class TextProcessor
    {
        /*
         * COMPILED REGEX PATTERNS FOR ADVANCED TEXT PROCESSING
         * 
         * These patterns are designed for complex parsing and validation tasks.
         * Each pattern includes comprehensive validation for real-world data scenarios.
         */

        /// <summary>
        /// Log entry parsing pattern for structured log files.
        /// Pattern: ^\[(\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2})\] (\w+): (.+)$
        /// 
        /// Breakdown:
        /// - ^ : Start of string
        /// - \[ : Literal opening bracket
        /// - (\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}) : Timestamp (captured group 1)
        /// - \] : Literal closing bracket
        /// - (\w+) : Log level (captured group 2)
        /// - : : Literal colon and space
        /// - (.+) : Message content (captured group 3)
        /// - $ : End of string
        /// </summary>
        private static readonly Regex _logEntryRegex = new(@"^\[(\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2})\] (\w+): (.+)$", RegexOptions.Compiled);

        /// <summary>
        /// URL validation pattern for HTTP/HTTPS URLs.
        /// Pattern: ^https?://[^\s/$.?#].[^\s]*$
        /// 
        /// Breakdown:
        /// - ^ : Start of string
        /// - https? : http or https
        /// - :// : Literal protocol separator
        /// - [^\s/$.?#] : First character cannot be whitespace, /, $, ., ?, #
        /// - [^\s]* : Remaining characters cannot be whitespace
        /// - $ : End of string
        /// </summary>
        private static readonly Regex _urlRegex = new(@"^https?://[^\s/$.?#].[^\s]*$", RegexOptions.Compiled);

        /// <summary>
        /// Social Security Number validation pattern with business rules.
        /// Pattern: ^(?!000|666|9\d{2})\d{3}-(?!00)\d{2}-(?!0000)\d{4}$
        /// 
        /// Breakdown:
        /// - ^ : Start of string
        /// - (?!000|666|9\d{2}) : Negative lookahead - cannot start with 000, 666, or 900-999
        /// - \d{3} : Exactly 3 digits
        /// - - : Literal hyphen
        /// - (?!00) : Negative lookahead - middle group cannot be 00
        /// - \d{2} : Exactly 2 digits
        /// - - : Literal hyphen
        /// - (?!0000) : Negative lookahead - last group cannot be 0000
        /// - \d{4} : Exactly 4 digits
        /// - $ : End of string
        /// </summary>
        private static readonly Regex _ssnRegex = new(@"^(?!000|666|9\d{2})\d{3}-(?!00)\d{2}-(?!0000)\d{4}$", RegexOptions.Compiled);

        /// <summary>
        /// IPv4 address validation pattern with proper octet ranges.
        /// Pattern: ^((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(25[0-5]|2[0-4]\d|[01]?\d\d?)$
        /// 
        /// Breakdown:
        /// - ^ : Start of string
        /// - (25[0-5]|2[0-4]\d|[01]?\d\d?) : Octet pattern (0-255)
        ///   - 25[0-5] : 250-255
        ///   - 2[0-4]\d : 200-249
        ///   - [01]?\d\d? : 0-199
        /// - \. : Literal dot
        /// - {3} : Exactly 3 times (for first 3 octets)
        /// - (25[0-5]|2[0-4]\d|[01]?\d\d?) : Last octet
        /// - $ : End of string
        /// </summary>
        private static readonly Regex _ipAddressRegex = new(@"^((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(25[0-5]|2[0-4]\d|[01]?\d\d?)$", RegexOptions.Compiled);

        /// <summary>
        /// 24-hour time format validation pattern.
        /// Pattern: ^([01]\d|2[0-3]):([0-5]\d)$
        /// 
        /// Breakdown:
        /// - ^ : Start of string
        /// - ([01]\d|2[0-3]) : Hours (00-23)
        ///   - [01]\d : 00-19
        ///   - 2[0-3] : 20-23
        /// - : : Literal colon
        /// - ([0-5]\d) : Minutes (00-59)
        /// - $ : End of string
        /// </summary>
        private static readonly Regex _timeRegex = new(@"^([01]\d|2[0-3]):([0-5]\d)$", RegexOptions.Compiled);

        /// <summary>
        /// US ZIP code validation pattern supporting both 5-digit and 9-digit formats.
        /// Pattern: ^\d{5}(-\d{4})?$
        /// 
        /// Breakdown:
        /// - ^ : Start of string
        /// - \d{5} : Exactly 5 digits
        /// - (-\d{4})? : Optional hyphen followed by exactly 4 digits
        /// - $ : End of string
        /// </summary>
        private static readonly Regex _zipCodeRegex = new(@"^\d{5}(-\d{4})?$", RegexOptions.Compiled);

        /// <summary>
        /// Represents a parsed log entry with structured data.
        /// </summary>
        /// <remarks>
        /// This class encapsulates the components of a log entry after parsing:
        /// <list type="bullet">
        /// <item><description>Timestamp: The exact date and time of the log entry</description></item>
        /// <item><description>Level: The log level (INFO, WARNING, ERROR, DEBUG, etc.)</description></item>
        /// <item><description>Message: The actual log message content</description></item>
        /// </list>
        /// 
        /// <para>
        /// The ToString method provides a formatted representation of the log entry
        /// in the original format for easy output and debugging.
        /// </para>
        /// </remarks>
        public class LogEntry
        {
            /// <summary>
            /// Gets or sets the timestamp of the log entry.
            /// </summary>
            public DateTime Timestamp { get; set; }

            /// <summary>
            /// Gets or sets the log level (e.g., INFO, WARNING, ERROR, DEBUG).
            /// </summary>
            public string Level { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the log message content.
            /// </summary>
            public string Message { get; set; } = string.Empty;

            /// <summary>
            /// Returns a formatted string representation of the log entry.
            /// </summary>
            /// <returns>A string in the format "[YYYY-MM-DD HH:MM:SS] LEVEL: Message"</returns>
            public override string ToString()
            {
                return $"[{Timestamp:yyyy-MM-dd HH:mm:ss}] {Level}: {Message}";
            }
        }

        /// <summary>
        /// Represents the components of a parsed URL.
        /// </summary>
        /// <remarks>
        /// This class breaks down a URL into its constituent parts for analysis
        /// and manipulation. It provides a structured way to work with URL components.
        /// 
        /// <para>
        /// The ToString method reconstructs the URL from its components, ensuring
        /// proper formatting and handling of optional query parameters.
        /// </para>
        /// </remarks>
        public class UrlComponents
        {
            /// <summary>
            /// Gets or sets the URL protocol (e.g., "http", "https").
            /// </summary>
            public string Protocol { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the domain name (e.g., "www.example.com").
            /// </summary>
            public string Domain { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the URL path (e.g., "/path/to/resource").
            /// </summary>
            public string Path { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the query string parameters (without the leading "?").
            /// </summary>
            public string Query { get; set; } = string.Empty;

            /// <summary>
            /// Returns a reconstructed URL string from the components.
            /// </summary>
            /// <returns>A properly formatted URL string</returns>
            public override string ToString()
            {
                var url = $"{Protocol}://{Domain}{Path}";
                return string.IsNullOrEmpty(Query) ? url : $"{url}?{Query}";
            }
        }

        /// <summary>
        /// Parses log entries from a text containing multiple log lines.
        /// Returns an ArrayList of LogEntry objects.
        /// </summary>
        public static ArrayList ParseLogEntries(string logText)
        {
            ArrayList entries = new ArrayList();
            if (string.IsNullOrWhiteSpace(logText))
                return entries;
            var lines = logText.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var match = _logEntryRegex.Match(line.Trim());
                if (match.Success)
                {
                    var entry = new LogEntry
                    {
                        Timestamp = DateTime.Parse(match.Groups[1].Value),
                        Level = match.Groups[2].Value,
                        Message = match.Groups[3].Value
                    };
                    entries.Add(entry);
                }
            }
            return entries;
        }

        /// <summary>
        /// Validates and parses URLs into their component parts.
        /// </summary>
        /// <param name="url">The URL to validate and parse.</param>
        /// <returns>
        /// A UrlComponents object containing the parsed URL parts, or <c>null</c>
        /// if the URL is invalid or cannot be parsed.
        /// </returns>
        /// <remarks>
        /// This method performs comprehensive URL validation and parsing:
        /// <list type="number">
        /// <item><description>Validates URL format using regex pattern</description></item>
        /// <item><description>Parses URL using System.Uri for component extraction</description></item>
        /// <item><description>Extracts protocol, domain, path, and query components</description></item>
        /// <item><description>Handles various URL formats and edge cases</description></item>
        /// </list>
        /// 
        /// <para>
        /// Supported URL formats:
        /// <list type="bullet">
        /// <item><description>https://www.example.com</description></item>
        /// <item><description>http://example.com/path</description></item>
        /// <item><description>https://example.com/path?param=value</description></item>
        /// <item><description>https://subdomain.example.com:8080/path</description></item>
        /// </list>
        /// </para>
        /// 
        /// <para>
        /// The method uses both regex validation and System.Uri parsing to ensure
        /// comprehensive validation and accurate component extraction.
        /// </para>
        /// </remarks>
        public static UrlComponents? ParseUrl(string url)
        {
            /*
             * URL PARSING LOGIC:
             * 1. Check for null or whitespace input
             * 2. Validate URL format using regex pattern
             * 3. Use System.Uri for reliable component extraction
             * 4. Extract protocol, host, path, and query components
             * 5. Create UrlComponents object with extracted data
             * 6. Handle parsing exceptions gracefully
             */

            if (string.IsNullOrWhiteSpace(url) || !_urlRegex.IsMatch(url))
                return null;

            try
            {
                var uri = new Uri(url);
                return new UrlComponents
                {
                    Protocol = uri.Scheme,
                    Domain = uri.Host,
                    Path = uri.AbsolutePath,
                    Query = uri.Query.TrimStart('?')
                };
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Validates US Social Security Numbers with business rule enforcement.
        /// </summary>
        /// <param name="ssn">The SSN to validate.</param>
        /// <returns>
        /// <c>true</c> if the SSN is valid according to business rules;
        /// otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method enforces strict SSN validation rules:
        /// <list type="bullet">
        /// <item><description>Format: XXX-XX-XXXX (exactly 9 digits with hyphens)</description></item>
        /// <item><description>Cannot start with 000, 666, or 900-999 (reserved ranges)</description></item>
        /// <item><description>Middle group cannot be 00</description></item>
        /// <item><description>Last group cannot be 0000</description></item>
        /// <item><description>Cannot be 000-00-0000 (invalid SSN)</description></item>
        /// </list>
        /// 
        /// <para>
        /// Examples of valid SSNs:
        /// <code>
        /// 123-45-6789
        /// 111-22-3333
        /// 987-65-4321
        /// </code>
        /// </para>
        /// 
        /// <para>
        /// Examples of invalid SSNs:
        /// <code>
        /// 000-12-3456 (starts with 000)
        /// 666-12-3456 (starts with 666)
        /// 999-12-3456 (starts with 999)
        /// 123-00-4567 (middle group is 00)
        /// 123-45-0000 (last group is 0000)
        /// 123456789 (missing hyphens)
        /// </code>
        /// </para>
        /// 
        /// <para>
        /// The regex uses negative lookaheads to enforce business rules without
        /// consuming characters, allowing for efficient validation.
        /// </para>
        /// </remarks>
        public static bool IsValidSSN(string ssn)
        {
            /*
             * SSN VALIDATION LOGIC:
             * 1. Check for null or whitespace input
             * 2. Use compiled regex with negative lookaheads
             * 3. Pattern enforces format and business rules simultaneously
             * 4. Returns true only if all requirements are met
             */

            if (string.IsNullOrWhiteSpace(ssn))
                return false;

            return _ssnRegex.IsMatch(ssn);
        }

        /// <summary>
        /// Validates IPv4 addresses with proper octet range checking.
        /// </summary>
        /// <param name="ipAddress">The IP address to validate.</param>
        /// <returns>
        /// <c>true</c> if the IP address is a valid IPv4 address;
        /// otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method validates IPv4 addresses with comprehensive range checking:
        /// <list type="bullet">
        /// <item><description>Format: X.X.X.X (four octets separated by dots)</description></item>
        /// <item><description>Each octet must be 0-255</description></item>
        /// <item><description>No leading zeros (except 0 itself)</description></item>
        /// <item><description>Exactly four octets</description></item>
        /// </list>
        /// 
        /// <para>
        /// Examples of valid IPs:
        /// <code>
        /// 192.168.1.1
        /// 10.0.0.0
        /// 255.255.255.255
        /// 0.0.0.0
        /// </code>
        /// </para>
        /// 
        /// <para>
        /// Examples of invalid IPs:
        /// <code>
        /// 256.1.2.3 (octet > 255)
        /// 1.2.3.4.5 (too many octets)
        /// 192.168.001.1 (leading zeros)
        /// 192.168.1 (too few octets)
        /// </code>
        /// </para>
        /// 
        /// <para>
        /// The regex pattern uses precise character classes to ensure each octet
        /// falls within the valid 0-255 range without allowing leading zeros.
        /// </para>
        /// </remarks>
        public static bool IsValidIpAddress(string ipAddress)
        {
            /*
             * IP ADDRESS VALIDATION LOGIC:
             * 1. Check for null or whitespace input
             * 2. Use compiled regex with precise octet range patterns
             * 3. Pattern ensures exactly 4 octets with proper ranges
             * 4. Prevents leading zeros and invalid octet values
             */

            if (string.IsNullOrWhiteSpace(ipAddress))
                return false;

            return _ipAddressRegex.IsMatch(ipAddress);
        }

        /// <summary>
        /// Validates time strings in 24-hour format (HH:MM).
        /// </summary>
        /// <param name="time">The time string to validate.</param>
        /// <returns>
        /// <c>true</c> if the time is in valid 24-hour format;
        /// otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method validates time in strict 24-hour format:
        /// <list type="bullet">
        /// <item><description>Format: HH:MM (two digits each)</description></item>
        /// <item><description>Hours: 00-23</description></item>
        /// <item><description>Minutes: 00-59</description></item>
        /// <item><description>Must use leading zeros</description></item>
        /// </list>
        /// 
        /// <para>
        /// Examples of valid times:
        /// <code>
        /// 00:00 (midnight)
        /// 12:30 (12:30 PM)
        /// 23:59 (11:59 PM)
        /// 09:05 (9:05 AM)
        /// </code>
        /// </para>
        /// 
        /// <para>
        /// Examples of invalid times:
        /// <code>
        /// 24:00 (hour > 23)
        /// 12:60 (minute > 59)
        /// 1:30 (missing leading zero)
        /// 12:5 (missing leading zero)
        /// </code>
        /// </para>
        /// 
        /// <para>
        /// The regex pattern uses character classes to ensure proper hour and
        /// minute ranges while requiring leading zeros for single digits.
        /// </para>
        /// </remarks>
        public static bool IsValidTime(string time)
        {
            /*
             * TIME VALIDATION LOGIC:
             * 1. Check for null or whitespace input
             * 2. Use compiled regex with precise hour/minute patterns
             * 3. Pattern ensures 00-23 hours and 00-59 minutes
             * 4. Requires leading zeros for proper formatting
             */

            if (string.IsNullOrWhiteSpace(time))
                return false;

            return _timeRegex.IsMatch(time);
        }

        /// <summary>
        /// Validates US ZIP codes in both 5-digit and 9-digit formats.
        /// </summary>
        /// <param name="zipCode">The ZIP code to validate.</param>
        /// <returns>
        /// <c>true</c> if the ZIP code is in valid format;
        /// otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method validates US ZIP codes in standard formats:
        /// <list type="bullet">
        /// <item><description>5-digit format: 12345</description></item>
        /// <item><description>9-digit format: 12345-6789</description></item>
        /// <item><description>Only digits and optional hyphen allowed</description></item>
        /// <item><description>Hyphen must be followed by exactly 4 digits</description></item>
        /// </list>
        /// 
        /// <para>
        /// Examples of valid ZIP codes:
        /// <code>
        /// 12345
        /// 12345-6789
        /// 00000
        /// 99999-9999
        /// </code>
        /// </para>
        /// 
        /// <para>
        /// Examples of invalid ZIP codes:
        /// <code>
        /// 1234 (too short)
        /// 123456 (too long)
        /// 12345-678 (wrong format)
        /// abcde (not digits)
        /// </code>
        /// </para>
        /// 
        /// <para>
        /// The regex pattern uses optional groups to handle both 5-digit and
        /// 9-digit formats with proper hyphen placement.
        /// </para>
        /// </remarks>
        public static bool IsValidZipCode(string zipCode)
        {
            /*
             * ZIP CODE VALIDATION LOGIC:
             * 1. Check for null or whitespace input
             * 2. Use compiled regex with optional 9-digit extension
             * 3. Pattern ensures exactly 5 digits with optional 4-digit extension
             * 4. Validates proper hyphen placement and digit counts
             */

            if (string.IsNullOrWhiteSpace(zipCode))
                return false;

            return _zipCodeRegex.IsMatch(zipCode);
        }

        /// <summary>
        /// Transforms text by applying multiple regex operations for formatting.
        /// </summary>
        /// <param name="text">The text to transform.</param>
        /// <returns>
        /// The transformed text with improved formatting, or an empty string
        /// if the input is null/empty.
        /// </returns>
        /// <remarks>
        /// This method applies a series of text transformations:
        /// <list type="number">
        /// <item><description>Converts to title case (first letter of each word capitalized)</description></item>
        /// <item><description>Removes extra whitespace</description></item>
        /// <item><description>Adds proper spacing around punctuation</description></item>
        /// <item><description>Trims leading and trailing whitespace</description></item>
        /// </list>
        /// 
        /// <para>
        /// Example transformation:
        /// <code>
        /// Input: "hello world! this is a test."
        /// Output: "Hello World! This Is A Test."
        /// </code>
        /// </para>
        /// 
        /// <para>
        /// The method uses multiple regex operations to achieve comprehensive
        /// text formatting while preserving essential content and structure.
        /// </para>
        /// </remarks>
        public static string TransformText(string text)
        {
            /*
             * TEXT TRANSFORMATION LOGIC:
             * 1. Check for null or whitespace input
             * 2. Convert to title case using word boundary regex
             * 3. Remove extra whitespace
             * 4. Add proper spacing around punctuation
             * 5. Trim leading/trailing whitespace
             */

            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            // Convert to title case (first letter of each word capitalized)
            text = Regex.Replace(text, @"\b\w", m => m.Value.ToUpper());
            
            // Remove extra spaces
            text = Regex.Replace(text, @"\s+", " ");
            
            // Add proper spacing around punctuation
            text = Regex.Replace(text, @"([.!?])([A-Za-z])", "$1 $2");
            
            // Remove leading/trailing whitespace
            text = text.Trim();

            return text;
        }

        /// <summary>
        /// Extracts all numeric values from a given text and returns an int array.
        /// </summary>
        public static int[] ExtractNumbers(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new int[0];
            var matches = Regex.Matches(text, @"\d+");
            int[] numbers = new int[matches.Count];
            int idx = 0;
            foreach (Match match in matches)
            {
                if (int.TryParse(match.Value, out int number))
                {
                    numbers[idx++] = number;
                }
            }
            if (idx < numbers.Length)
            {
                // If some matches failed to parse, resize the array
                int[] result = new int[idx];
                Array.Copy(numbers, result, idx);
                return result;
            }
            return numbers;
        }

        /// <summary>
        /// Counts the frequency of words in a given text and returns a Hashtable.
        /// </summary>
        public static Hashtable CountWordFrequency(string text)
        {
            Hashtable wordCount = new Hashtable();
            if (string.IsNullOrWhiteSpace(text))
                return wordCount;
            var words = Regex.Split(text.ToLower(), @"\W+")
                           .Where(word => !string.IsNullOrWhiteSpace(word))
                           .Where(word => word.Length > 1);
            foreach (var word in words)
            {
                if (wordCount.ContainsKey(word))
                    wordCount[word] = (int)wordCount[word] + 1;
                else
                    wordCount[word] = 1;
            }
            return wordCount;
        }

        /// <summary>
        /// Validates credit card number format with basic checks.
        /// </summary>
        /// <param name="cardNumber">The credit card number to validate.</param>
        /// <returns>
        /// <c>true</c> if the credit card number has valid format;
        /// otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method performs basic credit card format validation:
        /// <list type="bullet">
        /// <item><description>13-19 digits in length</description></item>
        /// <item><description>May contain spaces or hyphens</description></item>
        /// <item><description>Must start with 3, 4, 5, or 6</description></item>
        /// <item><description>Removes formatting characters for validation</description></item>
        /// </list>
        /// 
        /// <para>
        /// Examples of valid card numbers:
        /// <code>
        /// 4111111111111111 (Visa)
        /// 5555 5555 5555 4444 (MasterCard with spaces)
        /// 3782-822463-10005 (American Express with hyphens)
        /// </code>
        /// </para>
        /// 
        /// <para>
        /// Examples of invalid card numbers:
        /// <code>
        /// 1234567890123456 (starts with 1)
        /// 411111111111111 (too short)
        /// abc-def-ghij-klmn (not digits)
        /// </code>
        /// </para>
        /// 
        /// <para>
        /// Note: This method only validates format, not the Luhn algorithm.
        /// For production use, implement additional validation checks.
        /// </para>
        /// </remarks>
        public static bool IsValidCreditCardFormat(string cardNumber)
        {
            /*
             * CREDIT CARD FORMAT VALIDATION LOGIC:
             * 1. Check for null or whitespace input
             * 2. Remove spaces and hyphens using regex
             * 3. Validate length (13-19 digits)
             * 4. Check starting digit (3, 4, 5, or 6)
             * 5. Ensure all characters are digits
             */

            if (string.IsNullOrWhiteSpace(cardNumber))
                return false;

            // Remove spaces and hyphens
            string cleanNumber = Regex.Replace(cardNumber, @"[\s-]", "");
            
            // Check if it's 13-19 digits and starts with valid prefix
            return Regex.IsMatch(cleanNumber, @"^[3-6]\d{12,18}$");
        }

        /// <summary>
        /// Formats credit card numbers with consistent spacing.
        /// </summary>
        /// <param name="cardNumber">The credit card number to format.</param>
        /// <returns>
        /// The formatted credit card number with spaces every 4 digits, or <c>null</c>
        /// if the input is not a valid credit card number.
        /// </returns>
        /// <remarks>
        /// This method formats credit card numbers for better readability:
        /// <list type="number">
        /// <item><description>Validates the credit card number format</description></item>
        /// <item><description>Removes all non-digit characters</description></item>
        /// <item><description>Adds spaces every 4 digits</description></item>
        /// <item><description>Returns null for invalid numbers</description></item>
        /// </list>
        /// 
        /// <para>
        /// Example formatting:
        /// <code>
        /// "4111111111111111" -> "4111 1111 1111 1111"
        /// "5555 5555 5555 4444" -> "5555 5555 5555 4444"
        /// "3782-822463-10005" -> "3782 8224 6310 005"
        /// </code>
        /// </para>
        /// 
        /// <para>
        /// The method uses regex to remove formatting characters and then
        /// applies a pattern to insert spaces at appropriate positions.
        /// </para>
        /// </remarks>
        public static string? FormatCreditCard(string cardNumber)
        {
            /*
             * CREDIT CARD FORMATTING LOGIC:
             * 1. Validate credit card number format first
             * 2. Remove all non-digit characters using regex
             * 3. Use regex to insert spaces every 4 digits
             * 4. Return null if validation fails
             */

            if (!IsValidCreditCardFormat(cardNumber))
                return null;

            // Remove all non-digit characters
            string digitsOnly = Regex.Replace(cardNumber, @"\D", "");
            
            // Format with spaces every 4 digits
            return Regex.Replace(digitsOnly, @"(\d{4})(?=\d)", "$1 ");
        }
    }
} 
} 