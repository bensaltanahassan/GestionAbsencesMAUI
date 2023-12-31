using GestionAbsencesMAUI.Models;
using GestionAbsencesMAUI.Services;
using GestionAbsencesMAUI.Views;

namespace GestionAbsencesMAUI
{
    public partial class App : Application
    {
        public static Etudiant Etudiant;
        public static Professeur Professeur;
        public static Filiere Filiere;
        public static Absence Absence;
        public static Session Session;
        public static Module Module;
        public static FiliereModule FiliereModule;

        public static EtudiantService _etudiantService;
        public static EtudiantService etudiantService
        {
            get
            {
                if (_etudiantService == null)
                    _etudiantService = new EtudiantService(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GestionAbsences.db3")
                    );
                return _etudiantService;
            }
        }   

        public static ProfesseurServices _professeurServices;
        public static ProfesseurServices professeurServices
        {
            get
            {
                if (_professeurServices == null)
                    _professeurServices = new ProfesseurServices(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GestionAbsences.db3")
                                                                  );
                return _professeurServices;
            }
        }

        public static FiliereServices _filiereServices;
        public static FiliereServices filiereServices
        {
            get
            {
                if (_filiereServices == null)
                    _filiereServices = new FiliereServices(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GestionAbsences.db3")
                                                                                                                                       );
                return _filiereServices;
            }
        }

        public static ModuleServices _moduleServices;
        public static ModuleServices moduleServices
        {
            get
            {
                if (_moduleServices == null)
                    _moduleServices = new ModuleServices(
                 Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GestionAbsences.db3")
                                                                                                                                                                                                                                   );
                return _moduleServices;
            }
        }

        public static FiliereModuleServices _filiereModuleServices;
        public static FiliereModuleServices filiereModuleServices
        {
            get
            {
                if (_filiereModuleServices == null)
                    _filiereModuleServices = new FiliereModuleServices(
                  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GestionAbsences.db3")
                                                                                                                                                                                                                                                                          );
                return _filiereModuleServices;
            }
        }

        public static SessionServices _sessionServices;
        public static SessionServices sessionServices
        {
            get
            {
                if (_sessionServices == null)
                    _sessionServices = new SessionServices(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GestionAbsences.db3")
                                                                                                                                                                                                                                                                                        );
                return _sessionServices;
            }
        }

        public static AbsenceServices _absenceServices;
        public static AbsenceServices absenceServices
        {
            get
            {
                if (_absenceServices == null)
                    _absenceServices = new AbsenceServices(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GestionAbsences.db3")
                                                                                                                                                                                                                                                                                                                  );
                return _absenceServices;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new InfoPage();
        }

        protected override async void OnStart()
        {
            //run this only once and then comment it
            //TestDbService testDbService = new TestDbService();
            //await testDbService.insertInitialData();
        }
    }
}
