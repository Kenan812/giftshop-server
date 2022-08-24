namespace Core.Constants
{
    public class RegexConstants
    {
        public const string EmailRegex = @"(([^<>()\[\]\\.,;:\s@""]+(\.[^<>()\[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";

        public const string PasswordRegex = @"^.{5,100}$";
    }
}
