using Application.Dto.StoreUser;
using Application.Features.StoreUser.Command.StoreUserEdit;
using Application.Features.StoreUser.Query.StoreUserGet;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Admin.Controllers.Base;
namespace WebApi.Areas.Admin.Controllers.StoreUser
{
    public class StoreUserAdminController : BaseAdminController
    {
        #region StoreUserGet
        [HttpGet("StoreUserGet")]
        public async Task<ActionResult<StoreUserDto>> StoreUserGetAsync([FromQuery] StoreUserGetQuery storeUserGetQuery, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(storeUserGetQuery, cancellationToken));
        }
        #endregion

        #region StoreUserEdit
        [HttpPut("StoreUserEdit")]
        public async Task<ActionResult<bool>> StoreUserEditAsync([FromBody] StoreUserEditCommand storeUserEditCommand, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(storeUserEditCommand, cancellationToken));
        }
        #endregion
    }
}