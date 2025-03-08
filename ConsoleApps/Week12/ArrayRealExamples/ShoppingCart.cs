using System;
using System.Linq;

namespace ArrayRealExamples
{
    /// <summary>
    /// Represents an item in the shopping cart.
    /// </summary>
    public class CartItem
    {
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product.
        /// </summary>
        public int Quantity { get; set; }
    }

    /// <summary>
    /// Manages shopping cart items.
    /// </summary>
    public class ShoppingCart
    {


        /// <summary>
        /// Manages the shopping cart operations.
        /// </summary>
        public static void ManageCart()
        {
            CartItem[] cartItems = new CartItem[]
            {
                new CartItem { ProductName = "Laptop", Price = 999.99m, Quantity = 1 },
                new CartItem { ProductName = "Smartphone", Price = 499.99m, Quantity = 2 },
                new CartItem { ProductName = "Tablet", Price = 299.99m, Quantity = 1 }
            };

            // Add items to cart
            cartItems = AddItemToCart(cartItems, new CartItem { ProductName = "Headphones", Price = 199.99m, Quantity = 1 });

            // Remove items from cart
            cartItems = RemoveItemFromCart(cartItems, "Tablet");

            // Calculate total price
            decimal totalPrice = CalculateTotalPrice(cartItems);
            Console.WriteLine($"Total Price: ${totalPrice}");
        }

        /// <summary>
        /// Adds a new item to the shopping cart.
        /// </summary>
        /// <param name="cartItems">The current array of cart items.</param>
        /// <param name="newItem">The new item to add to the cart.</param>
        /// <returns>The updated array of cart items.</returns>
        private static CartItem[] AddItemToCart(CartItem[] cartItems, CartItem newItem)
        {
            CartItem[] newCartItems = new CartItem[cartItems.Length + 1];
            for (int i = 0; i < cartItems.Length; i++)
            {
                newCartItems[i] = cartItems[i];
            }
            newCartItems[cartItems.Length] = newItem;
            return newCartItems;
        }

        /// <summary>
        /// Removes an item from the shopping cart by product name.
        /// </summary>
        /// <param name="cartItems">The current array of cart items.</param>
        /// <param name="productName">The name of the product to remove.</param>
        /// <returns>The updated array of cart items.</returns>
        private static CartItem[] RemoveItemFromCart(CartItem[] cartItems, string productName)
        {
            int index = -1;
            for (int i = 0; i < cartItems.Length; i++)
            {
                if (cartItems[i].ProductName == productName)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                return cartItems;
            }

            CartItem[] newCartItems = new CartItem[cartItems.Length - 1];
            for (int i = 0, j = 0; i < cartItems.Length; i++)
            {
                if (i != index)
                {
                    newCartItems[j++] = cartItems[i];
                }
            }
            return newCartItems;
        }

        /// <summary>
        /// Calculates the total price of all items in the shopping cart.
        /// </summary>
        /// <param name="cartItems">The array of cart items.</param>
        /// <returns>The total price of all items in the cart.</returns>
        private static decimal CalculateTotalPrice(CartItem[] cartItems)
        {
            decimal total = 0;
            for (int i = 0; i < cartItems.Length; i++)
            {
                total += cartItems[i].Price * cartItems[i].Quantity;
            }
            return total;
        }
    }
}
