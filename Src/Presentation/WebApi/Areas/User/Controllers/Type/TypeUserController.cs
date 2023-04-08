using Application.Features.Type.Query.TypeGetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.User.Controllers.Base;

namespace WebApi.Areas.User.Controllers.Type
{
    public class TypeUserController : BaseUserController
    {
        [HttpGet("TypeGetAll")]
        public async Task<ActionResult> TypeGetAllAsync([FromQuery]TypeGetAllQuery typeGetAllQuery,CancellationToken cancellationToken)
        {
            return Ok (await Mediator.Send(typeGetAllQuery,cancellationToken));
        }
    }
}