using System;
using System.Collections;
using Practice.Models;

namespace Practice.Services
{
    /// <summary>
    /// Defines the contract for print queue management operations using non-generic Queue.
    /// This interface follows the Interface Segregation Principle by providing
    /// only the methods necessary for queue management.
    /// </summary>
    public interface IPrintQueueService
    {
        /// <summary>
        /// Adds a new print job to the queue.
        /// </summary>
        /// <param name="job">The print job to add to the queue.</param>
        /// <exception cref="ArgumentNullException">Thrown when job is null.</exception>
        void AddJob(PrintJob job);

        /// <summary>
        /// Processes and removes the next print job from the queue.
        /// </summary>
        /// <returns>The processed print job.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
        /// <exception cref="InvalidCastException">Thrown when the dequeued object cannot be cast to PrintJob.</exception>
        PrintJob ProcessNextJob();

        /// <summary>
        /// Returns the next print job without removing it from the queue.
        /// </summary>
        /// <returns>The next print job in the queue, or null if the queue is empty.</returns>
        PrintJob PeekNextJob();

        /// <summary>
        /// Gets the current number of jobs in the queue.
        /// </summary>
        /// <returns>The number of jobs in the queue.</returns>
        int GetJobCount();

        /// <summary>
        /// Retrieves all print jobs currently in the queue.
        /// </summary>
        /// <returns>An array of print jobs.</returns>
        PrintJob[] GetAllJobs();

        /// <summary>
        /// Calculates the total estimated wait time for all jobs in the queue.
        /// </summary>
        /// <returns>The total estimated wait time in minutes.</returns>
        int GetEstimatedWaitTime();

        /// <summary>
        /// Removes all print jobs from the queue.
        /// </summary>
        void ClearQueue();

        /// <summary>
        /// Persists the current queue state to storage.
        /// </summary>
        void SaveQueue();

        /// <summary>
        /// Loads the queue state from storage.
        /// </summary>
        void LoadQueue();
    }
}