using victorina.Pages;

namespace victorina
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Level1), typeof(Level1));

            Routing.RegisterRoute(nameof(Level2), typeof(Level2));

            Routing.RegisterRoute(nameof(Level3), typeof(Level3));

            Routing.RegisterRoute(nameof(Level4), typeof(Level4));

            Routing.RegisterRoute(nameof(Level5), typeof(Level5));
        }

    }
}
