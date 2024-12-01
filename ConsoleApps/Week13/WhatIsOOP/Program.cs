using System;

namespace WhatIsOOP;

internal class Program
{
    static void Main(string[] args)
    {
        /*
        Introduction to Object-Oriented Programming (OOP) in C#:
        - In this example, you'll learn how to define and use classes and objects, which are core concepts of OOP.
        - We will create a class called 'Person' with properties like Name, Age, and Job.
        - Two objects of the 'Person' class will be created, each with unique data.
        - The objects will display their details using a method.

        Purpose:
        - Understand how to structure code using classes and objects.
        - Learn how to initialize objects with a constructor.
        - See how to access and use object properties and methods in C#.
        */

        // Creating two Person objects with different values
        Person person1 = new Person("Alice", 25, "Engineer"); // Creating the first object
        Person person2 = new Person("Bob", 30, "Teacher");    // Creating the second object

        // Calling the DisplayPersonInfo method to print details of each object
        person1.DisplayPersonInfo();
        person2.DisplayPersonInfo();
    }
}

/*
Class Definition: Person

- A class is a blueprint for creating objects. It defines the data (properties) and actions (methods) that an object can have.
- The Person class represents a person with three properties: Name, Age, and Job.
- A constructor is used to initialize these properties when a new object is created.
- The class also includes a method to display the details of a person.

Purpose of the class:
- To represent a person with their basic details and actions.
- To demonstrate how data can be organized using properties and how behavior can be added using methods.
*/

class Person
{
    // Properties: Define the data that each Person object will hold
    public string Name { get; set; }  // Stores the person's name
    public int Age { get; set; }      // Stores the person's age
    public string Job { get; set; }   // Stores the person's job

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