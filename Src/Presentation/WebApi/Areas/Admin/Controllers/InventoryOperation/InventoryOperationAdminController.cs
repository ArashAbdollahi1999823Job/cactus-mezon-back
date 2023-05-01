using Application.Dto.Base;
using Application.Dto.InventoryOperation;
using Application.Features.InventoryOperation.Command.InventoryOperationAdd;
using Application.Features.InventoryOperation.Command.InventoryOperationDelete;
using Application.Features.InventoryOperation.Query.InventoryOperationGetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.Controllers.Base;

namespace WebApi.Areas.Admin.Controllers.InventoryOperation
{
    public class InventoryOperationAdminController : BaseAdminController
    {
        #region InventoryOperationGetAllAsync
        [HttpGet("InventoryOperationGetAll")]
        public async Task<ActionResult<PaginationDto<InventoryOperationDto>>> InventoryOperationGetAllAsync([FromQuery] InventoryOperationGetAllQuery inventoryOperationGetAllQuery,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(inventoryOperationGetAllQuery, cancellationToken));
        }
        #endregion
        
        #region InventoryOperationAddAsync
        [HttpPost("InventoryOperationAdd")]
        public async Task<ActionResult<bool>> InventoryOperationAddAsync([FromBody] InventoryOperationAddCommand inventoryOperationAddCommand,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(inventoryOperationAddCommand, cancellationToken));
        }
        #endregion

        #region InventoryOperationDeleteAsync
        [HttpDelete("InventoryOperationDelete/{id:guid}")]
        public async Task<ActionResult<bool>> InventoryOperationDeleteAsync(Guid id,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new InventoryOperationDeleteCommand(id), cancellationToken));
        }
        #endregion
    }
}
