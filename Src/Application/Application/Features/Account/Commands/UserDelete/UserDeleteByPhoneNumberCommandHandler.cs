using Application.Common.Messages;
using Application.Dto.Chat.Group;
using Application.Enums;
using Application.Features.User.Command.UserDelete;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Account.Commands.UserDelete;
public class UserDeleteByPhoneNumberCommandHandler:IRequestHandler<UserDeleteByPhoneNumberCommand,bool>
{
    #region CrorAndInjection

    private readonly IGroupRepository _groupRepository;
    private readonly UserManager<Domain.Entities.IdentityEntity.User> _userManager;
    public UserDeleteByPhoneNumberCommandHandler(UserManager<Domain.Entities.IdentityEntity.User> userManager, IGroupRepository groupRepository)
    {
        _userManager = userManager;
        _groupRepository = groupRepository;
    }
    #endregion
    public async Task<bool> Handle(UserDeleteByPhoneNumberCommand req, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x=>x.PhoneNumber==req.PhoneNumber, cancellationToken: cancellationToken);
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