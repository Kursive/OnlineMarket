using FluentValidation;
using FluentValidation.Validators;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OnlineMarket.Application.DTOs.UserDTOs;


namespace OnlineMarket.Api.Validators
{
    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidator() 
        {
            RuleFor(n => n.Name)
            .NotEmpty().WithMessage("Имя не должно быть пустым ")
            .MaximumLength(10)
            .MinimumLength(4);


            RuleFor(e => e.Email)
             .NotEmpty().WithMessage("Почта не должна быть пустой")
             .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
             .MinimumLength(6).WithMessage("Почта введена неправильно");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Пароль не должен быть пустым")
                .MinimumLength(5).WithMessage("Пароль должен содержать более 5 символов")
                .MaximumLength(20).WithMessage("Пароль должен содержать менее 20 символов")
                .Matches("[A-Z]").WithMessage("Должна быть хотя бы одна заглавная буква")
                .Matches("[a-z]").WithMessage("Должна быть хотя бы одна строчная буква");
        }
    }
}
