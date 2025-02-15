namespace Practice.Payment;
/// <summary>
/// The PaymentProcessor class demonstrates static polymorphism through method overloading.
/// Static polymorphism is achieved at compile-time by having multiple methods with the same name
/// but different parameter lists. This allows the same method name to handle different types
/// of payments while providing type safety at compile time.
/// Handles different types of payment processing through method overloading.
/// Demonstrates static polymorphism by providing multiple methods with the same name
/// but different parameter lists.
/// </summary>
public class PaymentProcessor
{
    /// <summary>
    /// Processes a credit card payment.
    /// </summary>
    /// <param name="creditCardNumber">The credit card number for the transaction.</param>
    /// <param name="amount">The amount to be charged to the credit card.</param>
    public void ProcessPayment(string creditCardNumber, double amount)
    {
        Console.WriteLine($"Processing credit card payment of ${amount} with card number {creditCardNumber}");
    }

    /// <summary>
    /// Processes a bank transfer payment.
    /// </summary>
    /// <param name="bankAccount">The bank account number for the transaction.</param>
    /// <param name="routingNumber">The routing number for the bank transfer.</param>
    /// <param name="amount">The amount to be transferred.</param>
    public void ProcessPayment(string bankAccount, string routingNumber, double amount)
    {
        Console.WriteLine($"Processing bank transfer of ${amount} from account {bankAccount}");
    }

    /// <summary>
    /// Processes a cash payment.
    /// </summary>
    /// <param name="cashAmount">The amount of cash to be processed.</param>
    public void ProcessPayment(double cashAmount)
    {
        Console.WriteLine($"Processing cash payment of ${cashAmount}");
    }
}