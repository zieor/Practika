using victorina.Pages;

namespace victorina;

public partial class Level1 : ContentPage
{
	public Level1()
	{
		InitializeComponent();
	}

    private void OnOpenQuizClicked(object sender, EventArgs e)
    {
        QuizModal.IsVisible = true;
    }

    private async void OnAnswerClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        string selectedAnswer = button.CommandParameter?.ToString() ?? "";

        QuizModal.IsVisible = false;

        if (selectedAnswer == "8 планет")
        {
            await DisplayAlert("Правильно!", "Отличный результат!", "Ура");
        }
        else
        {
            await DisplayAlert("Неверно", $"Вы выбрали: {selectedAnswer}.", "ОК");
        }
    }
}
