namespace BoardGames.SecretHitler.Orchestrator.Hubs;

public static class HubBuilderExtension
{
    public static void AddHubs(this WebApplication app)
    {
        app.MapHub<GameHub>("/gameHub");
    }
}