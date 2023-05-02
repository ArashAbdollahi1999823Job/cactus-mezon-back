using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using WebApi.Extensions;
namespace WebApi.SignalR; 
[Authorize]
public class PresenceHub : Hub
{
    #region CtorAndInjection

    private readonly PresenceTracker _presenceTracker;

    public PresenceHub(PresenceTracker presenceTracker)
    {
        _presenceTracker = presenceTracker;
    }

    #endregion

    public override async Task OnConnectedAsync()
    {
        await _presenceTracker.UserConnected(Context.User.GetPhoneNumber(), Context.ConnectionId);
        await Clients.Others.SendAsync("UserIsOnline", Context.User.GetPhoneNumber());
        await UsersOnlineGet();
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        await _presenceTracker.UserDisconnected(Context.User.GetPhoneNumber(), Context.ConnectionId);
        await Clients.Others.SendAsync("UserIsOffline", Context.User.GetPhoneNumber());
        
        await UsersOnlineGet();

        await base.OnDisconnectedAsync(exception);
    }
    private async Task UsersOnlineGet()
    {
        var usersOnline = await _presenceTracker.GetOnlineUser();
        await Clients.All.SendAsync("UsersOnlineGet", usersOnline);
    }
}
