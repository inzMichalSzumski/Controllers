namespace Controllers.Services;

public class FakeAuthService : IAuthService
{
    public bool ValidateCredentials(string email, string password)
    {
        // Fake validation - simulates database or external IdP check
        return email == "test@example.com" && password == "password123";
    }
}