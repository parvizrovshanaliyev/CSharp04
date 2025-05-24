namespace ProductInventorySystem.Constants
{
    /// <summary>
    /// Represents the available menu options in the application.
    /// This enum defines all possible user interactions in the menu system.
    /// Each option corresponds to a specific operation in the product inventory system.
    /// </summary>
    public enum MenuOption
    {
        /// <summary>
        /// Option to add a new product to the inventory
        /// </summary>
        AddProduct = 1,

        /// <summary>
        /// Option to view all products in the inventory
        /// </summary>
        ViewAllProducts = 2,

        /// <summary>
        /// Option to search for a product by its code
        /// </summary>
        SearchProduct = 3,

        /// <summary>
        /// Option to update an existing product's name
        /// </summary>
        UpdateProduct = 4,

        /// <summary>
        /// Option to remove a product from the inventory
        /// </summary>
        RemoveProduct = 5,

        /// <summary>
        /// Option to check if a product exists by its name
        /// </summary>
        CheckProductExists = 6,

        /// <summary>
        /// Option to display the total number of products
        /// </summary>
        ShowProductCount = 7,

        /// <summary>
        /// Option to exit the application
        /// </summary>
        Exit = 8
    }

    /// <summary>
    /// Contains constant messages used throughout the application.
    /// This class provides centralized message strings for:
    /// - Success messages
    /// - Error messages
    /// - System messages
    /// - User feedback
    /// </summary>
    public static class Messages
    {
        /// <summary>
        /// Message displayed when an invalid menu choice is made
        /// </summary>
        public const string InvalidChoice = "Invalid choice. Please try again.";

        /// <summary>
        /// Message displayed when waiting for user to continue
        /// </summary>
        public const string PressKeyToContinue = "\nPress any key to continue...";

        /// <summary>
        /// Message displayed when no products exist in inventory
        /// </summary>
        public const string NoProducts = "No products in inventory.";

        /// <summary>
        /// Message displayed when a product is successfully added
        /// </summary>
        public const string ProductAdded = "✅ Product added!";

        /// <summary>
        /// Message displayed when a product is successfully updated
        /// </summary>
        public const string ProductUpdated = "✅ Product updated!";

        /// <summary>
        /// Message displayed when a product is successfully removed
        /// </summary>
        public const string ProductRemoved = "✅ Product removed from inventory.";

        /// <summary>
        /// Message displayed when a product is found in inventory
        /// </summary>
        public const string ProductExists = "✅ Product exists in inventory.";

        /// <summary>
        /// Message displayed when a product is not found
        /// </summary>
        public const string ProductNotFound = "❌ Product not found.";

        /// <summary>
        /// Message displayed when user input is invalid
        /// </summary>
        public const string InvalidInput = "❌ Invalid input.";

        /// <summary>
        /// Message displayed when attempting to add a duplicate product code
        /// </summary>
        public const string DuplicateCode = "❌ Product code already exists.";

        /// <summary>
        /// Message displayed when user provides empty input
        /// </summary>
        public const string EmptyInput = "❌ Input cannot be empty.";
    }

    /// <summary>
    /// Contains constant prompts used for user input.
    /// This class provides centralized prompt strings for:
    /// - Menu choices
    /// - Product information input
    /// - Search operations
    /// - Update operations
    /// </summary>
    public static class Prompts
    {
        /// <summary>
        /// Prompt for menu choice selection
        /// </summary>
        public const string EnterChoice = "Enter your choice: ";

        /// <summary>
        /// Prompt for entering a new product code
        /// </summary>
        public const string EnterProductCode = "Enter Product Code: ";

        /// <summary>
        /// Prompt for entering a new product name
        /// </summary>
        public const string EnterProductName = "Enter Product Name: ";

        /// <summary>
        /// Prompt for entering a new product name during update
        /// </summary>
        public const string EnterNewName = "Enter New Name: ";

        /// <summary>
        /// Prompt for entering a product code to search
        /// </summary>
        public const string EnterCodeToSearch = "Enter Product Code to search: ";

        /// <summary>
        /// Prompt for entering a product code to update
        /// </summary>
        public const string EnterCodeToUpdate = "Enter Product Code to update: ";

        /// <summary>
        /// Prompt for entering a product code to remove
        /// </summary>
        public const string EnterCodeToRemove = "Enter Product Code to remove: ";

        /// <summary>
        /// Prompt for entering a product name to check existence
        /// </summary>
        public const string EnterNameToCheck = "Enter Product Name to check: ";
    }
}