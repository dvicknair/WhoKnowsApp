using WhoKnowsApp.Shared.Models;

namespace WhoKnowsApp.APIClient.Endpoints.Interfaces
{
    public interface IQuestionEndpoints
    {
        Task<List<Question>> GetQuestions();
    }
}