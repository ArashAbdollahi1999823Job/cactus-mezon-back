using Application.Dto.Chat.Group;

namespace WebApi.Contracts.IApplication;

public interface IGroupApplication
{
   public Task<GroupDto> GroupAddAsync(GroupAddDto groupAddDto);
   public Task<List<GroupDto>> GroupGetAllAsync(GroupSearchDto groupSearchDto);
   public Task<bool> GroupDeleteAsync(string groupName);
}