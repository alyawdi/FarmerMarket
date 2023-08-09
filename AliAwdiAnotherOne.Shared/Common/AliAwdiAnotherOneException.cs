namespace AliAwdiAnotherOne.Shared.Abstractions.Common
{
    public abstract class AliAwdiAnotherOneException : Exception
    {
        public AliAwdiAnotherOneException(string message) : base(message) { }
    }
}
