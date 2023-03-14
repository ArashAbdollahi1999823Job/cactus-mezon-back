using Application.Dto.Base;
using Application.Dto.User;
using Application.Features.User.Command.UserAdd;
using Application.Features.User.Command.UserDelete;
using Application.Features.User.Command.UserEdit;
using Application.Features.User.Query.UserGetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.Controllers.Base;
namespace WebApi.Areas.Admin.Controllers.User
{
    public class UserAdminController : BaseAdminController
    {
        #region UserGetAllAsync
        [HttpGet("UserGetAll")]
        public async Task<ActionResult<PaginationDto<UserDto>>> UserGetAllAsync([FromQuery] UserGetAllQuery userGetAllQuery, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(userGetAllQuery, cancellationToken));
        }
        #endregion
        
        #region UserAddAsync
        [HttpPost("UserAdd")]
        public async Task<ActionResult<bool>> UserAddAsync([FromBody] UserAddCommand userAddCommand, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(userAddCommand,cancellationToken));
        }
        #endregion

        #region UserEditAsync
        [HttpPut("UserEdit")]
        public async Task<ActionResult<bool>> UserEditAsync([FromBody] UserEditCommand userEditCommand,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(userEditCommand, cancellationToken));
        }
        #endregion

        #region UserDeleteAsync
        [HttpDelete("UserDelete/{id}")]
        public async Task<ActionResult<bool>> UserDeleteAsync([FromRoute] string id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new UserDeleteCommand(id), cancellationToken));
        }
        #endregion
    }
}