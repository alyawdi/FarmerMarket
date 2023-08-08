using FluentValidation;
using AliAwdiAnotherOne.Domain.Entities;
using System.Runtime.InteropServices;
using AliAwdiAnotherOne.Application.Commands.FarmerMarketCommands;

namespace AliAwdiAnotherOne.Application.Commands.FarmerMarketCommands.Handlers.FarmerValidation
{
    public class MarketValidation : AbstractValidator<FarmerMarket>
    {
        public MarketValidation()
        {

            RuleFor(fm => fm.Name).NotEmpty().WithMessage("Name can't be empty");
            var quantityValidation = RuleFor(fm => fm.Quantity);
            quantityValidation.NotNull().WithMessage("quantity can't be empty");
            quantityValidation.LessThanOrEqualTo(0).WithMessage("quantity can't be zero or negative");

        }
    }
}
