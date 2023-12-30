using GestionAbsencesMAUI.Models;
using GestionAbsencesMAUI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencesMAUI.ViewModels
{
    
    public class AbsencesPageViewModel
    {

        public string? selectedDate;

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


        public List<Etudiant> etudiants { get; set; }

        public List<EtudiantAbsentModel> etudiantsAbsents { get; set; }


        public int profId { get; set; }

        public AbsencesPageViewModel()
        {
            InitializeViewModel();
            
        }

        public async Task InitializeViewModel()
        {
            await getModules();
        }

        public async Task getModules() {
            profId = 1; // test
            var data = await App.moduleServices.GetModulesInProf(profId);
            Modules = data.ToList();
            ModulesNames = new List<String>();
            foreach (var module in Modules)
            {
                ModulesNames.Add(module.Nom);
                Console.WriteLine("Module: " + module.Nom);
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
            await getEtudiantsInFiliere();


        }

        public async Task OnSelectedSessionChanged(string selectedSession)
        {
            if (selectedDate == "Add new session")
            {
            }
            else
            {
                Session session = sessions.FirstOrDefault(m => m.Date.ToString() == selectedSession)!;
                CurrentSession = session;
                var data = await App.absenceServices.GetAbsencesInSession(session.Id);
                absences = data.ToList();

                


            }
        }


        public void getEtudiantsAbsences() {
            etudiantsAbsents = new List<EtudiantAbsentModel>();
            foreach (var etudiant in etudiants)
            {
                EtudiantAbsentModel etudiantAbsent = new EtudiantAbsentModel();
                etudiantAbsent.etudiant = etudiant;
                etudiantAbsent.isAbsent = false;

                foreach (var absence in absences)
                {
                    if (absence.EtudiantId == etudiant.Id)
                    {
                        etudiantAbsent.isAbsent = true;
                    }
                }
                etudiantsAbsents.Add(etudiantAbsent);
            }
            foreach (var etudiant in etudiantsAbsents)
            {
                Console.WriteLine("Etudiant: " + etudiant.etudiant.Nom + " is absent: " + etudiant.isAbsent);
            }
        }




        public async Task addSessionToDb(string date)
        {
            Session session = new Session
            {
                Date = date,
                FiliereModuleId = CurrentFiliere!.Id,
            };
            await App.sessionServices.addSession(session);
        }

        public async Task addAbsenceToDb(int etudiantId)
        {
            Absence absence = new Absence
            {
                EtudiantId = etudiantId,
                SessionId = CurrentSession!.Id,
            };
            await App.absenceServices.addAbsence(absence);
        }

        public async Task getEtudiantsInFiliere()
        {
            var data = await App.etudiantService.getEtudiantsInFiliere(CurrentFiliere!.Id);
            if(data == null)
            {
                etudiants = new List<Etudiant>();
            }
            else
            {
                etudiants = data.ToList();
            }
           

            foreach (var etudiant in etudiants)
            {
                Console.WriteLine("Etudiant: " + etudiant.Nom);
            }
        }

    }
}
