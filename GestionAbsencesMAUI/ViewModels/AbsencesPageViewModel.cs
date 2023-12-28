using GestionAbsencesMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencesMAUI.ViewModels
{
    
    public class AbsencesPageViewModel
    {
        public List<Etudiant> Students { get; set; }

        public AbsencesPageViewModel()
        {
            Students = new List<Etudiant>
            {
                     new Etudiant
            {
                Id = 1,
                Cne = "123456",
                Nom = "Smith",
                Prenom = "John",
                Email = "john@example.com",
                Phone = "123-456-7890",
                filiereId = 101
            },
            new Etudiant
            {
                Id = 2,
                Cne = "987654",
                Nom = "Doe",
                Prenom = "Jane",
                Email = "jane@example.com",
                Phone = "987-654-3210",
                filiereId = 102
            },
            new Etudiant
            {
                Id = 3,
                Cne = "123789",
                Nom = "Doe",
                Prenom = "John",
                Email = "John@example.com",
                Phone = "123-789-4560",
                filiereId = 103
            },

            };
        }


    }
}
