namespace Practice.Notifications;

/// <summary>
/// Abstract base class for handling different types of notifications in the system.
/// </summary>
public abstract class NotificationSender
{
    /// <summary>
    /// Gets or sets the priority level of the notification.
    /// </summary>
    public abstract string Priority { get; set; }

    /// <summary>
    /// Gets or sets the current delivery status of the notification.
    /// </summary>
    public abstract string DeliveryStatus { get; set; }

    /// <summary>
    /// Gets or sets the number of retry attempts for failed notifications.
    /// </summary>
    public abstract int RetryCount { get; set; }

    /// <summary>
    /// Sends the notification to the intended recipient.
    /// </summary>
    public abstract void Send();

    /// <summary>
    /// Validates the notification content before sending.
    /// </summary>
    /// <returns>True if the content is valid; otherwise, false.</returns>
    public abstract bool ValidateContent();

    /// <summary>
    /// Retrieves the current delivery status of the notification.
    /// </summary>
    /// <returns>A string representing the current delivery status.</returns>
    public abstract string GetDeliveryStatus();

    /// <summary>
    /// Logs the notification details to the system.
    /// </summary>
    protected void LogNotification()
    {
        Console.WriteLine("Notification logged.");
    }
}
