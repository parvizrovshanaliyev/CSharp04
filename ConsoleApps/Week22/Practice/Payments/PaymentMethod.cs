namespace Practice.Payments;

/// <summary>
/// Abstract base class for handling different payment methods in the system.
/// </summary>
public abstract class PaymentMethod
{
    /// <summary>
    /// Gets the type of payment method being used.
    /// </summary>
    public abstract string PaymentType { get; }

    /// <summary>
    /// Gets the processing fee associated with this payment method.
    /// </summary>
    public abstract decimal ProcessingFee { get; }

    /// <summary>
    /// Gets or sets the unique transaction identifier.
    /// </summary>
    public abstract string TransactionId { get; set; }

    /// <summary>
    /// Processes a payment for the specified amount.
    /// </summary>
    /// <param name="amount">The amount to process.</param>
    public abstract void ProcessPayment(decimal amount);

    /// <summary>
    /// Validates the payment details before processing.
    /// </summary>
    /// <returns>True if the payment details are valid; otherwise, false.</returns>
    public abstract bool ValidatePaymentDetails();

    /// <summary>
    /// Generates a receipt for the processed payment.
    /// </summary>
    /// <returns>A formatted receipt string.</returns>
    public abstract string GenerateReceipt();
}
