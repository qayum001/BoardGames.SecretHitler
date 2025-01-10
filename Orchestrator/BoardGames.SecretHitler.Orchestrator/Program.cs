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

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(32000);
});

builder.Services.AddSingleton<IConnectionTokenService, ConnectionTokenService>();

var app = builder.Build();

app.UseCors();

app.AddHubs(); //Add SignalR hubs

app.Run();