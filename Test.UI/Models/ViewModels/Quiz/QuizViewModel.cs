using Test.UI.Models.ViewModels.User;

namespace Test.UI.Models.ViewModels.Quiz
{
    public class QuizViewModel
    {
        
        
            // لیست سوالات برای نمایش
            public List<ShowQuestionViewModel> Questions { get; set; }

            // ایندکس سوال فعلی که باید نمایش داده شود
            public int CurrentQuestionIndex { get; set; }
        
    }
}
