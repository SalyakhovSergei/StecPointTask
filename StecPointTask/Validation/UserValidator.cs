using FluentValidation;
using StacPointTask.BL.Models;

namespace StecPointTask.Validation
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(e => e.FirstName).NotEmpty().WithMessage("Не указано имя пользователя");
            RuleFor(e => e.LastName).NotEmpty().WithMessage("Не указана фамилия пользователя");
            RuleFor(e => e.Email).NotEmpty().WithMessage("Не указан e-mail пользователя");
            RuleFor(e => e.PhoneNumber).NotEmpty().WithMessage("Не указан номер телефона");
        }
    }
}