using Microsoft.AspNetCore.SignalR;
using WhoKnowsGame.Shared.Models;

namespace WhoKnowsGame.SignalR
{
    public class GameHub : Hub
    {
        public async Task ReportNewPlayer(Player player)
        {
            await Clients.All.SendAsync("ReceiveNewPlayer", player);
        }
        public async Task ReportGameStarted(int gameId)
        {
            await Clients.All.SendAsync("ReceiveGameStarted", gameId);
        }
        public async Task ReportNextRiddle(int riddleIndex)
        {
            await Clients.All.SendAsync("ReceiveNextRiddle", riddleIndex);
        }
        public async Task ReportFinishGame()
        {
            await Clients.All.SendAsync("ReceiveFinishGame");
        }
    }
}
