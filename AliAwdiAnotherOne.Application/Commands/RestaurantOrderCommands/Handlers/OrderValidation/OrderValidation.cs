using FluentValidation;
using AliAwdiAnotherOne.Domain.Entities;

namespace AliAwdiAnotherOne.Application.Commands.RestaurantOrderCommands.Handlers
{
    public class OrderValidation : AbstractValidator<RestaurantOrder>
    {
        public OrderValidation()
        {

            RuleFor(fm => fm.Name).NotEmpty().WithMessage("Name can't be empty");
            var quantityValidation = RuleFor(fm => fm.RequiredQuantity);
            quantityValidation.NotNull().WithMessage("quantity can't be empty");
            quantityValidation.LessThanOrEqualTo(0).WithMessage("quantity can't be zero or negative");

        }
    }
}
