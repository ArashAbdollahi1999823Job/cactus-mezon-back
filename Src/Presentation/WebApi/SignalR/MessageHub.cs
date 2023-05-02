using Microsoft.AspNetCore.SignalR;
using WebApi.Extensions;

namespace WebApi.SignalR;

public class MessageHub:Hub
{
    public override async Task OnConnectedAsync()
    {
        
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        var httpContext = Context.GetHttpContext();
        var currentUserPhoneNumber = Context.User.GetPhoneNumber();
        var otherUserPhoneNumber = httpContext.Request.Query["phoneNumber"].ToString();
        var groupName = CreateGroupName(currentUserPhoneNumber, otherUserPhoneNumber);
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        /*get all messages*/
        /*var messages =await _messages.MessagesGet(currentUserPhoneNumber, otherUserPhoneNumber);*/

        /*await Clients.Group(groupName).SendAsync("ReceiveMessages", messages);*/
    }

    public static string CreateGroupName(string caller,string other)
    {
        var stringCompare = string.CompareOrdinal(caller, other) < 0;
        return stringCompare ? $"{caller}-{other}" : $"{other}-{caller}";
    }
    
    
}