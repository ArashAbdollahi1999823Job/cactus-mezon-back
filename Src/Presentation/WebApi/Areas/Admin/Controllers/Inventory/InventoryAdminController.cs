using Application.Dto.Inventory;
using Application.Features.Inventory.Command.InventoryAdd;
using Application.Features.Inventory.Command.InventoryDelete;
using Application.Features.Inventory.Command.InventoryEdit;
using Application.Features.Inventory.Query.InventoryGetAll;
using Application.IContracts.IRepository;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.Controllers.Base;

namespace WebApi.Areas.Admin.Controllers.Inventory
{
    public class InventoryAdminController : BaseAdminController
    {
        private readonly IInventoryRepository _inventoryRepository;
        
        #region InventoryGetAllAsync
        [HttpGet("InventoryGetAll")]
        public async Task<ActionResult> InventoryGetAllAsync([FromQuery] InventoryGetAllQuery inventoryGetAllQuery,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send (inventoryGetAllQuery,cancellationToken));
        }
        #endregion
        
        #region InventoryAddAsync
        public InventoryAdminController(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        [HttpPost("InventoryAdd")]
        public async Task<ActionResult<bool>> InventoryAddAsync([FromBody] InventoryAddCommand inventoryAddCommand,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(inventoryAddCommand, cancellationToken));
        }
        #endregion
        
        #region InventoryEditAsync
        [HttpPut("InventoryEdit")]
        public async Task<ActionResult<InventoryDto>> InventoryEditAsync([FromBody] InventoryEditCommand inventoryEditCommand,CancellationToken cancellationToken)
        {
            return Ok(await  Mediator.Send(inventoryEditCommand,cancellationToken));
        }
        #endregion
        
        #region InventoryDeleteAsync
        [HttpDelete("InventoryDelete/{id:long}")]
        public async Task<ActionResult<bool>> InventoryDeleteAsync(long id,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new InventoryDeleteCommand(id), cancellationToken));
        }
        #endregion
    }
}
