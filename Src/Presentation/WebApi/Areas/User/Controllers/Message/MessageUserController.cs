using Application.Dto.Base;
using Application.Dto.Chat.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.User.Controllers.Base;
using WebApi.Contracts.IApplication;
namespace WebApi.Areas.User.Controllers.Message
{
    public class MessageUserController : BaseUserController
    {
        #region CtorAndInjectoin
        private readonly IMessageApplication _messageApplication;
        public MessageUserController(IMessageApplication messageApplication)
        {
            _messageApplication = messageApplication;
        }
        #endregion

        #region MessageAddAsync
        [HttpPost("MessageAdd")]
        public async Task<ActionResult<MessageDto>> MessageAddAsync([FromForm] MessageAddDto messageAddDto)
        {
            return await _messageApplication.MessageAddAsync(messageAddDto);
        }
        #endregion
        
        #region MessageGetAllAsync
        [HttpGet("MessageGetAll")]
        public async Task<ActionResult<PaginationDto<MessageDto>>> MessageGetAllAsync([FromQuery] MessageSearchDto messageSearchDto)
        {
            return await _messageApplication.MessageGetAllAsync(messageSearchDto);
        }
        #endregion
        
        #region MessageGetAllJustAsync
        [HttpGet("MessageGetAllJust")]
        public async Task<ActionResult<PaginationDto<MessageDto>>> MessageGetAllJustAsync([FromQuery] MessageSearchDto messageSearchDto)
        {
            return await _messageApplication.MessageGetAllJustAsync(messageSearchDto);
        }
        #endregion
    }
}