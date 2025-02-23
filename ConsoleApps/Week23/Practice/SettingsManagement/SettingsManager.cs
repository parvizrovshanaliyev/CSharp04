using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.SettingsManagement;

/// <summary>
/// Manages application settings, including user preferences such as username, display mode, and sound settings.
/// This class ensures settings persistence and allows modifications, resets, and retrievals.
/// </summary>
public sealed class SettingsManager
{
    /// <summary>
    /// Array to store setting names.
    /// </summary>
    private string[] settingNames = { "UserName", "DisplayMode", "Sound" };

    /// <summary>
    /// Array to store setting values.
    /// </summary>
    private string[] settingValues = new string[3];

    /// <summary>
    /// Initializes a new instance of the <see cref="SettingsManager"/> class and loads default settings.
    /// </summary>
    public SettingsManager()
    {
        LoadDefaultSettings();
    }

    /// <summary>
    /// Loads default settings into the settings arrays.
    /// This ensures that the application starts with predefined values.
    /// </summary>
    private void LoadDefaultSettings()
    {
        settingValues[0] = "Guest";
        settingValues[1] = "Light";
        settingValues[2] = "On";
        Console.WriteLine("Default settings loaded.");
    }

    /// <summary>
    /// Updates a specific setting if the name exists.
    /// </summary>
    /// <param name="key">The name of the setting to update.</param>
    /// <param name="value">The new value for the setting.</param>
    public void UpdateSetting(string key, string value)
    {
        for (int i = 0; i < settingNames.Length; i++)
        {
            if (settingNames[i] == key)
            {
                settingValues[i] = value;
                Console.WriteLine($"Setting updated: {key} = {value}");
                return;
            }
        }
        Console.WriteLine($"Invalid setting: {key}");
    }

    /// <summary>
    /// Displays all current settings in a structured format.
    /// </summary>
    public void DisplaySettings()
    {
        Console.WriteLine("Current Settings:");
        for (int i = 0; i < settingNames.Length; i++)
        {
            Console.WriteLine($" - {settingNames[i]}: {settingValues[i]}");
        }
    }

    /// <summary>
    /// Resets all settings back to their default values.
    /// This allows users to revert changes and restore the initial configuration.
    /// </summary>
    public void ResetToDefaults()
    {
        LoadDefaultSettings();
        Console.WriteLine("Settings reset to defaults.");
    }
}
