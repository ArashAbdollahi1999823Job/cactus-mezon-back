using Application.Dto.ProductPicture;
using Application.Features.ProductPicture.Command.ProductPictureAdd;
using Application.Features.ProductPicture.Command.ProductPictureDelete;
using Application.Features.ProductPicture.Command.ProductPictureEdit;
using Application.Features.ProductPicture.Query.ProductPictureGetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.Controllers.Base;

namespace WebApi.Areas.Admin.Controllers.ProductPicture;
public class ProductPictureAdminController : BaseAdminController
{
    #region ProductPictureGetAllAsync
    [HttpGet("ProductPictureGetAll")]
    public async Task<ActionResult<ProductPictureDto>> ProductPictureGetAllAsync([FromQuery] ProductPictureGetAllQuery productPictureGetAllQuery,CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(productPictureGetAllQuery, cancellationToken));
    }
    #endregion
    
    #region ProductPictureAddAsync
    [HttpPost("ProductPictureAdd")]
    public async Task<ActionResult<bool>> ProductPictureAddAsync([FromForm] ProductPictureAddCommand productPictureAddCommand, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(productPictureAddCommand, cancellationToken));
    }
    #endregion
    
    #region ProductPictureEditAsync
    [HttpPut("ProductPictureEdit")]
    public async Task<ActionResult<bool>> ProductPictureEditAsync([FromBody] ProductPictureEditCommand productPictureEditCommand, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(productPictureEditCommand, cancellationToken));
    }
    #endregion

    #region ProductPictureDeleteAsync
    [HttpDelete("ProductPictureDelete/{id:guid}")]
    public async Task<ActionResult<bool>> ProductPictureDeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new ProductPictureDeleteCommand(id), cancellationToken));
    }
    #endregion
}