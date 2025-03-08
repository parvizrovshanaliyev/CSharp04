using System;
using System.Linq;

namespace ArrayRealExamples
{
    /// <summary>
    /// Represents a stock with a date and price.
    /// </summary>
    public class Stock
    {
        /// <summary>
        /// Gets or sets the date of the stock price.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the price of the stock.
        /// </summary>
        public decimal Price { get; set; }
    }

    /// <summary>
    /// Manages stock market prices.
    /// </summary>
    public class StockMarketTracker
    {


        /// <summary>
        /// Manages stock prices by finding the highest, lowest, average prices and sorting them chronologically.
        /// </summary>
        public static void ManageStockPrices()
        {
            Stock[] stocks = new Stock[]
            {
            new Stock { Date = new DateTime(2023, 1, 1), Price = 150.25m },
            new Stock { Date = new DateTime(2023, 1, 2), Price = 152.30m },
            new Stock { Date = new DateTime(2023, 1, 3), Price = 148.75m }
            };

            Stock highestPrice = FindHighestPrice(stocks);
            Stock lowestPrice = FindLowestPrice(stocks);
            decimal averagePrice = CalculateAveragePrice(stocks);
            SortStocksChronologically(stocks);

            Console.WriteLine($"Highest Price: {highestPrice.Date.ToShortDateString()} - ${highestPrice.Price}");
            Console.WriteLine($"Lowest Price: {lowestPrice.Date.ToShortDateString()} - ${lowestPrice.Price}");
            Console.WriteLine($"Average Price: ${averagePrice:F2}");
            Console.WriteLine("Stock prices sorted chronologically:");
            foreach (var stock in stocks)
            {
                Console.WriteLine($"{stock.Date.ToShortDateString()}: ${stock.Price}");
            }
        }

        /// <summary>
        /// Finds the stock with the highest price.
        /// </summary>
        /// <param name="stocks">Array of stocks.</param>
        /// <returns>Stock with the highest price.</returns>
        private static Stock FindHighestPrice(Stock[] stocks)
        {
            Stock highestPrice = stocks[0];
            foreach (var stock in stocks)
            {
                if (stock.Price > highestPrice.Price)
                {
                    highestPrice = stock;
                }
            }
            return highestPrice;
        }

        /// <summary>
        /// Finds the stock with the lowest price.
        /// </summary>
        /// <param name="stocks">Array of stocks.</param>
        /// <returns>Stock with the lowest price.</returns>
        private static Stock FindLowestPrice(Stock[] stocks)
        {
            Stock lowestPrice = stocks[0];
            foreach (var stock in stocks)
            {
                if (stock.Price < lowestPrice.Price)
                {
                    lowestPrice = stock;
                }
            }
            return lowestPrice;
        }

        /// <summary>
        /// Calculates the average price of the stocks.
        /// </summary>
        /// <param name="stocks">Array of stocks.</param>
        /// <returns>Average price of the stocks.</returns>
        private static decimal CalculateAveragePrice(Stock[] stocks)
        {
            decimal totalPrice = 0;
            foreach (var stock in stocks)
            {
                totalPrice += stock.Price;
            }
            return totalPrice / stocks.Length;
        }

        /// <summary>
        /// Sorts the stocks chronologically by date.
        /// </summary>
        /// <param name="stocks">Array of stocks.</param>
        private static void SortStocksChronologically(Stock[] stocks)
        {
            for (int i = 0; i < stocks.Length - 1; i++)
            {
                for (int j = i + 1; j < stocks.Length; j++)
                {
                    if (stocks[i].Date > stocks[j].Date)
                    {
                        var temp = stocks[i];
                        stocks[i] = stocks[j];
                        stocks[j] = temp;
                    }
                }
            }
        }
    }
}
