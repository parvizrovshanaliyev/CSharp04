using System;
using Practice.Constants;
using Practice.Enums;

namespace Practice.Models
{
    /// <summary>
    /// Represents a print job in the queue with its properties and validation logic.
    /// This class is designed to work with non-generic Queue.
    /// </summary>
    public class PrintJob
    {
        /// <summary>
        /// Gets the name of the print job.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the estimated time in minutes required to complete the print job.
        /// </summary>
        public int EstimatedPrintTimeMinutes { get; private set; }

        /// <summary>
        /// Gets the date and time when the print job was added to the queue.
        /// </summary>
        public DateTime AddedTime { get; private set; }

        /// <summary>
        /// Gets or sets the current status of the print job.
        /// </summary>
        public JobStatus Status { get; set; }

        /// <summary>
        /// Initializes a new instance of the PrintJob class.
        /// </summary>
        /// <param name="name">The name of the print job. Cannot be null or empty.</param>
        /// <param name="estimatedPrintTimeMinutes">The estimated time in minutes to complete the job. Must be between MIN_PRINT_TIME and MAX_PRINT_TIME.</param>
        /// <exception cref="ArgumentException">Thrown when name is null/empty or print time is invalid.</exception>
        public PrintJob(string name, int estimatedPrintTimeMinutes)
        {
            // Validate input parameters
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Job name cannot be empty", nameof(name));

            if (estimatedPrintTimeMinutes < PrintQueueConstants.MIN_PRINT_TIME ||
                estimatedPrintTimeMinutes > PrintQueueConstants.MAX_PRINT_TIME)
                throw new ArgumentException(
                    $"Print time must be between {PrintQueueConstants.MIN_PRINT_TIME} and {PrintQueueConstants.MAX_PRINT_TIME} minutes",
                    nameof(estimatedPrintTimeMinutes));

            // Initialize properties
            Name = name;
            EstimatedPrintTimeMinutes = estimatedPrintTimeMinutes;
            AddedTime = DateTime.Now;
            Status = JobStatus.Pending;
        }

        /// <summary>
        /// Returns a string representation of the print job.
        /// </summary>
        /// <returns>A string in the format "JobName (X minutes) - Status"</returns>
        public override string ToString()
        {
            return $"{Name} ({EstimatedPrintTimeMinutes} minutes) - {Status}";
        }
    }
}