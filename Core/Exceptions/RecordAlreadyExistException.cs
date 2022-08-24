namespace Core.Exceptions
{
    public class RecordAlreadyExistException : Exception
    {
        public RecordAlreadyExistException(string message = "Record already exist.") : base(message)
        {
        }
    }

}
