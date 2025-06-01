namespace Practice.Constants
{
    /// <summary>
    /// Contains constant values used throughout the Print Job Management System.
    /// </summary>
    public static class PrintQueueConstants
    {
        // File related constants
        public const string DEFAULT_QUEUE_FILE = "printqueue.txt";
        public const string FILE_DELIMITER = "|";

        // UI related constants
        public const string MENU_TITLE = "=== Print Job Management System ===";
        public const string SUCCESS_PREFIX = "[SUCCESS]";
        public const string ERROR_PREFIX = "[ERROR]";
        public const string INFO_PREFIX = "[INFO]";

        // Validation related constants
        public const int MIN_PRINT_TIME = 1;
        public const int MAX_PRINT_TIME = 1440; // 24 hours in minutes

        // Messages
        public const string MSG_NO_JOBS = "No jobs in the queue.";
        public const string MSG_QUEUE_CLEARED = "Print queue cleared.";
        public const string MSG_JOB_ADDED = "Print job added to queue.";
        public const string MSG_JOB_COMPLETED = "Print job completed!";
        public const string MSG_CHANGES_SAVED = "Changes saved. Exiting...";
        public const string MSG_INVALID_CHOICE = "Invalid choice. Please try again.";
        public const string MSG_INVALID_PRINT_TIME = "Invalid print time. Please enter a positive number.";
        public const string MSG_QUEUE_CORRUPTED = "Invalid data type in queue. The queue may be corrupted.";
    }
}