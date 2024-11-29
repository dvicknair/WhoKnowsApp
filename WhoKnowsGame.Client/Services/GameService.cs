using System.Net.Http.Json;
using WhoKnowsGame.Shared.Dtos;
using WhoKnowsGame.Shared.Interfaces;
using WhoKnowsGame.Shared.Models;

namespace WhoKnowsGame.Client.Services
{
    public class GameService : IGameService
    {
        private readonly HttpClient httpClient;

        public GameService(HttpClient httpClient) => this.httpClient = httpClient;

        public async Task AnswerRiddle(AnswerRiddleDto answerRiddleDto)
        {
            await httpClient.PostAsJsonAsync("AnswerRiddle", answerRiddleDto);
        }

        public async Task<Player> EnterGame(EnterGameDto enterGameDto)
        {
            var response = await httpClient.PostAsJsonAsync("EnterGame", enterGameDto);
            return await response.Content.ReadFromJsonAsync<Player>();
        }

        public async Task<Game> GetGame(int gameId) => await httpClient.GetFromJsonAsync<Game>($"game/{gameId}");
        public async Task<List<Player>> GetPlayers(int gameId) => await httpClient.GetFromJsonAsync<List<Player>>($"playersss/{gameId}");

        public async Task<Game> StartGame(int gameId) => await httpClient.GetFromJsonAsync<Game>($"StartGame/{gameId}");

        public async Task<List<Player>> GetGameResults(int gameId) => await httpClient.GetFromJsonAsync<List<Player>>($"GetGameResults/{gameId}");
    }
}
