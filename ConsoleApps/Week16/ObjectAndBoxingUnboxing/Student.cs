namespace ObjectAndBoxingUnboxing;

public class Student
{
    // Properties of the Student class
    public int StudentId { get; set; }
    public string Name { get; set; }

    /*
         * Override Equals:
         * This method defines logical equality for Student objects based on StudentId and Name.
         * It ensures that two students with the same ID and name are considered equal.
         */
    public override bool Equals(object obj)
    {
        // Check if the object is of type Student
        if (obj != null && obj.GetType() == typeof(Student))
        {
            Student otherStudent = (Student)obj; // Explicit casting after type check
            // Logical equality: Compare StudentId and Name
            return this.StudentId == otherStudent.StudentId &&
                   string.Equals(this.Name, otherStudent.Name, StringComparison.OrdinalIgnoreCase);
        }
        return false; // Return false if the object is not a Student
    }

    /*
         * Override GetHashCode:
         * This method ensures that logically equal objects produce the same hash code.
         * HashCode.Combine() is used to generate a consistent hash code based on StudentId and Name.
         */
    public override int GetHashCode()
    {
        return HashCode.Combine(StudentId, Name?.ToLowerInvariant());
    }

    /*
         * Override ToString:
         * Provides a meaningful string representation of the Student object.
         */
    public override string ToString()
    {
        return $"StudentId: {StudentId}, Name: {Name}";
    }
}