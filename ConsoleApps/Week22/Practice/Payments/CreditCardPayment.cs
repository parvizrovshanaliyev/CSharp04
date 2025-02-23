namespace Practice.Payments;

/// <summary>
/// Represents a credit card payment method.
/// </summary>
public class CreditCardPayment : PaymentMethod
{
    /// <summary>
    /// Gets the type of payment.
    /// </summary>
    public override string PaymentType => "Credit Card";

    /// <summary>
    /// Gets the processing fee for the credit card payment.
    /// </summary>
    public override decimal ProcessingFee => 2.5m;

    /// <summary>
    /// Gets or sets the transaction ID for the payment.
    /// </summary>
    public override string TransactionId { get; set; }

    /// <summary>
    /// Gets the private card number of the credit card.
    /// </summary>
    private string CardNumber { get; set; }

    /// <summary>
    /// Gets the CVV security code of the credit card.
    /// </summary>
    private int CVV { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CreditCardPayment"/> class.
    /// </summary>
    /// <param name="cardNumber">The credit card number.</param>
    /// <param name="cvv">The CVV security code.</param>
    public CreditCardPayment(string cardNumber, int cvv)
    {
        CardNumber = cardNumber;
        CVV = cvv;
        TransactionId = Guid.NewGuid().ToString();
    }

    /// <summary>
    /// Processes the credit card payment.
    /// </summary>
    /// <param name="amount">The amount to be paid.</param>
    public override void ProcessPayment(decimal amount)
    {
        if (ValidatePaymentDetails())
        {
            decimal totalAmount = amount + ProcessingFee;
            Console.WriteLine($"Processing {PaymentType} payment of ${totalAmount}");
        }
        else
        {
            Console.WriteLine("Invalid credit card details.");
        }
    }

    /// <summary>
    /// Validates the credit card payment details.
    /// </summary>
    /// <returns><c>true</c> if the payment details are valid; otherwise, <c>false</c>.</returns>
    public override bool ValidatePaymentDetails()
    {
        return CardNumber.Length == 16 && CVV > 99 && CVV < 1000;
    }

    /// <summary>
    /// Generates a receipt for the credit card payment.
    /// </summary>
    /// <returns>A string representing the receipt.</returns>
    public override string GenerateReceipt()
    {
        return $"Transaction {TransactionId} - {PaymentType} payment processed.";
    }
}
