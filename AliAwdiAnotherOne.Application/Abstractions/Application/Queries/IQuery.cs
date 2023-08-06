using MediatR;

namespace AliAwdiAnotherOne.Shared.Abstractions.Application.Queries
{
    public interface IQuery<TOut> : IRequest<TOut> { }
}
