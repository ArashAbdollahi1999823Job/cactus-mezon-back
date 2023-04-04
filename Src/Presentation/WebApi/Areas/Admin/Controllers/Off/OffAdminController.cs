using Application.Dto.Off;
using Application.Features.Off.Command.OffAdd;
using Application.Features.Off.Command.OffDelete;
using Application.Features.Off.Command.OffEdit;
using Application.Features.Off.Query.OffGetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.Controllers.Base;
namespace WebApi.Areas.Admin.Controllers.Off
{
    public class OffAdminController : BaseAdminController
    {
        #region OffGetAllAsync
        [HttpGet("OffGetAll")]
        public async Task<ActionResult<List<OffDto>>> OffGetAllAsync([FromQuery] OffGetAllQuery offGetAllQuery,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send (offGetAllQuery,cancellationToken));
        }
        #endregion

        #region OffAddAsync
        [HttpPost("OffAdd")]
        public async Task<ActionResult<bool>> OffAddAsync([FromBody] OffAddCommand offAddCommand,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(offAddCommand, cancellationToken));
        }
        #endregion
        
        #region OffEditAsync
        [HttpPut("OffEdit")]
        public async Task<ActionResult<bool>> OffEditAsync([FromBody] OffEditCommand offEditCommand,CancellationToken cancellationToken)
        {
            return Ok(await  Mediator.Send(offEditCommand,cancellationToken));
        }
        #endregion

        #region OffDeleteAsync
        [HttpDelete("OffDelete/{id:long}")]
        public async Task<ActionResult<bool>> OffDeleteAsync(long id,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new OffDeleteCommand(id), cancellationToken));
        }
        #endregion
    }
}
