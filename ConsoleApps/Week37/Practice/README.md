# Week 37 - Regular Expressions Practice

## Overview
This project contains practice tasks for learning Regular Expressions (Regex) in C#. The project is structured to provide both example implementations and tasks for you to complete yourself.

## Project Structure

```
Week37/Practice/
├── Program.cs              # Main program with test demonstrations
├── RegexValidator.cs       # Example implementations (study these!)
├── TextProcessor.cs        # Example implementations (study these!)
├── StudentTasks.cs         # YOUR implementations go here
├── regex-task.md          # Task descriptions and requirements
└── README.md              # This file
```

## What You Need to Do

### 1. Study the Example Implementations
Before implementing your own tasks, study the example implementations in:
- `RegexValidator.cs` - Basic validation methods
- `TextProcessor.cs` - Advanced text processing methods

These files contain well-documented, working implementations that demonstrate:
- Proper regex pattern usage
- Input validation and error handling
- XML documentation
- Best practices for C# regex

### 2. Implement Your Tasks
Open `StudentTasks.cs` and implement the following methods:

#### Task 2.3: Credit Card Validation
```csharp
public static bool IsValidCreditCard(string cardNumber)
```
- Remove non-digit characters
- Check if starts with 3, 4, 5, or 6
- Validate length (13-19 digits)

#### Task 5.1: IP Address Validation
```csharp
public static bool IsValidIpAddress(string ipAddress)
```
- Validate IPv4 format (four octets)
- Each octet: 0-255
- No leading zeros (except 0)

#### Task 5.2: Time Format Validation
```csharp
public static bool IsValidTime(string time)
```
- Format: HH:MM (24-hour)
- Hours: 00-23
- Minutes: 00-59

#### Task 5.3: ZIP Code Validation
```csharp
public static bool IsValidZipCode(string zipCode)
```
- 5 digits OR 5 digits + 4 digits
- Format: 12345 or 12345-6789

#### Task 5.4: Credit Card Formatter
```csharp
public static string? FormatCreditCard(string cardNumber)
```
- Format to XXXX-XXXX-XXXX-XXXX
- Remove non-digit characters
- Validate length (13-19 digits)

#### Task 5.5: Number Extractor
```csharp
public static int[] ExtractNumbers(string text)
```
- Extract all numbers from text
- Return array of integers
- Handle various number formats

#### Bonus Task: Word Counter
```csharp
public static Hashtable CountWordFrequency(string text)
```
- Count word frequencies
- Ignore case
- Remove punctuation

### 3. Test Your Implementations
Run the program to test your implementations:

```bash
dotnet run
```

The program will:
1. Show example implementations working
2. Test your student implementations
3. Display results with ✅/❌ indicators

## Important Rules

### Collections Usage
- ✅ **Use**: `ArrayList`, `Hashtable`, arrays (`int[]`, `string[]`)
- ❌ **Don't use**: `List<T>`, `Dictionary<K,V>`, or other generic collections

### Regex Best Practices
1. **Use raw string literals**: `@"pattern"` instead of `"pattern"`
2. **Handle null/empty inputs**: Always check for null or empty strings
3. **Document your patterns**: Add comments explaining regex logic
4. **Test edge cases**: Empty strings, very long strings, special characters

### Example Pattern Documentation
```csharp
/// <summary>
/// Email validation pattern: ^[a-zA-Z0-9._%+-]{3,20}@[a-zA-Z0-9.-]{2,50}\.(com|org|net|edu)$
/// 
/// Breakdown:
/// - ^ : Start of string
/// - [a-zA-Z0-9._%+-]{3,20} : Username (3-20 chars, letters, digits, dots, etc.)
/// - @ : Literal @ symbol
/// - [a-zA-Z0-9.-]{2,50} : Domain (2-50 chars, letters, digits, dots, hyphens)
/// - \.(com|org|net|edu) : Literal dot followed by allowed TLDs
/// - $ : End of string
/// </summary>
```

## Testing Your Code

### Running Tests
1. Open terminal in the project directory
2. Run: `dotnet run`
3. Check the "Student Implementation Tests" section
4. Look for ✅ (correct) or ❌ (incorrect) results

### Expected Output Example
```
--- Student Implementation Tests ---

Credit Card Validation (Task 2.3):
Valid credit cards:
  4111111111111111      -> ✅
  5555 5555 5555 4444   -> ✅
  3782-822463-10005     -> ✅
  6011111111111117      -> ✅
Invalid credit cards:
  1234567890123456      -> ✅
  411111111111111       -> ✅
  abc-def-ghij-klmn     -> ✅
```

### Debugging Tips
1. **Use online regex testers**:
   - [Regex101](https://regex101.com/)
   - [RegExr](https://regexr.com/)

2. **Test with simple cases first**:
   - Start with basic patterns
   - Add complexity gradually
   - Test edge cases last

3. **Check your patterns**:
   - Verify escaping (dots, parentheses, etc.)
   - Ensure proper anchors (^ and $)
   - Test with various inputs

## Common Mistakes to Avoid

### 1. Forgetting to Escape Special Characters
```csharp
// Wrong
string pattern = @"example.com";

// Correct
string pattern = @"example\.com";
```

### 2. Not Using Anchors
```csharp
// Wrong - matches anywhere in string
string pattern = @"\d{3}-\d{4}";

// Correct - matches entire string
string pattern = @"^\d{3}-\d{4}$";
```

### 3. Not Handling Null/Empty Inputs
```csharp
// Always check for null/empty first
if (string.IsNullOrWhiteSpace(input))
    return false;
```

### 4. Using Generic Collections
```csharp
// Wrong - don't use generics
List<string> results = new List<string>();

// Correct - use non-generic collections
ArrayList results = new ArrayList();
```

## Resources

### Documentation
- [Task Requirements](regex-task.md) - Detailed task descriptions
- [Regex Guide](../Week35/PhoneBookManagementSystem/docs/RegexGuide.md) - Comprehensive regex guide

### Online Tools
- [Regex101](https://regex101.com/) - Test and debug patterns
- [RegExr](https://regexr.com/) - Interactive regex testing
- [Microsoft Regex Docs](https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expressions)

### Learning Materials
- Study the example implementations in `RegexValidator.cs` and `TextProcessor.cs`
- Read the XML documentation in the example files
- Practice with the provided test cases

## Submission Checklist

Before submitting your work, ensure:

- [ ] All 6 required methods are implemented in `StudentTasks.cs`
- [ ] All methods handle null/empty inputs properly
- [ ] All methods use correct regex patterns
- [ ] All methods return expected results for test cases
- [ ] Code is well-documented with comments
- [ ] No generic collections are used
- [ ] Program runs without errors
- [ ] All tests pass (show ✅ for correct results)

## Getting Help

If you're stuck:

1. **Study the examples** - Look at how similar problems are solved in `RegexValidator.cs`
2. **Use online testers** - Test your patterns before implementing
3. **Start simple** - Build complex patterns step by step
4. **Check the regex guide** - Reference the comprehensive guide in the docs folder

Good luck with your regex practice! Remember, regex becomes easier with practice. Start with simple patterns and gradually build complexity. 