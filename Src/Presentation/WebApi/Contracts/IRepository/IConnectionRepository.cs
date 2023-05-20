using Domain.Entities.ChatEntity;

namespace WebApi.Contracts.IRepository;

public interface IConnectionRepository
{
    public Task<bool> ConnectionAddAsync(Connection connection);
    public Task<bool> ConnectionDeleteAsync(string? connectionId);
    public Task<bool> UserInGroup(string groupName, List<string> chatUserConnection);
}