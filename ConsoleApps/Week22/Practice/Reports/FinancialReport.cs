namespace Practice.Reports;

/// <summary>
/// Represents a financial report.
/// </summary>
public class FinancialReport : Report
{
    public override string ReportType { get; set; } = "Financial";
    public override string Timeframe { get; set; }
    public override string FormatPreference { get; set; }
    private MetricData[] Data;

    /// <summary>
    /// Initializes a new instance of the <see cref="FinancialReport"/> class.
    /// </summary>
    /// <param name="timeframe">The timeframe of the report.</param>
    /// <param name="format">The format preference of the report.</param>
    public FinancialReport(string timeframe, string format)
    {
        Timeframe = timeframe ?? throw new ArgumentNullException(nameof(timeframe));
        FormatPreference = format ?? throw new ArgumentNullException(nameof(format));
    }

    /// <summary>
    /// Gathers the financial data for the report.
    /// </summary>
    public override void GatherData()
    {
        Console.WriteLine("Gathering financial data...");
        Data = new MetricData[]
        {
            new MetricData("Total Revenue", 1250000, "USD"),
            new MetricData("Net Profit", 300000, "USD"),
            new MetricData("Operating Expenses", 450000, "USD"),
            new MetricData("Gross Margin", 40, "%"),
            new MetricData("Cash Flow", 200000, "USD")
        };
    }

    /// <summary>
    /// Processes the financial metrics for the report.
    /// </summary>
    public override void ProcessData()
    {
        Console.WriteLine("Processing financial metrics...");
        DisplayMetrics();
    }

    /// <summary>
    /// Generates the financial report.
    /// </summary>
    public override void GenerateReport()
    {
        Console.WriteLine("Generating financial report...");
        Console.WriteLine("Financial Data Summary:");
        DisplayMetrics();
    }

    /// <summary>
    /// Displays the financial metrics.
    /// </summary>
    private void DisplayMetrics()
    {
        foreach (var metric in Data)
        {
            Console.WriteLine($" - {metric.Name}: {metric.Value} {metric.Unit}");
        }
    }

    /// <summary>
    /// Exports the financial report to the specified format.
    /// </summary>
    /// <param name="format">The format to export the report to.</param>
    public override void ExportReport(string format)
    {
        if (string.IsNullOrWhiteSpace(format))
        {
            throw new ArgumentException("Format cannot be null or empty.", nameof(format));
        }
        Console.WriteLine($"Exporting financial report to {format}...");
    }
}
