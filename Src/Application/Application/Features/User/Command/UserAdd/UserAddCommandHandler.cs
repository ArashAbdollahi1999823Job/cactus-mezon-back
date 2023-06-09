#region UsingAndNamesapce
using Application.Common.Messages;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace Application.Features.User.Command.UserAdd;
#endregion
public class UserAddCommandHandler:IRequestHandler<UserAddCommand,bool>
{
    #region CtorAndInjection
    private readonly UserManager<Domain.Entities.IdentityEntity.User> _userManager;
    public UserAddCommandHandler( UserManager<Domain.Entities.IdentityEntity.User> userManager)
    {
        _userManager = userManager;
    }
    #endregion
    public async Task<bool> Handle(UserAddCommand req, CancellationToken cancellationToken)
    {
        var user=await _userManager.Users.AsNoTracking().FirstOrDefaultAsync(x => x.PhoneNumber == req.PhoneNumber, cancellationToken: cancellationToken);
       if (user != null) throw new BadRequestEntityException(ApplicationMessages.UserDuplicate);

       var newUser = new Domain.Entities.IdentityEntity.User()
       {
           PhoneNumber = req.PhoneNumber,
           Password = req.Password,
           PhoneNumberConfirmed = req.PhoneNumberConfirmed,
           UserName = req.Username,
           Description = req.Description,
           Name = req.Name
       };
       var checkAdd = await _userManager.CreateAsync(newUser,req.Password);

       if (checkAdd.Succeeded)
       {
           if (req.Roles != null)
           {
               var userCreated = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == req.PhoneNumber, cancellationToken: cancellationToken);
               var checkAddRole = await _userManager.AddToRolesAsync(userCreated, req.Roles);
           }
       }
       return true;
    }
}