using Microsoft.AspNetCore.Mvc;
using mpNuget;
using WebApi.Areas.User.Controllers.Base;

namespace WebApi.Areas.User.Controllers.test
{
    public class TestUserController : BaseUserController
    {
        #region UserGetAllAsync
        [HttpGet("Test")]
        public  IActionResult UserGetAllAsync( )
        {
            var rest = new RestClient("9178092254", "GCS84");
           var result= rest.SendByBaseNumber("142654", "09178092254", 142654);
            return Ok();
        }
        #endregion
    }
}