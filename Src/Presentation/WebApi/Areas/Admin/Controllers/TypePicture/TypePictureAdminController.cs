using Application.Dto.TypePicture;
using Application.Features.TypePicture.Command.TypePictureAdd;
using Application.Features.TypePicture.Command.TypePictureDelete;
using Application.Features.TypePicture.Command.TypePictureEdit;
using Application.Features.TypePicture.Query.TypePictureGetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.Controllers.Base;
namespace WebApi.Areas.Admin.Controllers.TypePicture;
public class TypePictureAdminController : BaseAdminController
{
    #region TypePictureGetAllAsync
    [HttpGet("TypePictureGetAll")]
    public async Task<ActionResult<TypePictureDto>> TypePictureGetAllAsync([FromQuery] TypePictureGetAllQuery typePictureGetAllQuery,CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(typePictureGetAllQuery, cancellationToken));
    }
    #endregion
    
    #region TypePictureAddAsync
    [HttpPost("TypePictureAdd")]
    public async Task<ActionResult<bool>> TypePictureAddAsync([FromForm] TypePictureAddCommand typePictureAddCommand, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(typePictureAddCommand, cancellationToken));
    }
    #endregion
    
    #region TypePictureEditAsync
    [HttpPut("TypePictureEdit")]
    public async Task<ActionResult<bool>> TypePictureEditAsync([FromBody] TypePictureEditCommand typePictureEditCommand, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(typePictureEditCommand, cancellationToken));
    }
    #endregion

    #region TypePictureDeleteAsync
    [HttpDelete("TypePictureDelete/{id:guid}")]
    public async Task<ActionResult<bool>> TypePictureDeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new TypePictureDeleteCommand(id), cancellationToken));
    }
    #endregion
}