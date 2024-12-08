namespace WhatIsOOP;

/// <summary>
/// 
/// Class Definition: Person
/// 
/// - A class is a blueprint for creating objects. It defines the data (properties) and actions (methods) that an object can have.
/// - The Person class represents a person with three properties: Name, Age, and Job.
/// - A constructor is used to initialize these properties when a new object is created.
/// - The class also includes a method to display the details of a person.
/// 
/// Purpose of the class:
/// - To represent a person with their basic details and actions.
/// - To demonstrate how data can be organized using properties and how behavior can be added using methods.
/// 
/// </summary>
public class Person
{
    // Properties: Define the data that each Person object will hold
    public string Name { get; set; }  // Stores the person's name
    public int Age { get; set; }      // Stores the person's age
    public string Job { get; set; }   // Stores the person's job

    public Person()
    {
        Console.Write("new instance");
    }

    /*
    Constructor:
    - Automatically called when an object is created.
    - Used to set initial values for the properties.
    - Helps ensure every object starts with meaningful data.
    */
    public Person(string name, int age, string job)
    {
        // Initializing the properties with values passed to the constructor
        Name = name;
        Age = age;
        Job = job;
    }

    /*
    Method: DisplayPersonInfo
    - A method defines an action that an object can perform.
    - In this case, it prints the Name, Age, and Job of the person.
    - This method demonstrates how to access object properties and display them in a formatted way.
    */
    public void DisplayPersonInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Job: {Job}");
    }
}