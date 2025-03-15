namespace Practice.Helpers;

/// <summary>
/// Manages application configuration settings.
/// </summary>
public static class ConfigManager
{
    public static readonly string ApplicationName = "MyApp";
    public static readonly string Version = "1.0.0";

    /// <summary>
    /// Simulates reloading configuration settings.
    /// Example:
    /// <code>
    /// ConfigManager.Reload();
    /// // Output: Configuration reloaded successfully.
    /// </code>
    /// </summary>
    public static void Reload()
    {
        Console.WriteLine("Configuration reloaded successfully.");
    }
}