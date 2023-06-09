using Application.Dto.Sms;

namespace Application.IContracts.IServices;

public interface ISmsService
{
    public Task<bool> AuthSmsSendAsync(AuthSmsDto authSmsDto);
    public Task<bool> ForgetSmsSendAsync(ForgetSmsDto forgetSmsDto);
}