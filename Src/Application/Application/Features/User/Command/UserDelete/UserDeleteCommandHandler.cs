using Application.Common.Enums;
using Application.Common.Messages;
using Application.Dto.Chat.Group;
using Application.Dto.Favorite;
using Application.Dto.Store;
using Application.Dto.UserPicture;
using Application.Enums;
using Application.IContracts.IRepository;
using Application.IContracts.IServices;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.User.Command.UserDelete;

public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand, bool>
{
    #region CrorAndInjection
    private readonly UserManager<Domain.Entities.IdentityEntity.User> _userManager;
    private readonly IUserRepository _userRepository;
 
    public UserDeleteCommandHandler(UserManager<Domain.Entities.IdentityEntity.User> userManager, IUserRepository userRepository)
    {
        _userManager = userManager;
        _userRepository = userRepository;
    }
    #endregion
    public async Task<bool> Handle(UserDeleteCommand req, CancellationToken cancellationToken)
    {
        return await _userRepository.UserDeleteAsync(req.id, cancellationToken);
    
        throw new BadRequestEntityException(ApplicationMessages.UserFailedDelete);
    }
}