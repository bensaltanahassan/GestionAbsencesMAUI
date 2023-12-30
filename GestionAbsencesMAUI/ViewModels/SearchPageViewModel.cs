using GestionAbsencesMAUI.Models;
using GestionAbsencesMAUI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencesMAUI.ViewModels
{
    public class SearchPageViewModel
    {
        public string? selectedDate;
        public string? formattedDate;

        Module? CurrentModule { get; set; }
        Filiere? CurrentFiliere { get; set; }
        FiliereModule? CurrentFiliereModule { get; set; }
        Session? CurrentSession { get; set; }

        public List<Module> Modules { get; set; }
        public List<String> ModulesNames { get; set; }

        public List<Filiere> filieres { get; set; }
        public List<String> filieresNames { get; set; }

        public List<Session> sessions { get; set; }
        public List<String> sessionsDates { get; set; }

        public List<Absence> absences { get; set; }

        public Etudiant etudiant { get; set; }

        public List<EtudiantAbsentModel> etudiantsStatus { get; set; }

        public int profId { get; set; }

        public SearchPageViewModel()
        {
            InitializeViewModel();
        }
        public async Task InitializeViewModel()
        {
            await getModules();
        }
        public async Task getModules()
        {
            profId = 1; // test
            var data = await App.moduleServices.GetModulesInProf(profId);
            Modules = data.ToList();
            ModulesNames = new List<String>();
            foreach (var module in Modules)
            {
                ModulesNames.Add(module.Nom);
            }
        }
        public async Task OnSelectedModuleChanged(string selectedModule)
        {
            Module module = Modules.FirstOrDefault(m => m.Nom == selectedModule)!;
            CurrentModule = module;
            var data = await App.filiereModuleServices.GetFilieresThatHaveModule(module.Id);
            filieres = data.ToList();
            filieresNames = new List<String>();
            foreach (var filiere in filieres)
            {
                filieresNames.Add(filiere.Nom);
            }

        }
        public async Task OnSelectedFiliereChanged(string selectedModule)
        {
            Filiere filiere = filieres.FirstOrDefault(m => m.Nom == selectedModule)!;
            CurrentFiliere = filiere;
            var fm = await App.filiereModuleServices.getFiliereModule(CurrentModule!.Id, filiere.Id);
            CurrentFiliereModule = fm;

            //get the sessions of the filiereModule
            var data = await App.sessionServices.GetSessionByFiliereModuleAsync(fm);
            sessions = data.ToList();
            sessionsDates = new List<String>();
            foreach (var session in sessions)
            {
                sessionsDates.Add(session.Date.ToString());
            }
            sessionsDates.Add("Add new session");

            //get the etudiants in the filiere
            await getEtudiantInFiliere();
        }
        public async Task getEtudiantInFiliere()
        {
            var data = await App.etudiantService.getEtudiantsInFiliere(CurrentFiliere!.Id);
            if (data == null)
            {
                etudiant = new Etudiant();
            }
            else
            {
                etudiant = data;
            }
        }
    }
}
