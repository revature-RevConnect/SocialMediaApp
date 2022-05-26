using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace RevConnectChat.Hubs;
//[Authorize]
public class ChatHub : Hub
{
    public async Task SendMessage(string receiver, string sender, string message)
    {
        string connectionID = Context.ConnectionId;
        if (receiver == "AllChatters")
        {
            await Clients.All.SendAsync("ReceiveMessage", receiver, sender, message);
        }
        else
        {
            //await Clients.Client(receiver).SendAsync("ReceiveMessage", receiver, sender, message);
            await Clients.All.SendAsync("ReceiveMessage", receiver, sender, message);
        }

    }

    public override async Task OnConnectedAsync()
    {
        string? username = Context.GetHttpContext().Request.Query["userName"];
        //string? username = Context.GetHttpContext().Request.QueryString.Value;
        string connectionID = Context.ConnectionId;
        OnlineUsers.users.Add(new User() { connectionId = connectionID, name = username != "" ? username : "admin_default" });
        await Clients.All.SendAsync("OnlineUsers", OnlineUsers.users);
        await base.OnConnectedAsync();
    }
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var connectionID = Context.ConnectionId;
        var connectionIdToRemove = OnlineUsers.users.Single(r => r.connectionId == connectionID);
        OnlineUsers.users.Remove(connectionIdToRemove);
        await Clients.All.SendAsync("OnlineUsers", OnlineUsers.users);
        await base.OnDisconnectedAsync(exception);
    }
}
public class User
{
    public string connectionId { get; set; }
    public string name { get; set; }
}
public static class OnlineUsers
{
    public static List<User> users = new List<User>();
}
