
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

        public InfoPage()
        {
            InitializeComponent();
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
           
            var modules = await _moduleServices.GetAllModulesAsync();

            
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

            var selectedModule = (await _moduleServices.GetAllModulesAsync())
                .FirstOrDefault(module => module.Nom == selectedModuleName);

            if (selectedModule != null)
            {
                
                var etudiants = await _etudiantService.GetEtudiantsInModule(selectedModule.Id);

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

            var selectedModule = (await _moduleServices.GetAllModulesAsync())
                .FirstOrDefault(module => module.Nom == selectedModuleName);

            var selectedEtudiant = (await _etudiantService.getAllEtudiants())
                .FirstOrDefault(etudiant => $"{etudiant.Nom} {etudiant.Prenom}" == selectedEtudiantName);


            if (selectedModule != null && selectedEtudiant != null)
            {
                var absences = await _absenceServices.GetAbsencesInModuleForStudent(selectedEtudiant.Id, selectedModule.Id);

                
                var presences = absences.Count(a => a.IsPresent == 1); // Supposant que 1 signifie "présent" dans notre modèle Abscence

                ResultLabel.Text = $"Absent:    {absences.Count}\n";
                ResultLabel2.Text = $"Present: {presences}";
            }

            ResultLabelFrame.IsVisible = true;
            ResultLabel2Frame.IsVisible = true;
        }
    }
}
