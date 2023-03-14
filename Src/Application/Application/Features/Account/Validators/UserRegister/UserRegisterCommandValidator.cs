#region UsingAndNamespace
using Application.Common.Messages;
using Application.Features.Account.Commands.UserRegister;
using FluentValidation;
namespace Application.Features.Account.Validators.UserRegister;
#endregion
public class UserRegisterCommandValidator:AbstractValidator<UserRegisterCommand>
{
    public UserRegisterCommandValidator()
    {
        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage(ApplicationMessages.PleaseEnterPhone);
        RuleFor(x => x.Username).NotEmpty().WithMessage(ApplicationMessages.PleaseEnterUsername);
        RuleFor(x => x.Password).NotEmpty().WithMessage(ApplicationMessages.PleaseEnterPassword);
    }
}