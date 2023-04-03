using Application.Dto.Base;
using Application.Dto.Product;
using Application.Features.Product.Command.ProductAdd;
using Application.Features.Product.Command.ProductDelete;
using Application.Features.Product.Command.ProductEdit;
using Application.Features.Product.Query.ProductGetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.Controllers.Base;
namespace WebApi.Areas.Admin.Controllers.Product
{
    public class ProductAdminController : BaseAdminController
    {
        #region ProductGetAllAsync
        [HttpGet("ProductGetAll")]
        public async Task<ActionResult<PaginationDto<ProductDto>>> ProductGetAllAsync([FromQuery] ProductGetAllQuery productGetAllQuery,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send (productGetAllQuery,cancellationToken));
        }
        #endregion

        #region ProductAddAsync
        [HttpPost("ProductAdd")]
        public async Task<ActionResult<bool>> ProductAddAsync([FromBody] ProductAddCommand productAddCommand,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(productAddCommand, cancellationToken));
        }
        #endregion
        
        #region IProductEditAsync
        [HttpPut("ProductEdit")]
        public async Task<ActionResult<bool>> ProductEditAsync([FromBody] ProductEditCommand productEditCommand,CancellationToken cancellationToken)
        {
            return Ok(await  Mediator.Send(productEditCommand,cancellationToken));
        }
        #endregion

        #region ProductDeleteAsync
        [HttpDelete("ProductDelete/{id:long}")]
        public async Task<ActionResult<bool>> ProductDeleteAsync(long id,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new ProductDeleteCommand(id), cancellationToken));
        }
        #endregion
    }
}
