namespace victorina.Pages;

public partial class Level6 : ContentPage
{
    private Border _lastClickedQuestionButton;
    private string _correctAnswer = "";

    public Level6()
    {
        InitializeComponent();
    }

    private void OnOpenQuizClicked(object sender, TappedEventArgs e)
    {
        _lastClickedQuestionButton = sender as Border;

        if (_lastClickedQuestionButton?.GestureRecognizers.FirstOrDefault() is TapGestureRecognizer recognizer)
        {
            if (recognizer.CommandParameter is string rawData)
            {
                string[] parts = rawData.Split('|');

                // Минимум 5 частей: вопрос, 3 варианта, правильный ответ
                if (parts.Length >= 5)
                {
                    QuestionLabel.Text = parts[0];

                    AnswerBtnA.Text = "А) " + parts[1];
                    AnswerBtnA.CommandParameter = parts[1];

                    AnswerBtnB.Text = "Б) " + parts[2];
                    AnswerBtnB.CommandParameter = parts[2];

                    AnswerBtnC.Text = "В) " + parts[3];
                    AnswerBtnC.CommandParameter = parts[3];

                    _correctAnswer = parts[4];

                    // Обработка картинки (6-й параметр)
                    if (parts.Length >= 6 && !string.IsNullOrWhiteSpace(parts[5]))
                    {
                        string imageName = parts[5].Trim();
                        QuestionImage.Source = ImageSource.FromFile(imageName);
                        QuestionImage.IsVisible = true;
                    }
                    else
                    {
                        QuestionImage.IsVisible = false;
                    }

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