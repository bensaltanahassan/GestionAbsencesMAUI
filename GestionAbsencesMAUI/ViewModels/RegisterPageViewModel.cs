using GestionAbsencesMAUI.Models;
using GestionAbsencesMAUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencesMAUI.ViewModels
{
    internal class RegisterPageViewModel : BindableObject
    {
        private readonly ProfesseurServices _profService;
        public RegisterPageViewModel() {

            _profService = App.professeurServices;
            OnSignUpClickede = new Command(async () => await OnSignUpClicked());
            

        }

        public Command OnSignUpClickede { get; }


        private string nom;
        public string Nom
        {
            get { return nom; }
            set
            {
                nom = value;
                OnPropertyChanged(nameof(Nom));
            }
        }

        private string prenom;
        public string Prenom
        {
            get { return prenom; }
            set
            {
                prenom = value;
                OnPropertyChanged(nameof(Prenom));
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

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged(nameof(Phone));
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

        private async Task OnSignUpClicked()
        {
            // Get user input
            string professorFirstName = prenom;
            string professorLastName = nom;
            string professorEmail = email;
            string professorPhone = phone;
            string professorUsername = username;
            string professorPassword = password;

            // Validate input
            if (string.IsNullOrWhiteSpace(professorFirstName) ||
                string.IsNullOrWhiteSpace(professorLastName) ||
                string.IsNullOrWhiteSpace(professorEmail) ||
                string.IsNullOrWhiteSpace(professorPhone) ||
                string.IsNullOrWhiteSpace(professorUsername) ||
                string.IsNullOrWhiteSpace(professorPassword))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill in all fields.", "OK");
                return;
            }

            // Check if the professor already exists
            Professeur existingProfessor = await _profService.getProfesseurByUsername(professorUsername);

            if (existingProfessor != null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Username already exists.", "OK");
                return;
            }


            // If the professor does not exist, proceed with registration
            var newProfessor = new Models.Professeur
            {
                Prenom = professorFirstName,
                Nom = professorLastName,
                Email = professorEmail,
                Phone = professorPhone,
                Username = professorUsername,
                Password = professorPassword // You should hash the password for security
            };

            bool registrationSuccess = await _profService.ajouterProfesseur(newProfessor);

            if (registrationSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "Registration successful!", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Registration failed.", "OK");
            }
        }

    }
}
