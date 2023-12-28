using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencesMAUI.Models
{
    public class Session
    {
        [PrimaryKey]
        public int Id { get; set; }

        public int FiliereModuleId { get; set; }
        public string Date { get; set; }
    }
}
