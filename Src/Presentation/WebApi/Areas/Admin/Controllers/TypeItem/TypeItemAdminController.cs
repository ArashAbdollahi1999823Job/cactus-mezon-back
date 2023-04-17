using Application.Dto.TypeItem;
using Application.Features.TypeItem.Command.TypeItemAdd;
using Application.Features.TypeItem.Command.TypeItemDelete;
using Application.Features.TypeItem.Query.TypeItemGetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.Controllers.Base;

namespace WebApi.Areas.Admin.Controllers.TypeItem;
public class TypeItemAdminController : BaseAdminController
{
    #region TypeItemGetAllAsync
    [HttpGet("TypeItemGetAll")]
    public async Task<ActionResult<TypeItemDto>> TypeItemGetAllAsync([FromQuery] TypeItemGetAllQuery typeItemGetAllQuery,CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(typeItemGetAllQuery, cancellationToken));
    }
    #endregion
    
    #region TypeItemAddAsync
    [HttpPost("TypeItemAdd")]
    public async Task<ActionResult<bool>> TypeItemAddAsync([FromBody] TypeItemAddCommand typeItemAddCommand, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(typeItemAddCommand, cancellationToken));
    }
    #endregion

    #region TypeItemDeleteAsync
    [HttpDelete("TypeItemDelete/{id:long}")]
    public async Task<ActionResult<bool>> TypeItemDeleteAsync([FromRoute] long id, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new TypeItemDeleteCommand(id), cancellationToken));
    }
    #endregion
}