namespace IntelligentUserProfileApp;

public interface IUserService
{
    User CreateProfile();
    void AnalyzeBio(User user);
    void DisplayProfile(User user);
}