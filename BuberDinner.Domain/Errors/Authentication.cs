using ErrorOr;

namespace BuberDinner.Domain.Errors
{
    public static partial class Errors
    {
        public class Authentication
        {
            public static Error InvalidCredentials => Error.Custom(
                type: 401,
                code: "Authentication.InvalidCredentials",
                description: "Invalid Credentials");
        }
    }
}
