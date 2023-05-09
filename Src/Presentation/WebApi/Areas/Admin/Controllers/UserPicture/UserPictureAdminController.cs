using Application.Dto.UserPicture;
using Application.Features.UserPicture.Command.UserPictureAdd;
using Application.Features.UserPicture.Command.UserPictureDelete;
using Application.Features.UserPicture.Query.UserPictureGetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.Controllers.Base;
namespace WebApi.Areas.Admin.Controllers.UserPicture;
public class UserPictureAdminController : BaseAdminController
{
    #region UserPictureGetAllAsync
    [HttpGet("UserPictureGetAll")]
    public async Task<ActionResult<UserPictureDto>> UserPictureGetAllAsync([FromQuery] UserPictureGetAllQuery userPictureGetAllQuery,CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(userPictureGetAllQuery, cancellationToken));
    }
    #endregion
    
    #region UserPictureAddAsync
    [HttpPost("UserPictureAdd")]
    public async Task<ActionResult<bool>> UserPictureAddAsync([FromForm] UserPictureAddCommand userPictureAddCommand, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(userPictureAddCommand, cancellationToken));
    }
    #endregion
    
    #region UserPictureDeleteAsync
    [HttpDelete("UserPictureDelete/{id:guid}")]
    public async Task<ActionResult<bool>> UserPictureDeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new UserPictureDeleteCommand(id), cancellationToken));
    }
    #endregion
}