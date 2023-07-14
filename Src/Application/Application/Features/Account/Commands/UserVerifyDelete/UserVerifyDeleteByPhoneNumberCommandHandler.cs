using Application.IContracts.IRepository;
using MediatR;

namespace Application.Features.Account.Commands.UserVerifyDelete;
public class UserVerifyDeleteByPhoneNumberCommandHandler:IRequestHandler<UserVerifyDeleteByPhoneNumberCommand,bool>
{
    #region CrorAndInjection
    private readonly IUserVerifyRepository _userVerifyRepository;
    public UserVerifyDeleteByPhoneNumberCommandHandler(IUserVerifyRepository userVerifyRepository)
    {
        _userVerifyRepository = userVerifyRepository;
    }
    #endregion
    public async Task<bool> Handle(UserVerifyDeleteByPhoneNumberCommand req, CancellationToken cancellationToken)
    {
        return await _userVerifyRepository.UserVerifyDelete(req.PhoneNumber);
    }
}