﻿namespace WebApi.SignalR;
public class ChatTracker
{
    private readonly Dictionary<string, List<string>?> _onlineUsersInChat = new Dictionary<string, List<string>?>();

    #region Connected
    public Task UserConnected(string phoneNumber, string connectionId)
    {
        lock (_onlineUsersInChat)
        {
            if (_onlineUsersInChat.ContainsKey(phoneNumber))
            {
                _onlineUsersInChat[phoneNumber].Add(connectionId);
            }
            else
            {
                _onlineUsersInChat.Add(phoneNumber, new List<string> { connectionId });
            }
        }

        return Task.CompletedTask;
    }
    #endregion

    #region Disconnected
    public Task UserDisconnected(string phoneNumber, string connectionId)
    {
        lock (_onlineUsersInChat)
        {
            if (!_onlineUsersInChat.ContainsKey(phoneNumber))
            {
                return Task.CompletedTask;
            }

            _onlineUsersInChat[phoneNumber].Remove(connectionId);
            if (_onlineUsersInChat[phoneNumber].Count == 0)
            {
                _onlineUsersInChat.Remove(phoneNumber);
            }
        }

        return Task.CompletedTask;
    }
    #endregion

    #region GetUserOnlineInChat
    public Task<string[]> GetOnlineUserInChat()
    {
        string[] userOnline;
        lock (_onlineUsersInChat)
            userOnline =
                _onlineUsersInChat.OrderBy(x => x.Key).Select(x => x.Key).ToArray();
        return Task.FromResult(userOnline);
    }
    #endregion

    #region GetConnectionsOnlineUserInChat
    public Task<List<string>?> GetConnectionsOnlineUserInChat(string userResponderPhoneNumber)
    {
        lock (_onlineUsersInChat)
        {
            List<string>? connection=new List<string>();
            _onlineUsersInChat.TryGetValue(userResponderPhoneNumber,out connection );
            return Task.FromResult(connection);
        }
    }
    #endregion
}