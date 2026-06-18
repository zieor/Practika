namespace victorina;

public partial class Level1 : ContentPage
{
	public Level1()
	{
		InitializeComponent();
	}
    async void OnActionSheetCancelDeleteClicked(object sender, EventArgs e)
    {
        var questionPage = new QuestionPage();

        await Navigation.PushModalAsync(questionPage);
    }

}