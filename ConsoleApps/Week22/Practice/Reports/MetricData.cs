
/// <summary>
/// Represents a metric data point in an analytics report.
/// </summary>
public class MetricData
{
    public string Name { get; set; }
    public object Value { get; set; }
    public string Unit { get; set; }

    public MetricData(string name, object value, string unit)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Value = value ?? throw new ArgumentNullException(nameof(value));
        Unit = unit ?? throw new ArgumentNullException(nameof(unit));
    }
}