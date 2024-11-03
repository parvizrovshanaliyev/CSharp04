using System;
using System.Linq;

namespace Practice
{
    class StringTasks
    {
        static void Run()
        {
            // --- Task 1: Count Characters in a String ---
            /*
             * Description:
             * Write a program that asks the user for a string and outputs
             * the number of characters in it.
             *
             * Explanation:
             * The `Length` property of a string provides the total count of characters,
             * including spaces and punctuation.
             *
             * Sample Input:
             *   Enter a string: Hello, World!
             * Sample Output:
             *   The string has 13 characters.
             */

            Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            int characterCount = input.Length;
            Console.WriteLine($"The string has {characterCount} characters.\n");

            // --- Task 2: Check if String Contains a Substring ---
            /*
             * Description:
             * Prompt the user for two strings and check if the second string
             * is a substring of the first.
             *
             * Explanation:
             * Use the `Contains` method of the main string to determine if it includes the substring.
             *
             * Sample Input:
             *   Enter the main string: Programming is fun
             *   Enter the substring to search: fun
             * Sample Output:
             *   The substring 'fun' is found in the main string.
             */

            Console.Write("Enter the main string: ");
            string mainString = Console.ReadLine();
            Console.Write("Enter the substring to search: ");
            string substring = Console.ReadLine();
            if (mainString.Contains(substring))
                Console.WriteLine($"The substring '{substring}' is found in the main string.\n");
            else
                Console.WriteLine($"The substring '{substring}' is not found in the main string.\n");

            // --- Task 3: Convert to Uppercase ---
            /*
             * Description:
             * Take a string as input and convert it to uppercase.
             *
             * Explanation:
             * Use the `ToUpper` method to change all characters in the string to uppercase.
             *
             * Sample Input:
             *   Enter a string: hello world
             * Sample Output:
             *   Output: HELLO WORLD
             */

            Console.Write("Enter a string: ");
            string toConvert = Console.ReadLine();
            Console.WriteLine($"Output: {toConvert.ToUpper()}\n");

            // --- Task 4: Count Vowels and Consonants ---
            /*
             * Description:
             * Ask the user for a string and count the number of vowels and consonants in it.
             *
             * Explanation:
             * Loop through each character in the string, check if it's a letter, then determine
             * if it's a vowel or consonant using a predefined set of vowels.
             *
             * Sample Input:
             *   Enter a string: Hello
             * Sample Output:
             *   Vowels: 2, Consonants: 3
             */

            Console.Write("Enter a string: ");
            string vowelString = Console.ReadLine();
            int vowels = 0, consonants = 0;
            string vowelChars = "aeiouAEIOU";
            foreach (char c in vowelString)
            {
                if (char.IsLetter(c))
                {
                    if (vowelChars.Contains(c))
                        vowels++;
                    else
                        consonants++;
                }
            }
            Console.WriteLine($"Vowels: {vowels}, Consonants: {consonants}\n");

            // --- Task 5: Reverse a String (Using LINQ) ---
            /*
             * Description:
             * Take a string as input and output it in reverse.
             *
             * Explanation:
             * This version uses LINQ to reverse the string by converting it to an array,
             * reversing it, and converting it back to a string.
             *
             * Sample Input:
             *   Enter a string: OpenAI
             * Sample Output:
             *   Output: IAnepO
             */

            Console.Write("Enter a string: ");
            string toReverse = Console.ReadLine();
            string reversedWithLinq1 = new string(toReverse.Reverse().ToArray());
            Console.WriteLine($"Output (LINQ): {reversedWithLinq1}\n");


            // --- Task 5: Reverse a String (Using Loop) ---
            /*
             * Description:
             * Take a string as input and output it in reverse.
             *
             * Explanation:
             * This version uses a loop to reverse the string manually, adding each character
             * from the end of the original string to a new string variable.
             *
             * Sample Input:
             *   Enter a string: OpenAI
             * Sample Output:
             *   Output: IAnepO
             */

            Console.Write("Enter a string: ");
            string toReverseWithLoop = Console.ReadLine();

            // Initialize an empty string to store the reversed version
            string reversedString = "";

            // Loop through the original string backwards, starting from the last character
            for (int i = toReverseWithLoop.Length - 1; i >= 0; i--)
            {
                // Add each character to the reversed string
                reversedString += toReverseWithLoop[i];
            }

            // Display the reversed string
            Console.WriteLine($"Output (Loop): {reversedString}\n");

            // --- Task 6: Check if String is a Palindrome (Using LINQ) ---
            /*
             * Description:
             * Check if a string is a palindrome (same forwards and backwards).
             *
             * Explanation:
             * Convert the string to lowercase, reverse it using LINQ, and check if the reversed version matches the original.
             *
             * Sample Input:
             *   Enter a string: Racecar
             * Sample Output:
             *   The string is a palindrome.
             */

            Console.Write("Enter a string: ");
            string palindromeInput = Console.ReadLine();

            // Normalize the string by converting it to lowercase
            string normalized = palindromeInput.ToLower();

            // Reverse the string using LINQ and check if it matches the original
            string reversedWithLinq = new string(normalized.Reverse().ToArray());

            if (normalized == reversedWithLinq)
            {
                Console.WriteLine("The string is a palindrome (LINQ).\n");
            }
            else
            {
                Console.WriteLine("The string is not a palindrome (LINQ).\n");
            }

            // --- Task 6: Check if String is a Palindrome (Using Loop) ---
            /*
             * Description:
             * Check if a string is a palindrome (same forwards and backwards).
             *
             * Explanation:
             * Convert the string to lowercase, then use a loop to check if the string reads the same forwards and backwards.
             *
             * Sample Input:
             *   Enter a string: Racecar
             * Sample Output:
             *   The string is a palindrome.
             */

            Console.Write("Enter a string: ");
            string palindromeInputLoop = Console.ReadLine();

            // Normalize the string by converting it to lowercase
            string normalizedLoop = palindromeInputLoop.ToLower();

            bool isPalindrome = true;

            // Loop from start to middle of the string to check if it's a palindrome
            for (int i = 0; i < normalizedLoop.Length / 2; i++)
            {
                // Compare characters from the start and end
                if (normalizedLoop[i] != normalizedLoop[normalizedLoop.Length - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
            }

            // Display result based on whether the string is a palindrome
            if (isPalindrome)
            {
                Console.WriteLine("The string is a palindrome (Loop).\n");
            }
            else
            {
                Console.WriteLine("The string is not a palindrome (Loop).\n");
            }

            // --- Task 7: Count Words in a Sentence ---
            /*
             * Description:
             * Take a sentence as input and count the number of words in it.
             *
             * Explanation:
             * This version uses `Split` with spaces to separate words, then counts the resulting array elements.
             * An alternative version with a loop counts words by looking for spaces between words.
             *
             * Sample Input:
             *   Enter a sentence: This is a simple sentence.
             * Sample Output:
             *   The sentence has 5 words.
             */

            Console.Write("Enter a sentence: ");
            string sentence1 = Console.ReadLine();

            // Version 1: Using Split (Concise method)
            int wordCount = sentence1.Split(new char[]
            {
                ' '
            }, StringSplitOptions.RemoveEmptyEntries).Length;
            Console.WriteLine($"The sentence has {wordCount} words (using Split).\n");

            // --- Alternative Version: Using a Loop to Count Words ---
            /*
             * Explanation:
             * This version uses a loop to count words by detecting spaces between words.
             * It counts each word by checking for sequences of non-space characters separated by spaces.
             */

            Console.Write("Enter a sentence: ");
            string sentence2 = Console.ReadLine();
            int wordCountLoop = 0;
            bool inWord = false;

            for (int i = 0; i < sentence2.Length; i++)
            {
                // Check if current character is not a space (indicating we're in a word)
                if (!char.IsWhiteSpace(sentence2[i]))
                {
                    if (!inWord)
                    {
                        wordCountLoop++;// Start of a new word
                        inWord = true;// Mark that we're in a word
                    }
                }
                else
                {
                    inWord = false;// Outside a word when encountering a space
                }
            }

            Console.WriteLine($"The sentence has {wordCountLoop} words (using Loop).\n");

            // --- Task 8: Replace a Word in a String ---
            /*
             * Description:
             * Prompt the user for a sentence, a word to replace, and a replacement word. Display the new sentence.
             *
             * Explanation:
             * Use the `Replace` method to replace the specified word in the sentence with the new word.
             *
             * Sample Input:
             *   Enter a sentence: I love coding
             *   Enter the word to replace: coding
             *   Enter the replacement word: programming
             * Sample Output:
             *   New sentence: I love programming
             */

            Console.Write("Enter a sentence: ");
            string sentenceInput = Console.ReadLine();
            Console.Write("Enter the word to replace: ");
            string wordToReplace = Console.ReadLine();
            Console.Write("Enter the replacement word: ");
            string replacementWord = Console.ReadLine();
            Console.WriteLine($"New sentence: {sentenceInput.Replace(wordToReplace, replacementWord)}\n");

            // --- Task 9: Extract Initials from a Full Name ---
            /*
             * Description:
             * Take a full name as input and output the initials without a trailing dot.
             *
             * Explanation:
             * Split the full name into parts by spaces. For each part, take the first character
             * to form the initials. To avoid an extra dot at the end, add the dot only between initials.
             *
             * Sample Input:
             *   Enter your full name: John Michael Doe
             * Sample Output:
             *   Initials: J.M.D
             */

            Console.Write("Enter your full name: ");
            string fullName = Console.ReadLine();

            string[] fullNameParts = fullName.Split(' ');

            Console.Write("Initials: ");
            for (int i = 0; i < fullNameParts.Length; i++)
            {
                if (fullNameParts[i].Length > 0)// Ensure part is not empty
                {
                    char firstChar = fullNameParts[i][0];// Take the first character of each part
                    Console.Write(firstChar);

                    // Add a dot only if it’s not the last part
                    if (i < fullNameParts.Length - 1)
                    {
                        Console.Write(".");
                    }
                }
            }

            Console.WriteLine();

            // --- Task 10: Count Occurrences of a Character ---
            /*
             * Description:
             * Ask the user for a string and a character, then count how many times the character appears in the string.
             *
             * Explanation:
             * A `foreach` loop is used to go through each character in the string.
             * For each character that matches the target character, the count is incremented.
             *
             * Sample Input:
             *   Enter a string: Mississippi
             *   Enter a character to count: s
             * Sample Output:
             *   The character 's' appears 4 times.
             */

            Console.Write("Enter a string: ");
            string inputString1 = Console.ReadLine();

            Console.Write("Enter a character to count: ");
            char character = Console.ReadLine()[0];

            int charCount = 0;// Initialize a counter for occurrences

            // Iterate through each character in the input string
            foreach (char c in inputString1)
            {
                // Check if the current character matches the target character
                if (c == character)
                {
                    charCount++;// Increment the count if there's a match
                }
            }

            // Display the total occurrences of the target character
            Console.WriteLine($"The character '{character}' appears {charCount} times.\n");


            // --- Task 11: Remove Spaces from a String ---
            /*
             * Description:
             * Write a program that removes all spaces from a string entered by the user.
             *
             * Explanation:
             * This version uses the `Replace` method to replace all spaces with an empty string, effectively removing them.
             * An alternative version uses a loop to manually build a new string without spaces.
             *
             * Sample Input:
             *   Enter a string: Hello World
             * Sample Output:
             *   Output: HelloWorld
             */

            Console.Write("Enter a string: ");
            string inputString2 = Console.ReadLine();

            // Version 1: Using Replace (Concise method)
            string noSpaces = inputString2.Replace(" ", "");
            Console.WriteLine($"Output (using Replace): {noSpaces}\n");

            // --- Alternative Version: Using a Loop to Remove Spaces ---
            /*
             * Explanation:
             * This version uses a loop to create a new string by skipping spaces in the original string.
             * It appends only non-space characters to a new string variable.
             */

            Console.Write("Enter a string: ");
            string inputStringLoop = Console.ReadLine();
            string noSpacesLoop = "";

            foreach (char c in inputStringLoop)
            {
                // If character is not a space, add it to noSpacesLoop
                if (c != ' ')
                {
                    noSpacesLoop += c;
                }
            }

            Console.WriteLine($"Output (using Loop): {noSpacesLoop}\n");


            // --- Task 12: Find the Longest Word in a Sentence ---
            /*
             * Description:
             * Write a program that takes a sentence as input and finds the longest word in the sentence.
             *
             * Explanation:
             * Split the sentence by spaces and use a loop to check the length of each word.
             * Keep track of the longest word found.
             *
             * Sample Input:
             *   Enter a sentence: The quick brown fox jumps
             * Sample Output:
             *   The longest word is: jumps
             */
            Console.Write("Enter a sentence: ");
            string sentence3 = Console.ReadLine();
            string[] words = sentence3.Split(' ');
            string longestWord = "";

            foreach (string word in words)
            {
                if (word.Length > longestWord.Length)
                {
                    longestWord = word;
                }
            }

            Console.WriteLine($"The longest word is: {longestWord}\n");

            // --- Task 13: Capitalize Each Word ---
            /*
             * Description:
             * Write a program that takes a sentence as input and capitalizes the first letter of each word.
             *
             * Explanation:
             * Split the sentence into words, capitalize the first letter of each word, and join them back together.
             *
             * Sample Input:
             *   Enter a sentence: welcome to the world of c#
             * Sample Output:
             *   Output: Welcome To The World Of C#
             */
            Console.Write("Enter a sentence: ");
            string sentenceToCapitalize = Console.ReadLine();
            string[] sentenceWords = sentenceToCapitalize.Split(' ');
            string capitalizedSentence = "";

            foreach (string word in sentenceWords)
            {
                if (word.Length > 0)
                {
                    // Capitalize the first letter and add to result
                    capitalizedSentence += char.ToUpper(word[0]) + word.Substring(1).ToLower() + " ";
                }
            }

            Console.WriteLine($"Output: {capitalizedSentence.Trim()}\n");

            // --- Task 14: Check if String Starts or Ends with a Specific Word ---
            /*
             * Description:
             * Write a program that asks the user for a sentence and a word.
             * Check if the sentence starts or ends with the given word.
             *
             * Explanation:
             * Use `StartsWith` and `EndsWith` methods to check the sentence's beginning and end.
             *
             * Sample Input:
             *   Enter a sentence: Hello, welcome to C# programming.
             *   Enter the word to check: Hello
             * Sample Output:
             *   The sentence starts with 'Hello'.
             *
             *   Enter a sentence: Welcome to C# programming.
             *   Enter the word to check: programming
             * Sample Output:
             *   The sentence ends with 'programming'.
             */
            Console.Write("Enter a sentence: ");
            string checkSentence = Console.ReadLine();
            Console.Write("Enter the word to check: ");
            string wordToCheck = Console.ReadLine();

            if (checkSentence.StartsWith(wordToCheck))
            {
                Console.WriteLine($"The sentence starts with '{wordToCheck}'.\n");
            }
            else if (checkSentence.EndsWith(wordToCheck))
            {
                Console.WriteLine($"The sentence ends with '{wordToCheck}'.\n");
            }
            else
            {
                Console.WriteLine($"The sentence does not start or end with '{wordToCheck}'.\n");
            }

            // --- Task 15: Convert String to Title Case ---
            /*
             * Description:
             * Write a program that converts a string to title case (first letter of each word capitalized, rest lowercase).
             *
             * Explanation:
             * Split the string into words, capitalize the first letter of each word, and make the rest lowercase.
             * Then, join the words back together to form the title case string.
             *
             * Sample Input:
             *   Enter a string: c# programming IS fun
             * Sample Output:
             *   Output: C# Programming Is Fun
             */
            Console.Write("Enter a string: ");
            string titleInput = Console.ReadLine();
            string[] titleWords = titleInput.Split(' ');
            string titleCaseString = "";

            foreach (string word in titleWords)
            {
                if (word.Length > 0)
                {
                    // Capitalize the first letter and make the rest lowercase
                    titleCaseString += char.ToUpper(word[0]) + word.Substring(1).ToLower() + " ";
                }
            }

            Console.WriteLine($"Output: {titleCaseString.Trim()}\n");

        }
    }
}
