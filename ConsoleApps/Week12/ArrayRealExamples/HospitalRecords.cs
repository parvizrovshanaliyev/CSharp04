using System;
using System.Linq;

namespace ArrayRealExamples
{
    /// <summary>
    /// Represents a patient with Name, Age, and Temperature properties.
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// Gets or sets the name of the patient.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the age of the patient.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the temperature of the patient.
        /// </summary>
        public double Temperature { get; set; }
    }

    /// <summary>
    /// Manages hospital patient records.
    /// </summary>
    public class HospitalRecords
    {

        /// <summary>
        /// Manages the list of patients, identifies fever cases, sorts patients by temperature,
        /// and finds a patient by name.
        /// </summary>
        public static void ManagePatients()
        {
            // Initialize an array of patients
            Patient[] patients = new Patient[]
            {
            new Patient { Name = "John", Age = 30, Temperature = 36.5 },
            new Patient { Name = "Jane", Age = 25, Temperature = 38.2 },
            new Patient { Name = "Doe", Age = 40, Temperature = 37.0 }
            };

            // Identify fever cases
            IdentifyFeverCases(patients);

            // Sort patients by temperature
            SortPatientsByTemperature(patients);

            // Display patients sorted by temperature
            DisplayPatients(patients);

            // Find a patient by name
            string searchName = "Jane";
            FindPatientByName(patients, searchName);
        }

        /// <summary>
        /// Identifies and displays patients with a temperature greater than 37.5°C.
        /// </summary>
        /// <param name="patients">Array of patients.</param>
        private static void IdentifyFeverCases(Patient[] patients)
        {
            Console.WriteLine("Fever cases:");
            for (int i = 0; i < patients.Length; i++)
            {
            if (patients[i].Temperature > 37.5)
            {
                Console.WriteLine($"{patients[i].Name}: {patients[i].Temperature}°C");
            }
            }
        }

        /// <summary>
        /// Sorts the patients by their temperature using the Selection Sort algorithm.
        /// </summary>
        /// <param name="patients">Array of patients.</param>
        private static void SortPatientsByTemperature(Patient[] patients)
        {
            for (int i = 0; i < patients.Length - 1; i++)
            {
            for (int j = i + 1; j < patients.Length; j++)
            {
                if (patients[i].Temperature > patients[j].Temperature)
                {
                // Swap patients[i] and patients[j]
                Patient temp = patients[i];
                patients[i] = patients[j];
                patients[j] = temp;
                }
            }
            }
        }

        /// <summary>
        /// Displays the list of patients with their temperatures.
        /// </summary>
        /// <param name="patients">Array of patients.</param>
        private static void DisplayPatients(Patient[] patients)
        {
            Console.WriteLine("Patients sorted by temperature:");
            for (int i = 0; i < patients.Length; i++)
            {
            Console.WriteLine($"{patients[i].Name}: {patients[i].Temperature}°C");
            }
        }

        /// <summary>
        /// Finds and displays a patient by name using Linear Search.
        /// </summary>
        /// <param name="patients">Array of patients.</param>
        /// <param name="name">Name of the patient to find.</param>
        private static void FindPatientByName(Patient[] patients, string name)
        {
            Patient foundPatient = null;
            for (int i = 0; i < patients.Length; i++)
            {
            if (patients[i].Name == name)
            {
                foundPatient = patients[i];
                break;
            }
            }

            // Display the search result
            if (foundPatient != null)
            {
            Console.WriteLine($"Found {name}: {foundPatient.Temperature}°C");
            }
            else
            {
            Console.WriteLine($"{name} not found.");
            }
        }
    }
}
