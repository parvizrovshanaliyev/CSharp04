namespace Practice.Models
{
    /// <summary>
    /// Represents a screen component that can be used in different devices.
    /// This class demonstrates both inheritance and composition patterns.
    /// </summary>
    public class Screen
    {
        /// <summary>
        /// Displays the resolution information of the screen.
        /// This method can be used both through inheritance and composition.
        /// </summary>
        public void ShowResolution()
        {
            /* Basic screen functionality that can be accessed
             * either directly (inheritance) or through composition
             */
            Console.WriteLine("Resolution: 1920x1080");
        }
    }

    /// <summary>
    /// Represents a desktop computer that inherits from Screen.
    /// Demonstrates the inheritance approach to reusing Screen functionality.
    /// </summary>
    public class Desktop : Screen
    {
        /* Desktop directly inherits Screen functionality
         * This is an example of "is-a" relationship:
         * A Desktop is a Screen (has screen capabilities directly)
         */
    }

    /// <summary>
    /// Represents a laptop computer that contains a Screen.
    /// Demonstrates the composition approach to reusing Screen functionality.
    /// </summary>
    public class Laptop
    {
        /* Laptop has a Screen as a component
         * This is an example of "has-a" relationship:
         * A Laptop has a Screen (contains screen capabilities)
         */
        private Screen screen;

        /// <summary>
        /// Initializes a new instance of the Laptop class.
        /// Creates a new Screen instance as part of the Laptop.
        /// </summary>
        public Laptop()
        {
            screen = new Screen();
        }

        /// <summary>
        /// Displays the screen information by delegating to the contained Screen object.
        /// Demonstrates method delegation in composition.
        /// </summary>
        public void DisplayScreenInfo()
        {
            /* Delegate the call to the contained Screen object
             * This is an example of composition where we forward
             * the request to the contained object
             */
            screen.ShowResolution();
        }
    }
}