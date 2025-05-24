using ProductInventorySystem.Constants;
using ProductInventorySystem.Repositories;
using ProductInventorySystem.Services;
using ProductInventorySystem.Utils;
using System.Collections;

namespace ProductInventorySystem
{
    /// <summary>
    /// Main program class that handles the user interface and program flow
    /// </summary>
    internal class Program
    {
        private static readonly IProductService _productService;

        /// <summary>
        /// Static constructor to initialize the service layer
        /// </summary>
        static Program()
        {
            var repository = new ProductRepository();
            _productService = new ProductService(repository);
        }

        /// <summary>
        /// Main entry point of the application
        /// </summary>
        static void Main(string[] args)
        {
            while (true)
            {
                DisplayMenu();
                var choice = ConsoleHelper.GetMenuChoice();

                if (!choice.HasValue)
                {
                    ConsoleHelper.ShowError(Messages.InvalidChoice);
                    ConsoleHelper.WaitForKeyPress();
                    continue;
                }

                if (choice == MenuOption.Exit)
                    break;

                ProcessMenuChoice(choice.Value);
                ConsoleHelper.WaitForKeyPress();
            }
        }

        /// <summary>
        /// Displays the main menu options
        /// </summary>
        private static void DisplayMenu()
        {
            Console.WriteLine("=== 🛒 Product Inventory System ===");
            foreach (MenuOption option in Enum.GetValues(typeof(MenuOption)))
            {
                Console.WriteLine($"{(int)option}. {FormatMenuOption(option)}");
            }
        }

        /// <summary>
        /// Formats a menu option for display
        /// </summary>
        private static string FormatMenuOption(MenuOption option)
        {
            return option switch
            {
                MenuOption.AddProduct => "Add new product",
                MenuOption.ViewAllProducts => "View all products",
                MenuOption.SearchProduct => "Search product by code",
                MenuOption.UpdateProduct => "Update product name",
                MenuOption.RemoveProduct => "Remove product",
                MenuOption.CheckProductExists => "Check if product exists by name",
                MenuOption.ShowProductCount => "Show product count",
                MenuOption.Exit => "Exit",
                _ => option.ToString()
            };
        }

        /// <summary>
        /// Processes the selected menu choice
        /// </summary>
        private static void ProcessMenuChoice(MenuOption choice)
        {
            switch (choice)
            {
                case MenuOption.AddProduct:
                    AddProduct();
                    break;
                case MenuOption.ViewAllProducts:
                    ViewAllProducts();
                    break;
                case MenuOption.SearchProduct:
                    SearchProduct();
                    break;
                case MenuOption.UpdateProduct:
                    UpdateProduct();
                    break;
                case MenuOption.RemoveProduct:
                    RemoveProduct();
                    break;
                case MenuOption.CheckProductExists:
                    CheckProductExists();
                    break;
                case MenuOption.ShowProductCount:
                    ShowProductCount();
                    break;
            }
        }

        /// <summary>
        /// Handles the process of adding a new product
        /// </summary>
        private static void AddProduct()
        {
            var code = ConsoleHelper.GetNonEmptyInput(Prompts.EnterProductCode);
            if (code == null)
            {
                ConsoleHelper.ShowError(Messages.EmptyInput);
                return;
            }

            var name = ConsoleHelper.GetNonEmptyInput(Prompts.EnterProductName);
            if (name == null)
            {
                ConsoleHelper.ShowError(Messages.EmptyInput);
                return;
            }

            if (_productService.AddProduct(code, name))
            {
                ConsoleHelper.ShowSuccess(Messages.ProductAdded);
            }
            else
            {
                ConsoleHelper.ShowError(Messages.DuplicateCode);
            }
        }

        /// <summary>
        /// Displays all products in the inventory
        /// </summary>
        private static void ViewAllProducts()
        {
            var products = _productService.GetAllProducts();
            if (products.Count == 0)
            {
                ConsoleHelper.ShowError(Messages.NoProducts);
                return;
            }

            Console.WriteLine("\n📋 Products in Inventory:");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        /// <summary>
        /// Handles the process of searching for a product
        /// </summary>
        private static void SearchProduct()
        {
            var code = ConsoleHelper.GetNonEmptyInput(Prompts.EnterCodeToSearch);
            if (code == null)
            {
                ConsoleHelper.ShowError(Messages.EmptyInput);
                return;
            }

            var product = _productService.GetProductByCode(code);
            if (product != null)
            {
                ConsoleHelper.ShowSuccess($"Found: {product}");
            }
            else
            {
                ConsoleHelper.ShowError(Messages.ProductNotFound);
            }
        }

        /// <summary>
        /// Handles the process of updating a product
        /// </summary>
        private static void UpdateProduct()
        {
            var code = ConsoleHelper.GetNonEmptyInput(Prompts.EnterCodeToUpdate);
            if (code == null)
            {
                ConsoleHelper.ShowError(Messages.EmptyInput);
                return;
            }

            var newName = ConsoleHelper.GetNonEmptyInput(Prompts.EnterNewName);
            if (newName == null)
            {
                ConsoleHelper.ShowError(Messages.EmptyInput);
                return;
            }

            if (_productService.UpdateProduct(code, newName))
            {
                ConsoleHelper.ShowSuccess(Messages.ProductUpdated);
            }
            else
            {
                ConsoleHelper.ShowError(Messages.ProductNotFound);
            }
        }

        /// <summary>
        /// Handles the process of removing a product
        /// </summary>
        private static void RemoveProduct()
        {
            var code = ConsoleHelper.GetNonEmptyInput(Prompts.EnterCodeToRemove);
            if (code == null)
            {
                ConsoleHelper.ShowError(Messages.EmptyInput);
                return;
            }

            if (_productService.RemoveProduct(code))
            {
                ConsoleHelper.ShowSuccess(Messages.ProductRemoved);
            }
            else
            {
                ConsoleHelper.ShowError(Messages.ProductNotFound);
            }
        }

        /// <summary>
        /// Handles the process of checking if a product exists by name
        /// </summary>
        private static void CheckProductExists()
        {
            var name = ConsoleHelper.GetNonEmptyInput(Prompts.EnterNameToCheck);
            if (name == null)
            {
                ConsoleHelper.ShowError(Messages.EmptyInput);
                return;
            }

            if (_productService.ProductExistsByName(name))
            {
                ConsoleHelper.ShowSuccess(Messages.ProductExists);
            }
            else
            {
                ConsoleHelper.ShowError(Messages.ProductNotFound);
            }
        }

        /// <summary>
        /// Displays the total number of products in the inventory
        /// </summary>
        private static void ShowProductCount()
        {
            var count = _productService.GetProductCount();
            Console.WriteLine($"Total Products: {count}");
        }
    }
}
