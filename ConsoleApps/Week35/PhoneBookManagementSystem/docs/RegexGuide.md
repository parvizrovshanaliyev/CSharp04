# Regular Expressions (Regex) Guide for Phone Book Management System

## Table of Contents
1. [Introduction to Regex](#introduction-to-regex)
2. [Quick Reference](#quick-reference)
3. [Visual Regex Builder](#visual-regex-builder)
4. [Regex Patterns Used in This Project](#regex-patterns-used-in-this-project)
5. [Understanding Each Pattern](#understanding-each-pattern)
6. [Testing Regex Patterns](#testing-regex-patterns)
7. [Common Regex Metacharacters](#common-regex-metacharacters)
8. [Best Practices](#best-practices)
9. [Performance Optimization](#performance-optimization)
10. [Debugging and Troubleshooting](#debugging-and-troubleshooting)
11. [Real-World Examples](#real-world-examples)
12. [Learning Resources](#learning-resources)
13. [Exercises and Examples](#exercises-and-examples)

---

## Introduction to Regex

Regular Expressions (Regex) are powerful pattern-matching tools used to validate and search text. In our Phone Book Management System, we use regex to validate:

- **Email addresses** - Ensure proper email format
- **Phone numbers** - Validate international phone number formats
- **Names** - Check for valid character patterns
- **Addresses** - Validate address format requirements

### Why Use Regex?

1. **Consistency**: Ensures all data follows the same format
2. **Validation**: Prevents invalid data from being stored
3. **User Experience**: Provides immediate feedback on input errors
4. **Data Integrity**: Maintains clean, structured data
5. **Efficiency**: Single pattern can validate complex formats
6. **Flexibility**: Can handle various input formats with one pattern

---

## Quick Reference

### Most Common Metacharacters
| Character | Meaning | Example |
|-----------|---------|---------|
| `^` | Start of string | `^Hello` |
| `$` | End of string | `World$` |
| `.` | Any character | `a.c` matches "abc", "a1c" |
| `*` | Zero or more | `a*` matches "", "a", "aa" |
| `+` | One or more | `a+` matches "a", "aa", "aaa" |
| `?` | Zero or one | `a?` matches "", "a" |
| `\d` | Any digit | `\d{3}` matches "123" |
| `\w` | Word character | `\w+` matches "hello123" |
| `\s` | Whitespace | `\s+` matches spaces, tabs |
| `[abc]` | Any of a, b, c | `[abc]` matches "a", "b", or "c" |
| `[^abc]` | Not a, b, or c | `[^abc]` matches "d", "e", etc. |

### Common Patterns
| Pattern | Purpose | Example |
|---------|---------|---------|
| `^\d{3}-\d{3}-\d{4}$` | US Phone | "555-123-4567" |
| `^[^@\s]+@[^@\s]+\.[^@\s]+$` | Email | "user@domain.com" |
| `^[A-Za-z\s]{2,50}$` | Name | "John Smith" |
| `^\d{5}(-\d{4})?$` | ZIP Code | "12345" or "12345-6789" |

---

## Visual Regex Builder

### Step-by-Step Pattern Building

Let's build a regex pattern for a US phone number step by step:

**Goal**: Match phone numbers like "(555) 123-4567", "555-123-4567", "555.123.4567"

**Step 1**: Start with basic structure
```
^...$
```
*Explanation: Match entire string from start to end*

**Step 2**: Add optional opening parenthesis
```
^\(?...
```
*Explanation: Optional opening parenthesis*

**Step 3**: Add area code (3 digits)
```
^\(?[0-9]{3}...
```
*Explanation: Exactly 3 digits*

**Step 4**: Add optional closing parenthesis
```
^\(?[0-9]{3}\)?...
```
*Explanation: Optional closing parenthesis*

**Step 5**: Add optional separator
```
^\(?[0-9]{3}\)?[-. ]?...
```
*Explanation: Optional hyphen, dot, or space*

**Step 6**: Add first 3 digits
```
^\(?[0-9]{3}\)?[-. ]?[0-9]{3}...
```
*Explanation: Exactly 3 digits*

**Step 7**: Add optional separator
```
^\(?[0-9]{3}\)?[-. ]?[0-9]{3}[-. ]?...
```
*Explanation: Optional hyphen, dot, or space*

**Step 8**: Add last 4 digits
```
^\(?[0-9]{3}\)?[-. ]?[0-9]{3}[-. ]?[0-9]{4}$
```
*Explanation: Exactly 4 digits at the end*

**Final Pattern**: `^\(?[0-9]{3}\)?[-. ]?[0-9]{3}[-. ]?[0-9]{4}$`

**Test Results**:
- `(555) 123-4567` ✅
- `555-123-4567` ✅
- `555.123.4567` ✅
- `555 123 4567` ✅
- `5551234567` ✅

---

## Regex Patterns Used in This Project

### 1. Email Validation Pattern
```csharp
private readonly Regex _emailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
```

**Purpose**: Validates email addresses
**Location**: `Services/ContactValidator.cs`

### 2. Phone Number Validation Pattern
```csharp
private readonly Regex _phoneRegex = new(@"^\+?[\d\s\-\(\)]{7,20}$");
```

**Purpose**: Validates international phone numbers
**Location**: `Services/ContactValidator.cs`

### 3. Name Validation Pattern
```csharp
private readonly Regex _nameRegex = new(@"^[a-zA-Z\s\-'\.]{2,50}$");
```

**Purpose**: Validates contact names
**Location**: `Services/ContactValidator.cs`

### 4. Address Validation Pattern
```csharp
private readonly Regex _addressRegex = new(@"^[a-zA-Z0-9\s\-'\.\,]{1,200}$");
```

**Purpose**: Validates contact addresses
**Location**: `Services/ContactValidator.cs`

---

## Understanding Each Pattern

### Email Pattern: `^[^@\s]+@[^@\s]+\.[^@\s]+$`

Let's break this down:

| Component | Meaning | Example |
|-----------|---------|---------|
| `^` | Start of string | - |
| `[^@\s]+` | One or more characters that are NOT @ or whitespace | `john`, `user123` |
| `@` | Literal @ symbol | `@` |
| `[^@\s]+` | One or more characters that are NOT @ or whitespace | `gmail`, `company` |
| `\.` | Literal dot (escaped) | `.` |
| `[^@\s]+` | One or more characters that are NOT @ or whitespace | `com`, `org` |
| `$` | End of string | - |

**Valid Examples:**
- `john.doe@gmail.com` ✅
- `user123@company.org` ✅
- `test@domain.co.uk` ✅

**Invalid Examples:**
- `john@.com` ❌ (no domain before dot)
- `@gmail.com` ❌ (no username)
- `john@gmail` ❌ (no domain extension)
- `john gmail.com` ❌ (space instead of @)

### Phone Number Pattern: `^\+?[\d\s\-\(\)]{7,20}$`

| Component | Meaning | Example |
|-----------|---------|---------|
| `^` | Start of string | - |
| `\+?` | Optional plus sign | `+` or nothing |
| `[\d\s\-\(\)]` | Any digit, space, hyphen, or parentheses | `1`, ` `, `-`, `(`, `)` |
| `{7,20}` | Between 7 and 20 characters | - |
| `$` | End of string | - |

**Valid Examples:**
- `+1-555-0123` ✅
- `5550123` ✅
- `+44 20 7946 0958` ✅
- `(555) 123-4567` ✅

**Invalid Examples:**
- `123` ❌ (too short)
- `+1-555-01234567890123456789` ❌ (too long)
- `abc-def-ghij` ❌ (contains letters)

### Name Pattern: `^[a-zA-Z\s\-'\.]{2,50}$`

| Component | Meaning | Example |
|-----------|---------|---------|
| `^` | Start of string | - |
| `[a-zA-Z\s\-'\.]` | Letters, spaces, hyphens, apostrophes, dots | `a`, ` `, `-`, `'`, `.` |
| `{2,50}` | Between 2 and 50 characters | - |
| `$` | End of string | - |

**Valid Examples:**
- `John Smith` ✅
- `Mary-Jane` ✅
- `O'Connor` ✅
- `Dr. Smith` ✅

**Invalid Examples:**
- `A` ❌ (too short)
- `John123` ❌ (contains numbers)
- `John@Smith` ❌ (contains special characters)

### Address Pattern: `^[a-zA-Z0-9\s\-'\.\,]{1,200}$`

| Component | Meaning | Example |
|-----------|---------|---------|
| `^` | Start of string | - |
| `[a-zA-Z0-9\s\-'\.\,]` | Letters, numbers, spaces, hyphens, apostrophes, dots, commas | `a`, `1`, ` `, `-`, `'`, `.`, `,` |
| `{1,200}` | Between 1 and 200 characters | - |
| `$` | End of string | - |

**Valid Examples:**
- `123 Main St` ✅
- `456 Oak Ave, Apt 7B` ✅
- `P.O. Box 123` ✅

**Invalid Examples:**
- `123 Main St@` ❌ (contains @)
- `123 Main St#` ❌ (contains #)

---

## Testing Regex Patterns

### Online Regex Testers
1. **Regex101**: https://regex101.com/ - Most popular, great explanations
2. **RegExr**: https://regexr.com/ - Interactive, real-time matching
3. **Regex Tester**: https://www.regextester.com/ - Simple and fast
4. **Debuggex**: https://www.debuggex.com/ - Visual regex debugger

### C# Testing Example
```csharp
// Test email pattern
string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
Regex emailRegex = new Regex(emailPattern);

string[] testEmails = {
    "john.doe@gmail.com",
    "user@domain.org",
    "invalid.email",
    "@gmail.com",
    "john@gmail"
};

foreach (string email in testEmails)
{
    bool isValid = emailRegex.IsMatch(email);
    Console.WriteLine($"Email: {email} -> Valid: {isValid}");
}
```

### Unit Testing with Regex
```csharp
[Test]
public void EmailValidation_ValidEmails_ShouldReturnTrue()
{
    var validator = new ContactValidator();
    string[] validEmails = {
        "test@example.com",
        "user.name@domain.org",
        "john123@company.co.uk"
    };
    
    foreach (string email in validEmails)
    {
        Assert.IsTrue(validator.IsValidEmail(email), 
            $"Email {email} should be valid");
    }
}

[Test]
public void EmailValidation_InvalidEmails_ShouldReturnFalse()
{
    var validator = new ContactValidator();
    string[] invalidEmails = {
        "invalid.email",
        "@domain.com",
        "user@",
        "user@.com"
    };
    
    foreach (string email in invalidEmails)
    {
        Assert.IsFalse(validator.IsValidEmail(email), 
            $"Email {email} should be invalid");
    }
}
```

### Interactive Testing in C#
```csharp
public static void TestRegexPattern(string pattern, string[] testStrings)
{
    Regex regex = new Regex(pattern);
    
    Console.WriteLine($"Testing pattern: {pattern}");
    Console.WriteLine(new string('-', 50));
    
    foreach (string testString in testStrings)
    {
        bool isMatch = regex.IsMatch(testString);
        string result = isMatch ? "✅ MATCH" : "❌ NO MATCH";
        Console.WriteLine($"{testString,-20} -> {result}");
    }
    
    Console.WriteLine();
}

// Usage
string phonePattern = @"^\+?[\d\s\-\(\)]{7,20}$";
string[] testPhones = {
    "+1-555-0123",
    "5550123",
    "123",
    "abc-def-ghij"
};

TestRegexPattern(phonePattern, testPhones);
```

---

## Common Regex Metacharacters

### Anchors
| Character | Meaning | Example |
|-----------|---------|---------|
| `^` | Start of string | `^Hello` matches "Hello World" but not "World Hello" |
| `$` | End of string | `World$` matches "Hello World" but not "World Hello" |
| `\b` | Word boundary | `\bcat\b` matches "cat" but not "category" |
| `\B` | Not word boundary | `\Bcat\B` matches "category" but not "cat" |

### Character Classes
| Pattern | Meaning | Example |
|---------|---------|---------|
| `[abc]` | Any single character from set | `[abc]` matches "a", "b", or "c" |
| `[^abc]` | Any character NOT in set | `[^abc]` matches "d", "e", "f", etc. |
| `[a-z]` | Any lowercase letter | `[a-z]` matches "a" through "z" |
| `[A-Z]` | Any uppercase letter | `[A-Z]` matches "A" through "Z" |
| `[0-9]` | Any digit | `[0-9]` matches "0" through "9" |
| `\d` | Any digit (same as [0-9]) | `\d` matches "0" through "9" |
| `\D` | Any non-digit | `\D` matches "a", "b", "!", etc. |
| `\w` | Word character (letter, digit, underscore) | `\w` matches "a", "1", "_" |
| `\W` | Non-word character | `\W` matches "!", "@", " ", etc. |
| `\s` | Whitespace character | `\s` matches space, tab, newline |
| `\S` | Non-whitespace character | `\S` matches "a", "1", "!", etc. |

### Quantifiers
| Character | Meaning | Example |
|-----------|---------|---------|
| `*` | Zero or more | `a*` matches "", "a", "aa", "aaa", etc. |
| `+` | One or more | `a+` matches "a", "aa", "aaa", etc. |
| `?` | Zero or one | `a?` matches "" or "a" |
| `{n}` | Exactly n times | `a{3}` matches "aaa" |
| `{n,}` | n or more times | `a{2,}` matches "aa", "aaa", etc. |
| `{n,m}` | Between n and m times | `a{2,4}` matches "aa", "aaa", "aaaa" |
| `*?` | Lazy zero or more | `a*?` matches as few as possible |
| `+?` | Lazy one or more | `a+?` matches as few as possible |

### Special Characters
| Character | Meaning | Example |
|-----------|---------|---------|
| `.` | Any character except newline | `.` matches "a", "1", "@", etc. |
| `\` | Escape character | `\.` matches literal dot |
| `\|` | Alternation (OR) | `cat\|dog` matches "cat" or "dog" |
| `()` | Grouping | `(ab)+` matches "ab", "abab", etc. |
| `(?:)` | Non-capturing group | `(?:ab)+` groups but doesn't capture |

---

## Best Practices

### 1. Use Raw String Literals
```csharp
// Good - Raw string literal (C# 11+)
private readonly Regex _emailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

// Avoid - Escaped strings
private readonly Regex _emailRegex = new("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$");
```

### 2. Compile Regex for Performance
```csharp
// Good - Compiled regex for repeated use
private static readonly Regex _emailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

// Regular regex for one-time use
Regex tempRegex = new(@"\d+");
```

### 3. Use Meaningful Variable Names
```csharp
// Good
private readonly Regex _emailValidationPattern = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

// Avoid
private readonly Regex _regex1 = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
```

### 4. Add Comments for Complex Patterns
```csharp
// Email validation: username@domain.extension
// - Username: one or more non-@, non-whitespace characters
// - Domain: one or more non-@, non-whitespace characters
// - Extension: one or more non-@, non-whitespace characters
private readonly Regex _emailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
```

### 5. Test Edge Cases
```csharp
public void TestEmailValidation()
{
    var validator = new ContactValidator();
    
    // Test valid emails
    Assert.IsTrue(validator.IsValidEmail("test@example.com"));
    Assert.IsTrue(validator.IsValidEmail("user.name@domain.org"));
    
    // Test edge cases
    Assert.IsFalse(validator.IsValidEmail("")); // Empty string
    Assert.IsFalse(validator.IsValidEmail("test@.com")); // No domain
    Assert.IsFalse(validator.IsValidEmail("@example.com")); // No username
    Assert.IsFalse(validator.IsValidEmail("test@example")); // No extension
}
```

### 6. Use Constants for Reusable Patterns
```csharp
public static class RegexPatterns
{
    public const string Email = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
    public const string Phone = @"^\+?[\d\s\-\(\)]{7,20}$";
    public const string Name = @"^[a-zA-Z\s\-'\.]{2,50}$";
    public const string Address = @"^[a-zA-Z0-9\s\-'\.\,]{1,200}$";
}

// Usage
private readonly Regex _emailRegex = new(RegexPatterns.Email);
```

---

## Performance Optimization

### 1. Use Compiled Regex for Repeated Use
```csharp
// Good for frequently used patterns
private static readonly Regex _emailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

// Regular regex for one-time use
Regex tempRegex = new(@"\d+");
```

### 2. Avoid Regex for Simple String Operations
```csharp
// Bad - using regex for simple check
bool hasDigit = Regex.IsMatch(input, @"\d");

// Good - using string methods
bool hasDigit = input.Any(char.IsDigit);

// Bad - using regex for simple replacement
string result = Regex.Replace(input, @"\s+", " ");

// Good - using string methods
string result = string.Join(" ", input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
```

### 3. Use Non-Capturing Groups When Possible
```csharp
// Capturing group (slower)
string pattern = @"(hello|world)";

// Non-capturing group (faster)
string pattern = @"(?:hello|world)";
```

### 4. Be Careful with Backtracking
```csharp
// Potentially slow - lots of backtracking
string slowPattern = @"(a+)+b";

// Better - atomic group
string fastPattern = @"(?>a+)+b";

// Or use possessive quantifier
string fastPattern2 = @"a++b";
```

### 5. Use Appropriate Regex Options
```csharp
// Case insensitive matching
Regex regex = new(@"hello", RegexOptions.IgnoreCase);

// Multiline mode for ^ and $ to match line boundaries
Regex regex = new(@"^start", RegexOptions.Multiline);

// Single line mode (dot matches newlines)
Regex regex = new(@".*", RegexOptions.Singleline);

// Right-to-left matching
Regex regex = new(@"\d+", RegexOptions.RightToLeft);
```

### 6. Cache Regex Objects
```csharp
// Bad - creating new regex each time
public bool IsValidEmail(string email)
{
    return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
}

// Good - cached regex
private static readonly Regex _emailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

public bool IsValidEmail(string email)
{
    return _emailRegex.IsMatch(email);
}
```

### 7. Use Constants for Reusable Patterns
```csharp
public static class RegexPatterns
{
    public const string Email = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
    public const string Phone = @"^\+?[\d\s\-\(\)]{7,20}$";
    public const string Name = @"^[a-zA-Z\s\-'\.]{2,50}$";
    public const string Address = @"^[a-zA-Z0-9\s\-'\.\,]{1,200}$";
}

// Usage
private readonly Regex _emailRegex = new(RegexPatterns.Email);
```

---

## Debugging and Troubleshooting

### Common Issues and Solutions

#### Issue 1: Pattern Not Matching Expected Text
**Problem**: Your regex doesn't match what you expect.

**Debugging Steps**:
1. **Use online testers** like Regex101 to visualize the pattern
2. **Break down the pattern** into smaller parts
3. **Test with simple examples** first
4. **Check for escaping issues**

**Example**:
```csharp
// Problem: Want to match "example.com"
string pattern = @"example.com"; // Wrong - dot matches any character
string correctPattern = @"example\.com"; // Correct - escaped dot
```

#### Issue 2: Greedy vs Lazy Matching
**Problem**: Pattern matches too much or too little.

**Solution**:
```csharp
// Greedy (default) - matches as much as possible
string greedyPattern = @"<.*>"; // Matches entire string
// Input: "<tag>content</tag>"
// Result: "<tag>content</tag>"

// Lazy - matches as little as possible
string lazyPattern = @"<.*?>"; // Matches individual tags
// Input: "<tag>content</tag>"
// Result: "<tag>", "</tag>"
```

#### Issue 3: Anchors Not Working
**Problem**: Pattern matches in middle of string when you want full match.

**Solution**:
```csharp
// Wrong - matches anywhere in string
string wrongPattern = @"\d{3}-\d{4}";
// Input: "Phone: 555-1234 and 123-4567"
// Result: "555-1234", "123-4567"

// Correct - matches entire string
string correctPattern = @"^\d{3}-\d{4}$";
// Input: "555-1234"
// Result: "555-1234"
```

### Debugging Tools and Techniques

#### 1. Use Regex101 for Visualization
- Paste your pattern and test string
- See exactly what matches and what doesn't
- Get explanations for each part of the pattern

#### 2. Use C# Debugging
```csharp
public static void DebugRegex(string pattern, string testString)
{
    Regex regex = new Regex(pattern);
    Match match = regex.Match(testString);
    
    Console.WriteLine($"Pattern: {pattern}");
    Console.WriteLine($"Test String: {testString}");
    Console.WriteLine($"Success: {match.Success}");
    
    if (match.Success)
    {
        Console.WriteLine($"Match: '{match.Value}'");
        Console.WriteLine($"Index: {match.Index}");
        Console.WriteLine($"Length: {match.Length}");
        
        // Show groups
        for (int i = 0; i < match.Groups.Count; i++)
        {
            Console.WriteLine($"Group {i}: '{match.Groups[i].Value}'");
        }
    }
    else
    {
        Console.WriteLine("No match found");
    }
}
```

#### 3. Step-by-Step Pattern Building
```csharp
public static void TestPatternStep(string pattern, string testString, string stepName)
{
    Regex regex = new Regex(pattern);
    bool isMatch = regex.IsMatch(testString);
    
    Console.WriteLine($"[{stepName}] Pattern: {pattern}");
    Console.WriteLine($"[{stepName}] Test: '{testString}' -> {(isMatch ? "✅" : "❌")}");
    Console.WriteLine();
}
```

---

## Real-World Examples

### 1. Credit Card Validation
```csharp
// Basic credit card pattern (13-19 digits, may contain spaces/hyphens)
string cardPattern = @"^[3-6]\d{3}[- ]?\d{4}[- ]?\d{4}[- ]?\d{4}$";

// Test cases
string[] testCards = {
    "4111111111111111",     // Visa
    "5555 5555 5555 4444",  // MasterCard with spaces
    "3782-822463-10005",    // American Express with hyphens
    "1234567890123456",     // Invalid (starts with 1)
    "411111111111111"       // Too short
};
```

### 2. Password Strength Validation
```csharp
// Password requirements:
// - At least 8 characters
// - Contains uppercase, lowercase, digit, and special character
string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

// Test cases
string[] testPasswords = {
    "StrongPass1!",     // Valid
    "weakpass",         // No uppercase, digit, or special char
    "WeakPass1",        // No special character
    "WEAKPASS1!",       // No lowercase
    "WeakPass!",        // No digit
    "Weak1!"            // Too short
};
```

### 3. Date Validation (MM/DD/YYYY)
```csharp
// Date in MM/DD/YYYY format (1900-2099)
string datePattern = @"^(0[1-9]|1[0-2])/(0[1-9]|[12]\d|3[01])/(19|20)\d{2}$";

// Test cases
string[] testDates = {
    "12/25/2023",       // Valid
    "01/01/1900",       // Valid
    "13/01/2023",       // Invalid month
    "12/32/2023",       // Invalid day
    "12/25/1899",       // Invalid year
    "1/1/2023",         // Invalid format (missing leading zeros)
    "12-25-2023"        // Invalid format (wrong separator)
};
```

### 4. URL Validation
```csharp
// Basic URL validation
string urlPattern = @"^https?://[^\s/$.?#].[^\s]*$";

// Test cases
string[] testUrls = {
    "https://www.example.com",           // Valid
    "http://example.com/path",           // Valid
    "ftp://example.com",                 // Invalid (not http/https)
    "https://",                          // Invalid (no domain)
    "example.com",                       // Invalid (no protocol)
    "https://example.com/path?param=1"   // Valid
};
```

### 5. Social Security Number (US)
```csharp
// SSN format: XXX-XX-XXXX
string ssnPattern = @"^\d{3}-\d{2}-\d{4}$";

// Test cases
string[] testSsns = {
    "123-45-6789",      // Valid
    "123456789",        // Invalid (no hyphens)
    "12-345-6789",      // Invalid (wrong format)
    "123-45-67890",     // Invalid (too many digits)
    "abc-def-ghij"      // Invalid (not digits)
};
```

### 6. ZIP Code Validation
```csharp
// ZIP format: 5 digits or 5+4 digits
string zipPattern = @"^\d{5}(-\d{4})?$";

// Test cases
string[] testZips = {
    "12345",            // Valid
    "12345-6789",       // Valid
    "1234",             // Invalid (too short)
    "123456",           // Invalid (too long)
    "12345-678",        // Invalid (wrong format)
    "abcde"             // Invalid (not digits)
};
```

---

## Learning Resources

### Online Tutorials
1. **Microsoft Docs**: https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expressions
2. **RegexOne**: https://regexone.com/ - Interactive tutorial
3. **Regular-Expressions.info**: https://www.regular-expressions.info/
4. **MDN Web Docs**: https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Regular_Expressions

### Books
1. **"Mastering Regular Expressions"** by Jeffrey Friedl
2. **"Regular Expressions Cookbook"** by Jan Goyvaerts
3. **"Introducing Regular Expressions"** by Michael Fitzgerald

### Practice Websites
1. **Regex Crossword**: https://regexcrossword.com/
2. **Regex Golf**: https://alf.nu/RegexGolf
3. **HackerRank Regex**: https://www.hackerrank.com/domains/regex
4. **Regex101 Challenges**: https://regex101.com/quiz

### Video Tutorials
1. **YouTube**: Search for "regex tutorial C#" or "regular expressions explained"
2. **Pluralsight**: Regular Expressions courses
3. **Udemy**: Regex courses for various programming languages

---

## Exercises and Examples

### Exercise 1: Basic Email Validation
Create a regex pattern to validate email addresses with the following rules:
- Must contain exactly one @ symbol
- Username must be 3-20 characters long
- Domain must be 2-50 characters long
- Must end with .com, .org, or .net

**Solution:**
```csharp
string emailPattern = @"^[a-zA-Z0-9._%+-]{3,20}@[a-zA-Z0-9.-]{2,50}\.(com|org|net)$";
```

### Exercise 2: Phone Number Validation
Create a regex pattern to validate US phone numbers in these formats:
- (555) 123-4567
- 555-123-4567
- 555.123.4567
- 5551234567

**Solution:**
```csharp
string phonePattern = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
```

### Exercise 3: Password Validation
Create a regex pattern to validate passwords with these requirements:
- At least 8 characters long
- Contains at least one uppercase letter
- Contains at least one lowercase letter
- Contains at least one digit
- Contains at least one special character

**Solution:**
```csharp
string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
```

### Exercise 4: Date Validation
Create a regex pattern to validate dates in MM/DD/YYYY format:
- Month: 01-12
- Day: 01-31
- Year: 1900-2099

**Solution:**
```csharp
string datePattern = @"^(0[1-9]|1[0-2])/(0[1-9]|[12]\d|3[01])/(19|20)\d{2}$";
```

### Exercise 5: Credit Card Validation
Create a regex pattern to validate credit card numbers:
- 13-19 digits
- May contain spaces or hyphens
- Must start with 3, 4, 5, or 6

**Solution:**
```csharp
string cardPattern = @"^[3-6]\d{3}[- ]?\d{4}[- ]?\d{4}[- ]?\d{4}$";
```

### Exercise 6: ZIP Code Validation
Create a regex pattern to validate US ZIP codes:
- 5 digits (12345)
- Or 5 digits + 4 digits (12345-6789)

**Solution:**
```csharp
string zipPattern = @"^\d{5}(-\d{4})?$";
```

### Exercise 7: Time Validation (24-hour format)
Create a regex pattern to validate time in HH:MM format:
- Hours: 00-23
- Minutes: 00-59

**Solution:**
```csharp
string timePattern = @"^([01]\d|2[0-3]):([0-5]\d)$";
```

### Exercise 8: IP Address Validation
Create a regex pattern to validate IPv4 addresses:
- Four octets separated by dots
- Each octet: 0-255

**Solution:**
```csharp
string ipPattern = @"^((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(25[0-5]|2[0-4]\d|[01]?\d\d?)$";
```

---

## Advanced Regex Features

### Lookahead and Lookbehind
```csharp
// Positive lookahead: (?=...)
// Password must contain at least one digit
string passwordPattern = @"^(?=.*\d).{8,}$";

// Negative lookahead: (?!...)
// Username cannot end with numbers
string usernamePattern = @"^[a-zA-Z][a-zA-Z0-9]*(?!\d)$";

// Positive lookbehind: (?<=...)
// Match word after "Hello "
string pattern = @"(?<=Hello )\w+";

// Negative lookbehind: (?<!...)
// Match word not after "Hello "
string pattern = @"(?<!Hello )\w+";
```

### Named Groups
```csharp
// Extract parts of email address
string emailPattern = @"^(?<username>[^@\s]+)@(?<domain>[^@\s]+)\.(?<extension>[^@\s]+)$";

Match match = Regex.Match("john.doe@gmail.com", emailPattern);
if (match.Success)
{
    string username = match.Groups["username"].Value; // "john.doe"
    string domain = match.Groups["domain"].Value;     // "gmail"
    string extension = match.Groups["extension"].Value; // "com"
}
```

### Regex Options
```csharp
// Case insensitive
Regex regex = new(@"hello", RegexOptions.IgnoreCase);

// Multiline mode
Regex regex = new(@"^start", RegexOptions.Multiline);

// Single line mode (dot matches newlines)
Regex regex = new(@".*", RegexOptions.Singleline);

// Compiled for performance
Regex regex = new(@"\d+", RegexOptions.Compiled);

// Multiple options
Regex regex = new(@"hello", RegexOptions.IgnoreCase | RegexOptions.Compiled);
```

---

## Common Mistakes to Avoid

### 1. Greedy vs Lazy Quantifiers
```csharp
// Greedy (default) - matches as much as possible
string greedyPattern = @"<.*>"; // Matches entire string
// Input: "<tag>content</tag>"
// Result: "<tag>content</tag>"

// Lazy - matches as little as possible
string lazyPattern = @"<.*?>"; // Matches individual tags
// Input: "<tag>content</tag>"
// Result: "<tag>", "</tag>"
```

### 2. Forgetting to Escape Special Characters
```csharp
// Wrong - dot matches any character
string wrongPattern = @"example.com";

// Correct - dot matches literal dot
string correctPattern = @"example\.com";
```

### 3. Not Using Anchors
```csharp
// Wrong - matches anywhere in string
string wrongPattern = @"\d{3}-\d{4}";
// Input: "Phone: 555-1234 and 123-4567"
// Result: "555-1234", "123-4567"

// Correct - matches entire string
string correctPattern = @"^\d{3}-\d{4}$";
// Input: "555-1234"
// Result: "555-1234"
```

### 4. Overly Complex Patterns
```csharp
// Too complex - hard to maintain
string complexPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

// Better - break into parts
string usernamePattern = @"[a-zA-Z0-9._%+-]+";
string domainPattern = @"[a-zA-Z0-9.-]+";
string extensionPattern = @"[a-zA-Z]{2,}";
string emailPattern = $@"^{usernamePattern}@{domainPattern}\.{extensionPattern}$";
```

### 5. Not Testing Edge Cases
```csharp
// Always test with:
// - Empty strings
// - Very long strings
// - Special characters
// - Unicode characters
// - Boundary conditions

public void TestEdgeCases()
{
    var validator = new ContactValidator();
    
    // Test empty and null
    Assert.IsFalse(validator.IsValidEmail(""));
    Assert.IsFalse(validator.IsValidEmail(null));
    
    // Test very long strings
    string longEmail = new string('a', 1000) + "@example.com";
    Assert.IsFalse(validator.IsValidEmail(longEmail));
    
    // Test special characters
    Assert.IsFalse(validator.IsValidEmail("test@example.com\n"));
    Assert.IsFalse(validator.IsValidEmail("test@example.com\r"));
}
```

---

## Performance Considerations

### 1. Use Compiled Regex for Repeated Use
```csharp
// Good for frequently used patterns
private static readonly Regex _emailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);
```

### 2. Avoid Regex for Simple String Operations
```csharp
// Bad - using regex for simple check
bool hasDigit = Regex.IsMatch(input, @"\d");

// Good - using string methods
bool hasDigit = input.Any(char.IsDigit);
```

### 3. Use Non-Capturing Groups When Possible
```csharp
// Capturing group (slower)
string pattern = @"(hello|world)";

// Non-capturing group (faster)
string pattern = @"(?:hello|world)";
```

### 4. Be Careful with Backtracking
```csharp
// Potentially slow - lots of backtracking
string slowPattern = @"(a+)+b";

// Better - atomic group
string fastPattern = @"(?>a+)+b";
```

---

## Conclusion

Regular expressions are powerful tools for text validation and manipulation. In our Phone Book Management System, they help ensure data quality and provide a better user experience. 

Remember:
- Start simple and build complexity gradually
- Test thoroughly with various inputs
- Use online tools to debug patterns
- Document complex patterns with comments
- Consider performance for frequently used patterns
- Practice regularly with the exercises provided

### Final Tips for Success:
1. **Start with simple patterns** and gradually add complexity
2. **Test your patterns** with a variety of inputs
3. **Use online regex testers** to visualize and debug patterns
4. **Document your patterns** with comments explaining the logic
5. **Consider performance** when using regex in loops or frequently called methods
6. **Keep patterns readable** by breaking complex ones into smaller parts
7. **Learn from examples** and practice regularly

### Common Mistakes to Avoid:
1. **Forgetting to escape special characters** like dots, parentheses, and brackets
2. **Not using anchors** when you want to match the entire string
3. **Using greedy quantifiers** when lazy ones would be more appropriate
4. **Overly complex patterns** that are hard to maintain and debug
5. **Not testing edge cases** like empty strings, very long strings, and special characters
6. **Using regex for simple string operations** that could be done with built-in methods

### Performance Best Practices:
1. **Compile frequently used patterns** with `RegexOptions.Compiled`
2. **Cache regex objects** instead of creating them repeatedly
3. **Use non-capturing groups** when you don't need to capture the content
4. **Avoid catastrophic backtracking** by using atomic groups or possessive quantifiers
5. **Choose the right regex options** for your use case
6. **Use string methods** for simple operations instead of regex

### Debugging Strategies:
1. **Use online tools** like Regex101 to visualize and test patterns
2. **Break complex patterns** into smaller, testable parts
3. **Test with edge cases** including empty strings, very long strings, and special characters
4. **Use C# debugging tools** to step through regex execution
5. **Add logging** to see what your regex is matching and why

Practice regularly with the exercises provided, and you'll become proficient in using regex for data validation and text processing. 

Happy regex coding! 