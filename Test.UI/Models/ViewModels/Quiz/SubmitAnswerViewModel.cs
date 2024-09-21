namespace Test.UI.Models.ViewModels.Quiz
{
    public class SubmitAnswerViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int QuestionId { get; set; }
        public string UserAnswer { get; set; }

    }
}
