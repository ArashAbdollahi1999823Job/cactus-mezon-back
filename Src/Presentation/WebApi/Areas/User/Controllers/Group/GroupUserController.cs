using Application.Dto.Chat.Group;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.User.Controllers.Base;
using WebApi.Contracts.IApplication;
namespace WebApi.Areas.User.Controllers.Group
{
    [Authorize]
    public class GroupUserController : BaseUserController
    {
        #region CtorAndInjectoin
        private readonly IGroupApplication _groupApplication;
        public GroupUserController(IGroupApplication groupApplication)
        {
            _groupApplication = groupApplication;
        }
        #endregion

        #region GroupAddAsync
        [HttpPost("GroupAdd")]
        public async Task<ActionResult<GroupDto>> GroupAddAsync([FromBody] GroupAddDto groupAddDto)
        {
            return await _groupApplication.GroupAddAsync(groupAddDto);
        }
        #endregion
        
        #region GroupGetAllAsync
        [HttpGet("GroupGetAll")]
        public async Task<ActionResult<List<GroupDto>>> GroupGetAllAsync([FromQuery] GroupSearchDto groupSearchDto)
        {
            return await _groupApplication.GroupGetAllAsync(groupSearchDto);
        }
        #endregion
    }
}