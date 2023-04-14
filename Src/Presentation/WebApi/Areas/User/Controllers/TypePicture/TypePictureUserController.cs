using Application.Dto.TypePicture;
using Application.Features.TypePicture.Query.TypePictureGetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.User.Controllers.Base;

namespace WebApi.Areas.User.Controllers.TypePicture;
public class TypePictureUserController : BaseUserController
{
    #region TypePictureGetAllAsync
    [HttpGet("TypePictureGetAll")]
    public async Task<ActionResult<TypePictureDto>> TypePictureGetAllAsync([FromQuery] TypePictureGetAllQuery typePictureGetAllQuery,CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(typePictureGetAllQuery, cancellationToken));
    }
    #endregion
}