using AliAwdiAnotherOne.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliAwdiAnotherOne.Shared.Abstractions.Application.Commands;
using AliAwdiAnotherOne.Application.Commands.FarmerMarketCommands;

namespace AliAwdiAnotherOne.Application.Commands.PostCommands.Handlers
{
    internal class DeletePostHandler : ICommandHandler<DeleteFarmerMarket, Unit>
    {
        private readonly IPostRepository _posts;


        public DeletePostHandler(IPostRepository posts)
        {
            _posts = posts;
        }

        public async Task<Response<Unit>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _posts.GetByIdAsync(request.Id, cancellationToken);
            if (post.Tags is not null)
                foreach (var tag in post.Tags)
                    post.RemoveTag(tag);
            await _posts.UpdateAsync(post, cancellationToken);
            await _posts.DeleteAsync(request.Id, cancellationToken);
            return Response.Success(Unit.Value, "Deleted post");
        }
    }
}