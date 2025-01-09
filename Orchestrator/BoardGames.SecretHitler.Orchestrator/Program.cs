using BoardGames.SecretHitler.Orchestrator.Hubs;
using BoardGames.SecretHitler.Orchestrator.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

/*using var channel = GrpcChannel.ForAddress("http://127.0.0.1:5000");
var client = new LobbyManager.LobbyManagerClient(channel);
var response = await client.GetLobbyAsync(new GetLobbyRequest() { Id = "lolkek"});

Console.WriteLine(response);*/

builder.Services.AddSingleton<IConnectionTokenService, ConnectionTokenService>();

var app = builder.Build();

app.UseCors();

app.AddHubs(); //Add SignalR hubs

app.Run();