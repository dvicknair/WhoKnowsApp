using Microsoft.AspNetCore.Mvc;
using WhoKnowsApp.Shared.Models;

namespace WhoKnowsApp.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestionController : BaseController<QuestionController>
    {
        public QuestionController()
        {
        }

        [HttpGet]
        public IActionResult GetQuestions() => Ok(new List<Question> { new Question { Name = "Test" } });
    }
}
