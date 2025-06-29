using Week37.Practice;

namespace Week37.Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Week 37 - Regular Expressions Practice ===\n");

            // Test basic validation methods
            TestBasicValidation();
            
            // Test text processing methods
            TestTextProcessing();
            
            // Test advanced validation methods
            TestAdvancedValidation();
            
            // Test real-world applications
            TestRealWorldApplications();

            // Test student implementation tasks
            TestStudentTasks();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void TestBasicValidation()
        {
            Console.WriteLine("--- Basic Validation Tests ---\n");

            // Email validation tests
            Console.WriteLine("Email Validation:");
            TestEmailValidation();

            // Phone number validation tests
            Console.WriteLine("\nPhone Number Validation:");
            TestPhoneValidation();

            // Name validation tests
            Console.WriteLine("\nName Validation:");
            TestNameValidation();

            // Password validation tests
            Console.WriteLine("\nPassword Validation:");
            TestPasswordValidation();
        }

        static void TestEmailValidation()
        {
            string[] validEmails = {
                "john.doe@gmail.com",
                "user123@company.org",
                "test@university.edu"
            };

            string[] invalidEmails = {
                "invalid.email",
                "@gmail.com",
                "user@",
                "user@.com",
                "verylongusername@domain.com"
            };

            Console.WriteLine("Valid emails:");
            foreach (var email in validEmails)
            {
                bool isValid = RegexValidator.IsValidEmail(email);
                Console.WriteLine($"  {email,-25} -> {(isValid ? "VALID" : "INVALID")}");
            }

            Console.WriteLine("Invalid emails:");
            foreach (var email in invalidEmails)
            {
                bool isValid = RegexValidator.IsValidEmail(email);
                Console.WriteLine($"  {email,-25} -> {(isValid ? "INVALID" : "VALID")}");
            }
        }

        static void TestPhoneValidation()
        {
            string[] validPhones = {
                "(555) 123-4567",
                "555-123-4567",
                "555.123.4567",
                "555 123 4567",
                "5551234567"
            };

            string[] invalidPhones = {
                "123-456-789",
                "555-123-45678",
                "abc-def-ghij",
                "(555) 123-456"
            };

            Console.WriteLine("Valid phone numbers:");
            foreach (var phone in validPhones)
            {
                bool isValid = RegexValidator.IsValidPhoneNumber(phone);
                string formatted = RegexValidator.FormatPhoneNumber(phone);
                Console.WriteLine($"  {phone,-15} -> {(isValid ? "VALID" : "INVALID")} -> {formatted}");
            }

            Console.WriteLine("Invalid phone numbers:");
            foreach (var phone in invalidPhones)
            {
                bool isValid = RegexValidator.IsValidPhoneNumber(phone);
                Console.WriteLine($"  {phone,-15} -> {(isValid ? "INVALID" : "VALID")}");
            }
        }

        static void TestNameValidation()
        {
            string[] validNames = {
                "John Smith",
                "Mary-Jane",
                "O'Connor",
                "Dr. Smith",
                "Jean-Pierre"
            };

            string[] invalidNames = {
                "A",
                "John123",
                "John@Smith",
                "John--Smith",
                " John "
            };

            Console.WriteLine("Valid names:");
            foreach (var name in validNames)
            {
                bool isValid = RegexValidator.IsValidName(name);
                Console.WriteLine($"  {name,-15} -> {(isValid ? "VALID" : "INVALID")}");
            }

            Console.WriteLine("Invalid names:");
            foreach (var name in invalidNames)
            {
                bool isValid = RegexValidator.IsValidName(name);
                Console.WriteLine($"  {name,-15} -> {(isValid ? "INVALID" : "VALID")}");
            }
        }

        static void TestPasswordValidation()
        {
            string[] validPasswords = {
                "StrongPass1!",
                "Secure123@",
                "MyP@ssw0rd"
            };

            string[] invalidPasswords = {
                "weakpass",
                "WeakPass1",
                "WEAKPASS1!",
                "WeakPass!",
                "Weak1!"
            };

            Console.WriteLine("Valid passwords:");
            foreach (var password in validPasswords)
            {
                bool isValid = RegexValidator.IsStrongPassword(password);
                Console.WriteLine($"  {password,-15} -> {(isValid ? "VALID" : "INVALID")}");
            }

            Console.WriteLine("Invalid passwords:");
            foreach (var password in invalidPasswords)
            {
                bool isValid = RegexValidator.IsStrongPassword(password);
                Console.WriteLine($"  {password,-15} -> {(isValid ? "INVALID" : "VALID")}");
            }
        }

        static void TestTextProcessing()
        {
            Console.WriteLine("\n--- Text Processing Tests ---\n");

            // Email extraction test
            Console.WriteLine("Email Extraction:");
            string textWithEmails = @"
                Contact us at john.doe@company.com or support@help.org.
                For sales inquiries, email sales@business.net.
                Invalid email: invalid.email@
            ";
            
            var emails = RegexValidator.ExtractEmails(textWithEmails);
            Console.WriteLine("Found emails:");
            foreach (var email in emails)
            {
                Console.WriteLine($"  {email}");
            }

            // Text cleaning test
            Console.WriteLine("\nText Cleaning:");
            string dirtyText = @"
                Hello    World!!!
                This   is   a   test   text.
                Multiple    spaces    and    tabs		here.
            ";
            
            string cleanedText = RegexValidator.CleanText(dirtyText);
            Console.WriteLine("Original text:");
            Console.WriteLine(dirtyText);
            Console.WriteLine("Cleaned text:");
            Console.WriteLine(cleanedText);

            // Text transformation test
            Console.WriteLine("\nText Transformation:");
            string sampleText = "hello world! this is a test.";
            string transformed = TextProcessor.TransformText(sampleText);
            Console.WriteLine($"Original: {sampleText}");
            Console.WriteLine($"Transformed: {transformed}");

            // Number extraction test
            Console.WriteLine("\nNumber Extraction:");
            string textWithNumbers = "I have 5 apples and 3 oranges. Total: 8 fruits.";
            var numbers = TextProcessor.ExtractNumbers(textWithNumbers);
            Console.WriteLine($"Text: {textWithNumbers}");
            Console.WriteLine($"Numbers found: {string.Join(", ", numbers)}");

            // Word frequency test
            Console.WriteLine("\nWord Frequency:");
            string sampleText2 = "the quick brown fox jumps over the lazy dog. the fox is quick.";
            var wordFreq = TextProcessor.CountWordFrequency(sampleText2);
            Console.WriteLine($"Text: {sampleText2}");
            Console.WriteLine("Word frequencies:");
            foreach (var kvp in wordFreq.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
            }
        }

        static void TestAdvancedValidation()
        {
            Console.WriteLine("\n--- Advanced Validation Tests ---\n");

            // Date validation tests
            Console.WriteLine("Date Validation:");
            string[] validDates = { "12/25/2023", "01/01/1900", "02/29/2024", "04/30/2023" };
            string[] invalidDates = { "13/01/2023", "12/32/2023", "12/25/1899", "1/1/2023" };

            Console.WriteLine("Valid dates:");
            foreach (var date in validDates)
            {
                bool isValid = RegexValidator.IsValidDateFormat(date);
                Console.WriteLine($"  {date,-12} -> {(isValid ? "VALID" : "INVALID")}");
            }

            Console.WriteLine("Invalid dates:");
            foreach (var date in invalidDates)
            {
                bool isValid = RegexValidator.IsValidDateFormat(date);
                Console.WriteLine($"  {date,-12} -> {(isValid ? "INVALID" : "VALID")}");
            }

            // IP address validation tests
            Console.WriteLine("\nIP Address Validation:");
            string[] validIPs = { "192.168.1.1", "10.0.0.0", "255.255.255.255", "0.0.0.0" };
            string[] invalidIPs = { "256.1.2.3", "1.2.3.4.5", "192.168.001.1", "192.168.1" };

            Console.WriteLine("Valid IPs:");
            foreach (var ip in validIPs)
            {
                bool isValid = TextProcessor.IsValidIpAddress(ip);
                Console.WriteLine($"  {ip,-15} -> {(isValid ? "VALID" : "INVALID")}");
            }

            Console.WriteLine("Invalid IPs:");
            foreach (var ip in invalidIPs)
            {
                bool isValid = TextProcessor.IsValidIpAddress(ip);
                Console.WriteLine($"  {ip,-15} -> {(isValid ? "INVALID" : "VALID")}");
            }

            // Time validation tests
            Console.WriteLine("\nTime Validation:");
            string[] validTimes = { "00:00", "12:30", "23:59", "09:05" };
            string[] invalidTimes = { "24:00", "12:60", "1:30", "12:5" };

            Console.WriteLine("Valid times:");
            foreach (var time in validTimes)
            {
                bool isValid = TextProcessor.IsValidTime(time);
                Console.WriteLine($"  {time,-8} -> {(isValid ? "VALID" : "INVALID")}");
            }

            Console.WriteLine("Invalid times:");
            foreach (var time in invalidTimes)
            {
                bool isValid = TextProcessor.IsValidTime(time);
                Console.WriteLine($"  {time,-8} -> {(isValid ? "INVALID" : "VALID")}");
            }

            // ZIP code validation tests
            Console.WriteLine("\nZIP Code Validation:");
            string[] validZips = { "12345", "12345-6789", "00000", "99999-9999" };
            string[] invalidZips = { "1234", "123456", "12345-678", "abcde" };

            Console.WriteLine("Valid ZIP codes:");
            foreach (var zip in validZips)
            {
                bool isValid = TextProcessor.IsValidZipCode(zip);
                Console.WriteLine($"  {zip,-12} -> {(isValid ? "VALID" : "INVALID")}");
            }

            Console.WriteLine("Invalid ZIP codes:");
            foreach (var zip in invalidZips)
            {
                bool isValid = TextProcessor.IsValidZipCode(zip);
                Console.WriteLine($"  {zip,-12} -> {(isValid ? "INVALID" : "VALID")}");
            }
        }

        static void TestRealWorldApplications()
        {
            Console.WriteLine("\n--- Real-World Applications Tests ---\n");

            // Log parsing test
            Console.WriteLine("Log Parsing:");
            string logText = @"
[2023-12-25 14:30:15] INFO: User login successful
[2023-12-25 14:31:22] WARNING: High memory usage detected
[2023-12-25 14:32:45] ERROR: Database connection failed
[2023-12-25 14:33:12] DEBUG: Processing request ID 12345
            ";

            var logEntries = TextProcessor.ParseLogEntries(logText);
            Console.WriteLine("Parsed log entries:");
            foreach (var entry in logEntries)
            {
                Console.WriteLine($"  {entry}");
            }

            // URL parsing test
            Console.WriteLine("\nURL Parsing:");
            string[] testUrls = {
                "https://www.example.com",
                "http://example.com/path",
                "https://example.com/path?param=value",
                "ftp://example.com",
                "https://"
            };

            foreach (var url in testUrls)
            {
                var urlComponents = TextProcessor.ParseUrl(url);
                if (urlComponents != null)
                {
                    Console.WriteLine($"  {url}");
                    Console.WriteLine($"    Protocol: {urlComponents.Protocol}");
                    Console.WriteLine($"    Domain: {urlComponents.Domain}");
                    Console.WriteLine($"    Path: {urlComponents.Path}");
                    Console.WriteLine($"    Query: {urlComponents.Query}");
                }
                else
                {
                    Console.WriteLine($"  {url} -> Invalid URL");
                }
            }

            // SSN validation test
            Console.WriteLine("\nSSN Validation:");
            string[] validSsns = { "123-45-6789", "111-22-3333", "987-65-4321" };
            string[] invalidSsns = { "000-12-3456", "666-12-3456", "999-12-3456", "123-45-678" };

            Console.WriteLine("Valid SSNs:");
            foreach (var ssn in validSsns)
            {
                bool isValid = TextProcessor.IsValidSSN(ssn);
                Console.WriteLine($"  {ssn,-12} -> {(isValid ? "VALID" : "INVALID")}");
            }

            Console.WriteLine("Invalid SSNs:");
            foreach (var ssn in invalidSsns)
            {
                bool isValid = TextProcessor.IsValidSSN(ssn);
                Console.WriteLine($"  {ssn,-12} -> {(isValid ? "INVALID" : "VALID")}");
            }

            // Credit card validation test
            Console.WriteLine("\nCredit Card Validation:");
            string[] validCards = { "4111111111111111", "5555 5555 5555 4444", "3782-822463-10005" };
            string[] invalidCards = { "1234567890123456", "411111111111111", "abc-def-ghij-klmn" };

            Console.WriteLine("Valid credit cards:");
            foreach (var card in validCards)
            {
                bool isValid = TextProcessor.IsValidCreditCardFormat(card);
                string formatted = TextProcessor.FormatCreditCard(card);
                Console.WriteLine($"  {card,-20} -> {(isValid ? "VALID" : "INVALID")} -> {formatted}");
            }

            Console.WriteLine("Invalid credit cards:");
            foreach (var card in invalidCards)
            {
                bool isValid = TextProcessor.IsValidCreditCardFormat(card);
                Console.WriteLine($"  {card,-20} -> {(isValid ? "INVALID" : "VALID")}");
            }
        }

        static void TestStudentTasks()
        {
            Console.WriteLine("\n--- Student Implementation Tests ---\n");
            Console.WriteLine("Note: These tests will fail until you implement the methods in StudentTasks.cs\n");

            // Test credit card validation
            Console.WriteLine("Credit Card Validation (Task 2.3):");
            TestStudentCreditCardValidation();

            // Test IP address validation
            Console.WriteLine("\nIP Address Validation (Task 5.1):");
            TestStudentIpAddressValidation();

            // Test time format validation
            Console.WriteLine("\nTime Format Validation (Task 5.2):");
            TestStudentTimeValidation();

            // Test ZIP code validation
            Console.WriteLine("\nZIP Code Validation (Task 5.3):");
            TestStudentZipCodeValidation();

            // Test credit card formatting
            Console.WriteLine("\nCredit Card Formatting (Task 5.4):");
            TestStudentCreditCardFormatting();

            // Test number extraction
            Console.WriteLine("\nNumber Extraction (Task 5.5):");
            TestStudentNumberExtraction();
        }

        static void TestStudentCreditCardValidation()
        {
            string[] validCards = {
                "4111111111111111",
                "5555 5555 5555 4444",
                "3782-822463-10005",
                "6011111111111117"
            };

            string[] invalidCards = {
                "1234567890123456",
                "411111111111111",
                "abc-def-ghij-klmn",
                "4111111111111112"
            };

            Console.WriteLine("Valid credit cards:");
            foreach (var card in validCards)
            {
                try
                {
                    bool isValid = StudentTasks.IsValidCreditCard(card);
                    Console.WriteLine($"  {card,-20} -> {(isValid ? "VALID" : "INVALID")}");
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine($"  {card,-20} -> NOT IMPLEMENTED");
                }
            }

            Console.WriteLine("Invalid credit cards:");
            foreach (var card in invalidCards)
            {
                try
                {
                    bool isValid = StudentTasks.IsValidCreditCard(card);
                    Console.WriteLine($"  {card,-20} -> {(isValid ? "INVALID" : "VALID")}");
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine($"  {card,-20} -> NOT IMPLEMENTED");
                }
            }
        }

        static void TestStudentIpAddressValidation()
        {
            string[] validIps = {
                "192.168.1.1",
                "10.0.0.0",
                "255.255.255.255",
                "0.0.0.0"
            };

            string[] invalidIps = {
                "256.1.2.3",
                "1.2.3.4.5",
                "192.168.001.1",
                "192.168.1",
                "192.168.1.256"
            };

            Console.WriteLine("Valid IP addresses:");
            foreach (var ip in validIps)
            {
                try
                {
                    bool isValid = StudentTasks.IsValidIpAddress(ip);
                    Console.WriteLine($"  {ip,-15} -> {(isValid ? "VALID" : "INVALID")}");
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine($"  {ip,-15} -> NOT IMPLEMENTED");
                }
            }

            Console.WriteLine("Invalid IP addresses:");
            foreach (var ip in invalidIps)
            {
                try
                {
                    bool isValid = StudentTasks.IsValidIpAddress(ip);
                    Console.WriteLine($"  {ip,-15} -> {(isValid ? "INVALID" : "VALID")}");
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine($"  {ip,-15} -> NOT IMPLEMENTED");
                }
            }
        }

        static void TestStudentTimeValidation()
        {
            string[] validTimes = {
                "00:00",
                "12:30",
                "23:59",
                "09:05"
            };

            string[] invalidTimes = {
                "24:00",
                "12:60",
                "1:30",
                "12:5",
                "25:30"
            };

            Console.WriteLine("Valid times:");
            foreach (var time in validTimes)
            {
                try
                {
                    bool isValid = StudentTasks.IsValidTime(time);
                    Console.WriteLine($"  {time,-8} -> {(isValid ? "VALID" : "INVALID")}");
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine($"  {time,-8} -> NOT IMPLEMENTED");
                }
            }

            Console.WriteLine("Invalid times:");
            foreach (var time in invalidTimes)
            {
                try
                {
                    bool isValid = StudentTasks.IsValidTime(time);
                    Console.WriteLine($"  {time,-8} -> {(isValid ? "INVALID" : "VALID")}");
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine($"  {time,-8} -> NOT IMPLEMENTED");
                }
            }
        }

        static void TestStudentZipCodeValidation()
        {
            string[] validZips = {
                "12345",
                "12345-6789",
                "00000",
                "99999-9999"
            };

            string[] invalidZips = {
                "1234",
                "123456",
                "12345-678",
                "abcde",
                "12345-67890"
            };

            Console.WriteLine("Valid ZIP codes:");
            foreach (var zip in validZips)
            {
                try
                {
                    bool isValid = StudentTasks.IsValidZipCode(zip);
                    Console.WriteLine($"  {zip,-12} -> {(isValid ? "VALID" : "INVALID")}");
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine($"  {zip,-12} -> NOT IMPLEMENTED");
                }
            }

            Console.WriteLine("Invalid ZIP codes:");
            foreach (var zip in invalidZips)
            {
                try
                {
                    bool isValid = StudentTasks.IsValidZipCode(zip);
                    Console.WriteLine($"  {zip,-12} -> {(isValid ? "INVALID" : "VALID")}");
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine($"  {zip,-12} -> NOT IMPLEMENTED");
                }
            }
        }

        static void TestStudentCreditCardFormatting()
        {
            string[] testCards = {
                "4111111111111111",
                "5555 5555 5555 4444",
                "3782-822463-10005"
            };

            Console.WriteLine("Credit card formatting:");
            foreach (var card in testCards)
            {
                try
                {
                    string? formatted = StudentTasks.FormatCreditCard(card);
                    Console.WriteLine($"  {card,-20} -> {formatted ?? "INVALID"}");
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine($"  {card,-20} -> NOT IMPLEMENTED");
                }
            }
        }

        static void TestStudentNumberExtraction()
        {
            string testText = "The price is $25.99 and quantity is 5. Phone number: 555-123-4567. Age: 25, Height: 5.8 feet";

            Console.WriteLine("Number extraction:");
            Console.WriteLine($"Input: {testText}");
            
            try
            {
                int[] numbers = StudentTasks.ExtractNumbers(testText);
                Console.WriteLine($"Output: [{string.Join(", ", numbers)}]");
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Output: NOT IMPLEMENTED");
            }
        }
    }
}
