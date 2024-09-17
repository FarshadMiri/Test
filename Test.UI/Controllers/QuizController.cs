using Microsoft.AspNetCore.Mvc;

namespace Test.UI.Controllers
{
    public class QuizController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("StartQuiz");
        }
        public async Task<IActionResult> StartQuiz()
        {
            return View();
        }

    }
}
