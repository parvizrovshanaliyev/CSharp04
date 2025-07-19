using System.Text.RegularExpressions;
using System.Collections;

namespace Week37.Practice
{
    /// <summary>
    /// Student implementation tasks for regex practice.
    /// 
    /// This class contains method stubs for tasks that you need to implement yourself.
    /// Study the example implementations in RegexValidator.cs and TextProcessor.cs
    /// to understand the patterns and approaches used.
    /// 
    /// NOTE: Use only arrays and non-generic collections (ArrayList, Hashtable).
    /// Do NOT use generic collections (List<T>, Dictionary<K,V>, etc.).
    /// </summary>
    public static class StudentTasks
    {
        /// <summary>
        /// Task 2.3: Credit Card Validation
        /// 
        /// Validates credit card numbers with the following requirements:
        /// - 13-19 digits
        /// - May contain spaces or hyphens
        /// - Must start with 3, 4, 5, or 6
        /// - Remove all non-digit characters before validation
        /// 
        /// Examples:
        /// Valid: "4111111111111111", "5555 5555 5555 4444", "3782-822463-10005"
        /// Invalid: "1234567890123456", "411111111111111", "abc-def-ghij-klmn"
        /// </summary>
        /// <param name="cardNumber">The credit card number to validate</param>
        /// <returns>true if valid, false otherwise</returns>
        public static bool IsValidCreditCard(string cardNumber)
        {
            // Check for null or empty input
            if (string.IsNullOrWhiteSpace(cardNumber))
                return false;

            // Remove all non-digit characters (spaces, hyphens, etc.)
            string cleanNumber = Regex.Replace(cardNumber, @"\D", "");
            
            // Check if the cleaned number starts with 3, 4, 5, or 6
            if (!Regex.IsMatch(cleanNumber, @"^[3-6]"))
                return false;
            
            // Check if the length is between 13 and 19 digits
            if (cleanNumber.Length < 13 || cleanNumber.Length > 19)
                return false;
            
            // Return true if all conditions are met
            return true;
        }

        /// <summary>
        /// Task 5.1: IP Address Validator
        /// 
        /// Validates IPv4 addresses with the following requirements:
        /// - Four octets separated by dots
        /// - Each octet: 0-255
        /// - No leading zeros (except 0 itself)
        /// 
        /// Examples:
        /// Valid: "192.168.1.1", "10.0.0.0", "255.255.255.255", "0.0.0.0"
        /// Invalid: "256.1.2.3", "1.2.3.4.5", "192.168.001.1", "192.168.1"
        /// </summary>
        /// <param name="ipAddress">The IP address to validate</param>
        /// <returns>true if valid, false otherwise</returns>
        public static bool IsValidIpAddress(string ipAddress)
        {
            // Check for null or empty input
            if (string.IsNullOrWhiteSpace(ipAddress))
                return false;

            // Split by dots and check for exactly 4 parts
            string[] octets = ipAddress.Split('.');
            if (octets.Length != 4)
                return false;

            // For each octet:
            foreach (string octet in octets)
            {
                // Must be a valid number
                if (!int.TryParse(octet, out int value))
                    return false;
                
                // Must be between 0 and 255
                if (value < 0 || value > 255)
                    return false;
                
                // Must not have leading zeros (except 0 itself)
                if (octet.Length > 1 && octet[0] == '0')
                    return false;
            }
            
            // Return true if all conditions are met
            return true;
        }

        /// <summary>
        /// Task 5.2: Time Format Validator
        /// 
        /// Validates time in 24-hour format with the following requirements:
        /// - Format: HH:MM
        /// - Hours: 00-23
        /// - Minutes: 00-59
        /// - Must use leading zeros
        /// 
        /// Examples:
        /// Valid: "00:00", "12:30", "23:59", "09:05"
        /// Invalid: "24:00", "12:60", "1:30", "12:5", "25:30"
        /// </summary>
        /// <param name="time">The time string to validate</param>
        /// <returns>true if valid, false otherwise</returns>
        public static bool IsValidTime(string time)
        {
            // Check for null or empty input
            if (string.IsNullOrWhiteSpace(time))
                return false;

            // Check if the format is HH:MM (exactly 5 characters with colon in middle)
            if (time.Length != 5 || time[2] != ':')
                return false;

            // Extract hours and minutes
            string hoursStr = time.Substring(0, 2);
            string minutesStr = time.Substring(3, 2);

            // Validate hours (00-23)
            if (!int.TryParse(hoursStr, out int hours) || hours < 0 || hours > 23)
                return false;

            // Validate minutes (00-59)
            if (!int.TryParse(minutesStr, out int minutes) || minutes < 0 || minutes > 59)
                return false;

            // Return true if all conditions are met
            return true;
        }

        /// <summary>
        /// Task 5.3: ZIP Code Validator
        /// 
        /// Validates US ZIP codes with the following requirements:
        /// - 5 digits (12345)
        /// - Or 5 digits + 4 digits (12345-6789)
        /// - Only digits and optional hyphen
        /// 
        /// Examples:
        /// Valid: "12345", "12345-6789", "00000", "99999-9999"
        /// Invalid: "1234", "123456", "12345-678", "abcde", "12345-67890"
        /// </summary>
        /// <param name="zipCode">The ZIP code to validate</param>
        /// <returns>true if valid, false otherwise</returns>
        public static bool IsValidZipCode(string zipCode)
        {
            // Check for null or empty input
            if (string.IsNullOrWhiteSpace(zipCode))
                return false;

            // Check if the format matches either:
            // - Exactly 5 digits: "12345"
            // - 5 digits + hyphen + 4 digits: "12345-6789"
            return Regex.IsMatch(zipCode, @"^\d{5}(-\d{4})?$");
        }

        /// <summary>
        /// Task 5.4: Credit Card Formatter
        /// 
        /// Formats credit card numbers consistently with the following requirements:
        /// - Accept credit card numbers in various formats
        /// - Format to XXXX-XXXX-XXXX-XXXX format
        /// - Remove all non-digit characters
        /// - Validate that the result has 13-19 digits
        /// 
        /// Examples:
        /// Input: "4111111111111111" -> Output: "4111-1111-1111-1111"
        /// Input: "5555 5555 5555 4444" -> Output: "5555-5555-5555-4444"
        /// Input: "3782-822463-10005" -> Output: "3782-8224-6310-005"
        /// </summary>
        /// <param name="cardNumber">The credit card number to format</param>
        /// <returns>Formatted credit card number or null if invalid</returns>
        public static string? FormatCreditCard(string cardNumber)
        {
            // Check for null or empty input
            if (string.IsNullOrWhiteSpace(cardNumber))
                return null;

            // Remove all non-digit characters
            string digitsOnly = Regex.Replace(cardNumber, @"\D", "");
            
            // Check if the cleaned number has 13-19 digits
            if (digitsOnly.Length < 13 || digitsOnly.Length > 19)
                return null;
            
            // Check if it starts with valid prefix (3, 4, 5, or 6)
            if (!Regex.IsMatch(digitsOnly, @"^[3-6]"))
                return null;

            // Format into groups of 4 digits separated by hyphens
            string formatted = "";
            for (int i = 0; i < digitsOnly.Length; i++)
            {
                if (i > 0 && i % 4 == 0)
                    formatted += "-";
                formatted += digitsOnly[i];
            }
            
            return formatted;
        }

        /// <summary>
        /// Task 5.5: Number Extractor
        /// 
        /// Extracts all numbers from text with the following requirements:
        /// - Find all numbers (integers and decimals) in text
        /// - Return an array of integers
        /// - Handle various number formats
        /// 
        /// Example:
        /// Input: "The price is $25.99 and quantity is 5. Phone number: 555-123-4567"
        /// Output: [25, 99, 5, 555, 123, 4567]
        /// </summary>
        /// <param name="text">The text to extract numbers from</param>
        /// <returns>Array of integers found in the text</returns>
        public static int[] ExtractNumbers(string text)
        {
            // Check for null or empty input
            if (string.IsNullOrWhiteSpace(text))
                return new int[0];

            // Use regex to find all numbers in the text
            // Pattern \d+ finds sequences of digits
            MatchCollection matches = Regex.Matches(text, @"\d+");
            
            // Convert found numbers to integers
            int[] numbers = new int[matches.Count];
            int index = 0;
            
            foreach (Match match in matches)
            {
                if (int.TryParse(match.Value, out int number))
                {
                    numbers[index] = number;
                    index++;
                }
            }
            
            // If some matches failed to parse, resize the array
            if (index < numbers.Length)
            {
                int[] result = new int[index];
                Array.Copy(numbers, result, index);
                return result;
            }
            
            return numbers;
        }

        /// <summary>
        /// Bonus Task: Word Counter
        /// 
        /// Counts the frequency of words in text with the following requirements:
        /// - Count how many times each word appears
        /// - Ignore case (treat "Hello" and "hello" as the same word)
        /// - Remove punctuation from words
        /// - Return a Hashtable with word as key and count as value
        /// 
        /// Example:
        /// Input: "Hello world! Hello there, world."
        /// Output: Hashtable with "hello" -> 2, "world" -> 2, "there" -> 1
        /// </summary>
        /// <param name="text">The text to count words in</param>
        /// <returns>Hashtable with word frequencies</returns>
        public static Hashtable CountWordFrequency(string text)
        {
            // Check for null or empty input
            if (string.IsNullOrWhiteSpace(text))
                return new Hashtable();

            // Split text into words and clean each word
            string[] words = Regex.Split(text.ToLower(), @"\W+");
            Hashtable wordCount = new Hashtable();
            
            foreach (string word in words)
            {
                // Skip empty words and single characters
                if (string.IsNullOrWhiteSpace(word) || word.Length <= 1)
                    continue;
                
                // Count frequency of each word
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word] = (int)wordCount[word] + 1;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }
            
            return wordCount;
        }
    }
} 