namespace Practice.Models
{
    /// <summary>
    /// Represents a base class for electronic devices.
    /// Demonstrates basic inheritance concepts with a simple property and method.
    /// </summary>
    public class Device
    {
        /// <summary>
        /// Gets or sets the manufacturer of the device.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Initializes a new instance of the Device class.
        /// </summary>
        /// <param name="manufacturer">The name of the device manufacturer</param>
        public Device(string manufacturer)
        {
            Manufacturer = manufacturer;
        }

        /// <summary>
        /// Displays the manufacturer information of the device.
        /// </summary>
        public void DisplayManufacturer()
        {
            Console.WriteLine($"Manufacturer: {Manufacturer}");
        }
    }

    /// <summary>
    /// Represents a mobile device.
    /// Inherits from Device and adds model-specific functionality.
    /// </summary>
    public class Mobile : Device
    {
        /// <summary>
        /// Gets or sets the model name of the mobile device.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Initializes a new instance of the Mobile class.
        /// </summary>
        /// <param name="manufacturer">The name of the device manufacturer</param>
        /// <param name="model">The model name of the mobile device</param>
        public Mobile(string manufacturer, string model) : base(manufacturer)
        {
            Model = model;
        }

        /// <summary>
        /// Displays complete details of the mobile device including manufacturer and model.
        /// Demonstrates calling base class method from derived class.
        /// </summary>
        public void DisplayDetails()
        {
            /* First display manufacturer info using base class method,
             * then add model-specific information
             */
            DisplayManufacturer();
            Console.WriteLine($"Model: {Model}");
        }
    }

    /// <summary>
    /// Represents a tablet device.
    /// Inherits from Device and adds stylus support information.
    /// </summary>
    public class Tablet : Device
    {
        /// <summary>
        /// Gets or sets whether the tablet has stylus support.
        /// </summary>
        public bool HasStylus { get; set; }

        /// <summary>
        /// Initializes a new instance of the Tablet class.
        /// </summary>
        /// <param name="manufacturer">The name of the device manufacturer</param>
        /// <param name="hasStylus">Whether the tablet has stylus support</param>
        public Tablet(string manufacturer, bool hasStylus) : base(manufacturer)
        {
            HasStylus = hasStylus;
        }

        /// <summary>
        /// Displays complete details of the tablet including manufacturer and stylus support.
        /// </summary>
        public void DisplayTabletDetails()
        {
            /* Display base device information first,
             * then add tablet-specific features
             */
            DisplayManufacturer();
            Console.WriteLine($"Has Stylus: {HasStylus}");
        }
    }
}