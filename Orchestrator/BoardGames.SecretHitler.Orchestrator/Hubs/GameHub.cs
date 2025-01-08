using BoardGames.SecretHitler.Orchestrator.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BoardGames.SecretHitler.Orchestrator.Hubs;

public class GameHub(IConnectionTokenService tokenService) : Hub
{
    public override async Task OnConnectedAsync()
    {
        var connectionId = Context.ConnectionId;
        var token = tokenService.GetConnectionToken(connectionId);
        
        await Clients.Client(connectionId).SendAsync("GameConnected", token);
    }

    public void SetConnection(string message)
    {
        Console.WriteLine($"Message received: {message}");
    }

    public async Task SendMessage(string message)
    {
        Console.WriteLine($"ConnectionId: {Context.ConnectionId}");
        Console.WriteLine($"Message: {Context.UserIdentifier}");
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}