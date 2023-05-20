using Application.Dto.Chat.Group;
namespace WebApi.Contracts.IRepository;

public interface IGroupRepository
{
    public Task<List<GroupDto>> GroupGetAllAsync(GroupSearchDto groupSearchDto);
    public Task<GroupDto> GroupAddAsync(GroupAddDto groupAddDto);
    public Task<bool> GroupExistAsync(string groupName);
}