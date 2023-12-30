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
        public EtudiantAbsentModel etudiantStatus { get; set; }

        public List<Etudiant> etudiants { get; set; }
        public List<EtudiantAbsentModel> etudiantsStatus { get; set; }
        

        public int profId { get; set; }
        public string cne { get; set; }

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

            //get the etudiants in the filiere
            await getEtudiantsInFiliere();
        }
        public async Task getEtudiantsInFiliere()
        {
            var data = await App.etudiantService.getEtudiantsInFiliere(CurrentFiliere!.Id);
            if (data == null)
            {
                etudiants = new List<Etudiant>();
            }
            else
            {
                etudiants = data.ToList();
            }
        }
        public async Task getEtudiantInFiliere()
        {
            etudiant = await App.etudiantService.getEtudiantInFiliereByCne(CurrentFiliere!.Id,cne);
        }
        public async Task OnSelectedSessionChanged()
        {
            
            Session session = sessions.FirstOrDefault(m => m.Date.ToString() == selectedDate)!;
            CurrentSession = session;
            var data = await App.absenceServices.GetAbsencesInSession(session.Id);
            absences = data.ToList();

            
            getEtudiantsStatus();
            etudiantStatus = etudiantsStatus.FirstOrDefault(m => m.etudiant.Cne == cne);
            if (etudiantStatus == null)
            {
                etudiant = null;
            }
            else
            {
                etudiant = etudiantStatus.etudiant;
            }
        }
        public void getEtudiantsStatus()
        {
            etudiantsStatus = new List<EtudiantAbsentModel>();
            foreach (var etudiant in etudiants)
            {
                EtudiantAbsentModel etudiantAbsent = new EtudiantAbsentModel();
                etudiantAbsent.etudiant = etudiant;
                etudiantAbsent.isPresent = false;
                foreach (var absence in absences)
                {
                    if (absence.EtudiantId == etudiant.Id)
                    {
                        if (absence.IsPresent == 1)
                        {
                            etudiantAbsent.isPresent = true;
                        }
                        else
                        {
                            etudiantAbsent.isPresent = false;
                        }
                    }
                }
                etudiantsStatus.Add(etudiantAbsent);
            }

        }




    }
        
}
