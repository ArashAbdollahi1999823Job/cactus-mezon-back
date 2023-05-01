using Application.Dto.Color;
using Application.Features.Color.Command.ColorAdd;
using Application.Features.Color.Command.ColorDelete;
using Application.Features.Color.Query.ColorGetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.Controllers.Base;

namespace WebApi.Areas.Admin.Controllers.Color;
public class ColorAdminController : BaseAdminController
{
    #region ColorGetAllAsync
    [HttpGet("ColorGetAll")]
    public async Task<ActionResult<ColorDto>> ColorGetAllAsync([FromQuery] ColorGetAllQuery colorGetAllQuery,CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(colorGetAllQuery, cancellationToken));
    }
    #endregion
    
    #region ColorAddAsync
    [HttpPost("ColorAdd")]
    public async Task<ActionResult<bool>> ColorAddAsync([FromBody] ColorAddCommand colorAddCommand, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(colorAddCommand, cancellationToken));
    }
    #endregion

    #region ColorDeleteAsync
    [HttpDelete("ColorDelete/{id:guid}")]
    public async Task<ActionResult<bool>> ColorDeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new ColorDeleteCommand(id), cancellationToken));
    }
    #endregion
}