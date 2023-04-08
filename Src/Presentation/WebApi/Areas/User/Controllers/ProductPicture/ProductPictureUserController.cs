using Application.Dto.ProductPicture;
using Application.Features.ProductPicture.Query.ProductPictureGetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.User.Controllers.Base;

namespace WebApi.Areas.User.Controllers.ProductPicture;
public class ProductPictureUserController : BaseUserController
{
    #region ProductPictureGetAllAsync
    [HttpGet("ProductPictureGetAll")]
    public async Task<ActionResult<ProductPictureDto>> ProductPictureGetAllAsync([FromQuery] ProductPictureGetAllQuery productPictureGetAllQuery,CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(productPictureGetAllQuery, cancellationToken));
    }
    #endregion
}