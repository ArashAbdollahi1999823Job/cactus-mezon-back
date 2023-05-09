using Application.Dto.UserPicture;
using Application.IContracts.IRepository;
using MediatR;

namespace Application.Features.UserPicture.Query.UserPictureGetAll;
public class UserPictureGetAllQueryHandler:IRequestHandler<UserPictureGetAllQuery,UserPictureDto>
{
    #region CtorAndInjection
    private readonly IUserPictureRepository _userPictureRepository;
    public UserPictureGetAllQueryHandler(IUserPictureRepository userPictureRepository)
    {
        _userPictureRepository = userPictureRepository;
    }
    #endregion
    public async Task<UserPictureDto> Handle(UserPictureGetAllQuery req, CancellationToken cancellationToken)
    {
        UserPictureSearchDto userPictureSearchDto = new UserPictureSearchDto(req.Id, req.UserId);
        return await _userPictureRepository.UserPictureGetAllAsync(userPictureSearchDto, cancellationToken);
    }
}