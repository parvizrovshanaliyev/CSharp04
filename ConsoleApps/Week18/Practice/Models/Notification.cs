namespace Practice.Models
{
    /// <summary>
    /// Represents a base notification class that demonstrates method overriding.
    /// This class provides a virtual method that can be overridden by derived classes.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Sends a generic notification.
        /// This is a virtual method that can be overridden by derived classes to provide specific implementation.
        /// </summary>
        public virtual void Send()
        {
            /* Base implementation of the Send method.
             * Derived classes can override this to provide their own implementation
             * while maintaining the same method signature.
             */
            Console.WriteLine("Sending generic notification...");
        }
    }

    /// <summary>
    /// Represents an email notification.
    /// Demonstrates method overriding by providing a specific implementation of the Send method.
    /// </summary>
    public class EmailNotification : Notification
    {
        /// <summary>
        /// Sends an email notification.
        /// Overrides the base Send method to provide email-specific implementation.
        /// </summary>
        public override void Send()
        {
            /* Email-specific implementation of the Send method.
             * This completely replaces the base class implementation
             * when called on an EmailNotification object.
             */
            Console.WriteLine("Sending email notification...");
        }
    }

    /// <summary>
    /// Represents an SMS notification.
    /// Demonstrates another example of method overriding with a different implementation.
    /// </summary>
    public class SMSNotification : Notification
    {
        /// <summary>
        /// Sends an SMS notification.
        /// Overrides the base Send method to provide SMS-specific implementation.
        /// </summary>
        public override void Send()
        {
            /* SMS-specific implementation of the Send method.
             * This completely replaces the base class implementation
             * when called on an SMSNotification object.
             */
            Console.WriteLine("Sending SMS notification...");
        }
    }
}