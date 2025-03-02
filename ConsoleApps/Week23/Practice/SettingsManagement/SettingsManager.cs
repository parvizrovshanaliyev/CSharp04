using System;

/// <summary>
/// Represents a single setting with a name and value.
/// </summary>
public class Setting
{
    /// <summary>
    /// The name of the setting (e.g., "UserName", "DisplayMode").
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The value associated with the setting.
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Setting"/> class.
    /// </summary>
    /// <param name="name">The name of the setting.</param>
    /// <param name="value">The default value of the setting.</param>
    public Setting(string name, string value)
    {
        Name = name;
        Value = value;
    }
}

/// <summary>
/// Manages application settings, including user preferences such as username, display mode, and sound settings.
/// </summary>
public sealed class SettingsManager
{
    /// <summary>
    /// Array to store multiple settings.
    /// </summary>
    private readonly Setting[] settings;

    /// <summary>
    /// Initializes a new instance of the <see cref="SettingsManager"/> class and loads default settings.
    /// </summary>
    public SettingsManager()
    {
        settings = new Setting[]
        {
            new Setting("UserName", "Guest"),
            new Setting("DisplayMode", "Light"),
            new Setting("Sound", "On")
        };
        Console.WriteLine("Default settings loaded.");
    }

    /// <summary>
    /// Updates a specific setting if it exists.
    /// </summary>
    /// <param name="key">The name of the setting to update.</param>
    /// <param name="value">The new value for the setting.</param>
    public void UpdateSetting(string key, string value)
    {
        foreach (var setting in settings)
        {
            if (setting.Name.Equals(key, StringComparison.OrdinalIgnoreCase))
            {
                setting.Value = value;
                Console.WriteLine($"Setting updated: {key} = {value}");
                return;
            }
        }
        Console.WriteLine($"Invalid setting: {key}");
    }

    /// <summary>
    /// Retrieves the value of a specific setting.
    /// </summary>
    /// <param name="key">The name of the setting to retrieve.</param>
    /// <returns>The value of the specified setting, or null if not found.</returns>
    public string GetSetting(string key)
    {
        foreach (var setting in settings)
        {
            if (setting.Name.Equals(key, StringComparison.OrdinalIgnoreCase))
            {
                return setting.Value;
            }
        }
        Console.WriteLine($"Setting not found: {key}");
        return null;
    }

    /// <summary>
    /// Displays all current settings in a structured format.
    /// </summary>
    public void DisplaySettings()
    {
        Console.WriteLine("Current Settings:");
        foreach (var setting in settings)
        {
            Console.WriteLine($" - {setting.Name}: {setting.Value}");
        }
    }

    /// <summary>
    /// Resets all settings back to their default values.
    /// </summary>
    public void ResetToDefaults()
    {
        settings[0].Value = "Guest";
        settings[1].Value = "Light";
        settings[2].Value = "On";
        Console.WriteLine("Settings reset to defaults.");
    }
}
