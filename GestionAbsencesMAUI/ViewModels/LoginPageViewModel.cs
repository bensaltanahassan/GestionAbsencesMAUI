using GestionAbsencesMAUI.Models;
using GestionAbsencesMAUI.Services;
using GestionAbsencesMAUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencesMAUI.ViewModels
{
    public partial class LoginPageViewModel : BindableObject
    {
        private readonly ProfesseurServices _profService;

       

        public LoginPageViewModel()
        {
            _profService = App.professeurServices;
            OnLoginClickede = new Command(async () => await OnLoginClicked());
            OnRegisterClickedCommand = new Command(async () => await OnRegisterClicked());
             HandleLoginMiddlware();
        }
        public async Task HandleLoginMiddlware()
        {
            if (Preferences.Get("profLoggedIn", false))
            {
                try
                {
                    await Shell.Current.GoToAsync(nameof(MainPageChoices));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during navigation: {ex.Message}");
                }
            }
        }


        public Command OnLoginClickede { get; }
        public Command OnRegisterClickedCommand { get; }

        private async Task OnLoginClicked()
        {
            // Get user input
            string professorUsername = username;
            string professorPassword = password;

            // Validate input
            if (string.IsNullOrWhiteSpace(professorUsername) || string.IsNullOrWhiteSpace(professorPassword))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill in all fields.", "OK");
                return;
            }

            // Check authentication against the database using ProfesseurServices
            bool isAuthenticated = await _profService.AuthenticateProfessorAsync(professorUsername, professorPassword);

            if (isAuthenticated)
            {
                // Successful login logic (navigate to another page, etc.)
                await Application.Current.MainPage.DisplayAlert("Success", "Login successful!", "OK");
                try
                {
                    Professeur p = await _profService.getProfesseurByUsername(professorUsername);
                    Preferences.Set("profLoggedIn", true);
                    Preferences.Set("profId", p.Id);
                    Preferences.Set("profUsername", p.Username);
                    Preferences.Set("profPassword", p.Password);
                    Preferences.Set("profNom", p.Nom);
                    Preferences.Set("profPrenom", p.Prenom);
                    Preferences.Set("profEmail", p.Email);
                    Preferences.Set("profPhone", p.Phone);
                    await Shell.Current.GoToAsync(nameof(MainPageChoices));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during navigation: {ex.Message}");
                }
               
            }
            else
            {
                // Authentication failed
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid credentials.", "OK");
            }
        }

        private async Task OnRegisterClicked()
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(RegisterPage));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during navigation: {ex.Message}");
            }
        }


        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

       

    }
}
