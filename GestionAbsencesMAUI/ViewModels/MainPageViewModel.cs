using GestionAbsencesMAUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencesMAUI.ViewModels
{
    public partial class MainPageViewModel : BindableObject
    {
        
        public Command OnGoToAbsencesPagesClickedCommand { get; }
        public Command OnGoToAddStudentPageClickedCommand { get; }
        public Command OnGoToStudentInfosPageClickedCommand { get; }
        public Command OnGoToSearchPageClickedCommand { get; }
        public Command OnLogoutClickedCommand { get; }

        INavigation Navigation { get; set; }


        public MainPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            OnLogoutClickedCommand = new Command(async () => await GoToLoginPage());
            OnGoToAbsencesPagesClickedCommand = new Command(async () => await GoToAbsencesPage());
            OnGoToAddStudentPageClickedCommand = new Command(async () => await GoToAddStudentPage());
            OnGoToStudentInfosPageClickedCommand = new Command(async () => await GoToStudentInfosPage());
            OnGoToSearchPageClickedCommand = new Command(async () => await GoToSearchPage());
        }





        async Task GoToAbsencesPage()
        {
            try
            {
                await Navigation.PushAsync(new AbsencesPage(), true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during navigation: {ex.Message}");
            }
        }

        async Task GoToAddStudentPage()
        {
            try
            {
                await Navigation.PushAsync(new StudentPage(), true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during navigation: {ex.Message}");
            }
            
            
        }

        async Task GoToStudentInfosPage()
        {
            try
            {
                await Navigation.PushAsync(new InfoPage(), true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during navigation: {ex.Message}");
            }
        }

        async Task GoToSearchPage()
        {
            try
            {
                await Navigation.PushAsync(new SearchPage(), true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during navigation: {ex.Message}");
            }
        }

        async Task GoToLoginPage()
        {
            try
            {
                Preferences.Clear();
                await Navigation.PopToRootAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during navigation: {ex.Message}");
            }
        }


    }





    
}
