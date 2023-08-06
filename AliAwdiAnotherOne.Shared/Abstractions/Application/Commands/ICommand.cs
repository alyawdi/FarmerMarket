using AliAwdiAnotherOne.Shared;
using MediatR;

namespace AliAwdiAnotherOne.Shared.Abstractions.Application.Commands
{
    public interface ICommand<T> : IRequest<Response<T>> { }
}
