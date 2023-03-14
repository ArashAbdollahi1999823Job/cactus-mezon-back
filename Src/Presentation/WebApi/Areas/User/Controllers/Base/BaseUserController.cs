using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Areas.User.Controllers.Base;
[Route("Api/[Area]/[controller]")]
[ApiController]
[Area("User")]
public class BaseUserController : ControllerBase
{
    #region CtorAndInjection
    private ISender _mediatorSender = null!;
    protected ISender Mediator => _mediatorSender ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    #endregion
}
