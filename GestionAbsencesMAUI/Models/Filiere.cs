using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencesMAUI.Models
{
    public class Filiere
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Nom { get; set; }
    }
}
