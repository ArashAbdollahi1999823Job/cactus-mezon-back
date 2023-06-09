using Application.Common.Messages;
using Application.Dto.Identity;
using Application.Dto.Sms;
using Application.IContracts.IServices;
using AutoMapper;
using Domain.Enums;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mpNuget;

namespace Application.Features.Account.Commands.UserRegister;
public class UserRegisterCommandHandler:IRequestHandler<UserRegisterCommand,RegisterReturnDto>
{
    #region CtorAndInjection
    private readonly UserManager<Domain.Entities.IdentityEntity.User> _userManager;
    private readonly ISmsService _smsService;
    public UserRegisterCommandHandler(UserManager<Domain.Entities.IdentityEntity.User> userManager, ISmsService smsService)
    {
        _userManager = userManager;
        _smsService = smsService;
    }
    #endregion
    public async Task<RegisterReturnDto> Handle(UserRegisterCommand req, CancellationToken cancellationToken)
    {
        var checkUser = await _userManager.Users.AnyAsync(x => x.PhoneNumber == req.PhoneNumber,cancellationToken);
        if (checkUser) throw new BadRequestEntityException(ApplicationMessages.UserDuplicate);
        var random = new Random();
        var user = new Domain.Entities.IdentityEntity.User
        {
            UserName = req.PhoneNumber,
            Code = random.Next(100000, 999999).ToString(),
            Name = req.Name,
            PhoneNumber = req.PhoneNumber,
            Password = req.Password
        };

        var checkAddUser =await _userManager.CreateAsync(user, req.Password);
        if (!checkAddUser.Succeeded) throw new BadRequestEntityException(ApplicationMessages.UserFailedAdd);

        var roleAddCheck= await _userManager.AddToRoleAsync(user, RoleType.User.ToString());
        if (!roleAddCheck.Succeeded) throw new BadRequestEntityException(roleAddCheck.Errors.FirstOrDefault()?.Description);

        var authSmsDto = new AuthSmsDto(user.PhoneNumber, user.Code);
        await _smsService.AuthSmsSendAsync(authSmsDto);

        return new RegisterReturnDto(){PhoneNumber = user.PhoneNumber};

    }
}