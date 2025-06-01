using System.Collections;

namespace Collections.NoneGenericSortedListClass
{
    /// <summary>
    /// Demonstrates the usage of non-generic SortedList collection and binary search implementation.
    /// </summary>
    internal class Program
    {
        #region Constants
        private const string SEPARATOR = "----------------------------------------";
        private const string PRESS_KEY_MESSAGE = "\nPress any key to continue...";
        #endregion

        static void Main(string[] args)
        {
            try
            {
                RunDemonstrations();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn error occurred: {ex.Message}");
                Console.WriteLine(PRESS_KEY_MESSAGE);
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Runs all demonstrations in sequence.
        /// </summary>
        private static void RunDemonstrations()
        {
            DemonstrateSortedList();
            DemonstrateBinarySearch();
        }

        /// <summary>
        /// Demonstrates various operations with SortedList collection.
        /// </summary>
        private static void DemonstrateSortedList()
        {
            Console.WriteLine("SortedList Demonstration\n");

            try
            {
                var sortedList = CreateAndPopulateSortedList();
                DisplaySortedListInfo(sortedList);
                DemonstrateSortedListOperations(sortedList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError in SortedList demonstration: {ex.Message}");
            }

            Console.WriteLine(PRESS_KEY_MESSAGE);
            Console.ReadKey();
        }

        /// <summary>
        /// Creates and populates a new SortedList with sample data.
        /// </summary>
        /// <returns>A populated SortedList</returns>
        private static SortedList CreateAndPopulateSortedList()
        {
            var sortedList = new SortedList();

            // Adding elements to SortedList
            sortedList.Add(key: 1, value: "One");
            sortedList.Add(key: 5, value: "Five");
            sortedList.Add(key: 4, value: "Four");
            sortedList.Add(key: 2, value: "Two");
            sortedList.Add(key: 3, value: "Three");

            /*
             * Behind the scenes, SortedList uses binary search for efficient operations:
             * 
             * 1. When adding elements:
             *    - Binary search is used to find the correct insertion point
             *    - Time Complexity: O(log n) for finding position
             *    - Elements are shifted to maintain sorted order
             * 
             * 2. When searching for elements:
             *    - Binary search is used to find elements by key
             *    - Time Complexity: O(log n) for lookups
             *    - Much faster than linear search O(n)
             * 
             * 3. Internal implementation:
             *    - Uses two arrays: one for keys, one for values
             *    - Keys array is always kept sorted
             *    - Binary search is used to maintain this sorted order
             *    - Array.BinarySearch is used internally
             * 
             * 4. Performance characteristics:
             *    - Fast lookups: O(log n)
             *    - Slow insertions: O(n) due to shifting
             *    - Memory efficient: uses arrays
             *    - Good for read-heavy operations
             */

            return sortedList;
        }

        /// <summary>
        /// Displays basic information about the SortedList.
        /// </summary>
        /// <param name="sortedList">The SortedList to display information about</param>
        private static void DisplaySortedListInfo(SortedList sortedList)
        {
            Console.WriteLine("SortedList automatically sorts by key:");
            PrintSortedList(sortedList);

            Console.WriteLine("\nSortedList Constraints:");
            Console.WriteLine("1. Keys must be of the same type");
            Console.WriteLine("2. Keys must be comparable");
            Console.WriteLine("3. Duplicate keys are not allowed");
            Console.WriteLine("4. Null values are allowed");
            Console.WriteLine("5. Duplicate values are allowed");
        }



        /// <summary>
        /// Demonstrates additional operations that can be performed on a SortedList.
        /// </summary>
        /// <param name="sortedList">The SortedList to demonstrate operations on</param>
        private static void DemonstrateSortedListOperations(SortedList sortedList)
        {
            Console.WriteLine("\nAdditional SortedList Operations:");

            DemonstrateKeyValueExistence(sortedList);
            DemonstrateIndexAccess(sortedList);
            DemonstrateKeyValueLists(sortedList);
            DemonstrateIndexFinding(sortedList);
            DemonstrateElementRemoval(sortedList);
            DemonstrateValueSetting(sortedList);
            DemonstrateCapacityManagement(sortedList);
            DemonstrateListClearing(sortedList);
        }

        /// <summary>
        /// Demonstrates checking for key and value existence.
        /// </summary>
        private static void DemonstrateKeyValueExistence(SortedList sortedList)
        {
            Console.WriteLine("\n1. Checking for Key/Value Existence:");
            Console.WriteLine($"Contains key 3: {sortedList.ContainsKey(key: 3)}");
            Console.WriteLine($"Contains key 10: {sortedList.ContainsKey(key: 10)}");
            Console.WriteLine($"Contains value 'Two': {sortedList.ContainsValue(value: "Two")}");
            Console.WriteLine($"Contains value 'Ten': {sortedList.ContainsValue(value: "Ten")}");
        }

        /// <summary>
        /// Demonstrates index access and modification.
        /// </summary>
        private static void DemonstrateIndexAccess(SortedList sortedList)
        {
            Console.WriteLine("\n2. Index Access and Modification:");
            Console.WriteLine($"Value at key 2: {sortedList[2]}");
            sortedList[2] = "Two Modified";
            Console.WriteLine($"Modified value at key 2: {sortedList[2]}");
        }

        /// <summary>
        /// Demonstrates getting key and value lists.
        /// </summary>
        private static void DemonstrateKeyValueLists(SortedList sortedList)
        {
            Console.WriteLine("\n3. Getting Keys and Values Lists:");
            IList keys = sortedList.GetKeyList();
            IList values = sortedList.GetValueList();
            Console.WriteLine("Keys: " + string.Join(", ", keys.Cast<int>()));
            Console.WriteLine("Values: " + string.Join(", ", values.Cast<string>()));
        }

        /// <summary>
        /// Demonstrates finding indices of keys and values.
        /// </summary>
        private static void DemonstrateIndexFinding(SortedList sortedList)
        {
            Console.WriteLine("\n4. Finding Indices:");
            Console.WriteLine($"Index of key 4: {sortedList.IndexOfKey(key: 4)}");
            Console.WriteLine($"Index of value 'Five': {sortedList.IndexOfValue(value: "Five")}");
        }

        /// <summary>
        /// Demonstrates removing elements from the list.
        /// </summary>
        private static void DemonstrateElementRemoval(SortedList sortedList)
        {
            Console.WriteLine("\n5. Removing Elements:");
            Console.WriteLine("Before removal:");
            PrintSortedList(sortedList);

            sortedList.Remove(key: 3);
            Console.WriteLine("\nAfter removing key 3:");
            PrintSortedList(sortedList);

            sortedList.RemoveAt(index: 0);
            Console.WriteLine("\nAfter removing element at index 0:");
            PrintSortedList(sortedList);
        }

        /// <summary>
        /// Demonstrates setting values by index.
        /// </summary>
        private static void DemonstrateValueSetting(SortedList sortedList)
        {
            Console.WriteLine("\n6. Setting Value by Index:");
            sortedList.SetByIndex(index: 0, value: "New Value");
            Console.WriteLine("After setting new value at index 0:");
            PrintSortedList(sortedList);
        }

        /// <summary>
        /// Demonstrates capacity management operations.
        /// </summary>
        private static void DemonstrateCapacityManagement(SortedList sortedList)
        {
            Console.WriteLine("\n7. Trimming Capacity:");
            Console.WriteLine($"Capacity before trim: {sortedList.Capacity}");
            sortedList.TrimToSize();
            Console.WriteLine($"Capacity after trim: {sortedList.Capacity}");
        }

        /// <summary>
        /// Demonstrates clearing the list.
        /// </summary>
        private static void DemonstrateListClearing(SortedList sortedList)
        {
            Console.WriteLine("\n8. Clearing the List:");
            sortedList.Clear();
            Console.WriteLine($"Count after clear: {sortedList.Count}");
            Console.WriteLine($"Capacity after clear: {sortedList.Capacity}");
        }

        /// <summary>
        /// Prints the contents of a SortedList in a formatted way.
        /// </summary>
        /// <param name="sortedList">The SortedList to print</param>
        private static void PrintSortedList(SortedList sortedList)
        {
            Console.WriteLine("Current SortedList contents:");
            foreach (DictionaryEntry entry in sortedList)
            {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }
        }

        /// <summary>
        /// Demonstrates binary search implementation with iteration tracking.
        /// </summary>
        private static void DemonstrateBinarySearch()
        {
            Console.WriteLine("\nBinary Search Demonstration\n");

            try
            {
                var (sortedArray, targetValue) = PrepareBinarySearchData();
                PerformBinarySearch(sortedArray, targetValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError in Binary Search demonstration: {ex.Message}");
            }

            Console.WriteLine(PRESS_KEY_MESSAGE);
            Console.ReadKey();
        }

        /// <summary>
        /// Prepares test data for binary search demonstration.
        /// </summary>
        /// <returns>A tuple containing the sorted array and target value</returns>
        private static (int[] array, int target) PrepareBinarySearchData()
        {
            int[] sortedArray = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };
            int targetValue = 23;

            Console.WriteLine($"Searching for value {targetValue} in sorted array:");
            Console.WriteLine($"Array: [{string.Join(", ", sortedArray)}]");

            return (sortedArray, targetValue);
        }

        /// <summary>
        /// Performs binary search and displays the results.
        /// </summary>
        private static void PerformBinarySearch(int[] sortedArray, int targetValue)
        {
            int resultIndex = BinarySearch(
                arr: sortedArray,
                target: targetValue
            );

            if (resultIndex == -1)
            {
                Console.WriteLine("Element is not present in array");
            }
            else
            {
                Console.WriteLine($"Element is present at index {resultIndex}");
            }
        }

        /// <summary>
        /// Performs binary search on a sorted array and tracks iterations.
        /// Time Complexity: O(log n)
        /// Space Complexity: O(1)
        /// </summary>
        /// <param name="arr">The sorted array to search in</param>
        /// <param name="target">The value to search for</param>
        /// <returns>The index of the target value if found, -1 otherwise</returns>
        private static int BinarySearch(int[] arr, int target)
        {
            if (arr == null || arr.Length == 0)
            {
                throw new ArgumentException("Array cannot be null or empty", nameof(arr));
            }

            int low = 0;
            int high = arr.Length - 1;
            int iterationCount = 1;

            while (low <= high)
            {
                int mid = CalculateMiddleIndex(low, high);
                int comparison = CompareWithTarget(arr[mid], target);

                if (comparison == 0)
                {
                    LogSearchResult(iterationCount, true);
                    return mid;
                }

                UpdateSearchRange(ref low, ref high, mid, comparison);
                LogIterationProgress(iterationCount, low, high);
                iterationCount++;
            }

            LogSearchResult(iterationCount - 1, false);
            return -1;
        }

        /// <summary>
        /// Calculates the middle index avoiding integer overflow.
        /// </summary>
        private static int CalculateMiddleIndex(int low, int high)
        {
            return low + (high - low) / 2;
        }

        /// <summary>
        /// Compares a value with the target.
        /// </summary>
        private static int CompareWithTarget(int value, int target)
        {
            return value.CompareTo(target);
        }

        /// <summary>
        /// Updates the search range based on the comparison result.
        /// </summary>
        private static void UpdateSearchRange(ref int low, ref int high, int mid, int comparison)
        {
            if (comparison < 0)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        /// <summary>
        /// Logs the progress of the search iteration.
        /// </summary>
        private static void LogIterationProgress(int iteration, int low, int high)
        {
            Console.WriteLine($"Iteration {iteration}: Searching in range [{low}, {high}]");
        }

        /// <summary>
        /// Logs the final search result.
        /// </summary>
        private static void LogSearchResult(int iterations, bool found)
        {
            if (found)
            {
                Console.WriteLine($"Found target in {iterations} iterations");
            }
            else
            {
                Console.WriteLine($"Target not found after {iterations} iterations");
            }
        }
    }
}
