using System;
using System.Threading.Tasks;

namespace OOP.Abstraction.AbstractClass
{
    /// <summary>
    /// Represents an abstract payment processor with basic payment operations.
    /// </summary>
    public abstract class PaymentProcessor
    {
        /// <summary>
        /// Gets or sets the amount to be processed.
        /// </summary>
        protected decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the currency of the amount.
        /// </summary>
        protected string Currency { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentProcessor"/> class.
        /// </summary>
        /// <param name="amount">The amount to be processed.</param>
        /// <param name="currency">The currency of the amount.</param>
        public PaymentProcessor(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        /// <summary>
        /// Authorizes the payment. This method must be implemented by derived classes.
        /// </summary>
        /// <returns>True if the payment is authorized; otherwise, false.</returns>
        public abstract bool AuthorizePayment();

        /// <summary>
        /// Processes the payment. This method must be implemented by derived classes.
        /// </summary>
        /// <returns>True if the payment is processed; otherwise, false.</returns>
        public abstract bool ProcessPayment();

        /// <summary>
        /// Refunds the payment. This method must be implemented by derived classes.
        /// </summary>
        /// <param name="transactionId">The transaction ID of the payment to be refunded.</param>
        /// <returns>True if the payment is refunded; otherwise, false.</returns>
        public abstract bool RefundPayment(string transactionId);

        /// <summary>
        /// Validates the payment details.
        /// </summary>
        public virtual void ValidatePayment()
        {
            if (Amount <= 0)
                throw new ArgumentException("Amount must be greater than zero");
            if (string.IsNullOrEmpty(Currency))
                throw new ArgumentException("Currency must be specified");
        }
    }

    /// <summary>
    /// Represents a credit card payment processor.
    /// </summary>
    public class CreditCardProcessor : PaymentProcessor
    {
        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        private string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the CVV of the card.
        /// </summary>
        private string CVV { get; set; }

        /// <summary>
        /// Gets or sets the expiry date of the card.
        /// </summary>
        private string ExpiryDate { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditCardProcessor"/> class.
        /// </summary>
        /// <param name="amount">The amount to be processed.</param>
        /// <param name="currency">The currency of the amount.</param>
        /// <param name="cardNumber">The card number.</param>
        /// <param name="cvv">The CVV of the card.</param>
        /// <param name="expiryDate">The expiry date of the card.</param>
        public CreditCardProcessor(decimal amount, string currency, string cardNumber, string cvv, string expiryDate)
            : base(amount, currency)
        {
            CardNumber = cardNumber;
            CVV = cvv;
            ExpiryDate = expiryDate;
        }

        /// <summary>
        /// Authorizes the credit card payment.
        /// </summary>
        /// <returns>True if the payment is authorized; otherwise, false.</returns>
        public override bool AuthorizePayment()
        {
            // Credit card authorization logic
            Console.WriteLine("CreditCardProcessor: Payment authorized.");
            return true;
        }

        /// <summary>
        /// Processes the credit card payment.
        /// </summary>
        /// <returns>True if the payment is processed; otherwise, false.</returns>
        public override bool ProcessPayment()
        {
            ValidatePayment();
            // Credit card processing logic
            Console.WriteLine("CreditCardProcessor: Payment processed.");
            return true;
        }

        /// <summary>
        /// Refunds the credit card payment.
        /// </summary>
        /// <param name="transactionId">The transaction ID of the payment to be refunded.</param>
        /// <returns>True if the payment is refunded; otherwise, false.</returns>
        public override bool RefundPayment(string transactionId)
        {
            // Credit card refund logic
            Console.WriteLine("CreditCardProcessor: Payment refunded.");
            return true;
        }
    }

    /// <summary>
    /// Represents a PayPal payment processor.
    /// </summary>
    public class PayPalProcessor : PaymentProcessor
    {
        /// <summary>
        /// Gets or sets the email address associated with the PayPal account.
        /// </summary>
        private string EmailAddress { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PayPalProcessor"/> class.
        /// </summary>
        /// <param name="amount">The amount to be processed.</param>
        /// <param name="currency">The currency of the amount.</param>
        /// <param name="emailAddress">The email address associated with the PayPal account.</param>
        public PayPalProcessor(decimal amount, string currency, string emailAddress)
            : base(amount, currency)
        {
            EmailAddress = emailAddress;
        }

        /// <summary>
        /// Authorizes the PayPal payment.
        /// </summary>
        /// <returns>True if the payment is authorized; otherwise, false.</returns>
        public override bool AuthorizePayment()
        {
            // PayPal authorization logic
            Console.WriteLine("PayPalProcessor: Payment authorized.");
            return true;
        }

        /// <summary>
        /// Processes the PayPal payment.
        /// </summary>
        /// <returns>True if the payment is processed; otherwise, false.</returns>
        public override bool ProcessPayment()
        {
            ValidatePayment();
            // PayPal processing logic
            Console.WriteLine("PayPalProcessor: Payment processed.");
            return true;
        }

        /// <summary>
        /// Refunds the PayPal payment.
        /// </summary>
        /// <param name="transactionId">The transaction ID of the payment to be refunded.</param>
        /// <returns>True if the payment is refunded; otherwise, false.</returns>
        public override bool RefundPayment(string transactionId)
        {
            // PayPal refund logic
            Console.WriteLine("PayPalProcessor: Payment refunded.");
            return true;
        }
    }
}
