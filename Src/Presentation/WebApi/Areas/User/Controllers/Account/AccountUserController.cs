using Application.Dto.Account;
using Application.Dto.User;
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
        public async Task<ActionResult<UserAuthorizeDto>> UserRegisterAsync([FromBody] UserRegisterCommand userRegisterCommand, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(userRegisterCommand, cancellationToken));
        }
        #endregion
    }
}