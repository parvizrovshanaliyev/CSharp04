namespace Practice;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Student Class Demonstration ===");

        // Default student
        Student student1 = new Student();
        student1.DisplayDetails();

        // Custom student (name and age)
        Student student2 = new Student("Alice", 20);
        student2.DisplayDetails();

        // Fully custom student
        Student student3 = new Student("Bob", 22, 85, "Computer Science");
        student3.DisplayDetails();

        // Improving and reducing grades
        student3.ImproveGrade(10);
        student3.ReduceGrade(30);

        // Changing major
        student3.ChangeMajor("Data Science");

        // Display final details
        student3.DisplayDetails();
    }
}
