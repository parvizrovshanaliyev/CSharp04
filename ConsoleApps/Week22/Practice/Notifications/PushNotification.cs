namespace Practice.Notifications;

/// <summary>
/// Handles push notifications to mobile devices.
/// </summary>
public class PushNotification : NotificationSender
{
    public override string Priority { get; set; }
    public override string DeliveryStatus { get; set; }
    public override int RetryCount { get; set; }

    /// <summary>
    /// Gets or sets the device token for push notification delivery.
    /// </summary>
    private string DeviceToken { get; set; }

    /// <summary>
    /// Initializes a new instance of the PushNotification class.
    /// </summary>
    /// <param name="deviceToken">The unique device token for the target device.</param>
    public PushNotification(string deviceToken)
    {
        DeviceToken = deviceToken;
        Priority = "High";
        DeliveryStatus = "Pending";
        RetryCount = 0;
    }

    /// <summary>
    /// Sends the push notification to the specified device.
    /// </summary>
    public override void Send()
    {
        if (ValidateContent())
        {
            DeliveryStatus = "Sent";
            Console.WriteLine($"Push notification sent to device: {DeviceToken}");
            LogNotification();
        }
    }

    /// <summary>
    /// Validates the device token and notification content.
    /// </summary>
    /// <returns>True if the device token is valid; otherwise, false.</returns>
    public override bool ValidateContent()
    {
        return !string.IsNullOrEmpty(DeviceToken);
    }

    /// <summary>
    /// Gets the current delivery status of the push notification.
    /// </summary>
    /// <returns>The current delivery status as a string.</returns>
    public override string GetDeliveryStatus()
    {
        return DeliveryStatus;
    }
}