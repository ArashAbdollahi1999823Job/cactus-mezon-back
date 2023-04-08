using Application.Dto.Base;
using Application.Dto.Product;
using Application.Features.Product.Command.ProductAdd;
using Application.Features.Product.Command.ProductDelete;
using Application.Features.Product.Command.ProductEdit;
using Application.Features.Product.Query.ProductGetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.Controllers.Base;
using WebApi.Areas.User.Controllers.Base;

namespace WebApi.Areas.User.Controllers.Product
{
    public class ProductUserController : BaseUserController
    {
        #region ProductGetAllAsync
        [HttpGet("ProductGetAll")]
        public async Task<ActionResult<PaginationDto<ProductDto>>> ProductGetAllAsync([FromQuery] ProductGetAllQuery productGetAllQuery,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send (productGetAllQuery,cancellationToken));
        }
        #endregion
    }
}
