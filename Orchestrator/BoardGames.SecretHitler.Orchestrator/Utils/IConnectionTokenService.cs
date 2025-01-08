namespace BoardGames.SecretHitler.Orchestrator.Utils;

public interface IConnectionTokenService
{
    string GetConnectionToken(string connectionId);
}