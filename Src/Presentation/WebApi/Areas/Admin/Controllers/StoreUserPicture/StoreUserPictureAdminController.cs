using Application.Dto.StoreUserPicture;
using Application.Features.StoreUserPicture.Command.StoreUserPictureAdd;
using Application.Features.StoreUserPicture.Command.StoreUserPictureDelete;
using Application.Features.StoreUserPicture.Command.StoreUserPictureEdit;
using Application.Features.StoreUserPicture.Query.StoreUserPictureGetAll;
using Application.Features.TypePicture.Command.TypePictureDelete;
using Application.Features.TypePicture.Command.TypePictureEdit;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.Controllers.Base;
namespace WebApi.Areas.Admin.Controllers.StoreUserPicture;
public class StoreUserPictureAdminController : BaseAdminController
{
    #region StoreUserPictureAddAsync
    [HttpPost("StoreUserPictureAdd")]
    public async Task<ActionResult<bool>> StoreUserPictureAddAsync([FromForm] StoreUserPictureAddCommand storeUserPictureAddCommand, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(storeUserPictureAddCommand, cancellationToken));
    }
    #endregion
    
    #region StoreUserPictureGetAllAsync
    [HttpGet("StoreUserPictureGetAll")]
    public async Task<ActionResult<StoreUserPictureDto>> StoreUserPictureGetAllAsync([FromQuery] StoreUserPictureGetAllQuery storeUserPictureGetAllQuery,CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(storeUserPictureGetAllQuery, cancellationToken));
    }
    #endregion
    
    #region StoreUserPictureEditAsync
    [HttpPut("StoreUserPictureEdit")]
    public async Task<ActionResult<bool>> StoreUserPictureEditAsync([FromBody] StoreUserPictureEditCommand storeUserPictureEditCommand, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(storeUserPictureEditCommand, cancellationToken));
    }
    #endregion

    #region StoreUserPictureDeleteAsync
    [HttpDelete("StoreUserPictureDelete/{id:long}")]
    public async Task<ActionResult<bool>> StoreUserPictureDeleteAsync([FromRoute] long id, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new StoreUserPictureDeleteCommand(id), cancellationToken));
    }
    #endregion
}