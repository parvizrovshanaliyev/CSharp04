namespace Practice.Payments;

/// <summary>
/// Represents a cryptocurrency payment method.
/// </summary>
public class CryptoCurrencyPayment : PaymentMethod
{
    /// <summary>
    /// Gets the type of payment.
    /// </summary>
    public override string PaymentType => "Cryptocurrency";

    /// <summary>
    /// Gets the processing fee for the payment.
    /// </summary>
    public override decimal ProcessingFee => 1.5m;

    /// <summary>
    /// Gets or sets the transaction ID.
    /// </summary>
    public override string TransactionId { get; set; }

    /// <summary>
    /// Gets or sets the wallet address.
    /// </summary>
    private string WalletAddress { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CryptoCurrencyPayment"/> class with the specified wallet address.
    /// </summary>
    /// <param name="walletAddress">The wallet address for the cryptocurrency payment.</param>
    public CryptoCurrencyPayment(string walletAddress)
    {
        WalletAddress = walletAddress;
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
        return !string.IsNullOrEmpty(WalletAddress) && WalletAddress.Length == 42;
    }

    /// <summary>
    /// Generates a receipt for the payment.
    /// </summary>
    /// <returns>A string representing the receipt for the payment.</returns>
    public override string GenerateReceipt()
    {
        return $"Crypto Transaction {TransactionId} - Payment processed to {WalletAddress}";
    }
}
