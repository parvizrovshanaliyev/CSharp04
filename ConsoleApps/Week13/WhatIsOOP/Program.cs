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
        Person person2 = new Person("Bob", 30, "Teacher");    // Creating the second object\

        Person person3 = new Person();

        person3.Name = "Ceyhun";
        person3.Age = 23;
        person3.Job = "developer";

        string name = "Ceyhun";

        // Calling the DisplayPersonInfo method to print details of each object
        person1.DisplayPersonInfo();
        person2.DisplayPersonInfo();
        person3.DisplayPersonInfo();

        int number1 = 1;
        int number2 = 2;
        int number3 = 3;

        int[] numbers = { 1, 2, 3 };

        string name1 = "A";
        int age1 = 2;
        string job1 = "A";



    }
}

