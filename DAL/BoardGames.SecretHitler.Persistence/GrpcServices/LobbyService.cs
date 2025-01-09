using Grpc.Core;

namespace BoardGames.SecretHitler.Persistence.GrpcServices;

public class LobbyService : LobbyManager.LobbyManagerBase
{
    public override Task<GetLobbyResponse> GetLobby(GetLobbyRequest request, ServerCallContext context)
    {   
        var random = new Random();
        Console.WriteLine("Data from LobbyService:" + request.Id);
        return Task.FromResult(new GetLobbyResponse{ Id = random.Next(1000, 9999).ToString() });
    }
}