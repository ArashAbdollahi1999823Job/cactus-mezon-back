using Application.Dto.StoreUserPicture;
using Application.Features.StoreUserPicture.Query.StoreUserPictureGetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.User.Controllers.Base;

namespace WebApi.Areas.User.Controllers.StorePicture;
public class StorePictureUserController : BaseUserController
{
    #region StoreUserPictureGetAllAsync
    [HttpGet("StorePictureGetAll")]
    public async Task<ActionResult<StoreUserPictureDto>> StoreUserPictureGetAllAsync([FromQuery] StoreUserPictureGetAllQuery storeUserPictureGetAllQuery,CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(storeUserPictureGetAllQuery, cancellationToken));
    }
    #endregion
}