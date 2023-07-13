using Application.Dto.Base;
using Application.Dto.Store;
using Application.Features.Store.Command.StoreAdd;
using Application.Features.Store.Command.StoreDelete;
using Application.Features.Store.Command.StoreEdit;
using Application.Features.Store.Query.StoreGetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.Controllers.Base;
using WebApi.Areas.User.Controllers.Base;

namespace WebApi.Areas.User.Controllers.Store
{
    public class StoreUserController : BaseUserController
    {
        #region StoreGetAllAsync
        [HttpGet("StoreGetAll")]
        public async Task<ActionResult<PaginationDto<StoreDto>>> StoreGetAllAsync([FromQuery] StoreGetAllQuery storeGetAllQuery,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(storeGetAllQuery, cancellationToken));
        }
        #endregion
    }
}
