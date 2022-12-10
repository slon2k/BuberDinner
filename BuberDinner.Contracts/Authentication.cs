namespace BuberDinner.Contracts
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
        string firstName,
        string lastName,
        string email,
        string password,
        string token
        );      
}