using Application.Dto.Base;
using Application.Dto.Brand;
using Application.Features.Brand.Command.BrandAdd;
using Application.Features.Brand.Command.BrandDelete;
using Application.Features.Brand.Command.BrandEdit;
using Application.Features.Brand.Query.BrandGetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.Controllers.Base;
using WebApi.Areas.User.Controllers.Base;
namespace WebApi.Areas.User.Controllers.Brand
{
    public class BrandUserController : BaseUserController
    {
        #region BrandGetAllAsync
        [HttpGet("BrandGetAll")]
        public async Task<ActionResult<PaginationDto<BrandDto>>> BrandGetAllAsync([FromQuery] BrandGetAllQuery brandGetAllQuery,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send (brandGetAllQuery,cancellationToken));
        }
        #endregion
    }
}
