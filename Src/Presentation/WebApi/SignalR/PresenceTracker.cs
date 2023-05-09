namespace WebApi.SignalR;

public class PresenceTracker
{
    private readonly Dictionary<string, List<string>?> _onlineUsers = new Dictionary<string, List<string>?>();

    public Task UserConnected(string phoneNumber, string connectionId)
    {
        lock (_onlineUsers)
        {
            if (_onlineUsers.ContainsKey(phoneNumber))
            {
                _onlineUsers[phoneNumber].Add(connectionId);
            }
            else
            {
                _onlineUsers.Add(phoneNumber, new List<string> { connectionId });
            }
        }

        return Task.CompletedTask;
    }

    public Task UserDisconnected(string phoneNumber, string connectionId)
    {
        lock (_onlineUsers)
        {
            if (!_onlineUsers.ContainsKey(phoneNumber))
            {
                return Task.CompletedTask;
            }

            _onlineUsers[phoneNumber].Remove(connectionId);
            if (_onlineUsers[phoneNumber].Count == 0)
            {
                _onlineUsers.Remove(phoneNumber);
            }
        }

        return Task.CompletedTask;
    }

    public Task<string[]> GetOnlineUser()
    {
        string[] userOnline;
        lock (_onlineUsers)
            userOnline =
                _onlineUsers.OrderBy(x => x.Key).Select(x => x.Key).ToArray();
        return Task.FromResult(userOnline);
    }

    public Task<List<string>?> GetOnlineUserEntire(string userResponderPhoneNumber)
    {
        lock (_onlineUsers)
        {
            List<string>? connection;
            _onlineUsers.TryGetValue(userResponderPhoneNumber,out connection );
            return Task.FromResult(connection);
        }
    }

}