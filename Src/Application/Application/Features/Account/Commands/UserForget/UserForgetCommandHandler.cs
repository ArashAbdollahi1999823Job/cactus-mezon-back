using Application.Common.Enums;
using Application.Dto.Sms;
using Application.Dto.User;
using Application.Enums;
using Application.IContracts.IRepository;
using Application.IContracts.IServices;
using Domain.Enums;
using MediatR;
namespace Application.Features.Account.Commands.UserForget;

public class UserForgetCommandHandler:IRequestHandler<UserForgetCommand,bool>
{
    #region CtorAndInjection
    private readonly IUserRepository _userRepository;
    private readonly ISmsService _smsService;
    public UserForgetCommandHandler(IUserRepository userRepository, ISmsService smsService)
    {
        _userRepository = userRepository;
        _smsService = smsService;
    }
    #endregion

    public async Task<bool> Handle(UserForgetCommand req, CancellationToken cancellationToken)
    {
         await _userRepository.ExistUserByPhoneNumberAsync(req.PhoneNumber, cancellationToken);
         var userSearchDto = new UserSearchDto(1, 1, null, PhoneConfirmType.NotImportant, req.PhoneNumber, null,
             SortType.Desc, RoleType.NotImportant);
         var user = _userRepository.UserGetAllAsync(userSearchDto, cancellationToken).Result.Data.FirstOrDefault();
         
         var forgetSmsDto = new ForgetSmsDto(user.PhoneNumber, user.Password);
         await _smsService.ForgetSmsSendAsync(forgetSmsDto);
         
         return true;
    }
}