namespace Practice.Models
{
    /// <summary>
    /// Represents a base building class that demonstrates constructor chaining.
    /// This class serves as the base for different types of buildings.
    /// </summary>
    public class Building
    {
        /// <summary>
        /// Gets or sets the type of the building (e.g., "Residential" or "Commercial").
        /// Protected to allow access from derived classes while maintaining encapsulation.
        /// </summary>
        protected string BuildingType { get; set; }

        /// <summary>
        /// Initializes a new instance of the Building class.
        /// This constructor will be called by derived classes using the base keyword.
        /// </summary>
        /// <param name="buildingType">The type of the building</param>
        public Building(string buildingType)
        {
            /* Store the building type and display it.
             * This constructor will be called first in the constructor chain
             * when creating derived class instances.
             */
            BuildingType = buildingType;
            Console.WriteLine($"Building type: {BuildingType}");
        }
    }

    /// <summary>
    /// Represents an apartment building.
    /// Demonstrates constructor chaining by calling the base class constructor.
    /// </summary>
    public class Apartment : Building
    {
        /// <summary>
        /// Gets or sets the number of floors in the apartment building.
        /// </summary>
        public int NumberOfFloors { get; set; }

        /// <summary>
        /// Initializes a new instance of the Apartment class.
        /// Demonstrates constructor chaining using the base keyword.
        /// </summary>
        /// <param name="buildingType">The type of the building</param>
        /// <param name="numberOfFloors">The number of floors in the apartment</param>
        public Apartment(string buildingType, int numberOfFloors) : base(buildingType)
        {
            /* After the base constructor is called and completes,
             * this constructor body executes to initialize derived class members.
             * This demonstrates the constructor execution order in inheritance.
             */
            NumberOfFloors = numberOfFloors;
            Console.WriteLine($"Number of floors: {NumberOfFloors}");
        }
    }
}