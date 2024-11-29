using WhoKnowsGame.Shared.Dtos;
using WhoKnowsGame.Shared.Models;

namespace WhoKnowsGame.Shared.Interfaces
{
    public interface IGameService
    {
        Task<Game> GetGame(int gameId);
        Task<Player> EnterGame(EnterGameDto EnterGameDto);
        Task<List<Player>> GetPlayers(int gameId);
        Task<Game> StartGame(int gameId);
        Task AnswerRiddle(AnswerRiddleDto answerRiddleDto);
        Task<List<Player>> GetGameResults(int gameId);
    }
}