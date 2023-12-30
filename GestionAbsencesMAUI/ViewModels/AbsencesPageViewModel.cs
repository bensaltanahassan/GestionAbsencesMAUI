﻿using GestionAbsencesMAUI.Models;
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


        public List<Etudiant> etudiants { get; set; }

        public List<EtudiantAbsentModel> etudiantsStatus { get; set; }


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

        public async Task OnSelectedSessionChanged()
        {
            if (selectedDate == "Add new session")
            {
                absences = new List<Absence>();
                getEtudiantsStatus();
            }
            else
            {
                Session session = sessions.FirstOrDefault(m => m.Date.ToString() == selectedDate)!;
                CurrentSession = session;
                var data = await App.absenceServices.GetAbsencesInSession(session.Id);
                absences = data.ToList();
                getEtudiantsStatus();
            }
        }
        public void getEtudiantsStatus() {
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
                        if (absence.IsPresent==1)
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
        }

        public async Task saveInfoToDb() {
            if (selectedDate == "Add new session" && formattedDate!=null )
            {
                if (CurrentSession!=null
                    && CurrentSession.Date==formattedDate 
                    && CurrentSession.FiliereModuleId==CurrentFiliereModule!.Id)
                {
                    foreach (var etudiant in etudiantsStatus)
                    {
                        await addAbsenceToDb(etudiant.etudiant.Id);
                    }
                    return;
                }
                //add new session
                var newSession = new Session
                {
                    Date = formattedDate!,
                    FiliereModuleId = CurrentFiliereModule!.Id,
                };
                var respAddSession = await App.sessionServices.addSession(newSession);
                //add absences
                if (respAddSession.Id != 0)
                {
                    CurrentSession = respAddSession;
                    foreach (var etudiant in etudiantsStatus)
                    {
                        await addAbsenceToDb(etudiant.etudiant.Id);
                    }
                }
            }
            else {
                foreach (var etudiant in etudiantsStatus)
                {
                    await addAbsenceToDb(etudiant.etudiant.Id);
                }
            }
        }

    }
}
