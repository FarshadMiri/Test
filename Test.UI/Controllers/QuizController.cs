using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Test.Application.DTOs;
using Test.Application.Services;
using Test.UI.Models.ViewModels.Quiz;
using Test.UI.Models.ViewModels.User;

namespace Test.UI.Controllers
{
    public class QuizController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;



        public QuizController(IQuestionService questionService, IAnswerService answerService, IMapper mapper)
        {
            _mapper = mapper;
            _questionService = questionService;
            _answerService = answerService;

        }


        public IActionResult Start()
        {
            return View();
        }

        // دریافت سوالات
        public async Task<IActionResult> GetQuestion(int index)
        {
            var questionsDtos = await _questionService.GetAllQuestion();
            var questionVM = _mapper.Map<List<ShowQuestionViewModel>>(questionsDtos);

            if (index < 0 || index >= questionVM.Count)
            {
                return NotFound();
            }

            var model = new QuizViewModel
            {
                Questions = questionVM,
                CurrentQuestionIndex = index
            };

            return PartialView("_QuestionPartial", model);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitAnswer([FromBody]SubmitAnswerViewModel sumbitAnswer)
        {
            if (ModelState.IsValid)
            {
               var answerDto=_mapper.Map<AnswerDto>(sumbitAnswer);
              
              

                _answerService.AddAnswer(answerDto);

                return Ok();
            }

            return BadRequest();
        }

        // پایان آزمون و نمایش نتیجه
        public IActionResult ShowResult()
        {
            return View(); // نمایش صفحه نتیجه
        }

        // هدایت پس از اتمام زمان آزمون
        public IActionResult Timeout()
        {
            return RedirectToAction("Start");
        }
    }
}
