namespace Core.Exceptions
{
    public class InvalidSignInException : Exception
    {
        public InvalidSignInException(string message = "Invalid username or password.") : base(message)
        {
        }
    }
}
