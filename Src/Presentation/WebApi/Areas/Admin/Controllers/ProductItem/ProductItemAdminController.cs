using Application.Dto.ProductItem;
using Application.Features.ProductItem.Command.ProductItemAdd;
using Application.Features.ProductItem.Command.ProductItemDelete;
using Application.Features.ProductItem.Query.ProductItemGetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.Controllers.Base;

namespace WebApi.Areas.Admin.Controllers.ProductItem;
public class ProductItemAdminController : BaseAdminController
{
    #region ProductItemGetAllAsync
    [HttpGet("ProductItemGetAll")]
    public async Task<ActionResult<ProductItemDto>> ProductItemGetAllAsync([FromQuery] ProductItemGetAllQuery productItemGetAllQuery,CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(productItemGetAllQuery, cancellationToken));
    }
    #endregion
    
    #region ProductItemAddAsync
    [HttpPost("ProductItemAdd")]
    public async Task<ActionResult<bool>> ProductItemAddAsync([FromBody] ProductItemAddCommand productItemAddCommand, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(productItemAddCommand, cancellationToken));
    }
    #endregion

    #region ProductItemDeleteAsync
    [HttpDelete("ProductItemDelete/{id:guid}")]
    public async Task<ActionResult<bool>> ProductItemDeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new ProductItemDeleteCommand(id), cancellationToken));
    }
    #endregion
}