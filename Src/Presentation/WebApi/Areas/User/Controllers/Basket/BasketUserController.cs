using Application.Features.Basket.Command.BasketDelete;
using Application.Features.Basket.Command.BasketEdit;
using Application.Features.Basket.Command.BasketItemDelete;
using Application.Features.Basket.Query.BasketGet;
using Domain.Entities.BasketEntity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.User.Controllers.Base;
namespace WebApi.Areas.User.Controllers.Basket; 
public class BasketUserController : BaseUserController
{
    #region BasketGetAsync
    [HttpGet("BasketGet/{id}")]
    public async Task<ActionResult<Domain.Entities.BasketEntity.Basket>> BasketGetAsync([FromRoute] string id,CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new BasketGetQuery(id),cancellationToken));
    }
    #endregion
    
    #region BasketEditAsync
    [HttpPut("BasketEdit")]
    public async Task<ActionResult<Domain.Entities.BasketEntity.Basket>> BasketEditAsync([FromBody] Domain.Entities.BasketEntity.Basket basket,CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new BasketEditCommand(basket),cancellationToken));
    }
    #endregion
    
    #region BasketDeleteAsync
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> BasketDeleteAsync([FromRoute] string id,CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new BasketDeleteCommand(id),cancellationToken));
    }
    #endregion
    
    #region BasketItemDeleteAsync
    [HttpDelete("{basketId}/{id:long}")]
    public async Task<ActionResult<bool>> BasketItemDeleteAsync([FromRoute] string basketId,[FromRoute] long id,CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new BasketItemDeleteCommand(basketId,id),cancellationToken));
    }
    #endregion
}

