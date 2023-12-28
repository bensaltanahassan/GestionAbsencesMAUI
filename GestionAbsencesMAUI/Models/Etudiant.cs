using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencesMAUI.Models
{
    public class Etudiant
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Cne { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int filiereId { get; set; }
       
    }
}
