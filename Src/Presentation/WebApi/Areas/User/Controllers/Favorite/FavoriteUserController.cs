using Application.Features.Favorite.Command.FavoriteAdd;
using Application.Features.Favorite.Command.FavoriteDelete;
using Application.Features.Favorite.Query.FavoriteGetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.User.Controllers.Base;
namespace WebApi.Areas.User.Controllers.Favorite
{
    public class FavoriteUserController : BaseUserController
    {
        #region FavoriteAddAsync
        [HttpPost("FavoriteAdd")]
        public async Task<ActionResult<bool>> FavoriteAddAsync([FromBody] FavoriteAddCommand favoriteAddCommand,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(favoriteAddCommand, cancellationToken));
        }
        #endregion
        
        #region FavoriteGetAllAsync
        [HttpGet("FavoriteGetAll")]
        public async Task<ActionResult<bool>> FavoriteGetAllAsync([FromQuery] FavoriteGetAllQuery favoriteGetAllQuery,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(favoriteGetAllQuery, cancellationToken));
        }
        #endregion
        
        #region FavoriteDeleteAsync
        [HttpDelete("FavoriteDelete/{userId}/{productId:guid}")]
        public async Task<ActionResult<bool>> FavoriteDeleteAsync([FromRoute] string userId,[FromRoute] Guid productId,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new FavoriteDeleteCommand(userId,productId), cancellationToken));
        }
        #endregion
    }
}