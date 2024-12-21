using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Book
    {
        // Properties
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int YearPublished { get; private set; }
        public decimal Price { get; private set; }

        // Default Constructor
        public Book()
        {
            Title = "Untitled";
            Author = "Unknown";
            YearPublished = 2000;
            Price = 0.0m;
        }

        // Parameterized Constructor 1
        public Book(string title, string author, int yearPublished)
        {
            Title = string.IsNullOrWhiteSpace(title) ? "Untitled" : title;
            Author = string.IsNullOrWhiteSpace(author) ? "Unknown" : author;
            YearPublished = yearPublished > 0 ? yearPublished : 2000;
            Price = 0.0m;
        }

        // Parameterized Constructor 2
        public Book(string title, string author, int yearPublished, decimal price)
        {
            Title = string.IsNullOrWhiteSpace(title) ? "Untitled" : title;
            Author = string.IsNullOrWhiteSpace(author) ? "Unknown" : author;
            YearPublished = yearPublished > 0 ? yearPublished : 2000;
            Price = price >= 0 ? price : 0.0m;
        }

        // Methods
        public void DisplayDetails()
        {
            Console.WriteLine($"Title: {Title}, Author: {Author}, Year Published: {YearPublished}, Price: ${Price:F2}");
        }

        public void DiscountPrice(decimal discountPercentage)
        {
            if (discountPercentage < 0 || discountPercentage > 100)
            {
                Console.WriteLine("Discount percentage must be between 0 and 100.");
                return;
            }

            decimal discountAmount = Price * (discountPercentage / 100);
            Price -= discountAmount;
            Console.WriteLine($"The price after {discountPercentage}% discount is: ${Price:F2}");
        }

        public void ChangePrice(decimal newPrice)
        {
            if (newPrice < 0)
            {
                Console.WriteLine("Price cannot be negative.");
                return;
            }

            Price = newPrice;
            Console.WriteLine($"The price has been updated to: ${Price:F2}");
        }

        public void UpdateYearPublished(int newYear)
        {
            if (newYear <= 0)
            {
                Console.WriteLine("Year published must be greater than 0.");
                return;
            }

            YearPublished = newYear;
            Console.WriteLine($"The year of publication has been updated to: {YearPublished}");
        }
    }
}
