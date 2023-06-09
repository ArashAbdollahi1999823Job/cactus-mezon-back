using Application.Common.Messages;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace Application.Features.User.Command.UserEdit;
public class UserEditCommandHandler : IRequestHandler<UserEditCommand, bool>
{
    #region CtorAndInjection
    private readonly UserManager<Domain.Entities.IdentityEntity.User> _userManager;
    public UserEditCommandHandler(UserManager<Domain.Entities.IdentityEntity.User> userManager)
    {
        _userManager = userManager;
    }
    #endregion
    public async Task<bool> Handle(UserEditCommand req, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(x => x.Id == req.Id,cancellationToken);
        if (user == null)
        {
            throw new NotFoundEntityException(ApplicationMessages.UserNotFound);
        }
        var listUserRoles = await _userManager.GetRolesAsync(user);
         await _userManager.RemoveFromRolesAsync(user, listUserRoles);
        if (req.Roles != null)
        {
             await _userManager.AddToRolesAsync(user, req.Roles);
        }
        if (req.PhoneNumberConfirmed != null) user.PhoneNumberConfirmed = (bool)req.PhoneNumberConfirmed;
        if (req.Password != null) user.Password = req.Password;
        if (req.PhoneNumber != null) user.PhoneNumber = req.PhoneNumber;
        if (req.Username != null) user.UserName = req.Username;
        if (req.Name != null) user.Name = req.Name;
        if (req.Description != null) user.Description = req.Description;
        var check = await _userManager.UpdateAsync(user);
        if (check.Succeeded) return true;
        throw new BadRequestEntityException(ApplicationMessages.UserFailedEdit);
    }
}