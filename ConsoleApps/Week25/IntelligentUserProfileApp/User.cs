namespace IntelligentUserProfileApp;

public class User
{
    public DateTime BirthDate { get; set; }
    public string Bio { get; set; }
    public int Age => BirthDate.GetAge();
}