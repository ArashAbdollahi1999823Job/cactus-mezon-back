#region UsingAndNamespace
using Application.Common.Messages;
using Application.Dto.Account;
using Application.Dto.User;
using Application.IContracts.IBase;
using Application.IContracts.IServices;
using AutoMapper;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace Application.Features.Account.Commands.UserLogin;
#endregion
public class UserLoginCommandHandler:IRequestHandler<UserLoginCommand,UserAuthorizeDto>
{
    #region CtorAndInjection
    private readonly SignInManager<Domain.Entities.IdentityEntity.User> _signInManager;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    private readonly UserManager<Domain.Entities.IdentityEntity.User> _userManager;
    public UserLoginCommandHandler(SignInManager<Domain.Entities.IdentityEntity.User> signInManager, IMapper mapper, ITokenService tokenService, UserManager<Domain.Entities.IdentityEntity.User> userManager)
    {
        _signInManager = signInManager;
        _mapper = mapper;
        _tokenService = tokenService;
        _userManager = userManager;
    }
    #endregion
    public async Task<UserAuthorizeDto> Handle(UserLoginCommand req, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.AsNoTracking().FirstOrDefaultAsync(x => x.PhoneNumber == req.PhoneNumber, cancellationToken);
        if (user==null) throw new BadRequestEntityException(ApplicationMessages.UserNotFound);

        var checkPassword = await _signInManager.CheckPasswordSignInAsync(user, req.Password, false);
        if (!checkPassword.Succeeded) throw new BadRequestEntityException(ApplicationMessages.UserWrong);

        var userAuthorizeDto = _mapper.Map<UserAuthorizeDto>(user);
        userAuthorizeDto.Token = await _tokenService.CreateToken(user);
        return userAuthorizeDto;
    }
}