using System;
using System.Linq;

namespace Practice
{
    class StringTasks
    {
        public static void Run()
        {
            // --- Task 1: Count Characters in a String ---
            /* Description:
             * Write a program that asks the user for a string and outputs
             * the number of characters in it.
             * Example Input: Hello, World!
             * Example Output: The string has 13 characters.
             */
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            int characterCount = input.Length;
            Console.WriteLine($"The string has {characterCount} characters.\n");

            // --- Task 2: Check if String Contains a Substring ---
            /* Description:
             * Write a program that prompts the user for two strings and checks
             * if the second string is a substring of the first. Display an appropriate message.
             * Example Input:
             *   Main string: Programming is fun
             *   Substring: fun
             * Example Output: The substring 'fun' is found in the main string.
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
            /* Description:
             * Write a program that takes a string as input and converts it to uppercase.
             * Example Input: hello world
             * Example Output: HELLO WORLD
             */
            Console.Write("Enter a string: ");
            string toConvert = Console.ReadLine();
            Console.WriteLine($"Output: {toConvert.ToUpper()}\n");

            // --- Task 4: Count Vowels and Consonants ---
            /* Description:
             * Write a program that asks the user for a string and counts
             * the number of vowels and consonants in it.
             * Example Input: Hello
             * Example Output: Vowels: 2, Consonants: 3
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

            // Using a for loop to go through each character in the string
            for (int i = 0; i < vowelString.Length; i++)
            {
                char c = vowelString[i]; // Get the current character

                // Check if the character is a letter
                if (char.IsLetter(c))
                {
                    // Check if it is a vowel
                    if (vowelChars.Contains(c))
                    {
                        vowels++;
                    }
                    else
                    {
                        consonants++;
                    }
                }
            }

            Console.WriteLine($"Vowels: {vowels}, Consonants: {consonants}\n");

            // --- Task 5: Reverse a String ---
            /* Description:
             * Write a program that takes a string as input and outputs it in reverse.
             * Example Input: OpenAI
             * Example Output: IAnepO
             */
            Console.Write("Enter a string: ");
            string toReverse = Console.ReadLine();
            Console.WriteLine($"Output: {new string(toReverse.Reverse().ToArray())}\n");

            // --- Task 6: Check if String is a Palindrome ---
            /* Description:
             * Write a program that checks if a string is a palindrome.
             * Example Input: Racecar
             * Example Output: The string is a palindrome.
             */
            Console.Write("Enter a string: ");
            string palindromeInput = Console.ReadLine();
            string normalized = palindromeInput.ToLower();
            string reversedPalindrome = new string(normalized.Reverse().ToArray());
            if (normalized == reversedPalindrome)
                Console.WriteLine("The string is a palindrome.\n");
            else
                Console.WriteLine("The string is not a palindrome.\n");

            // --- Task 7: Count Words in a Sentence ---
            /* Description:
             * Write a program that takes a sentence as input and counts the number of words in it.
             * Example Input: This is a simple sentence.
             * Example Output: The sentence has 5 words.
             */
            Console.Write("Enter a sentence: ");
            string sentence = Console.ReadLine();
            int wordCount = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
            Console.WriteLine($"The sentence has {wordCount} words.\n");

            // --- Task 8: Replace a Word in a String ---
            /* Description:
             * Write a program that prompts the user for a sentence and a word to replace.
             * Then ask for the replacement word and display the new sentence.
             * Example Input:
             *   Sentence: I love coding
             *   Word to replace: coding
             *   Replacement word: programming
             * Example Output: New sentence: I love programming
             */
            Console.Write("Enter a sentence: ");
            string sentenceInput = Console.ReadLine();
            Console.Write("Enter the word to replace: ");
            string wordToReplace = Console.ReadLine();
            Console.Write("Enter the replacement word: ");
            string replacementWord = Console.ReadLine();
            Console.WriteLine($"New sentence: {sentenceInput.Replace(wordToReplace, replacementWord)}\n");

            // --- Task 9: Extract Initials from a Full Name ---
            /* Description:
             * Write a program that takes a full name as input and outputs the initials.
             * Example Input: John Michael Doe
             * Example Output: Initials: J.M.D
             */
            Console.Write("Enter your full name: ");
            string fullName = Console.ReadLine();
            string initials = string.Join(".", fullName.Split(' ').Select(part => part[0])) + ".";
            Console.WriteLine($"Initials: {initials}\n");

            // --- Task 10: Count Occurrences of a Character ---
            /* Description:
             * Write a program that asks the user for a string and a character.
             * The program should count how many times the character appears in the string.
             * Example Input:
             *   String: Mississippi
             *   Character: s
             * Example Output: The character 's' appears 4 times.
             */
            Console.Write("Enter a string: ");
            string inputString = Console.ReadLine();
            Console.Write("Enter a character to count: ");
            char character = Console.ReadLine()[0];
            int charCount = inputString.Count(c => c == character);
            Console.WriteLine($"The character '{character}' appears {charCount} times.\n");

            // --- Task 11: Remove Spaces from a String ---
            /* Description:
             * Write a program that removes all spaces from a string entered by the user.
             * Example Input: Hello World
             * Example Output: HelloWorld
             */
            Console.Write("Enter a string: ");
            string stringWithSpaces = Console.ReadLine();
            Console.WriteLine($"Output: {stringWithSpaces.Replace(" ", "")}\n");

            // --- Task 12: Find the Longest Word in a Sentence ---
            /* Description:
             * Write a program that takes a sentence as input and finds the longest word in the sentence.
             * Example Input: The quick brown fox jumps
             * Example Output: The longest word is: jumps
             */
            Console.Write("Enter a sentence: ");
            string longSentence = Console.ReadLine();
            string longestWord = longSentence.Split(' ').OrderByDescending(word => word.Length).First();
            Console.WriteLine($"The longest word is: {longestWord}\n");

            // --- Task 13: Capitalize Each Word ---
            /* Description:
             * Write a program that takes a sentence as input and capitalizes the first letter of each word.
             * Example Input: welcome to the world of c#
             * Example Output: Welcome To The World Of C#
             */
            Console.Write("Enter a sentence: ");
            string sentenceToCapitalize = Console.ReadLine();
            string capitalizedSentence = string.Join(" ", sentenceToCapitalize.Split(' ').Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
            Console.WriteLine($"Output: {capitalizedSentence}\n");

            // --- Task 14: Check if String Starts or Ends with a Specific Word ---
            /* Description:
             * Write a program that asks the user for a sentence and a word.
             * Check if the sentence starts or ends with the given word.
             * Example Input:
             *   Sentence: Hello, welcome to C# programming.
             *   Word: Hello
             * Example Output: The sentence starts with 'Hello'.
             */
            Console.Write("Enter a sentence: ");
            string checkSentence = Console.ReadLine();
            Console.Write("Enter the word to check: ");
            string wordToCheck = Console.ReadLine();
            if (checkSentence.StartsWith(wordToCheck))
                Console.WriteLine($"The sentence starts with '{wordToCheck}'.\n");
            else if (checkSentence.EndsWith(wordToCheck))
                Console.WriteLine($"The sentence ends with '{wordToCheck}'.\n");
            else
                Console.WriteLine($"The sentence does not start or end with '{wordToCheck}'.\n");

            // --- Task 15: Convert String to Title Case ---
            /* Description:
             * Write a program that converts a string to title case.
             * Example Input: c# programming IS fun
             * Example Output: C# Programming Is Fun
             */
            Console.Write("Enter a string: ");
            string titleInput = Console.ReadLine();
            string titleCaseString = string.Join(" ", titleInput.Split(' ').Select(word => char.ToUpper(word[0]) + word.Substring(1).

ToLower()));
            Console.WriteLine($"Output: {titleCaseString}");
        }
    }
}