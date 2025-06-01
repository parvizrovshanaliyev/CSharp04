using System;
using System.Collections;
using System.IO;
using System.Linq;
using Practice.Constants;
using Practice.Enums;
using Practice.Models;

namespace Practice.Services
{
    /// <summary>
    /// Implements the print queue management functionality using non-generic Queue.
    /// This class is responsible for managing the queue of print jobs and persisting them to storage.
    /// </summary>
    public class PrintQueueService : IPrintQueueService
    {
        // The queue storing all print jobs as objects
        private readonly Queue _printQueue;

        // The file path where the queue state is persisted
        private readonly string _queueFilePath;

        /// <summary>
        /// Initializes a new instance of the PrintQueueService.
        /// </summary>
        /// <param name="queueFilePath">The path to the file where the queue state will be persisted. Defaults to DEFAULT_QUEUE_FILE.</param>
        public PrintQueueService(string queueFilePath = PrintQueueConstants.DEFAULT_QUEUE_FILE)
        {
            _printQueue = new Queue();
            _queueFilePath = queueFilePath;
            LoadQueue(); // Load any existing queue state
        }

        /// <summary>
        /// Adds a new print job to the queue and persists the updated state.
        /// </summary>
        /// <param name="job">The print job to add.</param>
        /// <exception cref="ArgumentNullException">Thrown when job is null.</exception>
        public void AddJob(PrintJob job)
        {
            if (job == null)
                throw new ArgumentNullException(nameof(job), PrintQueueConstants.ERROR_PREFIX + " Print job cannot be null");

            _printQueue.Enqueue(job);
            SaveQueue(); // Persist changes immediately
        }

        /// <summary>
        /// Processes and removes the next print job from the queue.
        /// </summary>
        /// <returns>The processed print job.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
        public PrintJob ProcessNextJob()
        {
            if (_printQueue.Count == 0)
                throw new InvalidOperationException(PrintQueueConstants.MSG_NO_JOBS);

            // Cast the dequeued object to PrintJob
            var job = (PrintJob)_printQueue.Dequeue();
            job.Status = JobStatus.InProgress;
            SaveQueue(); // Persist changes immediately
            return job;
        }

        /// <summary>
        /// Returns the next print job without removing it from the queue.
        /// </summary>
        /// <returns>The next print job in the queue, or null if the queue is empty.</returns>
        public PrintJob PeekNextJob()
        {
            if (_printQueue.Count == 0)
                return null;

            return (PrintJob)_printQueue.Peek();
        }

        /// <summary>
        /// Gets the current number of jobs in the queue.
        /// </summary>
        /// <returns>The number of jobs in the queue.</returns>
        public int GetJobCount()
        {
            return _printQueue.Count;
        }

        /// <summary>
        /// Retrieves all print jobs currently in the queue.
        /// </summary>
        /// <returns>An array of all print jobs in the queue.</returns>
        public PrintJob[] GetAllJobs()
        {
            var jobs = new PrintJob[_printQueue.Count];
            _printQueue.CopyTo(jobs, 0);
            return jobs;
        }

        /// <summary>
        /// Calculates the total estimated wait time for all jobs in the queue.
        /// </summary>
        /// <returns>The sum of estimated print times for all jobs in minutes.</returns>
        public int GetEstimatedWaitTime()
        {
            int totalTime = 0;
            foreach (PrintJob job in _printQueue)
            {
                totalTime += job.EstimatedPrintTimeMinutes;
            }
            return totalTime;
        }

        /// <summary>
        /// Removes all print jobs from the queue and persists the empty state.
        /// </summary>
        public void ClearQueue()
        {
            _printQueue.Clear();
            SaveQueue(); // Persist changes immediately
        }

        /// <summary>
        /// Persists the current queue state to the file.
        /// Each job is saved as a line in the format: "JobName|PrintTime"
        /// </summary>
        public void SaveQueue()
        {
            try
            {
                var jobStrings = _printQueue.Cast<PrintJob>()
                    .Select(job => $"{job.Name}{PrintQueueConstants.FILE_DELIMITER}{job.EstimatedPrintTimeMinutes}");
                File.WriteAllLines(_queueFilePath, jobStrings);
            }
            catch (Exception ex)
            {
                throw new IOException(PrintQueueConstants.ERROR_PREFIX + " Failed to save queue: " + ex.Message);
            }
        }

        /// <summary>
        /// Loads the queue state from the file.
        /// Each line should be in the format: "JobName|PrintTime"
        /// Invalid lines are skipped.
        /// </summary>
        public void LoadQueue()
        {
            if (!File.Exists(_queueFilePath))
                return;

            try
            {
                var jobStrings = File.ReadAllLines(_queueFilePath);
                foreach (var jobString in jobStrings)
                {
                    var parts = jobString.Split(PrintQueueConstants.FILE_DELIMITER[0]);
                    if (parts.Length == 2 && int.TryParse(parts[1], out int printTime))
                    {
                        if (printTime >= PrintQueueConstants.MIN_PRINT_TIME &&
                            printTime <= PrintQueueConstants.MAX_PRINT_TIME)
                        {
                            _printQueue.Enqueue(new PrintJob(parts[0], printTime));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new IOException(PrintQueueConstants.ERROR_PREFIX + " Failed to load queue: " + ex.Message);
            }
        }
    }
}