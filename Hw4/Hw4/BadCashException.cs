namespace Hw4
{
    internal class BadCashException : Exception
    {
        public BadCashException() : base("Bad cash received.") { }
    }
}
