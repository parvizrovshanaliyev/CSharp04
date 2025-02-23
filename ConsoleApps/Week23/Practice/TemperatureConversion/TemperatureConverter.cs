using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.TemperatureConversion;

/// <summary>
/// Provides methods to convert temperatures between different scales.
/// This class is marked as <c>sealed</c> to prevent inheritance, ensuring that the conversion logic remains consistent and unaltered.
/// Sealing the class ensures that no derived class can modify the formulae or introduce unexpected behavior.
/// </summary>
public sealed class TemperatureConverter
{
    /// <summary>
    /// Converts temperature from Celsius to Fahrenheit.
    /// </summary>
    /// <param name="celsius">Temperature in Celsius.</param>
    /// <returns>Equivalent temperature in Fahrenheit.</returns>
    public static double CelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    /// <summary>
    /// Converts temperature from Fahrenheit to Celsius.
    /// </summary>
    /// <param name="fahrenheit">Temperature in Fahrenheit.</param>
    /// <returns>Equivalent temperature in Celsius.</returns>
    public static double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    /// <summary>
    /// Converts temperature from Celsius to Kelvin.
    /// </summary>
    /// <param name="celsius">Temperature in Celsius.</param>
    /// <returns>Equivalent temperature in Kelvin.</returns>
    public static double CelsiusToKelvin(double celsius)
    {
        return celsius + 273.15;
    }

    /// <summary>
    /// Converts temperature from Kelvin to Celsius.
    /// </summary>
    /// <param name="kelvin">Temperature in Kelvin.</param>
    /// <returns>Equivalent temperature in Celsius.</returns>
    /// <exception cref="ArgumentException">Thrown when the Kelvin value is negative.</exception>
    public static double KelvinToCelsius(double kelvin)
    {
        if (kelvin < 0)
            throw new ArgumentException("Kelvin temperature cannot be negative.");
        return kelvin - 273.15;
    }
}