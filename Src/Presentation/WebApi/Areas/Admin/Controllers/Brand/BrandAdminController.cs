using Application.Dto.Base;
using Application.Dto.Brand;
using Application.Features.Brand.Command.BrandAdd;
using Application.Features.Brand.Command.BrandDelete;
using Application.Features.Brand.Command.BrandEdit;
using Application.Features.Brand.Query.BrandGetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.Controllers.Base;

namespace WebApi.Areas.Admin.Controllers.Brand
{
    public class BrandAdminController : BaseAdminController
    {
        #region BrandGetAllAsync
        [HttpGet("BrandGetAll")]
        public async Task<ActionResult<PaginationDto<BrandDto>>> BrandGetAllAsync([FromQuery] BrandGetAllQuery brandGetAllQuery,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send (brandGetAllQuery,cancellationToken));
        }
        #endregion

        #region BrandAddAsync
        [HttpPost("BrandAdd")]
        public async Task<ActionResult<bool>> BrandAddAsync([FromBody] BrandAddCommand brandAddCommand,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(brandAddCommand, cancellationToken));
        }
        #endregion
        
        #region BrandEditAsync
        [HttpPut("BrandEdit")]
        public async Task<ActionResult<bool>> BrandEditAsync([FromBody] BrandEditCommand brandEditCommand,CancellationToken cancellationToken)
        {
            return Ok(await  Mediator.Send(brandEditCommand,cancellationToken));
        }
        #endregion

        #region BrandDeleteAsync
        [HttpDelete("BrandDelete/{id:guid}")]
        public async Task<ActionResult<bool>> BrandDeleteAsync(Guid id,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new BrandDeleteCommand(id), cancellationToken));
        }
        #endregion
    }
}
