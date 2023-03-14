using Application.Dto.Base;
using Application.Dto.Type;
using Application.Features.Type.Command.TypeAdd;
using Application.Features.Type.Command.TypeDelete;
using Application.Features.Type.Command.TypeEdit;
using Application.Features.Type.Query.TypeGetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.Controllers.Base;
namespace WebApi.Areas.Admin.Controllers.Type;
public class TypeAdminController : BaseAdminController
{
    #region TypeGetAllAsync
    [HttpGet("TypeGetAll")]
    public async Task<ActionResult<PaginationDto<TypeDto>>> TypeGetAllAsync([FromQuery] TypeGetAllQuery typeGetAllQuery,CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(typeGetAllQuery, cancellationToken));
    }
    #endregion

    #region TypeAddAsync
    [HttpPost("TypeAdd")]
    public async Task<ActionResult<bool>> TypeAddAsync([FromBody] TypeAddCommand typeAddCommand, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(typeAddCommand, cancellationToken));
    }
    #endregion
    
    #region TypeEditAsync
    [HttpPut("TypeEdit")]
    public async Task<ActionResult<bool>> TypeEditAsync([FromBody] TypeEditCommand typeEditCommand, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(typeEditCommand, cancellationToken));
    }
    #endregion
    
    #region TypeDeleteAsync
    [HttpDelete("TypeDelete/{id:long}")]
    public async Task<ActionResult<bool>> TypeDeleteAsync([FromRoute] long id, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new TypeDeleteCommand(id), cancellationToken));
    }
    #endregion
}