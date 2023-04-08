using Application.Dto.Base;
using Application.Dto.Store;
using Application.Features.Store.Command.StoreAdd;
using Application.Features.Store.Command.StoreDelete;
using Application.Features.Store.Command.StoreEdit;
using Application.Features.Store.Query.StoreGetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.Controllers.Base;
namespace WebApi.Areas.Admin.Controllers.Store
{
    public class StoreAdminController : BaseAdminController
    {
        #region StoreGetAllAsync
        [HttpGet("StoreGetAll")]
        public async Task<ActionResult<PaginationDto<StoreDto>>> StoreGetAllAsync([FromQuery] StoreGetAllQuery storeGetAllQuery,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(storeGetAllQuery, cancellationToken));
        }
        #endregion
        
        #region StoreAddAsync
        [HttpPost("StoreAdd")]
        public async Task<ActionResult<bool>> StoreAddAsync([FromBody] StoreAddCommand storeAddCommand,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(storeAddCommand, cancellationToken));
        }
        #endregion
        
        #region StoreEditAsync
        [HttpPut("StoreEdit")]
        public async Task<ActionResult<StoreDto>> StoreEditAsync([FromBody] StoreEditCommand storeEditCommand,CancellationToken cancellationToken)
        {
            return Ok(await  Mediator.Send(storeEditCommand,cancellationToken));
        }
        #endregion
        
        #region StoreDeleteAsync
        [HttpDelete("StoreDelete/{id:guid}")]
        public async Task<ActionResult<bool>> StoreDeleteAsync(Guid id,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new StoreDeleteCommand(id), cancellationToken));
        }
        #endregion
    }
}
