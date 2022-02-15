namespace libIinBin.Exception
{
    public class InvalidIdentifierException : System.Exception
    {
        public InvalidIdentifierException() { }
        public InvalidIdentifierException(string message) : base(message) 
        {
        }
    }
}