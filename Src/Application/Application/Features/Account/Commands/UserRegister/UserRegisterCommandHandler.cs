using Application.Common.Messages;
using Application.Dto.Account;
using Application.Dto.Identity;
using Application.Dto.Sms;
using Application.IContracts.IRepository;
using Application.IContracts.IServices;
using AutoMapper;
using Domain.Entities.IdentityEntity;
using Domain.Enums;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mpNuget;
using Newtonsoft.Json;

namespace Application.Features.Account.Commands.UserRegister;

public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, RegisterReturnDto>
{
    #region CtorAndInjection

    private readonly UserManager<Domain.Entities.IdentityEntity.User> _userManager;
    private readonly ISmsService _smsService;
    private readonly IUserVerifyRepository _userVerifyRepository;

    public UserRegisterCommandHandler(UserManager<Domain.Entities.IdentityEntity.User> userManager,
        ISmsService smsService, IUserVerifyRepository userVerifyRepository)
    {
        _userManager = userManager;
        _smsService = smsService;
        _userVerifyRepository = userVerifyRepository;
    }

    #endregion

    public async Task<RegisterReturnDto> Handle(UserRegisterCommand req, CancellationToken cancellationToken)
    {
        var checkUser = await _userManager.Users.AnyAsync(x => x.PhoneNumber == req.PhoneNumber, cancellationToken);
        if (checkUser) throw new BadRequestEntityException(ApplicationMessages.UserDuplicate);

        var userVerify = new UserVerify(req.Name, req.Password, req.PhoneNumber, new Random().Next(100000, 999999).ToString());

        var check = await _userVerifyRepository.UserVerifyAdd(userVerify);

        var authSmsDto = new AuthSmsDto(userVerify.PhoneNumber, userVerify.Code);
        await _smsService.AuthSmsSendAsync(authSmsDto);

        return new RegisterReturnDto() { PhoneNumber = req.PhoneNumber };
    }
}