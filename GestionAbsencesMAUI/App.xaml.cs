using GestionAbsencesMAUI.Models;
using GestionAbsencesMAUI.Services;

namespace GestionAbsencesMAUI
{
    public partial class App : Application
    {
        public static Etudiant Etudiant;
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
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
