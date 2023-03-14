#region UsingAndNamespace

using Application.Common.Messages;
using Application.Dto.Account;
using Application.Dto.User;
using Application.IContracts.IServices;
using AutoMapper;
using Domain.Enums;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Account.Commands.UserRegister;
#endregion
public class UserRegisterCommandHandler:IRequestHandler<UserRegisterCommand,UserAuthorizeDto>
{
    #region CtorAndInjection
    private readonly IMapper _mapper;
    private readonly UserManager<Domain.Entities.IdentityEntity.User> _userManager;
    private readonly ITokenService _tokenService;
    public UserRegisterCommandHandler(UserManager<Domain.Entities.IdentityEntity.User> userManager, IMapper mapper, ITokenService tokenService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _tokenService = tokenService;
    }
    #endregion
    public async Task<UserAuthorizeDto> Handle(UserRegisterCommand req, CancellationToken cancellationToken)
    {
        var checkUser = await _userManager.Users.AnyAsync(x => x.PhoneNumber == req.PhoneNumber,cancellationToken);
        if (checkUser) throw new BadRequestEntityException(ApplicationMessages.UserDuplicate);

        var user = _mapper.Map<Domain.Entities.IdentityEntity.User>(req);
        user.UserName = req.Username;
        var checkAddUser =await _userManager.CreateAsync(user, req.Password);
        if (!checkAddUser.Succeeded) throw new BadRequestEntityException(ApplicationMessages.UserFailedAdd);

        var roleAddCheck= await _userManager.AddToRoleAsync(user, RoleType.User.ToString());
        if (!roleAddCheck.Succeeded) throw new BadRequestEntityException(roleAddCheck.Errors.FirstOrDefault()?.Description);

        var userAuthorizeDto= _mapper.Map<UserAuthorizeDto>(user);
        userAuthorizeDto.Token =await _tokenService.CreateToken(user);
        return userAuthorizeDto;
    }
}