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

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> SubmitAnswer([FromBody] SubmitAnswerViewModel submitAnswer)
        {
            if (ModelState.IsValid)
            {
                submitAnswer.UserId = 1; // باید UserId کاربر را به‌درستی از context دریافت کنید.
                var existingAnswer = await _answerService.GetAnswerByQuestionIdAndUserId(submitAnswer.QuestionId, submitAnswer.UserId);

                if (existingAnswer != null)
                {
                    // اگر پاسخی قبلاً داده شده، آن را آپدیت کنید
                    existingAnswer.UserAnswer = submitAnswer.UserAnswer;

                    // نیازی به Update نیست، چون موجودیت از قبل در حال ردیابی است
                    await _answerService.UpdateAnswer(existingAnswer);
                }
                else
                {
                    // در غیر اینصورت، پاسخ جدید اضافه کنید
                    var answerDto = _mapper.Map<AnswerDto>(submitAnswer);
                    _answerService.AddAnswer(answerDto);
                }

                return Ok();
            }

            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetAnswer(int questionId)
        {
            var userId = 1; // اینجا باید UserId کاربر را دریافت کنید
            var answer = await _answerService.GetAnswerByQuestionIdAndUserId(questionId, userId);

            if (answer == null)
            {
                return Ok(new { userAnswer = "" }); // اگر پاسخی نباشد، پاسخ خالی برگردانید
            }

            return Ok(new
            {
                userAnswer = answer.UserAnswer
            });
        }
        // پایان آزمون و نمایش نتیجه
        public async Task<IActionResult> ShowResult()
        {
            int userId = 1; // باید userId کاربر فعلی را از context یا session دریافت کنید

            // دریافت تمام پاسخ‌های کاربر از دیتابیس
            var answers = await _answerService.GetAnswersByUserId(userId);

            // محاسبه تعداد پاسخ‌های Yes و No
            var yesCount = answers.Count(a => a.UserAnswer == "Yes");
            var noCount = answers.Count(a => a.UserAnswer == "No");

            // تصمیم‌گیری بر اساس تعداد پاسخ‌ها
            string resultMessage = "";
            if (yesCount > noCount)
            {
                resultMessage = "شما برونگرا هستید!";
            }
            else if (noCount > yesCount)
            {
                resultMessage = "شما درونگرا هستید!";
            }
            else
            {
                resultMessage = "نتیجه‌گیری خاصی وجود ندارد!";
            }

            // ارسال پیام نتیجه به ویو
            ViewBag.ResultMessage = resultMessage;

            return View();
        }

        // هدایت پس از اتمام زمان آزمون
        public IActionResult Timeout()
        {
            return RedirectToAction("Start");
        }
    }
}
