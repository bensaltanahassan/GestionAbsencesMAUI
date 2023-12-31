using GestionAbsencesMAUI.Views;

namespace GestionAbsencesMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(MainPageChoices), typeof(MainPageChoices));
            Routing.RegisterRoute(nameof(AbsencesPage), typeof(AbsencesPage));
            Routing.RegisterRoute(nameof(StudentPage), typeof(StudentPage));
            Routing.RegisterRoute(nameof(InfoPage), typeof(InfoPage));
            Routing.RegisterRoute(nameof(SearchPage), typeof(SearchPage));

        }
    }
}
