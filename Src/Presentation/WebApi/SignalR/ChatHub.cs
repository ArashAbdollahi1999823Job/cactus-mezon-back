using Microsoft.AspNetCore.SignalR;
using WebApi.Contracts.IRepository;
using WebApi.Extensions;
namespace WebApi.SignalR;
public class ChatHub : Hub
{
    #region CtorAndInjection
    private readonly IConnectionRepository _connectionRepository;
    private readonly ChatTracker _chatTracker;
    public ChatHub(ChatTracker chatTracker, IConnectionRepository connectionRepository)
    {
        _chatTracker = chatTracker;
        _connectionRepository = connectionRepository;
    }
    #endregion
 
    #region Connected
    public override async Task OnConnectedAsync()
    {
        await _chatTracker.UserConnected(Context.User.GetPhoneNumber(), Context.ConnectionId);
    }
    #endregion

    #region Disconnected
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await _connectionRepository.ConnectionDeleteAsync(Context.ConnectionId);
        await _chatTracker.UserDisconnected(Context.User.GetPhoneNumber(), Context.ConnectionId);
        await base.OnDisconnectedAsync(exception);
    }
    #endregion
}