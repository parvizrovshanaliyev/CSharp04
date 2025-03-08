using System;
using System.Linq;

namespace ArrayRealExamples
{
    /// <summary>
    /// Represents weather data for a specific day.
    /// </summary>
    public class WeatherData
    {
        /// <summary>
        /// Gets or sets the day of the month.
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// Gets or sets the temperature for the day.
        /// </summary>
        public double Temperature { get; set; }
    }

    /// <summary>
    /// Manages weather data.
    /// </summary>
    public class WeatherStation
    {


        /// <summary>
        /// Manages and processes weather data.
        /// </summary>
        public static void ManageWeatherData()
        {
            WeatherData[] weatherData = new WeatherData[]
            {
            new WeatherData { Day = 1, Temperature = 22.5 },
            new WeatherData { Day = 2, Temperature = 25.3 },
            new WeatherData { Day = 3, Temperature = 20.1 },
            new WeatherData { Day = 4, Temperature = 18.7 },
            new WeatherData { Day = 5, Temperature = 21.4 },
            new WeatherData { Day = 6, Temperature = 23.9 },
            new WeatherData { Day = 7, Temperature = 19.8 }
            };

            WeatherData hottestDay = FindHottestDay(weatherData);
            WeatherData coldestDay = FindColdestDay(weatherData);
            double averageTemperature = CalculateAverageTemperature(weatherData);

            Console.WriteLine($"Hottest Day: Day {hottestDay.Day} - {hottestDay.Temperature}°C");
            Console.WriteLine($"Coldest Day: Day {coldestDay.Day} - {coldestDay.Temperature}°C");
            Console.WriteLine($"Average Temperature: {averageTemperature:F2}°C");

            SortWeatherDataByTemperature(weatherData);

            Console.WriteLine("Days sorted by temperature:");
            foreach (var data in weatherData)
            {
                Console.WriteLine($"Day {data.Day}: {data.Temperature}°C");
            }
        }

        /// <summary>
        /// Finds the hottest day from the weather data.
        /// </summary>
        /// <param name="weatherData">Array of weather data.</param>
        /// <returns>The hottest day.</returns>
        private static WeatherData FindHottestDay(WeatherData[] weatherData)
        {
            WeatherData hottestDay = weatherData[0];
            foreach (var data in weatherData)
            {
                if (data.Temperature > hottestDay.Temperature)
                {
                    hottestDay = data;
                }
            }
            return hottestDay;
        }

        /// <summary>
        /// Finds the coldest day from the weather data.
        /// </summary>
        /// <param name="weatherData">Array of weather data.</param>
        /// <returns>The coldest day.</returns>
        private static WeatherData FindColdestDay(WeatherData[] weatherData)
        {
            WeatherData coldestDay = weatherData[0];
            foreach (var data in weatherData)
            {
                if (data.Temperature < coldestDay.Temperature)
                {
                    coldestDay = data;
                }
            }
            return coldestDay;
        }

        /// <summary>
        /// Calculates the average temperature from the weather data.
        /// </summary>
        /// <param name="weatherData">Array of weather data.</param>
        /// <returns>The average temperature.</returns>
        private static double CalculateAverageTemperature(WeatherData[] weatherData)
        {
            double totalTemperature = 0;
            foreach (var data in weatherData)
            {
                totalTemperature += data.Temperature;
            }
            return totalTemperature / weatherData.Length;
        }

        /// <summary>
        /// Sorts the weather data by temperature in ascending order.
        /// </summary>
        /// <param name="weatherData">Array of weather data.</param>
        private static void SortWeatherDataByTemperature(WeatherData[] weatherData)
        {
            for (int i = 0; i < weatherData.Length - 1; i++)
            {
                for (int j = i + 1; j < weatherData.Length; j++)
                {
                    if (weatherData[i].Temperature > weatherData[j].Temperature)
                    {
                        WeatherData temp = weatherData[i];
                        weatherData[i] = weatherData[j];
                        weatherData[j] = temp;
                    }
                }
            }
        }
    }
}
