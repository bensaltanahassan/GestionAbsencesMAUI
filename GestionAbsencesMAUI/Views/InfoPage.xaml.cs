
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionAbsencesMAUI.Models;
using GestionAbsencesMAUI.Services;
using Microsoft.Maui.Controls;

namespace GestionAbsencesMAUI.Views
{
    public partial class InfoPage : ContentPage
    {
        private readonly ModuleServices _moduleServices;
        private readonly EtudiantService _etudiantService;
        private readonly AbsenceServices _absenceServices;
        List<Module> modules { get; set; }
        List<Etudiant> etudiants { get; set; }


        private int profId { get; set;}

        public InfoPage()
        {
            InitializeComponent();

            profId = Preferences.Get("profId", 1);
            _moduleServices = App.moduleServices;
            _etudiantService = App.etudiantService;
            _absenceServices = App.absenceServices;

            ModulePicker.SelectedIndexChanged += ModulePicker_SelectedIndexChanged;
            EtudiantPicker.SelectedIndexChanged += EtudiantPicker_SelectedIndexChanged;
            AfficherAbsencesButton.Clicked += AfficherAbsences_Clicked;

            LoadModulesAsync(); 
        }

        private async void LoadModulesAsync()
        {

            

            modules = await _moduleServices.GetModulesInProf(profId);

            ModulePicker.Items.Clear(); // Clear existing items

            foreach (var module in modules)
            {
                ModulePicker.Items.Add(module.Nom);
            }
        }

        private async void ModulePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            var selectedModuleName = ModulePicker.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedModuleName))
                return;

            var selectedModule = modules.FirstOrDefault(module => module.Nom == selectedModuleName);

            if (selectedModule != null)
            {
                etudiants = await _etudiantService.GetEtudiantsInModule(selectedModule.Id);
                EtudiantPicker.Items.Clear();
                foreach (var etudiant in etudiants)
                {
                    EtudiantPicker.Items.Add($"{etudiant.Nom} {etudiant.Prenom}");
                }
            }
        }

        private async void EtudiantPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private async void AfficherAbsences_Clicked(object sender, EventArgs e)
        {
            var selectedModuleName = ModulePicker.SelectedItem?.ToString();
            var selectedEtudiantName = EtudiantPicker.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedModuleName) || string.IsNullOrEmpty(selectedEtudiantName))
                return;

            var selectedModule= modules.FirstOrDefault(module => module.Nom == selectedModuleName);

            var selectedEtudiant = etudiants.FirstOrDefault(etudiant => $"{etudiant.Nom} {etudiant.Prenom}" == selectedEtudiantName);

            if (selectedModule != null && selectedEtudiant != null)
            {
                var absences = await _absenceServices.GetAbsencesInModuleForStudent(selectedEtudiant.Id, selectedModule.Id);

                // Counting the absences and presences
                var presencesCount = absences.Count(a => a.IsPresent == 1); 
                var absencesCount = absences.Count(a => a.IsPresent == 0); 

                ResultLabel.Text = $"Absent:    {absencesCount}\n";
                ResultLabel2.Text = $"Present: {presencesCount}";
            }

            ResultLabelFrame.IsVisible = true;
            ResultLabel2Frame.IsVisible = true;
        }

    }
}
