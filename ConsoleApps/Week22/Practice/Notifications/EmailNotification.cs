namespace Practice.Notifications;

/// <summary>
/// Handles email-based notifications.
/// </summary>
public class EmailNotification : NotificationSender
{
    public override string Priority { get; set; }
    public override string DeliveryStatus { get; set; }
    public override int RetryCount { get; set; }

    /// <summary>
    /// Gets or sets the recipient's email address.
    /// </summary>
    public string EmailAddress { get; set; }

    /// <summary>
    /// Initializes a new instance of the EmailNotification class.
    /// </summary>
    /// <param name="email">The recipient's email address.</param>
    public EmailNotification(string email)
    {
        EmailAddress = email;
        Priority = "High";
        DeliveryStatus = "Pending";
        RetryCount = 0;
    }

    /// <summary>
    /// Sends the email notification to the specified address.
    /// </summary>
    public override void Send()
    {
        if (ValidateContent())
        {
            DeliveryStatus = "Sent";
            Console.WriteLine($"Email sent to {EmailAddress}");
        }
        else
        {
            Console.WriteLine("Invalid email content.");
        }
    }

    /// <summary>
    /// Validates the email address format.
    /// </summary>
    /// <returns>True if the email address is valid; otherwise, false.</returns>
    public override bool ValidateContent()
    {
        return EmailAddress.Contains("@");
    }

    /// <summary>
    /// Gets the current delivery status of the email.
    /// </summary>
    /// <returns>The current delivery status as a string.</returns>
    public override string GetDeliveryStatus()
    {
        return DeliveryStatus;
    }
}
