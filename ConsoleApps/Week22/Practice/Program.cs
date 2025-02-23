using Practice.Documents;
using Practice.Notifications;
using Practice.Payments;
using Practice.Reports;

namespace Practice
{

    /// <summary>
    /// The main Program class that serves as the entry point for the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">Command line arguments passed to the program.</param>
        /// <returns>
        /// 0 if the program executes successfully,
        /// non-zero value if an error occurs during execution.
        /// </returns>
        public static int Main(string[] args)
        {
            RunDocumentsTest();
            Console.WriteLine(new string('-', 50));
            RunPaymentsTest();
            Console.WriteLine(new string('-', 50));
            RunNotificationsTest();
            Console.WriteLine(new string('-', 50));
            RunReportsTest();
            return 0;
        }

        private static void RunDocumentsTest()
        {
            Console.WriteLine("--- Document Tests ---");
            Document[] documents = new Document[]
            {
                new PDFDocument("C# Abstracts", "John Doe"),
                new WordDocument("Project Specs", "Jane Smith"),
                new SpreadsheetDocument("Q1 Data", "Bob Wilson")
            };

            foreach (var doc in documents)
            {
                doc.DisplayMetadata();
                doc.Convert("PDF");
                Console.WriteLine(new string('-', 30));
            }
        }

        private static void RunPaymentsTest()
        {
            Console.WriteLine("--- Payment Tests ---");
            PaymentMethod[] payments = {
            new CreditCardPayment("1234567890123456", 123),
            new PayPalPayment("user@example.com"),
            new CryptoCurrencyPayment("0x742d35Cc6634C0532925a3b844Bc454e4438f44e")
        };

            foreach (var payment in payments)
            {
                payment.ProcessPayment(100);
                Console.WriteLine(payment.GenerateReceipt());
                Console.WriteLine(new string('-', 30));
            }
        }

        private static void RunNotificationsTest()
        {
            Console.WriteLine("--- Notification Tests ---");
            NotificationSender[] notifications = {
            new EmailNotification("test@example.com"),
            new SMSNotification("1234567890"),
            new PushNotification("device_token_123")
        };

            foreach (var notification in notifications)
            {
                notification.Send();
                Console.WriteLine(notification.GetDeliveryStatus());
                Console.WriteLine(new string('-', 30));
            }
        }

        private static void RunReportsTest()
        {
            Console.WriteLine("--- Report Tests ---");
            Report[] reports = {
            new FinancialReport("Q1 2025", "PDF"),
            new AnalyticsReport("2024", "Excel"),
            new InventoryReport("Current", "CSV")
        };

            foreach (var report in reports)
            {
                report.GatherData();
                report.ProcessData();
                report.GenerateReport();
                report.ExportReport(report.FormatPreference);
                Console.WriteLine(new string('-', 30));
            }
        }
    }
}