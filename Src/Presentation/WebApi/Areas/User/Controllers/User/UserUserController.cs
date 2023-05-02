using Application.Dto.Base;
using Application.Dto.User;
using Application.Features.User.Command.UserAdd;
using Application.Features.User.Command.UserDelete;
using Application.Features.User.Command.UserEdit;
using Application.Features.User.Query.UserGetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.User.Controllers.Base;

namespace WebApi.Areas.User.Controllers.User
{
    public class UserUserController : BaseUserController
    {
        #region UserGetAllAsync
        [HttpGet("UserGetAll")]
        public async Task<ActionResult<PaginationDto<UserDto>>> UserGetAllAsync([FromQuery] UserGetAllQuery userGetAllQuery, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(userGetAllQuery, cancellationToken));
        }
        #endregion
    }
}