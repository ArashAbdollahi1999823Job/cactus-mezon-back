using Application.Features.Product.Command.ProductAdd;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.Controllers.Base;

namespace WebApi.Areas.Admin.Controllers.Product
{
    public class ProductAdminController : BaseAdminController
    {

        
        #region ProductAddAsync

        [HttpPost("ProductAdd")]
        public async Task<ActionResult<bool>> ProductAddAsync([FromBody] ProductAddCommand productAddCommand,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(productAddCommand, cancellationToken));
        }
        #endregion
        
        
        
        /*#region InventoryGetAllAsync
        [HttpGet("InventoryGetAll")]
        public async Task<ActionResult> InventoryGetAllAsync([FromQuery] InventoryGetAllQuery inventoryGetAllQuery,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send (inventoryGetAllQuery,cancellationToken));
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
        #endregion*/
    }
}
