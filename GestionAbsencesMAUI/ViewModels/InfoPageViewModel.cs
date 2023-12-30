using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using GestionAbsencesMAUI.Models;
using GestionAbsencesMAUI.Services;
using Microsoft.Maui.Controls;
using MvvmHelpers;


namespace GestionAbsencesMAUI.ViewModels
{
    public class InfoPageViewModel : BaseViewModel
    {
        private List<Module> modules;
        private List<Etudiant> etudiants;
        private int selectedModuleId;
        private int selectedEtudiantId;
        private string resultText;

        public ObservableCollection<string> ModuleOptions { get; set; }
        public ObservableCollection<string> EtudiantOptions { get; set; }

        public ICommand LoadModulesCommand { get; }
        public ICommand ModuleSelectedCommand { get; }
        public ICommand EtudiantSelectedCommand { get; }
        public ICommand AfficherAbsencesCommand { get; }

        public string ResultText
        {
            get => resultText;
            set => SetProperty(ref resultText, value);
        }

        public InfoPageViewModel()
        {
            ModuleOptions = new ObservableCollection<string>();
            EtudiantOptions = new ObservableCollection<string>();

            LoadModulesCommand = new Command(async () => await LoadModulesAsync());
            ModuleSelectedCommand = new Command<string>(async (moduleName) => await ModuleSelectedAsync(moduleName));
            EtudiantSelectedCommand = new Command<string>(EtudiantSelected);
            AfficherAbsencesCommand = new Command(AfficherAbsences);
        }

        private async Task LoadModulesAsync()
        {
            modules = await App.moduleServices.GetAllModulesAsync();
            ModuleOptions.Clear();
            foreach (var module in modules)
            {
                ModuleOptions.Add(module.Nom);
            }
        }

        private async Task ModuleSelectedAsync(string moduleName)
        {
            selectedModuleId = modules.Find(m => m.Nom == moduleName).Id;
            etudiants = await App.filiereModuleServices.GetEtudiantsInModule(selectedModuleId);
            EtudiantOptions.Clear();
            foreach (var etudiant in etudiants)
            {
                EtudiantOptions.Add($"{etudiant.Nom} {etudiant.Prenom}");
            }
        }

        private void EtudiantSelected(string etudiantName)
        {
            selectedEtudiantId = etudiants.Find(e => $"{e.Nom} {e.Prenom}" == etudiantName).Id;
        }

        private void AfficherAbsences()
        {
            
            var absences = App.absenceServices.GetAbsencesInModuleForStudent(selectedEtudiantId, selectedModuleId).Result;
            int nombreAbsences = absences.Count;

            ResultText = $"Nombre d'absences : {nombreAbsences}";
        }
    }
}
