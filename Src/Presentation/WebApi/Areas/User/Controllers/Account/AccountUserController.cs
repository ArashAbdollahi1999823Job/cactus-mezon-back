using Application.Dto.Account;
using Application.Features.Account.Commands.UserCode;
using Application.Features.Account.Commands.UserDelete;
using Application.Features.Account.Commands.UserForget;
using Application.Features.Account.Commands.UserLogin;
using Application.Features.Account.Commands.UserRegister;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.User.Controllers.Base;
namespace WebApi.Areas.User.Controllers.Account
{
    public class AccountUserController : BaseUserController
    {
        #region UserLogin
        [HttpPut("UserLogin")]
        public async Task<ActionResult<UserAuthorizeDto>> UserLoginAsync([FromBody] UserLoginCommand userLoginCommand, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(userLoginCommand, cancellationToken));
        }
        #endregion
        
        #region UserRegister
        [HttpPost("UserRegister")]
        public async Task<ActionResult<bool>> UserRegisterAsync([FromBody] UserRegisterCommand userRegisterCommand, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(userRegisterCommand, cancellationToken));
        }
        #endregion
        
        #region UserForget
        [HttpPost("UserForget")]
        public async Task<ActionResult<bool>> UserForgetAsync([FromBody] UserForgetCommand userForgetCommand, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(userForgetCommand, cancellationToken));
        }
        #endregion
        
        #region UserCode
        [HttpPost("UserCode")]
        public async Task<ActionResult<UserAuthorizeDto>> UserCodeAsync([FromBody] UserCodeCommand userCodeCommand, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(userCodeCommand, cancellationToken));
        }
        #endregion
        
        #region UserDeleteAsync
        [HttpDelete("UserDelete/{phoneNumber}")]
        public async Task<ActionResult<bool>> UserDeleteByPhoneNumberAsync([FromRoute] string phoneNumber, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new UserDeleteByPhoneNumberCommand(phoneNumber), cancellationToken));
        }
        #endregion
    }
}