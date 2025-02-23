namespace Practice.Notifications;

/// <summary>
/// Represents an SMS notification sender.
/// </summary>
public class SMSNotification : NotificationSender
{
    /// <summary>
    /// Gets or sets the priority of the notification.
    /// </summary>
    public override string Priority { get; set; }

    /// <summary>
    /// Gets or sets the delivery status of the notification.
    /// </summary>
    public override string DeliveryStatus { get; set; }

    /// <summary>
    /// Gets or sets the retry count for sending the notification.
    /// </summary>
    public override int RetryCount { get; set; }

    /// <summary>
    /// Gets or sets the phone number to which the SMS will be sent.
    /// </summary>
    private string PhoneNumber { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SMSNotification"/> class with the specified phone number.
    /// </summary>
    /// <param name="phoneNumber">The phone number to which the SMS will be sent.</param>
    public SMSNotification(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
        Priority = "Medium";
        DeliveryStatus = "Pending";
        RetryCount = 0;
    }

    /// <summary>
    /// Sends the SMS notification.
    /// </summary>
    public override void Send()
    {
        if (ValidateContent())
        {
            DeliveryStatus = "Sent";
            Console.WriteLine($"SMS sent to {PhoneNumber}");
            LogNotification();
        }
    }

    /// <summary>
    /// Validates the content of the SMS notification.
    /// </summary>
    /// <returns><c>true</c> if the content is valid; otherwise, <c>false</c>.</returns>
    public override bool ValidateContent()
    {
        return PhoneNumber.Length >= 10;
    }

    /// <summary>
    /// Gets the delivery status of the SMS notification.
    /// </summary>
    /// <returns>The delivery status of the SMS notification.</returns>
    public override string GetDeliveryStatus()
    {
        return DeliveryStatus;
    }
}
