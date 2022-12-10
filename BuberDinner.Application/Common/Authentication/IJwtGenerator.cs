namespace BuberDinner.Application.Common.Authentication
{
    public interface IJwtGenerator
    {
        string GenerateToken(Guid userId, string firstName, string lastName);
    }
}
