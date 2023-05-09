using Application.Dto.User;
using Domain.Entities.ChatEntity;
namespace Application.IContracts.IRepository;
public interface IChatRepository
{
    public Task ConnectionDeleteInGroup(string connectionId);
    public Task GroupAddAsync(Group group);
    public Task GroupDeleteAsync(string groupName);
    public Task ConnectionAddAsync(Connection connection);
    public Task<bool> GroupExistAsync(string groupName);
    public Task<bool> ConnectionExistAsync(string connectionId);
    public Task<List<Group>> GroupGetAllAsync(string halfGroupName);
    public Task<Group> GroupGetAsync(string groupName);
    public Task<List<UserDto>> UserInGroupsGet(string askerPhoneNumber);
    public Task<bool> UserInGroup(string groupName, List<string> chatConnections);
}