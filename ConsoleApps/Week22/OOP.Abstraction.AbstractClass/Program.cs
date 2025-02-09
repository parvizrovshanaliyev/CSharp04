using System;

namespace OOP.Abstraction.AbstractClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            /* 
             * Demonstrating the use of the Bank class and its derived classes.
             * We create instances of ABB and RabiteBank, and call their methods to show how they work.
             * Each method simulates a real-world banking operation such as validating a card, checking balance,
             * withdrawing money, transferring money, and printing a mini statement.
             * 
             * OOP Principles:
             * - Abstraction: The Bank class provides a simplified interface for banking operations.
             * - Inheritance: ABB and RabiteBank inherit from the Bank class and provide specific implementations.
             * - Polymorphism: We can use the Bank type to refer to instances of ABB and RabiteBank.
             * 
             * SOLID Principles:
             * - Single Responsibility Principle: Each class has a single responsibility (e.g., ABB handles ABB-specific banking operations).
             * - Open/Closed Principle: The Bank class is open for extension (through inheritance) but closed for modification.
             * - Liskov Substitution Principle: Instances of ABB and RabiteBank can be used interchangeably with the Bank type.
             */
            Bank abb = new ABB();
            abb.ValidateCard(); // Simulates card validation for ABB bank
            abb.CheckBalance(); // Simulates checking balance for ABB bank
            abb.WithdrawMoney(); // Simulates withdrawing money from ABB bank
            abb.BankTransfer(); // Simulates transferring money from ABB bank
            abb.MiniStatement(); // Prints a mini statement for ABB bank

            Bank rabiteBank = new RabiteBank();
            rabiteBank.ValidateCard(); // Simulates card validation for RabiteBank
            rabiteBank.CheckBalance(); // Simulates checking balance for RabiteBank
            rabiteBank.WithdrawMoney(); // Simulates withdrawing money from RabiteBank
            rabiteBank.BankTransfer(); // Simulates transferring money from RabiteBank
            rabiteBank.MiniStatement(); // Prints a mini statement for RabiteBank

            /* 
             * Demonstrating the use of the Document class and its derived classes.
             * We create instances of PdfDocument, WordDocument, and ExcelDocument, and call their methods to show how they work.
             * Each document type has specific properties and processing logic.
             * 
             * OOP Principles:
             * - Abstraction: The Document class provides a simplified interface for document operations.
             * - Inheritance: PdfDocument, WordDocument, and ExcelDocument inherit from the Document class and provide specific implementations.
             * - Polymorphism: We can use the Document type to refer to instances of PdfDocument, WordDocument, and ExcelDocument.
             * 
             * SOLID Principles:
             * - Single Responsibility Principle: Each class has a single responsibility (e.g., PdfDocument handles PDF-specific processing).
             * - Open/Closed Principle: The Document class is open for extension (through inheritance) but closed for modification.
             * - Liskov Substitution Principle: Instances of PdfDocument, WordDocument, and ExcelDocument can be used interchangeably with the Document type.
             */
            Document pdfDoc = new PdfDocument { Title = "PDF Guide", Author = "John Doe", CreatedDate = DateTime.Now, PdfVersion = "1.4" };
            pdfDoc.DisplayInfo(); // Displays basic information about the PDF document
            pdfDoc.Process(); // Processes the PDF document

            Document wordDoc = new WordDocument { Title = "Word Guide", Author = "Jane Doe", CreatedDate = DateTime.Now, WordVersion = "2019" };
            wordDoc.DisplayInfo(); // Displays basic information about the Word document
            wordDoc.Process(); // Processes the Word document

            Document excelDoc = new ExcelDocument { Title = "Excel Guide", Author = "Jim Doe", CreatedDate = DateTime.Now, ExcelVersion = "2016" };
            excelDoc.DisplayInfo(); // Displays basic information about the Excel document
            excelDoc.Process(); // Processes the Excel document

            /* 
             * Demonstrating the use of the PaymentProcessor class and its derived classes.
             * We create instances of CreditCardProcessor and PayPalProcessor, and call their methods to show how they work.
             * Each payment processor simulates real-world payment operations such as authorizing a payment, processing a payment,
             * and refunding a payment.
             * 
             * OOP Principles:
             * - Abstraction: The PaymentProcessor class provides a simplified interface for payment operations.
             * - Inheritance: CreditCardProcessor and PayPalProcessor inherit from the PaymentProcessor class and provide specific implementations.
             * - Polymorphism: We can use the PaymentProcessor type to refer to instances of CreditCardProcessor and PayPalProcessor.
             * 
             * SOLID Principles:
             * - Single Responsibility Principle: Each class has a single responsibility (e.g., CreditCardProcessor handles credit card payments).
             * - Open/Closed Principle: The PaymentProcessor class is open for extension (through inheritance) but closed for modification.
             * - Liskov Substitution Principle: Instances of CreditCardProcessor and PayPalProcessor can be used interchangeably with the PaymentProcessor type.
             */
            PaymentProcessor creditCardProcessor = new CreditCardProcessor(100, "USD", "1234-5678-9876-5432", "123", "12/23");
            creditCardProcessor.AuthorizePayment(); // Simulates authorizing a credit card payment
            creditCardProcessor.ProcessPayment(); // Simulates processing a credit card payment
            creditCardProcessor.RefundPayment("txn12345"); // Simulates refunding a credit card payment

            PaymentProcessor payPalProcessor = new PayPalProcessor(200, "USD", "user@example.com");
            payPalProcessor.AuthorizePayment(); // Simulates authorizing a PayPal payment
            payPalProcessor.ProcessPayment(); // Simulates processing a PayPal payment
            payPalProcessor.RefundPayment("txn67890"); // Simulates refunding a PayPal payment

            /* 
             * Demonstrating the use of the GameCharacter class and its derived classes.
             * We create instances of Warrior and Mage, and simulate a battle between them.
             * Each character type has specific properties, stats, and abilities.
             * 
             * OOP Principles:
             * - Abstraction: The GameCharacter class provides a simplified interface for character operations.
             * - Inheritance: Warrior and Mage inherit from the GameCharacter class and provide specific implementations.
             * - Polymorphism: We can use the GameCharacter type to refer to instances of Warrior and Mage.
             * 
             * SOLID Principles:
             * - Single Responsibility Principle: Each class has a single responsibility (e.g., Warrior handles warrior-specific abilities).
             * - Open/Closed Principle: The GameCharacter class is open for extension (through inheritance) but closed for modification.
             * - Liskov Substitution Principle: Instances of Warrior and Mage can be used interchangeably with the GameCharacter type.
             */
            var warrior = new Warrior("Conan", 1);
            var mage = new Mage("Gandalf", 1);

            // Battle simulation
            Console.WriteLine("Battle begins!");

            // Warrior uses special ability and attacks Mage
            warrior.UseSpecialAbility(); // Warrior uses a special ability to increase strength
            var warriorDamage = warrior.CalculateDamage("heavy"); // Calculates damage dealt by the warrior
            mage.TakeDamage(warriorDamage); // Mage takes damage from the warrior's attack

            // Mage uses special ability and attacks Warrior
            mage.UseSpecialAbility(); // Mage uses a special ability to cast a powerful spell
            var mageDamage = mage.CalculateDamage("arcane"); // Calculates damage dealt by the mage
            warrior.TakeDamage(mageDamage); // Warrior takes damage from the mage's attack

            // Level up both characters
            warrior.LevelUp(); // Warrior levels up, increasing stats and abilities
            mage.LevelUp(); // Mage levels up, increasing stats and abilities
        }
    }
}
