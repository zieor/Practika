using victorina;

namespace victorina;

public partial class Level1 : ContentPage
{
    private Border _lastClickedQuestionButton;
    private string _correctAnswer = "";

    public Level1()
    {
        InitializeComponent();
    }

    private void OnOpenQuizClicked(object sender, EventArgs e)
    {
        _lastClickedQuestionButton = sender as Border;

        if (_lastClickedQuestionButton?.GestureRecognizers.FirstOrDefault() is TapGestureRecognizer recognizer)
        {
            if (recognizer.CommandParameter is string rawData)
            {
                string[] parts = rawData.Split('|');
                if (parts.Length == 5)
                {
                    QuestionLabel.Text = parts[0];

                    AnswerBtnA.Text = "А) " + parts[1];
                    AnswerBtnA.CommandParameter = parts[1];

                    AnswerBtnB.Text = "Б) " + parts[2];
                    AnswerBtnB.CommandParameter = parts[2];

                    AnswerBtnC.Text = "В) " + parts[3];
                    AnswerBtnC.CommandParameter = parts[3];

                    _correctAnswer = parts[4];

                    QuizModal.IsVisible = true;
                }
            }
        }
    }

    private async void OnAnswerClicked(object sender, EventArgs e)
    {
        var answerButton = (Button)sender;
        string selectedAnswer = answerButton.CommandParameter?.ToString() ?? "";

        QuizModal.IsVisible = false;

        if (selectedAnswer == _correctAnswer)
        {
            if (_lastClickedQuestionButton != null)
            {
                _lastClickedQuestionButton.BackgroundColor = Colors.Green;

                _lastClickedQuestionButton.GestureRecognizers.Clear();
            }
            await DisplayAlert("Правильно!", "Отличный результат!", "Ура");
        }
        else
        {
            if (_lastClickedQuestionButton != null)
            {
                _lastClickedQuestionButton.BackgroundColor = Colors.Red;
                _lastClickedQuestionButton.GestureRecognizers.Clear();
            }
            await DisplayAlert("Неверно", $"Правильный ответ: {_correctAnswer}", "ОК");
        }
    }
}