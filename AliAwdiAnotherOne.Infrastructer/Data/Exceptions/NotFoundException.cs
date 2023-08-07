using AliAwdiAnotherOne.Shared.Abstractions.Common;

namespace AliAwdiAnotherOne.Infrastructure.Data.Exceptions
{
    public class NotFoundException : ALiAwdiAnotherOneException
    {
        public NotFoundException(string typeName, int id) : base("No " + typeName + " with Id " + id + " was found.") { }
    }
}
