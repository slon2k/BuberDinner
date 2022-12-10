namespace BuberDinner.Application.Services.Authentication
{
    public record RegisterRequest(
        string firstName,
        string lastName,
        string email,
        string password
        );
    
    public record LoginRequest(
        string email,
        string password
        );

    public record AuthResponse(
        Guid id,
        string firstName,
        string lastName,
        string email,
        string token
        );  
}