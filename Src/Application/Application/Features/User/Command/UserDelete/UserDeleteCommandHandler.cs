using Application.Common.Messages;
using Application.Dto.Chat.Group;
using Application.Enums;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
namespace Application.Features.User.Command.UserDelete;
public class UserDeleteCommandHandler:IRequestHandler<UserDeleteCommand,bool>
{
    #region CrorAndInjection
    private readonly UserManager<Domain.Entities.IdentityEntity.User> _userManager;
    private readonly IGroupRepository _groupRepository;
    public UserDeleteCommandHandler(UserManager<Domain.Entities.IdentityEntity.User> userManager, IGroupRepository groupRepository)
    {
        _userManager = userManager;
        _groupRepository = groupRepository;
    }
    #endregion
    public async Task<bool> Handle(UserDeleteCommand req, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(req.id);
        if (user == null) throw new NotFoundEntityException(ApplicationMessages.UserNotFound);
        var userGroups = await _groupRepository.GroupGetAllAsync(new GroupSearchDto(user.PhoneNumber,HasMessageType.NotImportant));
        var result = await _userManager.DeleteAsync(user);
        if (result.Succeeded)
        {
            return true;
        }
        throw new BadRequestEntityException(ApplicationMessages.UserFailedDelete);
    }
}