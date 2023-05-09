using Application.Common.Messages;
using Application.Dto.UserPicture;
using Application.IContracts.IRepository;
using Application.IContracts.IServices;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserPicture.Command.UserPictureAdd;
public class UserPictureAddCommandHandler : IRequestHandler<UserPictureAddCommand, bool>
{
    #region CtorAndInjection
    private readonly IUserPictureRepository _userPictureRepository;
    private readonly UserManager<Domain.Entities.IdentityEntity.User> _userManager;
    private readonly IFileUploader _fileUploader;
    public UserPictureAddCommandHandler(IUserPictureRepository userPictureRepository,UserManager<Domain.Entities.IdentityEntity.User> userManager, IFileUploader fileUploader)
    {
        _userPictureRepository = userPictureRepository;
        _userManager = userManager;
        _fileUploader = fileUploader;
    }
    #endregion


    public async Task<bool> Handle(UserPictureAddCommand req, CancellationToken cancellationToken)
    {
            string userName = _userManager.Users.FirstOrDefaultAsync(x=>x.Id==req.UserId, cancellationToken: cancellationToken).Result.UserName;
        var path = $"Picture/User/{userName}";
        string pictureUrlString = _fileUploader.Upload(req.PictureUrl, path);
        if (pictureUrlString != null)
        {
            UserPictureAddDto userPictureAddDto = new UserPictureAddDto(pictureUrlString,req.UserId);
            return await _userPictureRepository.UserPictureAddAsync(userPictureAddDto,cancellationToken);
        }
        throw new BadRequestEntityException(ApplicationMessages.UserPictureFailedAddOnHandle);
    }
}