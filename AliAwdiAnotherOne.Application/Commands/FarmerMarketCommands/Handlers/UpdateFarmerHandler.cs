
using AliAwdiAnotherOne.Shared.Abstractions.Application.Commands;
using AliAwdiAnotherOne.Application.DTOs;
using AliAwdiAnotherOne.Shared;
using AliAwdiAnotherOne.Domain.Entities;
using AliAwdiAnotherOne.Application.Repositories;
using Mapster;
namespace AliAwdiAnotherOne.Application.Commands.FarmerMarketCommands.Handlers
{
    internal class UpdateFarmerHandler : ICommandHandler<UpdateFarmerMarket, FarmerDto>
    {
        private readonly IFarmerMarketRepo _farmer;

        public UpdateFarmerHandler(IFarmerMarketRepo farmer)
        {
            _farmer = farmer;
        }

        public async Task<Response<FarmerDto>> Handle(UpdateFarmerMarket request, CancellationToken cancellationToken)
        {
            var (id, name, quantity) = request;
            FarmerMarket farmermarket = new(name, quantity);
            var updatedFarmer = await _farmer.UpdateAsync(farmermarket, cancellationToken);
            /*var user = await _farmer.GetWholeByIdAsync(id, cancellationToken);

            var newPosts = new List<FarmerMarket>();

            foreach (var postId in postIds)
                newPosts.Add(await _posts.GetByIdAsync(postId, cancellationToken));

            user.UpdateUsername(username);
            user.UpdateEmail(email);
            user.UpdatePosts(newPosts);

            var updatedUser = await _users.UpdateAsync(user, cancellationToken);*/

            return Response.Success(updatedFarmer.Adapt<FarmerMarket, FarmerDto>(), "Updated user " + updatedFarmer.Name + updatedFarmer.Quantity);
        }
    }
}
