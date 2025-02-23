using Practice.Reports;

/// <summary>
/// Represents an analytics report that gathers, processes, and generates analytics data.
/// </summary>
public class AnalyticsReport : Report
{
    public override string ReportType { get; set; } = "Analytics";
    public override string Timeframe { get; set; }
    public override string FormatPreference { get; set; }
    private readonly UserActivity[] UserActivities;
    private MetricData[] Data;

    /// <summary>
    /// Initializes a new instance of the <see cref="AnalyticsReport"/> class.
    /// </summary>
    /// <param name="timeframe">The timeframe of the analytics report.</param>
    /// <param name="format">The preferred format of the report.</param>
    public AnalyticsReport(string timeframe, string format)
    {
        Timeframe = timeframe ?? throw new ArgumentNullException(nameof(timeframe));
        FormatPreference = format ?? throw new ArgumentNullException(nameof(format));
        UserActivities = new UserActivity[]
        {
            new("Alice", "Login", DateTime.Now.AddMinutes(-30)),
            new("Bob", "Purchase", DateTime.Now.AddMinutes(-25)),
            new("Charlie", "Logout", DateTime.Now.AddMinutes(-20)),
            new("Alice", "Page View", DateTime.Now.AddMinutes(-15)),
            new("Bob", "Add to Cart", DateTime.Now.AddMinutes(-10))
        };
    }

    /// <summary>
    /// Gathers the analytics data based on user activities.
    /// </summary>
    public override void GatherData()
    {
        Console.WriteLine("Gathering analytics data from user activities...");
        Data = new MetricData[]
        {
            new("Active Users", UserActivities.Length, "users"),
            new("Average Session Duration", UserActivities.Average(a => (DateTime.Now - a.Timestamp).TotalMinutes), "minutes"),
            new("Most Frequent Activity", UserActivities.GroupBy(a => a.ActivityType).OrderByDescending(g => g.Count()).First().Key, "occurrences")
        };
    }

    /// <summary>
    /// Processes the gathered analytics data.
    /// </summary>
    public override void ProcessData()
    {
        Console.WriteLine("Processing user activity analytics...");
        DisplayMetrics();
    }

    /// <summary>
    /// Generates the analytics report based on user activities.
    /// </summary>
    public override void GenerateReport()
    {
        Console.WriteLine("Generating analytics report based on user activity logs...");
        Console.WriteLine("User Activity Details:");
        foreach (var activity in UserActivities)
        {
            Console.WriteLine($" - {activity.Username}: {activity.ActivityType} at {activity.Timestamp}");
        }
        Console.WriteLine("Summary Data:");
        DisplayMetrics();
    }

    /// <summary>
    /// Displays the analytics metrics.
    /// </summary>
    private void DisplayMetrics()
    {
        foreach (var metric in Data)
        {
            Console.WriteLine($" - {metric.Name}: {metric.Value} {metric.Unit}");
        }
    }

    /// <summary>
    /// Exports the analytics report to the specified format.
    /// </summary>
    /// <param name="format">The format in which to export the report.</param>
    public override void ExportReport(string format)
    {
        if (string.IsNullOrWhiteSpace(format))
        {
            throw new ArgumentException("Format cannot be null or empty.", nameof(format));
        }
        Console.WriteLine($"Exporting analytics report to {format}...");
    }
}

/// <summary>
/// Represents user activity data for analytics tracking.
/// </summary>
public class UserActivity
{
    public string Username { get; set; }
    public string ActivityType { get; set; }
    public DateTime Timestamp { get; set; }

    public UserActivity(string username, string activityType, DateTime timestamp)
    {
        Username = username ?? throw new ArgumentNullException(nameof(username));
        ActivityType = activityType ?? throw new ArgumentNullException(nameof(activityType));
        Timestamp = timestamp;
    }
}
