namespace OOP.PartialClass;

public interface IAuthService
{
    void Register();
        
    void Logout();
    void ResetPassword();
    void ChangePassword();
    void VerifyEmail();
    void VerifyPhone();
    void VerifyTwoFactor();
    void VerifyCaptcha();
    void VerifyRecaptcha();

    /// <summary>
    /// UserName and Password
    /// </summary>
    void Login();
    /// <summary>
    ///  LoginWithFacebook
    /// </summary>
    void LoginWithFacebook();
    /// <summary>
    /// LoginWithGoogle
    /// </summary>
    void LoginWithGoogle();
}