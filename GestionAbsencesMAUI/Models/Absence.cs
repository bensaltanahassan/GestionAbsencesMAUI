using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencesMAUI.Models
{
    public class Absence
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        public int SessionId { get; set; }
        public int EtudiantId { get; set; }
        public int IsPresent { get; set; }// 0 = absent, 1 = present, 2=not checked yet
    }
}
