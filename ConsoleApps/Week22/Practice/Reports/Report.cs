namespace Practice.Reports;

/// <summary>
/// Abstract base class for generating various types of reports in the system.
/// </summary>
public abstract class Report
{
    /// <summary>
    /// Gets or sets the type of report being generated.
    /// </summary>
    public abstract string ReportType { get; set; }

    /// <summary>
    /// Gets or sets the timeframe covered by the report.
    /// </summary>
    public abstract string Timeframe { get; set; }

    /// <summary>
    /// Gets or sets the preferred output format for the report.
    /// </summary>
    public abstract string FormatPreference { get; set; }

    /// <summary>
    /// Collects the necessary data for the report.
    /// </summary>
    public abstract void GatherData();

    /// <summary>
    /// Processes the collected data into meaningful information.
    /// </summary>
    public abstract void ProcessData();

    /// <summary>
    /// Generates the final report based on the processed data.
    /// </summary>
    public abstract void GenerateReport();

    /// <summary>
    /// Exports the generated report in the specified format.
    /// </summary>
    /// <param name="format">The desired output format for the report.</param>
    public abstract void ExportReport(string format);
}
