using System;

namespace ArrayRealExamples
{
    /// <summary>
    /// Represents a seat in the cinema.
    /// </summary>
    public class Seat
    {
        /// <summary>
        /// Gets or sets the row number of the seat.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets the column number of the seat.
        /// </summary>
        public int Col { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the seat is booked.
        /// </summary>
        public bool IsBooked { get; set; }
    }
    
    /// <summary>
    /// Manages cinema seat reservations.
    /// </summary>
    public class Cinema
    {


        /// <summary>
        /// Manages the seats by initializing, booking, and displaying available seats.
        /// </summary>
        public static void ManageSeats()
        {
            int rows = 5;
            int cols = 5;
            Seat[,] seats = new Seat[rows, cols];

            // Initialize seats
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    seats[i, j] = new Seat { Row = i, Col = j, IsBooked = false };
                }
            }

            // Book a seat
            BookSeat(seats, 2, 3);

            // Display available seats
            DisplayAvailableSeats(seats);
        }

        /// <summary>
        /// Books a seat at the specified row and column.
        /// </summary>
        /// <param name="seats">The array of seats.</param>
        /// <param name="row">The row number of the seat to book.</param>
        /// <param name="col">The column number of the seat to book.</param>
        private static void BookSeat(Seat[,] seats, int row, int col)
        {
            if (seats[row, col].IsBooked)
            {
                Console.WriteLine($"Seat at Row {row}, Col {col} is already booked.");
            }
            else
            {
                seats[row, col].IsBooked = true;
                Console.WriteLine($"Seat at Row {row}, Col {col} has been booked.");
            }
        }

        /// <summary>
        /// Displays all available seats.
        /// </summary>
        /// <param name="seats">The array of seats.</param>
        private static void DisplayAvailableSeats(Seat[,] seats)
        {
            Console.WriteLine("Available seats:");
            for (int i = 0; i < seats.GetLength(0); i++)
            {
                for (int j = 0; j < seats.GetLength(1); j++)
                {
                    if (!seats[i, j].IsBooked)
                    {
                        Console.WriteLine($"Row {i}, Col {j}");
                    }
                }
            }
        }
    }
}
