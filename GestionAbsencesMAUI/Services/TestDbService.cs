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

            etudiants.Add(new Etudiant
            {
                Cne = "CNE5",
                Nom = "Belaabdouli",
                Prenom = "Meryem",
                Email = "Belaabdoulimeryem@email.com",
                Phone = "0688228833",
                filiereId = 2
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE6",
                Nom = "Amghar",
                Prenom = "Imad",
                Email = "Amgharimad@email.com",
                Phone = "0688228833",
                filiereId = 3
            });

            
            etudiants.Add(new Etudiant
            {
                Cne = "CNE7",
                Nom = "Banamouad",
                Prenom = "Mouad",
                Email = "Banamouad@email.com",
                Phone = "0688228833",
                filiereId = 1
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE8",
                Nom = "Abdallah",
                Prenom = "Samira",
                Email = "abdallah.samira@email.com",
                Phone = "0688338844",
                filiereId = 2
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE9",
                Nom = "El-Khoury",
                Prenom = "Yasmine",
                Email = "elkhoury.yasmine@email.com",
                Phone = "0688448855",
                filiereId = 3
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE10",
                Nom = "Bouhaddi",
                Prenom = "Karim",
                Email = "bouhaddi.karim@email.com",
                Phone = "0688558866",
                filiereId = 1
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE11",
                Nom = "Abed",
                Prenom = "Lina",
                Email = "abed.lina@email.com",
                Phone = "0688668877",
                filiereId = 2
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE12",
                Nom = "Cherif",
                Prenom = "Fatima",
                Email = "cherif.fatima@email.com",
                Phone = "0688778888",
                filiereId = 3
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE13",
                Nom = "Hamzaoui",
                Prenom = "Nadia",
                Email = "hamzaoui.nadia@email.com",
                Phone = "0688888999",
                filiereId = 1
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE14",
                Nom = "Saidi",
                Prenom = "Rachid",
                Email = "saidi.rachid@email.com",
                Phone = "0688999000",
                filiereId = 2
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE15",
                Nom = "El-Mansour",
                Prenom = "Amira",
                Email = "elmansour.amira@email.com",
                Phone = "0689000111",
                filiereId = 3
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE16",
                Nom = "Rahal",
                Prenom = "Salma",
                Email = "rahal.salma@email.com",
                Phone = "0689111222",
                filiereId = 1
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE17",
                Nom = "Talal",
                Prenom = "Ali",
                Email = "talal.ali@email.com",
                Phone = "0689222333",
                filiereId = 2
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE18",
                Nom = "Haddad",
                Prenom = "Layla",
                Email = "haddad.layla@email.com",
                Phone = "0689333444",
                filiereId = 3
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE19",
                Nom = "Ben-Ali",
                Prenom = "Hassan",
                Email = "benali.hassan@email.com",
                Phone = "0689444555",
                filiereId = 1
            });


            etudiants.Add(new Etudiant
            {
                Cne = "CNE20",
                Nom = "Fadel",
                Prenom = "Sofia",
                Email = "fadel.sofia@email.com",
                Phone = "0689555666",
                filiereId = 2
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE21",
                Nom = "Said",
                Prenom = "Amina",
                Email = "said.amina@email.com",
                Phone = "0689666777",
                filiereId = 3
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE22",
                Nom = "Hariri",
                Prenom = "Omar",
                Email = "hariri.omar@email.com",
                Phone = "0689777888",
                filiereId = 1
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE23",
                Nom = "Salim",
                Prenom = "Laila",
                Email = "salim.laila@email.com",
                Phone = "0689888999",
                filiereId = 2
            });


            etudiants.Add(new Etudiant
            {
                Cne = "CNE24",
                Nom = "Abdi",
                Prenom = "Nora",
                Email = "abdi.nora@email.com",
                Phone = "0689999000",
                filiereId = 3
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE25",
                Nom = "Hamdi",
                Prenom = "Yasmine",
                Email = "hamdi.yasmine@email.com",
                Phone = "0690000111",
                filiereId = 1
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE26",
                Nom = "Khader",
                Prenom = "Adam",
                Email = "khader.adam@email.com",
                Phone = "0690111222",
                filiereId = 2
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE27",
                Nom = "Khalil",
                Prenom = "Sara",
                Email = "khalil.sara@email.com",
                Phone = "0690222333",
                filiereId = 3
            });


            etudiants.Add(new Etudiant
            {
                Cne = "CNE28",
                Nom = "Ben Youssef",
                Prenom = "Imane",
                Email = "benyoussef.imane@email.com",
                Phone = "0690333444",
                filiereId = 1
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE29",
                Nom = "Rahmani",
                Prenom = "Omar",
                Email = "rahmani.omar@email.com",
                Phone = "0690444555",
                filiereId = 2
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE30",
                Nom = "Ali",
                Prenom = "Fatima",
                Email = "ali.fatima@email.com",
                Phone = "0690555666",
                filiereId = 3
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE31",
                Nom = "Hamid",
                Prenom = "Lina",
                Email = "hamid.lina@email.com",
                Phone = "0690666777",
                filiereId = 1
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE32",
                Nom = "Kadiri",
                Prenom = "Sami",
                Email = "kadiri.sami@email.com",
                Phone = "0690777888",
                filiereId = 2
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE33",
                Nom = "Farsi",
                Prenom = "Yara",
                Email = "farsi.yara@email.com",
                Phone = "0690888999",
                filiereId = 3
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE34",
                Nom = "Nasri",
                Prenom = "Amir",
                Email = "nasri.amir@email.com",
                Phone = "0690999000",
                filiereId = 1
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE35",
                Nom = "Sabbagh",
                Prenom = "Leila",
                Email = "sabbagh.leila@email.com",
                Phone = "0691000111",
                filiereId = 2
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE36",
                Nom = "Taleb",
                Prenom = "Amina",
                Email = "taleb.amina@email.com",
                Phone = "0691111222",
                filiereId = 3
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE37",
                Nom = "Cherif",
                Prenom = "Youssef",
                Email = "cherif.youssef@email.com",
                Phone = "0691222333",
                filiereId = 1
            });


            etudiants.Add(new Etudiant
            {
                Cne = "CNE38",
                Nom = "Abou",
                Prenom = "Lamia",
                Email = "abou.lamia@email.com",
                Phone = "0691333444",
                filiereId = 2
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE39",
                Nom = "Bouzidi",
                Prenom = "Khaled",
                Email = "bouzidi.khaled@email.com",
                Phone = "0691444555",
                filiereId = 3
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE40",
                Nom = "Fawzi",
                Prenom = "Nour",
                Email = "fawzi.nour@email.com",
                Phone = "0691555666",
                filiereId = 1
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE41",
                Nom = "Hachemi",
                Prenom = "Yasmina",
                Email = "hachemi.yasmina@email.com",
                Phone = "0691666777",
                filiereId = 2
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE42",
                Nom = "Idrissi",
                Prenom = "Sofiane",
                Email = "idrissi.sofiane@email.com",
                Phone = "0691777888",
                filiereId = 3
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE43",
                Nom = "Jabari",
                Prenom = "Amina",
                Email = "jabari.amina@email.com",
                Phone = "0691888999",
                filiereId = 1
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE44",
                Nom = "Khalifa",
                Prenom = "Samia",
                Email = "khalifa.samia@email.com",
                Phone = "0691999000",
                filiereId = 2
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE45",
                Nom = "Lahoud",
                Prenom = "Omar",
                Email = "lahoud.omar@email.com",
                Phone = "0692000111",
                filiereId = 3
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE46",
                Nom = "Mahmoud",
                Prenom = "Laila",
                Email = "mahmoud.laila@email.com",
                Phone = "0692111222",
                filiereId = 1
            });

            etudiants.Add(new Etudiant
            {
                Cne = "CNE47",
                Nom = "Najjar",
                Prenom = "Ali",
                Email = "najjar.ali@email.com",
                Phone = "0692222333",
                filiereId = 2
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
                Nom = "Ouarrachi",
                Prenom = "Meryem",
                Email = "Ouarrachi.meryem@email.com",
                Phone = "0612345678",
                Username = "ouarrachi",
                Password = "ouarrachi"
            });
            professeurs.Add(new Professeur
            {
                Nom = "Belcaid",
                Prenom = "Anas",
                Email = "Belcaid.anas@email.com",
                Phone = "0612345678",
                Username = "belcaid",
                Password = "belcaid"
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
                Nom = "GI",
            });
            filieres.Add(new Filiere
            {
                Nom = "AI",
            });
            filieres.Add(new Filiere
            {
                Nom = "GTR",
            });
            foreach (var filiere in filieres)
            {
                await App.filiereServices.addFiliere(filiere);
            }
        }

        public async Task insertInitialModules()
        {
            List<Module> modules = new List<Module>();
            //INFO
            modules.Add(new Module
            {
                Nom = ".NET",
                NbrHeure = 35,
                ProfesseurId = 1
            });
            modules.Add(new Module
            {
                Nom = "Java",
                NbrHeure = 30,
                ProfesseurId = 2
            });
            modules.Add(new Module
            {
                Nom = "C++",
                NbrHeure = 28,
                ProfesseurId = 2
            });
            modules.Add(new Module
            {
                Nom = "Data Structures",
                NbrHeure = 32,
                ProfesseurId = 1
            });
            modules.Add(new Module
            {
                Nom = "Algorithms",
                NbrHeure = 27,
                ProfesseurId = 2
            });
            modules.Add(new Module
            {
                Nom = "Web Development",
                NbrHeure = 30,
                ProfesseurId = 1
            });

            

            //AI
            modules.Add(new Module
            {
                Nom = "Machine Learning Fundamentals",
                NbrHeure = 35,
                ProfesseurId = 1
            });

            modules.Add(new Module
            {
                Nom = "Deep Learning Basics",
                NbrHeure = 30,
                ProfesseurId = 2
            });

            modules.Add(new Module
            {
                Nom = "Natural Language Processing",
                NbrHeure = 28,
                ProfesseurId = 1
            });

            modules.Add(new Module
            {
                Nom = "Computer Vision",
                NbrHeure = 32,
                ProfesseurId = 2
            });

            modules.Add(new Module
            {
                Nom = "Reinforcement Learning",
                NbrHeure = 27,
                ProfesseurId = 1
            });

            modules.Add(new Module
            {
                Nom = "AI Ethics and Governance",
                NbrHeure = 30,
                ProfesseurId = 2
            });


            //GTR

            modules.Add(new Module
            {
                Nom = "Telecommunication Systems",
                NbrHeure = 35,
                ProfesseurId = 1
            });

            modules.Add(new Module
            {
                Nom = "Network Protocols",
                NbrHeure = 30,
                ProfesseurId = 2
            });

            modules.Add(new Module
            {
                Nom = "Wireless Communication",
                NbrHeure = 28,
                ProfesseurId = 1
            });

            modules.Add(new Module
            {
                Nom = "Optical Networks",
                NbrHeure = 32,
                ProfesseurId = 2
            });

            modules.Add(new Module
            {
                Nom = "Network Security",
                NbrHeure = 27,
                ProfesseurId = 1
            });

            modules.Add(new Module
            {
                Nom = "Internet of Things (IoT)",
                NbrHeure = 30,
                ProfesseurId = 2
            });


            // AI & INFO && GTR
            modules.Add(new Module
            {
                Nom = "SQL",
                NbrHeure = 25,
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

            // First 6 modules for filiere 1
            filiereModules.Add(new FiliereModule { FiliereId = 1, ModuleId = 1 });
            filiereModules.Add(new FiliereModule { FiliereId = 1, ModuleId = 2 });
            filiereModules.Add(new FiliereModule { FiliereId = 1, ModuleId = 3 });
            filiereModules.Add(new FiliereModule { FiliereId = 1, ModuleId = 4 });
            filiereModules.Add(new FiliereModule { FiliereId = 1, ModuleId = 5 });
            filiereModules.Add(new FiliereModule { FiliereId = 1, ModuleId = 6 });


            // Next 6 modules for filiere 2
            filiereModules.Add(new FiliereModule { FiliereId = 2, ModuleId = 7 });
            filiereModules.Add(new FiliereModule { FiliereId = 2, ModuleId = 8 });
            filiereModules.Add(new FiliereModule { FiliereId = 2, ModuleId = 9 });
            filiereModules.Add(new FiliereModule { FiliereId = 2, ModuleId = 10 });
            filiereModules.Add(new FiliereModule { FiliereId = 2, ModuleId = 11 });
            filiereModules.Add(new FiliereModule { FiliereId = 2, ModuleId = 12 });


            // Next 6 modules for filiere 3
            filiereModules.Add(new FiliereModule { FiliereId = 3, ModuleId = 13 });
            filiereModules.Add(new FiliereModule { FiliereId = 3, ModuleId = 14 });
            filiereModules.Add(new FiliereModule { FiliereId = 3, ModuleId = 15 });
            filiereModules.Add(new FiliereModule { FiliereId = 3, ModuleId = 16 });
            filiereModules.Add(new FiliereModule { FiliereId = 3, ModuleId = 17 });
            filiereModules.Add(new FiliereModule { FiliereId = 3, ModuleId = 18 });

            // The last module for filiere 1, 2, and 3
            filiereModules.Add(new FiliereModule { FiliereId = 1, ModuleId = 19 });
            filiereModules.Add(new FiliereModule { FiliereId = 2, ModuleId = 19 });
            filiereModules.Add(new FiliereModule { FiliereId = 3, ModuleId = 19 });


            foreach (var filiereModule in filiereModules)
            {
                await App.filiereModuleServices.addFiliereModule(filiereModule);
            }
        }
       
        public async Task insertInitialData()
        {

            if (!Preferences.Get("hasData",false))
            {
                await insertInitialFilieres();
                await insertInitialProfs();
                await insertInitialModules();
                await inserInitialFiliereModule();
                await insertInitialStudents();
                Console.WriteLine("Initial data inserted");
                Preferences.Set("hasData", true);
            }
        }

    }
}
