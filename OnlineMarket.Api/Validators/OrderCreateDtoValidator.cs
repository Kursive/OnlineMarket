using FluentValidation;
using FluentValidation.Validators;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OnlineMarket.Application.DTOs.OrderDTOs;


namespace OnlineMarket.Api.Validators
{
    public class OrderCreateDtoValidator : AbstractValidator<OrderCreateDto>
    {
        public OrderCreateDtoValidator() 
        {
            RuleFor(n => n.Name)
              .NotEmpty().WithMessage("Имя не должно быть пустым")
              .MaximumLength(10)
              .MinimumLength(3).WithMessage("Имя должно иметь более 3 букв ");

            RuleFor(p => p.Product)
                .NotEmpty().WithMessage("Введите кол-во продуктов")
                .GreaterThan(0);
        }
    }
}
