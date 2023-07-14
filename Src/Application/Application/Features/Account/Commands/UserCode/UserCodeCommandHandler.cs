using Application.Common.Messages;
using Application.Dto.Account;
using Application.IContracts.IRepository;
using Application.IContracts.IServices;
using Domain.Enums;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace Application.Features.Account.Commands.UserCode;

public class  UserCodeCommandHandler : IRequestHandler<UserCodeCommand, UserAuthorizeDto>
{
    #region CtorAndInjection

    private readonly ITokenService _tokenService;
    private readonly UserManager<Domain.Entities.IdentityEntity.User> _userManager;
    private readonly IUserVerifyRepository _userVerifyRepository;
    public UserCodeCommandHandler(UserManager<Domain.Entities.IdentityEntity.User> userManager, ITokenService tokenService, IUserVerifyRepository userVerifyRepository)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _userVerifyRepository = userVerifyRepository;
    }
    #endregion
    
    public async Task<UserAuthorizeDto> Handle(UserCodeCommand req, CancellationToken cancellationToken)
    {
        var userVerify = await _userVerifyRepository.UserVerifyGet(req.PhoneNumber);

        if(req.Code!= userVerify.Code)throw new BadRequestEntityException(ApplicationMessages.ConfirmCodeIsWrong);
        
        var user = new Domain.Entities.IdentityEntity.User
        {
            UserName = req.PhoneNumber,
            Code = userVerify.Code,
            Name = userVerify.Name,
            PhoneNumber = userVerify.PhoneNumber,
            Password = userVerify.Password,
            PhoneNumberConfirmed = true,
        };

        var checkAddUser =await _userManager.CreateAsync(user, userVerify.Password);
        if (!checkAddUser.Succeeded) throw new BadRequestEntityException(ApplicationMessages.UserFailedAdd);

        var roleAddCheck= await _userManager.AddToRoleAsync(user, RoleType.User.ToString());
        if (!roleAddCheck.Succeeded) throw new BadRequestEntityException(roleAddCheck.Errors.FirstOrDefault()?.Description);

        var userAuthorizeDto = new UserAuthorizeDto
        {
            Username = user.UserName,
            Token = await _tokenService.CreateToken(user)
        };

        await _userVerifyRepository.UserVerifyDelete(userVerify.PhoneNumber);
        
        return userAuthorizeDto;
    }
}