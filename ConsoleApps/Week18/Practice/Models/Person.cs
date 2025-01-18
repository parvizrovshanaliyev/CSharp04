namespace Practice.Models
{
    /// <summary>
    /// Represents a base person class in a real-world inheritance example.
    /// Provides common properties and methods for all types of persons.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the age of the person.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Initializes a new instance of the Person class.
        /// </summary>
        /// <param name="name">The name of the person</param>
        /// <param name="age">The age of the person</param>
        public Person(string name, int age)
        {
            /* Initialize basic person information.
             * These properties are common to all derived classes.
             */
            Name = name;
            Age = age;
        }

        /// <summary>
        /// Displays basic information about the person.
        /// This method can be called from any derived class.
        /// </summary>
        public void GetInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }

    /// <summary>
    /// Represents a doctor, inheriting from Person.
    /// Adds medical specialty information to the base person properties.
    /// </summary>
    public class Doctor : Person
    {
        /// <summary>
        /// Gets or sets the medical specialty of the doctor.
        /// </summary>
        public string Specialty { get; set; }

        /// <summary>
        /// Initializes a new instance of the Doctor class.
        /// </summary>
        /// <param name="name">The name of the doctor</param>
        /// <param name="age">The age of the doctor</param>
        /// <param name="specialty">The medical specialty of the doctor</param>
        public Doctor(string name, int age, string specialty) : base(name, age)
        {
            Specialty = specialty;
        }

        /// <summary>
        /// Displays complete information about the doctor.
        /// Demonstrates calling base class method along with additional information.
        /// </summary>
        public void GetDoctorDetails()
        {
            /* First get basic person information using base class method,
             * then add doctor-specific information
             */
            GetInfo();
            Console.WriteLine($"Specialty: {Specialty}");
        }
    }

    /// <summary>
    /// Represents an engineer, inheriting from Person.
    /// Adds engineering field information to the base person properties.
    /// </summary>
    public class Engineer : Person
    {
        /// <summary>
        /// Gets or sets the engineering field of specialization.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Initializes a new instance of the Engineer class.
        /// </summary>
        /// <param name="name">The name of the engineer</param>
        /// <param name="age">The age of the engineer</param>
        /// <param name="field">The engineering field of specialization</param>
        public Engineer(string name, int age, string field) : base(name, age)
        {
            Field = field;
        }

        /// <summary>
        /// Displays complete information about the engineer.
        /// Demonstrates parallel implementation to Doctor class with different specific details.
        /// </summary>
        public void GetEngineerDetails()
        {
            /* First get basic person information using base class method,
             * then add engineer-specific information
             */
            GetInfo();
            Console.WriteLine($"Field: {Field}");
        }
    }
}