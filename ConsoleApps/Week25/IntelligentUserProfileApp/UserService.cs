namespace IntelligentUserProfileApp;

public class UserService : IUserService
{
    public User CreateProfile()
    {
        DateTime birthDate;
        while (true)
        {
            Console.Write("Enter your birthdate (YYYY-MM-DD): ");
            if (DateTime.TryParse(Console.ReadLine(), out birthDate) && birthDate <= DateTime.Now)
                break;
            Console.WriteLine("Invalid format or future date. Try again.");
        }

        Console.Write("Enter a short bio about yourself: ");
        string bio = Console.ReadLine();

        var user = new User { BirthDate = birthDate, Bio = bio };
        AnalyzeBio(user);
        return user;
    }

    public void AnalyzeBio(User user)
    {
        Console.WriteLine($"Word count: {user.Bio.WordCount()}");
        Console.WriteLine($"Title Case: {user.Bio.ToTitleCase()}");
    }

    public void DisplayProfile(User user)
    {
        Console.WriteLine($"\nYour birthdate: {user.BirthDate:yyyy-MM-dd}");
        Console.WriteLine($"Your age: {user.Age}");
        Console.WriteLine($"Your bio: {user.Bio.ToTitleCase()}");
        Console.WriteLine($"Word count in bio: {user.Bio.WordCount()}");
    }
}