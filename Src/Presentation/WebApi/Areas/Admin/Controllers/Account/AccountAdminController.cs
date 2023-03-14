using Application.Dto.Account;
using Application.Dto.User;
using Application.Features.Account.Commands.UserLogin;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.Controllers.Base;
namespace WebApi.Areas.Admin.Controllers.Account
{
    public class AccountAdminController : BaseAdminController
    {
        #region UserLogin
        [HttpPut("UserLogin")]
        public async Task<ActionResult<UserAuthorizeDto>> UserLoginAsync([FromBody] UserLoginCommand userLoginCommand, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(userLoginCommand, cancellationToken));
        }
        #endregion
    }
}