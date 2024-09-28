using WhoKnowsApp.APIClient.Endpoints.Interfaces;
using WhoKnowsApp.Shared.Models;

namespace WhoKnowsApp.APIClient.Endpoints
{
    public class QuestionEndpoints : BaseEndpoint, IQuestionEndpoints
    {
        public QuestionEndpoints(IHttpClientFactory httpClientFactory) : base(httpClientFactory, "Question") { }

        public async Task<List<Question>> GetQuestions() => await HandleJsonResponse<List<Question>>(await _apiHttpClient.GetAsync($"{GetMethodName()}"));
    }
}
