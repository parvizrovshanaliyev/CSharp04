namespace Practice.Payments;

/// <summary>
/// Represents a PayPal payment method.
/// </summary>
public class PayPalPayment : PaymentMethod
{
    /// <summary>
    /// Gets the type of payment.
    /// </summary>
    public override string PaymentType => "PayPal";

    /// <summary>
    /// Gets the processing fee for the payment.
    /// </summary>
    public override decimal ProcessingFee => 3.0m;

    /// <summary>
    /// Gets or sets the transaction ID.
    /// </summary>
    public override string TransactionId { get; set; }

    /// <summary>
    /// Gets or sets the email associated with the PayPal account.
    /// </summary>
    private string Email { get; set; }

    /// <summary>
    /// Gets or sets the token for the PayPal payment.
    /// </summary>
    private string Token { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PayPalPayment"/> class with the specified email.
    /// </summary>
    /// <param name="email">The email associated with the PayPal account.</param>
    public PayPalPayment(string email)
    {
        Email = email;
        Token = Guid.NewGuid().ToString();
        TransactionId = Guid.NewGuid().ToString();
    }

    /// <summary>
    /// Processes the payment with the specified amount.
    /// </summary>
    /// <param name="amount">The amount to be processed.</param>
    public override void ProcessPayment(decimal amount)
    {
        if (ValidatePaymentDetails())
        {
            decimal totalAmount = amount + ProcessingFee;
            Console.WriteLine($"Processing {PaymentType} payment of ${totalAmount}");
        }
    }

    /// <summary>
    /// Validates the payment details.
    /// </summary>
    /// <returns><c>true</c> if the payment details are valid; otherwise, <c>false</c>.</returns>
    public override bool ValidatePaymentDetails()
    {
        return !string.IsNullOrEmpty(Email) && Email.Contains("@");
    }

    /// <summary>
    /// Generates a receipt for the payment.
    /// </summary>
    /// <returns>A string representing the receipt.</returns>
    public override string GenerateReceipt()
    {
        return $"PayPal Transaction {TransactionId} - Payment processed for {Email}";
    }
}
