using Application.Dto.Sms;
using Application.IContracts.IServices;
using Microsoft.Extensions.Configuration;
using mpNuget;
namespace Infrastructure.Persistence.Contract.Services;
public class SmsService:ISmsService
{
    #region CtorAndInjection
    private readonly RestClient _rest;
    private readonly IConfiguration _configuration;
    public SmsService(IConfiguration configuration)
    {
        _configuration = configuration;
        _rest =new RestClient(_configuration.GetValue<string>("Setting:Sms:UserName"),_configuration.GetValue<string>("Setting:Sms:Password"));
    }
    #endregion

    #region AuthSmsSendAsync
    public async Task<bool> AuthSmsSendAsync(AuthSmsDto authSmsDto)
    {
        _rest.SendByBaseNumber(authSmsDto.Code, authSmsDto.PhoneNumber,
            _configuration.GetValue<int>("Setting:Sms:authCode"));

        return true;
    }
    #endregion
    
    #region ForgetSmsSendAsync
    public async Task<bool> ForgetSmsSendAsync(ForgetSmsDto forgetSmsDto)
    {
        _rest.SendByBaseNumber(forgetSmsDto.Password, forgetSmsDto.PhoneNumber,
            _configuration.GetValue<int>("Setting:Sms:forgetCode"));

        return true;
    }
    #endregion
}