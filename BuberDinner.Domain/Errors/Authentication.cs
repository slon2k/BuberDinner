using ErrorOr;

namespace BuberDinner.Domain.Errors
{
    public static partial class Errors
    {
        public class Authentication
        {
            public static Error InvalidCredentials => Error.Validation(
                code: "Authentication.DuplicateEmail",
                description: "Invalid Credentials");
        }
    }
}
