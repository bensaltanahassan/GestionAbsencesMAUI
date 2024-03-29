﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GestionAbsencesMAUI.Models;
using GestionAbsencesMAUI.Services;
using Microsoft.Maui.Controls;

namespace GestionAbsencesMAUI.ViewModels
{
    public class StudentPageViewModel : BindableObject
    {
        private readonly EtudiantService _etudiantService;
        public Command BackToMainPageCmnd { get; }

        public ObservableCollection<Etudiant> ListeDesEtudiants { get; set; }

        private INavigation _navigation;

 
        private ObservableCollection<Filiere> _filieres;
        public ObservableCollection<Filiere> Filieres
        {
            get => _filieres;
            set
            {
                _filieres = value;
                OnPropertyChanged(nameof(Filieres));
            }
        }

        private Filiere _selectedFiliere;
        public Filiere SelectedFiliere
        {
            get => _selectedFiliere;
            set
            {
                _selectedFiliere = value;
                OnPropertyChanged(nameof(SelectedFiliere));
            }
        }

      
        private async Task LoadFilieres()
        {
            var filieres = await App.filiereServices.GetFilieresAsync();
            Filieres = new ObservableCollection<Filiere>(filieres);
        }

        public StudentPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _etudiantService = App.etudiantService;
            AjouterEtudiantCommand = new Command(async () => await AjouterEtudiant());
            BackToMainPageCmnd = new Command(BackToMainPage);
            ListeDesEtudiants = new ObservableCollection<Etudiant>();
            Task.Run(async () => await LoadFilieres());
        }

        public Command AjouterEtudiantCommand { get; }

        private async Task AjouterEtudiant()
        {
            var etudiant = new Etudiant
            {
                Cne = CneEntry,
                Nom = NomEntry,
                Prenom = PrenomEntry,
                Email = EmailEntry,
                Phone = PhoneEntry,
                filiereId = SelectedFiliere?.Id ?? 0
            };

            bool ajoutReussi = await _etudiantService.ajouterEtudiant(etudiant);

            if (ajoutReussi)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "Student added successfully.", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error in added student", "OK");
            }
        }

        private string _cneEntry;
        public string CneEntry
        {
            get { return _cneEntry; }
            set
            {
                _cneEntry = value;
                OnPropertyChanged(nameof(CneEntry));
            }
        }

        private string _nomEntry;
        public string NomEntry
        {
            get { return _nomEntry; }
            set
            {
                _nomEntry = value;
                OnPropertyChanged(nameof(NomEntry));
            }
        }

        private string _prenomEntry;
        public string PrenomEntry
        {
            get { return _prenomEntry; }
            set
            {
                _prenomEntry = value;
                OnPropertyChanged(nameof(PrenomEntry));
            }
        }

        private string _emailEntry;
        public string EmailEntry
        {
            get { return _emailEntry; }
            set
            {
                _emailEntry = value;
                OnPropertyChanged(nameof(EmailEntry));
            }
        }

        private string _phoneEntry;
        public string PhoneEntry
        {
            get { return _phoneEntry; }
            set
            {
                _phoneEntry = value;
                OnPropertyChanged(nameof(PhoneEntry));
            }
        }

        private string _filiereIdEntry;
        public string FiliereIdEntry
        {
            get { return _filiereIdEntry; }
            set
            {
                _filiereIdEntry = value;
                OnPropertyChanged(nameof(FiliereIdEntry));
            }
        }

        private async void BackToMainPage()
        {
            await _navigation.PopAsync();
        }
    }
}
