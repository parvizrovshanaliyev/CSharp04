using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Person
    {
        // Properties to store name and age
        public string Name { get; set; }
        public int Age { get; set; }

        // Override ToString to provide meaningful string representation
        public override string ToString()
        {
            /*
             * The default ToString() method from the object class returns the fully qualified type name.
             * By overriding it, we display the person's name and age for better readability.
             */
            return $"Name: {Name}, Age: {Age}";
        }

        // Override Equals to compare logical equality based on Name and Age
        public override bool Equals(object obj)
        {
            /*
             * This method checks if the given object is a Person
             * and compares the Name and Age properties for logical equality.
             */
            if (obj != null && obj.GetType() == typeof(Person))
            {
                Person other = (Person)obj; // Cast to Person for property comparison
                return this.Name == other.Name && this.Age == other.Age;
            }
            return false;
        }

        // Override GetHashCode to ensure consistency with Equals
        public override int GetHashCode()
        {
            /*
             * HashCode.Combine generates a unique hash based on Name and Age.
             * Consistent hash codes ensure that logically equal objects can work correctly
             * in hash-based collections like dictionaries or hash sets.
             */
            return HashCode.Combine(Name, Age);
        }
    }
}
