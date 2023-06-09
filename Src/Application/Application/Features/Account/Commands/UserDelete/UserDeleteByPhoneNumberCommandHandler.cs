using Application.Common.Messages;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
namespace Application.Features.User.Command.UserDelete;
public class UserDeleteCommandHandler:IRequestHandler<UserDeleteCommand,bool>
{
    #region CrorAndInjection
    private readonly UserManager<Domain.Entities.IdentityEntity.User> _userManager;
    public UserDeleteCommandHandler(UserManager<Domain.Entities.IdentityEntity.User> userManager)
    {
        _userManager = userManager;
    }
    #endregion
    public async Task<bool> Handle(UserDeleteCommand req, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(req.id);
        if (user == null) throw new NotFoundEntityException(ApplicationMessages.UserNotFound);
        var result = await _userManager.DeleteAsync(user);
        if (result.Succeeded)
        {
            return true;
        }
        throw new BadRequestEntityException(ApplicationMessages.UserFailedDelete);
    }
}