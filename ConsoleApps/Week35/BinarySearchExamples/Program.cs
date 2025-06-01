using System;

namespace BinarySearchExamples
{
    /// <summary>
    /// Demonstrates various implementations of binary search algorithms in C#.
    /// Includes iterative, recursive, and specialized search variations.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Binary Search Examples\n");

            // Test arrays
            int[] numbers = { 1, 3, 5, 7, 9, 11, 13, 15 };
            string[] names = { "Alice", "Bob", "Charlie", "David", "Eve" };
            int[] duplicates = { 1, 2, 2, 2, 3, 4, 5, 5, 5, 6 };

            // Test iterative binary search
            Console.WriteLine("1. Iterative Binary Search Examples:");
            TestBinarySearchIterative(array: numbers, target: 7);  // Should find
            TestBinarySearchIterative(array: numbers, target: 6);  // Should not find
            Console.WriteLine();

            // Test recursive binary search
            Console.WriteLine("2. Recursive Binary Search Examples:");
            TestBinarySearchRecursive(array: numbers, target: 9);  // Should find
            TestBinarySearchRecursive(array: numbers, target: 8);  // Should not find
            Console.WriteLine();

            // Test generic binary search
            Console.WriteLine("3. Generic Binary Search Examples:");
            TestBinarySearchGeneric(array: names, target: "Charlie");  // Should find
            TestBinarySearchGeneric(array: names, target: "Frank");    // Should not find
            Console.WriteLine();

            // Test finding first occurrence
            Console.WriteLine("4. Finding First Occurrence:");
            TestFindFirstOccurrence(array: duplicates, target: 2);  // Should find first 2
            Console.WriteLine();

            // Test finding last occurrence
            Console.WriteLine("5. Finding Last Occurrence:");
            TestFindLastOccurrence(array: duplicates, target: 5);  // Should find last 5
            Console.WriteLine();

            // Test finding closest element
            Console.WriteLine("6. Finding Closest Element:");
            TestFindClosestElement(array: numbers, target: 6);  // Should find 5 or 7
            Console.WriteLine();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        #region Binary Search Implementations

        /// <summary>
        /// Performs binary search using an iterative approach.
        /// Time Complexity: O(log n)
        /// Space Complexity: O(1)
        /// </summary>
        /// <param name="array">The sorted array to search in</param>
        /// <param name="target">The value to search for</param>
        /// <returns>The index of the target value if found, -1 otherwise</returns>
        public static int BinarySearchIterative(int[] array, int target)
        {
            /*
             * Implementation Details:
             * 1. Check for null or empty array
             * 2. Initialize left and right pointers
             * 3. While left <= right:
             *    a. Calculate middle index (avoiding overflow)
             *    b. If target found at middle, return index
             *    c. If target > middle value, search right half
             *    d. If target < middle value, search left half
             * 4. Return -1 if not found
             */

            if (array == null || array.Length == 0)
                return -1;

            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                // Calculate middle index avoiding integer overflow
                int mid = left + (right - left) / 2;

                if (array[mid] == target)
                    return mid;

                if (array[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }

        /// <summary>
        /// Performs binary search using a recursive approach.
        /// Time Complexity: O(log n)
        /// Space Complexity: O(log n) due to recursion stack
        /// </summary>
        /// <param name="array">The sorted array to search in</param>
        /// <param name="target">The value to search for</param>
        /// <returns>The index of the target value if found, -1 otherwise</returns>
        public static int BinarySearchRecursive(int[] array, int target)
        {
            /*
             * Implementation Details:
             * 1. Check for null or empty array
             * 2. Call internal recursive method with full array range
             * 3. Internal method:
             *    a. Base case: left > right (not found)
             *    b. Calculate middle index
             *    c. If target found at middle, return index
             *    d. Recursively search appropriate half
             */

            if (array == null || array.Length == 0)
                return -1;

            return BinarySearchRecursive(
                array: array,
                target: target,
                left: 0,
                right: array.Length - 1
            );
        }

        /// <summary>
        /// Internal recursive implementation of binary search.
        /// </summary>
        private static int BinarySearchRecursive(int[] array, int target, int left, int right)
        {
            if (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (array[mid] == target)
                    return mid;

                if (array[mid] > target)
                    return BinarySearchRecursive(
                        array: array,
                        target: target,
                        left: left,
                        right: mid - 1
                    );

                return BinarySearchRecursive(
                    array: array,
                    target: target,
                    left: mid + 1,
                    right: right
                );
            }

            return -1;
        }

        /// <summary>
        /// Performs binary search on any comparable type.
        /// Time Complexity: O(log n)
        /// Space Complexity: O(1)
        /// </summary>
        /// <typeparam name="T">Type that implements IComparable</typeparam>
        /// <param name="array">The sorted array to search in</param>
        /// <param name="target">The value to search for</param>
        /// <returns>The index of the target value if found, -1 otherwise</returns>
        public static int BinarySearchGeneric<T>(T[] array, T target) where T : IComparable<T>
        {
            /*
             * Implementation Details:
             * 1. Check for null or empty array
             * 2. Initialize left and right pointers
             * 3. While left <= right:
             *    a. Calculate middle index
             *    b. Compare target with middle element using IComparable
             *    c. If equal, return index
             *    d. If target > middle, search right half
             *    e. If target < middle, search left half
             * 4. Return -1 if not found
             */

            if (array == null || array.Length == 0)
                return -1;

            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = target.CompareTo(array[mid]);

                if (comparison == 0)
                    return mid;

                if (comparison > 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }

        /// <summary>
        /// Finds the first occurrence of a target value in a sorted array.
        /// Time Complexity: O(log n)
        /// Space Complexity: O(1)
        /// </summary>
        /// <param name="array">The sorted array to search in</param>
        /// <param name="target">The value to search for</param>
        /// <returns>The index of the first occurrence if found, -1 otherwise</returns>
        public static int FindFirstOccurrence(int[] array, int target)
        {
            /*
             * Implementation Details:
             * 1. Check for null or empty array
             * 2. Initialize left, right pointers and result
             * 3. While left <= right:
             *    a. Calculate middle index
             *    b. If target found at middle:
             *       - Store index as result
             *       - Continue searching left half
             *    c. If target > middle, search right half
             *    d. If target < middle, search left half
             * 4. Return first occurrence index or -1
             */

            if (array == null || array.Length == 0)
                return -1;

            int left = 0;
            int right = array.Length - 1;
            int result = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (array[mid] == target)
                {
                    result = mid;
                    right = mid - 1; // Continue searching left
                }
                else if (array[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return result;
        }

        /// <summary>
        /// Finds the last occurrence of a target value in a sorted array.
        /// Time Complexity: O(log n)
        /// Space Complexity: O(1)
        /// </summary>
        /// <param name="array">The sorted array to search in</param>
        /// <param name="target">The value to search for</param>
        /// <returns>The index of the last occurrence if found, -1 otherwise</returns>
        public static int FindLastOccurrence(int[] array, int target)
        {
            /*
             * Implementation Details:
             * 1. Check for null or empty array
             * 2. Initialize left, right pointers and result
             * 3. While left <= right:
             *    a. Calculate middle index
             *    b. If target found at middle:
             *       - Store index as result
             *       - Continue searching right half
             *    c. If target > middle, search right half
             *    d. If target < middle, search left half
             * 4. Return last occurrence index or -1
             */

            if (array == null || array.Length == 0)
                return -1;

            int left = 0;
            int right = array.Length - 1;
            int result = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (array[mid] == target)
                {
                    result = mid;
                    left = mid + 1; // Continue searching right
                }
                else if (array[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return result;
        }

        /// <summary>
        /// Finds the closest element to the target value in a sorted array.
        /// Time Complexity: O(log n)
        /// Space Complexity: O(1)
        /// </summary>
        /// <param name="array">The sorted array to search in</param>
        /// <param name="target">The value to find closest to</param>
        /// <returns>The index of the closest element</returns>
        public static int FindClosestElement(int[] array, int target)
        {
            /*
             * Implementation Details:
             * 1. Check for null or empty array
             * 2. Initialize left and right pointers
             * 3. While left <= right:
             *    a. Calculate middle index
             *    b. If target found at middle, return index
             *    c. If target > middle, search right half
             *    d. If target < middle, search left half
             * 4. When loop ends, left and right point to elements
             *    closest to target on either side
             * 5. Compare distances and return closest element
             */

            if (array == null || array.Length == 0)
                return -1;

            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (array[mid] == target)
                    return mid;

                if (array[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            // Handle edge cases
            if (right < 0) return 0;
            if (left >= array.Length) return array.Length - 1;

            // Return index of closest element
            return Math.Abs(array[left] - target) < Math.Abs(array[right] - target)
                ? left : right;
        }

        #endregion

        #region Test Methods

        /// <summary>
        /// Tests the iterative binary search implementation.
        /// </summary>
        private static void TestBinarySearchIterative(int[] array, int target)
        {
            int index = BinarySearchIterative(array: array, target: target);
            Console.WriteLine($"Searching for {target}: {(index != -1 ? $"Found at index {index}" : "Not found")}");
        }

        /// <summary>
        /// Tests the recursive binary search implementation.
        /// </summary>
        private static void TestBinarySearchRecursive(int[] array, int target)
        {
            int index = BinarySearchRecursive(array: array, target: target);
            Console.WriteLine($"Searching for {target}: {(index != -1 ? $"Found at index {index}" : "Not found")}");
        }

        /// <summary>
        /// Tests the generic binary search implementation.
        /// </summary>
        private static void TestBinarySearchGeneric<T>(T[] array, T target) where T : IComparable<T>
        {
            int index = BinarySearchGeneric(array: array, target: target);
            Console.WriteLine($"Searching for {target}: {(index != -1 ? $"Found at index {index}" : "Not found")}");
        }

        /// <summary>
        /// Tests finding the first occurrence of a value.
        /// </summary>
        private static void TestFindFirstOccurrence(int[] array, int target)
        {
            int index = FindFirstOccurrence(array: array, target: target);
            Console.WriteLine($"First occurrence of {target}: {(index != -1 ? $"Found at index {index}" : "Not found")}");
        }

        /// <summary>
        /// Tests finding the last occurrence of a value.
        /// </summary>
        private static void TestFindLastOccurrence(int[] array, int target)
        {
            int index = FindLastOccurrence(array: array, target: target);
            Console.WriteLine($"Last occurrence of {target}: {(index != -1 ? $"Found at index {index}" : "Not found")}");
        }

        /// <summary>
        /// Tests finding the closest element to a target value.
        /// </summary>
        private static void TestFindClosestElement(int[] array, int target)
        {
            int index = FindClosestElement(array: array, target: target);
            Console.WriteLine($"Closest element to {target}: {array[index]} at index {index}");
        }

        #endregion
    }
}
