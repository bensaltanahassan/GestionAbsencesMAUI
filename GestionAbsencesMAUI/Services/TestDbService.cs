using GestionAbsencesMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencesMAUI.Services
{
    internal class TestDbService
    {
        public async Task insertInitialStudents()
        {

            List<Etudiant> etudiants = new List<Etudiant>();

            etudiants.Add(new Etudiant
            {
                Cne = "CNE1",
                Nom = "Bensaltana",
                Prenom = "hassan",
                Email = "bensaltanahassan@email.com",
                Phone = "0612345678",
                filiereId = 1
            });
            etudiants.Add(new Etudiant
            {
                Cne = "CNE2",
                Nom = "Hasna",
                Prenom = "Anas",
                Email = "hasnaanas@email.com",
                Phone = "0612910291",
                filiereId = 2
            });
            etudiants.Add(new Etudiant
            {
                Cne = "CNE3",
                Nom = "Benmoussa",
                Prenom = "Salma",
                Email = "Benmoussasalma@email.com",
                Phone = "0688228833",
                filiereId = 3
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE4",
                Nom = "Daoudi",
                Prenom = "Oumaima",
                Email = "Oumaimadaoudi@email.com",
                Phone = "0688228833",
                filiereId = 1
            });



            foreach (var etudiant in etudiants)
            {
                await App.etudiantService.ajouterEtudiant(etudiant);
            }


        }

        public async Task insertInitialProfs()
        {
            List<Professeur> professeurs = new List<Professeur>();

            professeurs.Add(new Professeur
            {
                Nom = "Professeur1",
                Prenom = "Professeur1",
                Email = "prof1@mail.com",
                Phone = "0612345678",
                Username = "prof1",
                Password = "prof1"
            });
            professeurs.Add(new Professeur
            {
                Nom = "Professeur2",
                Prenom = "Professeur2",
                Email = "prof2@mail.com",
                Phone = "0612345678",
                Username = "prof2",
                Password = "prof2"
            });
            foreach (var professeur in professeurs)
            {
                await App.professeurServices.ajouterProfesseur(professeur);
            }

        }

        public async Task insertInitialFilieres()
        {
            List<Filiere> filieres = new List<Filiere>();

            filieres.Add(new Filiere
            {
                Nom = "Filiere1",
            });
            filieres.Add(new Filiere
            {
                Nom = "Filiere2",
            });
            filieres.Add(new Filiere
            {
                Nom = "Filiere3",
            });
            foreach (var filiere in filieres)
            {
                await App.filiereServices.addFiliere(filiere);
            }
        }

        public async Task insertInitialModules()
        {
            List<Module> modules = new List<Module>();

            modules.Add(new Module
            {
                Nom = "Module1",
                NbrHeure = 20,
                ProfesseurId = 1
            });
            modules.Add(new Module
            {
                Nom = "Module2",
                NbrHeure = 20,
                ProfesseurId = 2
            });
            modules.Add(new Module
            {
                Nom = "Module3",
                NbrHeure = 20,
                ProfesseurId = 1
            });


            foreach (var module in modules)
            {
                await App.moduleServices.addModule(module);
            }
        }

        public async Task inserInitialFiliereModule()
        {
            List<FiliereModule> filiereModules = new List<FiliereModule>();

            filiereModules.Add(new FiliereModule
            {
                FiliereId = 1,
                ModuleId = 1
            });
            filiereModules.Add(new FiliereModule
            {
                FiliereId = 1,
                ModuleId = 2
            });
            filiereModules.Add(new FiliereModule
            {
                FiliereId = 2,
                ModuleId = 1
            });
            filiereModules.Add(new FiliereModule
            {
                FiliereId = 2,
                ModuleId = 2
            });
            filiereModules.Add(new FiliereModule
            {
                FiliereId = 3,
                ModuleId = 3
            });

            foreach (var filiereModule in filiereModules)
            {
                await App.filiereModuleServices.addFiliereModule(filiereModule);
            }
        }
       
        public async Task insertInitialData()
        {
            await insertInitialFilieres();
            await insertInitialProfs();
            await insertInitialModules();
            await inserInitialFiliereModule();
            await insertInitialStudents();
            Console.WriteLine("Initial data inserted");
        }

    }
}
