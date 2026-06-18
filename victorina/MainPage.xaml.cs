using victorina.Pages;

namespace victorina
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked1(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Level1));
        }

        private async void Button_Clicked2(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Level2));
        }

        private async void Button_Clicked3(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Level3));
        }

        private async void Button_Clicked4(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Level4));
        }

        private async void Button_Clicked5(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Level5));
        }


    }
}
