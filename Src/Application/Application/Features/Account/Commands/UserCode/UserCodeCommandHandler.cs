using Application.Common.Messages;
using Application.Dto.Account;
using Application.IContracts.IServices;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Account.Commands.UserCode;

public class UserCodeCommandHandler : IRequestHandler<UserCodeCommand, UserAuthorizeDto>
{
    #region CtorAndInjection

    private readonly ITokenService _tokenService;
    private readonly UserManager<Domain.Entities.IdentityEntity.User> _userManager;
    public UserCodeCommandHandler(UserManager<Domain.Entities.IdentityEntity.User> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }
    #endregion
    
    public async Task<UserAuthorizeDto> Handle(UserCodeCommand req, CancellationToken cancellationToken)
    {
        var checkUser = await _userManager.Users.AnyAsync(x => x.PhoneNumber == req.PhoneNumber,cancellationToken);
        if (!checkUser) throw new BadRequestEntityException(ApplicationMessages.UserNotFound);

        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == req.PhoneNumber, cancellationToken: cancellationToken);
        if (user.Code != req.Code)throw new BadRequestEntityException(ApplicationMessages.ConfirmCodeIsWrong);

        user.PhoneNumberConfirmed = true;
        var checkUpdate = await _userManager.Users.Where(x=>x.PhoneNumber==req.PhoneNumber).ExecuteUpdateAsync(x=>x.SetProperty(x=>x.PhoneNumberConfirmed,true), cancellationToken);
        if(checkUpdate == 0)throw new BadRequestEntityException(ApplicationMessages.ErrorInConfirmPhoneNumber);
        
        var userAuthorizeDto = new UserAuthorizeDto
        {
            Username = user.UserName,
            Token = await _tokenService.CreateToken(user)
        };
        
        return userAuthorizeDto;
    }
}