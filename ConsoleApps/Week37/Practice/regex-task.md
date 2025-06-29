# Week 37 - Regular Expressions Practice Tasks

## Overview
This week's practice focuses on mastering Regular Expressions (Regex) in C#. You'll work with various patterns for data validation and text processing.

## Learning Objectives
- Understand regex syntax and patterns
- Implement data validation using regex
- Process and transform text with regex
- Apply regex in real-world scenarios

## Prerequisites
- Basic understanding of C# programming
- Familiarity with string manipulation
- Knowledge of the `System.Text.RegularExpressions` namespace

## Important Notes
- **Only arrays and non-generic collections (ArrayList, Hashtable) are allowed**
- **Do NOT use generic collections (List<T>, Dictionary<K,V>, etc.)**
- Some tasks have example implementations in the code files
- Other tasks are for you to implement as practice
- Focus on understanding regex patterns and validation logic

---

## Task 1: Basic Regex Patterns

### 1.1 Email Validation ✅ (Example Implementation Available)
**Status:** Example implementation available in `RegexValidator.IsValidEmail()`

Create a method that validates email addresses using regex.

**Requirements:**
- Must contain exactly one @ symbol
- Username must be 3-20 characters long
- Domain must be 2-50 characters long
- Must end with .com, .org, .net, or .edu

**Test Cases:**
```csharp
// Valid emails
"john.doe@gmail.com"
"user123@company.org"
"test@university.edu"

// Invalid emails
"invalid.email"
"@gmail.com"
"user@"
"user@.com"
"verylongusername@domain.com"
```

### 1.2 Phone Number Validation ✅ (Example Implementation Available)
**Status:** Example implementation available in `RegexValidator.IsValidPhoneNumber()`

Create a method that validates US phone numbers in multiple formats.

**Requirements:**
- Accept formats: (555) 123-4567, 555-123-4567, 555.123.4567, 5551234567
- Must have exactly 10 digits
- Optional parentheses, hyphens, dots, or spaces

**Test Cases:**
```csharp
// Valid phone numbers
"(555) 123-4567"
"555-123-4567"
"555.123.4567"
"555 123 4567"
"5551234567"

// Invalid phone numbers
"123-456-789"
"555-123-45678"
"abc-def-ghij"
"(555) 123-456"
```

### 1.3 Name Validation ✅ (Example Implementation Available)
**Status:** Example implementation available in `RegexValidator.IsValidName()`

Create a method that validates person names.

**Requirements:**
- 2-50 characters long
- Only letters, spaces, hyphens, apostrophes, and dots
- Must start and end with a letter
- No consecutive special characters

**Test Cases:**
```csharp
// Valid names
"John Smith"
"Mary-Jane"
"O'Connor"
"Dr. Smith"
"Jean-Pierre"

// Invalid names
"A"
"John123"
"John@Smith"
"John--Smith"
" John "
```

---

## Task 2: Intermediate Regex Patterns

### 2.1 Password Strength Validation ✅ (Example Implementation Available)
**Status:** Example implementation available in `RegexValidator.IsStrongPassword()`

Create a method that validates password strength.

**Requirements:**
- At least 8 characters long
- Contains at least one uppercase letter
- Contains at least one lowercase letter
- Contains at least one digit
- Contains at least one special character (@$!%*?&)

**Test Cases:**
```csharp
// Valid passwords
"StrongPass1!"
"Secure123@"
"MyP@ssw0rd"

// Invalid passwords
"weakpass"
"WeakPass1"
"WEAKPASS1!"
"WeakPass!"
"Weak1!"
```

### 2.2 Date Validation (MM/DD/YYYY) ✅ (Example Implementation Available)
**Status:** Example implementation available in `RegexValidator.IsValidDateFormat()`

Create a method that validates dates in MM/DD/YYYY format.

**Requirements:**
- Month: 01-12
- Day: 01-31 (consider month-specific days)
- Year: 1900-2099
- Must use leading zeros

**Test Cases:**
```csharp
// Valid dates
"12/25/2023"
"01/01/1900"
"02/29/2024"  // Leap year
"04/30/2023"

// Invalid dates
"13/01/2023"
"12/32/2023"
"12/25/1899"
"1/1/2023"
"12-25-2023"
"02/30/2023"
```

### 2.3 Credit Card Validation ❌ (Student Implementation Required)
**Status:** You need to implement this yourself

Create a method that validates credit card numbers.

**Requirements:**
- 13-19 digits
- May contain spaces or hyphens
- Must start with 3, 4, 5, or 6
- Remove all non-digit characters before validation

**Test Cases:**
```csharp
// Valid cards
"4111111111111111"
"5555 5555 5555 4444"
"3782-822463-10005"
"6011111111111117"

// Invalid cards
"1234567890123456"
"411111111111111"
"abc-def-ghij-klmn"
"4111111111111112"
```

---

## Task 3: Text Processing with Regex

### 3.1 Email Address Extractor ✅ (Example Implementation Available)
**Status:** Example implementation available in `RegexValidator.ExtractEmails()`

Create a method that extracts email addresses from text.

**Requirements:**
- Find all valid email addresses in a given text
- Return an ArrayList of found email addresses
- Handle multiple email addresses in one text

**Test Input:**
```
Contact us at john.doe@company.com or support@help.org.
For sales inquiries, email sales@business.net.
Invalid email: invalid.email@
```

**Expected Output:**
```
john.doe@company.com
support@help.org
sales@business.net
```

### 3.2 Phone Number Formatter ✅ (Example Implementation Available)
**Status:** Example implementation available in `RegexValidator.FormatPhoneNumber()`

Create a method that formats phone numbers consistently.

**Requirements:**
- Accept phone numbers in various formats
- Format all to (XXX) XXX-XXXX format
- Remove all non-digit characters
- Validate that the result has exactly 10 digits

**Test Cases:**
```csharp
// Input -> Expected Output
"5551234567" -> "(555) 123-4567"
"555-123-4567" -> "(555) 123-4567"
"(555) 123-4567" -> "(555) 123-4567"
"555.123.4567" -> "(555) 123-4567"
"555 123 4567" -> "(555) 123-4567"
```

### 3.3 Text Cleaner ✅ (Example Implementation Available)
**Status:** Example implementation available in `RegexValidator.CleanText()`

Create a method that cleans and normalizes text.

**Requirements:**
- Remove extra whitespace (multiple spaces, tabs, newlines)
- Normalize line endings to \n
- Remove special characters except letters, numbers, and basic punctuation
- Convert multiple consecutive punctuation marks to single

**Test Input:**
```
Hello    World!!!
This   is   a   test   text.
Multiple    spaces    and    tabs		here.
```

**Expected Output:**
```
Hello World!
This is a test text.
Multiple spaces and tabs here.
```

---

## Task 4: Real-World Applications

### 4.1 Log File Parser ✅ (Example Implementation Available)
**Status:** Example implementation available in `TextProcessor.ParseLogEntries()`

Create a method that parses log entries.

**Requirements:**
- Parse log entries in format: [YYYY-MM-DD HH:MM:SS] LEVEL: Message
- Extract timestamp, log level, and message
- Handle various log levels: INFO, WARNING, ERROR, DEBUG
- Return ArrayList of LogEntry objects

**Test Input:**
```
[2023-12-25 14:30:15] INFO: User login successful
[2023-12-25 14:31:22] WARNING: High memory usage detected
[2023-12-25 14:32:45] ERROR: Database connection failed
[2023-12-25 14:33:12] DEBUG: Processing request ID 12345
```

### 4.2 URL Validator and Extractor ✅ (Example Implementation Available)
**Status:** Example implementation available in `TextProcessor.ParseUrl()`

Create methods to validate and extract URL components.

**Requirements:**
- Validate URLs (http/https only)
- Extract protocol, domain, path, and query parameters
- Handle various URL formats
- Return UrlComponents object

**Test Cases:**
```csharp
// Valid URLs
"https://www.example.com"
"http://example.com/path"
"https://example.com/path?param=value"
"https://subdomain.example.com:8080/path"

// Invalid URLs
"ftp://example.com"
"https://"
"example.com"
"not-a-url"
```

### 4.3 Social Security Number Validator ✅ (Example Implementation Available)
**Status:** Example implementation available in `TextProcessor.IsValidSSN()`

Create a method that validates US Social Security Numbers.

**Requirements:**
- Format: XXX-XX-XXXX
- Must be exactly 9 digits
- Cannot start with 000, 666, or 900-999
- Cannot be 000-00-0000

**Test Cases:**
```csharp
// Valid SSNs
"123-45-6789"
"111-22-3333"
"987-65-4321"

// Invalid SSNs
"000-12-3456"
"666-12-3456"
"999-12-3456"
"123-45-678"
"123456789"
"abc-def-ghij"
```

---

## Task 5: Student Implementation Tasks

### 5.1 IP Address Validator ❌ (Student Implementation Required)
**Status:** You need to implement this yourself

Create a method that validates IPv4 addresses.

**Requirements:**
- Four octets separated by dots
- Each octet: 0-255
- No leading zeros (except 0 itself)

**Test Cases:**
```csharp
// Valid IPs
"192.168.1.1"
"10.0.0.0"
"255.255.255.255"
"0.0.0.0"

// Invalid IPs
"256.1.2.3"
"1.2.3.4.5"
"192.168.001.1"
"192.168.1"
"192.168.1.256"
```

### 5.2 Time Format Validator ❌ (Student Implementation Required)
**Status:** You need to implement this yourself

Create a method that validates time in 24-hour format.

**Requirements:**
- Format: HH:MM
- Hours: 00-23
- Minutes: 00-59
- Must use leading zeros

**Test Cases:**
```csharp
// Valid times
"00:00"
"12:30"
"23:59"
"09:05"

// Invalid times
"24:00"
"12:60"
"1:30"
"12:5"
"25:30"
```

### 5.3 ZIP Code Validator ❌ (Student Implementation Required)
**Status:** You need to implement this yourself

Create a method that validates US ZIP codes.

**Requirements:**
- 5 digits (12345)
- Or 5 digits + 4 digits (12345-6789)
- Only digits and optional hyphen

**Test Cases:**
```csharp
// Valid ZIP codes
"12345"
"12345-6789"
"00000"
"99999-9999"

// Invalid ZIP codes
"1234"
"123456"
"12345-678"
"abcde"
"12345-67890"
```

### 5.4 Credit Card Formatter ❌ (Student Implementation Required)
**Status:** You need to implement this yourself

Create a method that formats credit card numbers consistently.

**Requirements:**
- Accept credit card numbers in various formats
- Format to XXXX-XXXX-XXXX-XXXX format
- Remove all non-digit characters
- Validate that the result has 13-19 digits

**Test Cases:**
```csharp
// Input -> Expected Output
"4111111111111111" -> "4111-1111-1111-1111"
"5555 5555 5555 4444" -> "5555-5555-5555-4444"
"3782-822463-10005" -> "3782-8224-6310-005"
```

### 5.5 Number Extractor ❌ (Student Implementation Required)
**Status:** You need to implement this yourself

Create a method that extracts all numbers from text.

**Requirements:**
- Find all numbers (integers and decimals) in text
- Return an array of integers
- Handle various number formats

**Test Input:**
```
The price is $25.99 and quantity is 5.
Phone number: 555-123-4567
Age: 25, Height: 5.8 feet
```

**Expected Output:**
```
25, 99, 5, 555, 123, 4567, 25, 5, 8
```

---

## Submission Requirements

### Code Structure
```
Week37/Practice/
├── Program.cs (Example demonstrations)
├── RegexValidator.cs (Example implementations)
├── TextProcessor.cs (Example implementations)
├── StudentTasks.cs (Your implementations)
└── README.md (Your documentation)
```

### What You Need to Implement
Create a new file `StudentTasks.cs` with the following methods:

```csharp
public static class StudentTasks
{
    // Task 2.3: Credit Card Validation
    public static bool IsValidCreditCard(string cardNumber) { }
    
    // Task 5.1: IP Address Validation
    public static bool IsValidIpAddress(string ipAddress) { }
    
    // Task 5.2: Time Format Validation
    public static bool IsValidTime(string time) { }
    
    // Task 5.3: ZIP Code Validation
    public static bool IsValidZipCode(string zipCode) { }
    
    // Task 5.4: Credit Card Formatter
    public static string? FormatCreditCard(string cardNumber) { }
    
    // Task 5.5: Number Extractor
    public static int[] ExtractNumbers(string text) { }
}
```

### Documentation
- Comment all regex patterns explaining their purpose
- Document test cases and expected results
- Include usage examples

### Testing
- Create unit tests for all your validation methods
- Test edge cases and error conditions
- Validate against the provided test cases

### Best Practices
- Use raw string literals for regex patterns (`@"pattern"`)
- Handle null and empty string inputs
- Follow naming conventions
- Implement proper error handling

---

## Additional Resources

### Online Regex Testers
- [Regex101](https://regex101.com/) - Most popular, great explanations
- [RegExr](https://regexr.com/) - Interactive, real-time matching
- [Regex Tester](https://www.regextester.com/) - Simple and fast

### Learning Materials
- [Regex Guide](ConsoleApps/Week35/PhoneBookManagementSystem/docs/RegexGuide.md)
- [Microsoft Regex Documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expressions)

---

## Evaluation Criteria

### Code Quality (30%)
- Clean, readable code
- Proper error handling
- Good documentation
- Following C# conventions

### Functionality (40%)
- All requirements implemented
- Correct regex patterns
- Proper validation logic
- Edge cases handled

### Testing (20%)
- Comprehensive test coverage
- Edge case testing
- All provided test cases pass

### Documentation (10%)
- Clear explanations
- Usage examples
- Regex pattern documentation

---

## Tips for Success

1. **Start Simple**: Begin with basic patterns and gradually add complexity
2. **Test Thoroughly**: Use online regex testers to validate patterns
3. **Document Patterns**: Comment your regex patterns explaining the logic
4. **Handle Edge Cases**: Test with empty strings, very long strings, and special characters
5. **Use Raw Strings**: Use `@"pattern"` syntax to avoid escaping issues
6. **Study Examples**: Look at the example implementations to understand patterns

Good luck with your regex practice! Remember, regex is a powerful tool that becomes more intuitive with practice. 