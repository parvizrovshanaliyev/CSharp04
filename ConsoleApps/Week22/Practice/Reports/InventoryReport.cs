namespace Practice.Reports;

/// <summary>
/// Represents an inventory report.
/// </summary>
public class InventoryReport : Report
{
    public override string ReportType { get; set; } = "Inventory";
    public override string Timeframe { get; set; }
    public override string FormatPreference { get; set; }
    private  MetricData[] Data;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryReport"/> class with the specified timeframe and format.
    /// </summary>
    /// <param name="timeframe">The timeframe for the report.</param>
    /// <param name="format">The format preference for the report.</param>
    public InventoryReport(string timeframe, string format)
    {
        Timeframe = timeframe ?? throw new ArgumentNullException(nameof(timeframe));
        FormatPreference = format ?? throw new ArgumentNullException(nameof(format));
    }

    /// <summary>
    /// Gathers the data for the inventory report.
    /// </summary>
    public override void GatherData()
    {
        Console.WriteLine("Gathering inventory data...");
        Data = new MetricData[]
        {
            new MetricData("Total Stock Items", 1200, "units"),
            new MetricData("Low Stock Items", 150, "units"),
            new MetricData("Reorder Level", 200, "units"),
            new MetricData("Stock Turnover Rate", 5.3, "times per year"),
            new MetricData("Warehouse Utilization", 75, "%")
        };
    }

    /// <summary>
    /// Processes the gathered inventory data.
    /// </summary>
    public override void ProcessData()
    {
        Console.WriteLine("Processing inventory levels and turnover...");
        DisplayMetrics();
    }

    /// <summary>
    /// Generates the inventory report.
    /// </summary>
    public override void GenerateReport()
    {
        Console.WriteLine("Generating inventory status report...");
        Console.WriteLine("Inventory Data Summary:");
        DisplayMetrics();
    }

    /// <summary>
    /// Displays the inventory metrics.
    /// </summary>
    private void DisplayMetrics()
    {
        foreach (var metric in Data)
        {
            Console.WriteLine($" - {metric.Name}: {metric.Value} {metric.Unit}");
        }
    }

    /// <summary>
    /// Exports the inventory report to the specified format.
    /// </summary>
    /// <param name="format">The format to export the report to.</param>
    public override void ExportReport(string format)
    {
        if (string.IsNullOrWhiteSpace(format))
        {
            throw new ArgumentException("Format cannot be null or empty.", nameof(format));
        }
        Console.WriteLine($"Exporting inventory report to {format}...");
    }
}