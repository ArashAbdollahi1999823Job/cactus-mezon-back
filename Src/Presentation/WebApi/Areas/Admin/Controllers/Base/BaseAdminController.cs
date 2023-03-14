using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Areas.Admin.Controllers.Base;
[Route("Api/[Area]/[controller]")]
[ApiController]
[Area("Admin")]
public class BaseAdminController : ControllerBase
{
    #region CtorAndInjection
    private ISender _mediatorSender = null!;
    protected ISender Mediator => _mediatorSender ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    #endregion
}
