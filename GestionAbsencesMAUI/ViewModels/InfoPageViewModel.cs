using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GestionAbsencesMAUI.Models;
using GestionAbsencesMAUI.Services;
using Microsoft.Maui.Controls;

namespace GestionAbsencesMAUI.ViewModels
{
    public class InfoPageViewModel : INotifyPropertyChanged
    {
        private readonly ModuleServices _moduleServices;
        private readonly EtudiantService _etudiantService;
        private readonly AbsenceServices _absenceServices;

        private int profId;

        private ObservableCollection<string> _moduleItems;
        public ObservableCollection<string> ModuleItems
        {
            get { return _moduleItems; }
            set
            {
                _moduleItems = value;
                OnPropertyChanged(nameof(ModuleItems));
            }
        }

        private ObservableCollection<string> _etudiantItems;
        public ObservableCollection<string> EtudiantItems
        {
            get { return _etudiantItems; }
            set
            {
                _etudiantItems = value;
                OnPropertyChanged(nameof(EtudiantItems));
            }
        }

        private string _selectedModule;
        public string SelectedModule
        {
            get { return _selectedModule; }
            set
            {
                _selectedModule = value;
                OnPropertyChanged(nameof(SelectedModule));
                LoadEtudiantsAsync();
            }
        }

        private string _selectedEtudiant;
        public string SelectedEtudiant
        {
            get { return _selectedEtudiant; }
            set
            {
                _selectedEtudiant = value;
                OnPropertyChanged(nameof(SelectedEtudiant));
            }
        }

        private string _resultLabel;
        public string ResultLabel
        {
            get { return _resultLabel; }
            set
            {
                _resultLabel = value;
                OnPropertyChanged(nameof(ResultLabel));
            }
        }

        private string _resultLabel2;
        public string ResultLabel2
        {
            get { return _resultLabel2; }
            set
            {
                _resultLabel2 = value;
                OnPropertyChanged(nameof(ResultLabel2));
            }
        }

        public ICommand ShowAttendanceStatusCommand { get; private set; }

        public InfoPageViewModel()
        {
            _moduleServices = App.moduleServices;
            _etudiantService = App.etudiantService;
            _absenceServices = App.absenceServices;

            profId = Preferences.Get("profId", 1);

            LoadModulesAsync();

            ShowAttendanceStatusCommand = new Command(async () => await ShowAttendanceStatusAsync());
        }

        private async void LoadModulesAsync()
        {
            var modules = await _moduleServices.GetModulesInProf(profId);
            ModuleItems = new ObservableCollection<string>(modules.Select(module => module.Nom));
        }

        private async void LoadEtudiantsAsync()
        {
            var selectedModule = ModuleItems.FirstOrDefault(module => module == SelectedModule);
            if (string.IsNullOrEmpty(selectedModule))
                return;

            var module = (await _moduleServices.GetModulesInProf(profId)).FirstOrDefault(m => m.Nom == selectedModule);
            if (module != null)
            {
                var etudiants = await _etudiantService.GetEtudiantsInModule(module.Id);
                EtudiantItems = new ObservableCollection<string>(etudiants.Select(etudiant => $"{etudiant.Nom} {etudiant.Prenom}"));
            }
        }

        private async Task ShowAttendanceStatusAsync()
        {
            var selectedModule = ModuleItems.FirstOrDefault(module => module == SelectedModule);
            var selectedEtudiant = EtudiantItems.FirstOrDefault(etudiant => etudiant == SelectedEtudiant);

            if (string.IsNullOrEmpty(selectedModule) || string.IsNullOrEmpty(selectedEtudiant))
                return;

            var module = (await _moduleServices.GetModulesInProf(profId)).FirstOrDefault(m => m.Nom == selectedModule);
            var etudiant = (await _etudiantService.GetEtudiantsInModule(module.Id)).FirstOrDefault(e => $"{e.Nom} {e.Prenom}" == selectedEtudiant);

            if (module != null && etudiant != null)
            {
                var absences = await _absenceServices.GetAbsencesInModuleForStudent(etudiant.Id, module.Id);

                var presencesCount = absences.Count(a => a.IsPresent == 1);
                var absencesCount = absences.Count(a => a.IsPresent == 0);

                ResultLabel = $"Absent: {absencesCount}\n";
                ResultLabel2 = $"Present: {presencesCount}";

                MessagingCenter.Send(this, "ShowFramesMessage");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
