using System;
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
        public Command AfficherTousLesEtudiantsCommand { get; }

        public ObservableCollection<Etudiant> ListeDesEtudiants { get; set; }

        public StudentPageViewModel()
        {
            _etudiantService = App.etudiantService;
            AjouterEtudiantCommand = new Command(async () => await AjouterEtudiant());
            AfficherTousLesEtudiantsCommand = new Command(AfficherTousLesEtudiants);
            ListeDesEtudiants = new ObservableCollection<Etudiant>();
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
                filiereId = int.Parse(FiliereIdEntry)
            };

            bool ajoutReussi = await _etudiantService.ajouterEtudiant(etudiant);

            if (ajoutReussi)
            {
                await Application.Current.MainPage.DisplayAlert("Succès", "Étudiant ajouté avec succès.", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", "Échec de l'ajout de l'étudiant.", "OK");
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

        private async void AfficherTousLesEtudiants()
        {
            var tousLesEtudiants = await _etudiantService.getAllEtudiants();

            if (tousLesEtudiants != null)
            {
                ListeDesEtudiants.Clear();
                foreach (var etudiant in tousLesEtudiants)
                {
                    ListeDesEtudiants.Add(etudiant);
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", "Impossible de récupérer la liste des étudiants.", "OK");
            }
        }
    }
}
