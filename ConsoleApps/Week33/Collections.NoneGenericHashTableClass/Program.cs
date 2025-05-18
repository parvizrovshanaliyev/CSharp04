using System;
using System.Collections;

namespace Collections.NoneGenericHashTableClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * -------------------------------------------
             * 🔸 Why Hashtable over ArrayList?
             * -------------------------------------------
             * ArrayList stores elements by index, which means:
             * - You need to remember the index to retrieve a value
             * - There is no semantic meaning in the index
             * 
             * Hashtable allows key-based access, which is:
             * - More readable
             * - More maintainable
             * - More intuitive when working with named data
             */

            Console.WriteLine("=== Using ArrayList (Index-based access) ===");

            ArrayList al = new ArrayList();
            al.Add(1001);           // EId
            al.Add("James");        // Name
            al.Add("Manager");      // Job
            al.Add(3500);           // Salary
            al.Add("Mumbai");       // Location
            al.Add("IT");           // Department
            al.Add("a@a.com");      // Email ID

            // Accessing data by index (not ideal for readability)
            Console.WriteLine("Location  : " + al[4]);   // Index 4
            Console.WriteLine("Email ID  : " + al[6]);   // Index 6
            Console.ReadKey();
            Console.Clear();

            /*
             * -------------------------------------------
             * 🔸 Creating and Using Hashtable
             * -------------------------------------------
             * Hashtable stores key-value pairs, where keys are unique.
             * It allows fast lookup based on keys.
             */

            Console.WriteLine("=== Creating Hashtable with Add() ===");

            Hashtable employeeHashTable = new Hashtable();

            // Adding key-value pairs
            employeeHashTable.Add("EId", 1001);
            employeeHashTable.Add("Name", "James");
            employeeHashTable.Add("Salary", 3500);
            employeeHashTable.Add("Location", "Mumbai");
            employeeHashTable.Add("EmailID", "a@a.com");

            // Iterating using Keys
            Console.WriteLine("🔁 Iterating using Keys:");
            foreach (object key in employeeHashTable.Keys)
            {
                Console.WriteLine($"{key} : {employeeHashTable[key]}");
            }

            // Iterating using DictionaryEntry
            Console.WriteLine("\n🔁 Iterating using DictionaryEntry:");
            foreach (DictionaryEntry entry in employeeHashTable)
            {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }

            // Accessing values by key
            Console.WriteLine("\n🔍 Accessing individual entries:");
            Console.WriteLine("Location : " + employeeHashTable["Location"]);
            Console.WriteLine("Email ID : " + employeeHashTable["EmailID"]);

            Console.ReadKey();
            Console.Clear();

            /*
             * -------------------------------------------
             * 🔸 Hashtable with Collection Initializer
             * -------------------------------------------
             * You can also initialize a Hashtable inline.
             */

            Console.WriteLine("=== Hashtable with Collection Initializer ===");

            Hashtable citiesHashtable = new Hashtable()
            {
                { "UK", "London, Manchester, Birmingham" },
                { "USA", "Chicago, New York, Washington" },
                { "India", "Mumbai, New Delhi, Pune" }
            };

            foreach (DictionaryEntry city in citiesHashtable)
            {
                Console.WriteLine($"Key: {city.Key}, Value: {city.Value}");
            }

            Console.ReadKey();
            Console.Clear();

            /*
             * -------------------------------------------
             * 🔸 Assigning values using indexer
             * -------------------------------------------
             * Similar to using Add(), but overwrites if key exists
             */

            Console.WriteLine("=== Hashtable using Indexer Assignment ===");

            Hashtable indexedTable = new Hashtable();
            indexedTable[1] = "One";
            indexedTable[5] = "Five";
            indexedTable[30] = "Thirty";

            foreach (DictionaryEntry de in indexedTable)
            {
                Console.WriteLine($"Key: {de.Key}, Value: {de.Value}");
            }

            Console.ReadKey();
            Console.Clear();

            /*
             * -------------------------------------------
             * 🔸 Checking for Existence of Keys/Values
             * -------------------------------------------
             * Always check before accessing to avoid exceptions.
             */

            Console.WriteLine("=== Checking Key/Value Existence ===");

            try
            {
                // Retrieving value directly
                object value = indexedTable[1];

                // Check if key exists
                if (indexedTable.Contains(1))
                {
                    Console.WriteLine("Key 1 exists: " + value);
                }

                // ContainsKey & ContainsValue (more semantic)
                if (indexedTable.ContainsKey(2))
                {
                    Console.WriteLine("Key 2 exists.");
                }
                else
                {
                    Console.WriteLine("Key 2 does not exist.");
                }

                if (indexedTable.ContainsValue("One"))
                {
                    Console.WriteLine("Value 'One' exists in the hashtable.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❗ Exception: " + ex.Message);
            }

            Console.ReadKey();


            /*
             * ==========================================================
             * 🧹 REMOVE, COUNT, CLONE, CLEAR
             * ==========================================================
             */
            Console.WriteLine("=== 🔸 OTHER USEFUL METHODS ===");

            Console.WriteLine($"\n🔢 Total Entries: {employeeHashTable.Count}");

            // ✅ Remove an entry
            employeeHashTable.Remove("Salary");
            Console.WriteLine("❌ Removed 'Salary' key.");

            // ✅ Clone the hashtable
            Hashtable clone = (Hashtable)employeeHashTable.Clone();
            Console.WriteLine("\n📋 Cloned Hashtable:");
            foreach (DictionaryEntry item in clone)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            // ✅ Clear the original hashtable
            employeeHashTable.Clear();
            Console.WriteLine($"\n🧹 Original Hashtable cleared. Count: {employeeHashTable.Count}");

            Console.ReadKey();
            Console.Clear();
        }
    }
}
